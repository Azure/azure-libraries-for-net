using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Locks.Fluent;
using Microsoft.Azure.Management.Locks.Fluent.Models;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Network.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Storage.Fluent;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace TestSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSample(azure);
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }

        private static void RunSample(IAzure azure)
        {
            string password = SdkContext.RandomResourceName("P@s", 14);
            string rgName = SdkContext.RandomResourceName("rg", 15);
            string vmName = SdkContext.RandomResourceName("vm", 15);
            string storageName = SdkContext.RandomResourceName("st", 15);
            string diskName = SdkContext.RandomResourceName("dsk", 15);
            string netName = SdkContext.RandomResourceName("net", 15);
            Region region = Region.USEast;

            IResourceGroup resourceGroup = null;
            IManagementLock lockGroup = null,
                    lockVM = null,
                    lockStorage = null,
                    lockDiskRO = null,
                    lockDiskDel = null,
                    lockSubnet = null;

            try
            {
                //=============================================================
                // Create a shared resource group for all the resources so they can all be deleted together
                //
                resourceGroup = azure.ResourceGroups.Define(rgName)
                        .WithRegion(region)
                        .Create();
                Utilities.Log("Created a new resource group - " + resourceGroup.Id);

                //============================================================
                // Create various resources for demonstrating locks
                //

                // Define a network to apply a lock to
                ICreatable<INetwork> netDefinition = azure.Networks.Define(netName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithAddressSpace("10.0.0.0/28");

                // Define a managed disk for testing locks on that
                ICreatable<IDisk> diskDefinition = azure.Disks.Define(diskName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(resourceGroup)
                        .WithData()
                        .WithSizeInGB(100);

                // Define a VM to apply a lock to
                ICreatable<IVirtualMachine> vmDefinition = azure.VirtualMachines.Define(vmName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithNewPrimaryNetwork(netDefinition)
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012Datacenter)
                            .WithAdminUsername("tester")
                            .WithAdminPassword(password)
                            .WithNewDataDisk(diskDefinition, 1, CachingTypes.None)
                            .WithSize(VirtualMachineSizeTypes.BasicA1);

                // Define a storage account to apply a lock to
                ICreatable<IStorageAccount> storageDefinition = azure.StorageAccounts.Define(storageName)
                        .WithRegion(region)
                        .WithExistingResourceGroup(resourceGroup);

                // Create resources in parallel to save time
                Utilities.Log("Creating the needed resources...");
                Task.WaitAll(
                    storageDefinition.CreateAsync(),
                    vmDefinition.CreateAsync());
                Utilities.Log("Resources created.");

                IVirtualMachine vm = (IVirtualMachine)vmDefinition;
                IStorageAccount storage = (IStorageAccount)storageDefinition;
                IDisk disk = (IDisk)diskDefinition;
                INetwork network = vm.GetPrimaryNetworkInterface().PrimaryIPConfiguration.GetNetwork();
                ISubnet subnet = network.Subnets.Values.FirstOrDefault();

                //============================================================
                // Create various locks for the created resources
                //

                // Locks can be created serially, and multiple can be applied to the same resource:
                Utilities.Log("Creating locks sequentially...");

                // Apply a ReadOnly lock to the disk
                lockDiskRO = azure.ManagementLocks.Define("diskLockRO")
                        .WithLockedResource(disk)
                        .WithLevel(LockLevel.ReadOnly)
                        .Create();

                // Apply a lock preventing the disk from being deleted
                lockDiskDel = azure.ManagementLocks.Define("diskLockDel")
                        .WithLockedResource(disk)
                        .WithLevel(LockLevel.CanNotDelete)
                        .Create();

                // Locks can also be created in parallel, for better overall performance:
                Utilities.Log("Creating locks in parallel...");

                // Define a subnet lock
                ICreatable<IManagementLock> lockSubnetDef = azure.ManagementLocks.Define("subnetLock")
                        .WithLockedResource(subnet.Inner.Id)
                        .WithLevel(LockLevel.ReadOnly);

                // Define a VM lock
                ICreatable<IManagementLock> lockVMDef = azure.ManagementLocks.Define("vmlock")
                        .WithLockedResource(vm)
                        .WithLevel(LockLevel.ReadOnly)
                        .WithNotes("vm readonly lock");

                // Define a resource group lock
                ICreatable<IManagementLock> lockGroupDef = azure.ManagementLocks.Define("rglock")
                        .WithLockedResource(resourceGroup.Id)
                        .WithLevel(LockLevel.CanNotDelete);

                // Define a storage lock
                ICreatable<IManagementLock> lockStorageDef = azure.ManagementLocks.Define("stLock")
                        .WithLockedResource(storage)
                        .WithLevel(LockLevel.CanNotDelete);

                var created = azure.ManagementLocks.Create(
                    lockVMDef,
                    lockGroupDef,
                    lockStorageDef,
                    lockSubnetDef);

                lockVM = created.FirstOrDefault(o => o.Key.Equals(lockVMDef.Key, StringComparison.OrdinalIgnoreCase));
                lockStorage = created.FirstOrDefault(o => o.Key.Equals(lockStorageDef.Key, StringComparison.OrdinalIgnoreCase));
                lockGroup = created.FirstOrDefault(o => o.Key.Equals(lockGroupDef.Key, StringComparison.OrdinalIgnoreCase));
                lockSubnet = created.FirstOrDefault(o => o.Key.Equals(lockSubnetDef.Key, StringComparison.OrdinalIgnoreCase));

                Utilities.Log("Locks created.");

                //============================================================
                // Retrieve and show lock information
                //

                // Count and show locks (Note: locks returned for a resource include the locks for its resource group and child resources)
                int lockCount = azure.ManagementLocks.ListForResource(vm.Id).Count();
                Utilities.Log("Number of locks applied to the virtual machine: " + lockCount);
                lockCount = azure.ManagementLocks.ListByResourceGroup(resourceGroup.Name).Count();
                Utilities.Log("Number of locks applied to the resource group (includes locks on resources in the group): " + lockCount);
                lockCount = azure.ManagementLocks.ListForResource(storage.Id).Count();
                Utilities.Log("Number of locks applied to the storage account: " + lockCount);
                lockCount = azure.ManagementLocks.ListForResource(disk.Id).Count();
                Utilities.Log("Number of locks applied to the managed disk: " + lockCount);
                lockCount = azure.ManagementLocks.ListForResource(network.Id).Count();
                Utilities.Log("Number of locks applied to the network (including its subnets): " + lockCount);

                // Locks can be retrieved using their ID
                lockVM = azure.ManagementLocks.GetById(lockVM.Id);
                lockGroup = azure.ManagementLocks.GetByResourceGroup(resourceGroup.Name, "rglock");
                lockStorage = azure.ManagementLocks.GetById(lockStorage.Id);
                lockDiskRO = azure.ManagementLocks.GetById(lockDiskRO.Id);
                lockDiskDel = azure.ManagementLocks.GetById(lockDiskDel.Id);
                lockSubnet = azure.ManagementLocks.GetById(lockSubnet.Id);

                // Show the locks
                Utilities.Print(lockGroup);
                Utilities.Print(lockVM);
                Utilities.Print(lockDiskDel);
                Utilities.Print(lockDiskRO);
                Utilities.Print(lockStorage);
                Utilities.Print(lockSubnet);

                // List all locks within a subscription
                var locksSubscription = azure.ManagementLocks.List();
                Utilities.Log("Total number of locks within this subscription: " + locksSubscription.Count());
            }
            finally
            {
                try
                {
                    // Clean up (remember to unlock resources before deleting the resource group)
                    azure.ManagementLocks.DeleteByIds(
                            lockGroup.Id,
                            lockVM.Id,
                            lockDiskRO.Id,
                            lockDiskDel.Id,
                            lockStorage.Id,
                            lockSubnet.Id);
                    Utilities.Log("Starting the deletion of the resource group: " + rgName);
                    azure.ResourceGroups.BeginDeleteByName(rgName);
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
                catch (Exception ex)
                {
                    Utilities.Log(ex);
                }
            }
        }
    }
}
