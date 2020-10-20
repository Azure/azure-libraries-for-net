// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.Locks.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Locks.Fluent.Models;
using System.Linq;
using Xunit;
using System;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using System.Threading.Tasks;

namespace Fluent.Tests
{

    public class ManagementLocks
    {

        /**
         * Main entry point.
         * @param args the parameters
         */
        [Fact]
        public void CanCRUDLocks()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                IAuthorizationManager authorizationManager = TestHelper.CreateAuthorizationManager();
                IComputeManager computeManager = TestHelper.CreateComputeManager();
                IResourceManager managerResources = computeManager.ResourceManager;
                INetworkManager networkManager = TestHelper.CreateNetworkManager();
                IStorageManager storageManager = TestHelper.CreateStorageManager();

                // Prepare a VM
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
                    resourceGroup = managerResources.ResourceGroups.Define(rgName)
                            .WithRegion(region)
                            .Create();
                    Assert.NotNull(resourceGroup);

                    ICreatable<INetwork> netDefinition = networkManager.Networks.Define(netName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithAddressSpace("10.0.0.0/28");

                    // Define a VM for testing VM locks
                    ICreatable<IVirtualMachine> vmDefinition = computeManager.VirtualMachines.Define(vmName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithNewPrimaryNetwork(netDefinition)
                            .WithPrimaryPrivateIPAddressDynamic()
                            .WithoutPrimaryPublicIPAddress()
                            .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WindowsServer2012R2Datacenter)
                            .WithAdminUsername("tester")
                            .WithAdminPassword(password)
                            .WithSize(VirtualMachineSizeTypes.Parse("Standard_D2a_v4"));

                    // Define a managed disk for testing locks on that
                    ICreatable<IDisk> diskDefinition = computeManager.Disks.Define(diskName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup)
                            .WithData()
                            .WithSizeInGB(100);

                    // Define a storage account for testing locks on that
                    ICreatable<IStorageAccount> storageDefinition = storageManager.StorageAccounts.Define(storageName)
                            .WithRegion(region)
                            .WithExistingResourceGroup(resourceGroup);

                    // Create resources in parallel to save time and money
                    Extensions.Synchronize(() => Task.WhenAll(
                        storageDefinition.CreateAsync(),
                        vmDefinition.CreateAsync(),
                        diskDefinition.CreateAsync()));

                    IVirtualMachine vm = (IVirtualMachine)vmDefinition;
                    IStorageAccount storage = (IStorageAccount)storageDefinition;
                    IDisk disk = (IDisk)diskDefinition;
                    INetwork network = vm.GetPrimaryNetworkInterface().PrimaryIPConfiguration.GetNetwork();
                    ISubnet subnet = network.Subnets.Values.FirstOrDefault();

                    // Lock subnet
                    ICreatable<IManagementLock> lockSubnetDef = authorizationManager.ManagementLocks.Define("subnetLock")
                            .WithLockedResource(subnet.Inner.Id)
                            .WithLevel(LockLevel.ReadOnly);

                    // Lock VM
                    ICreatable<IManagementLock> lockVMDef = authorizationManager.ManagementLocks.Define("vmlock")
                            .WithLockedResource(vm)
                            .WithLevel(LockLevel.ReadOnly)
                            .WithNotes("vm readonly lock");

                    // Lock resource group
                    ICreatable<IManagementLock> lockGroupDef = authorizationManager.ManagementLocks.Define("rglock")
                            .WithLockedResource(resourceGroup.Id)
                            .WithLevel(LockLevel.CanNotDelete);

                    // Lock storage
                    ICreatable<IManagementLock> lockStorageDef = authorizationManager.ManagementLocks.Define("stLock")
                            .WithLockedResource(storage)
                            .WithLevel(LockLevel.CanNotDelete);

                    // Create locks in parallel
                    ICreatedResources<IManagementLock> created = authorizationManager.ManagementLocks.Create(lockVMDef, lockGroupDef, lockStorageDef, lockSubnetDef);

                    lockVM = created.FirstOrDefault(o => o.Key.Equals(lockVMDef.Key));
                    lockStorage = created.FirstOrDefault(o => o.Key.Equals(lockStorageDef.Key));
                    lockGroup = created.FirstOrDefault(o => o.Key.Equals(lockGroupDef.Key));
                    lockSubnet = created.FirstOrDefault(o => o.Key.Equals(lockSubnetDef.Key));

                    // Lock disk synchronously
                    lockDiskRO = authorizationManager.ManagementLocks.Define("diskLockRO")
                            .WithLockedResource(disk)
                            .WithLevel(LockLevel.ReadOnly)
                            .Create();

                    lockDiskDel = authorizationManager.ManagementLocks.Define("diskLockDel")
                            .WithLockedResource(disk)
                            .WithLevel(LockLevel.CanNotDelete)
                            .Create();

                    // Verify VM lock
                    Assert.Equal(2, authorizationManager.ManagementLocks.ListForResource(vm.Id).Count());

                    Assert.NotNull(lockVM);
                    lockVM = authorizationManager.ManagementLocks.GetById(lockVM.Id);
                    Assert.NotNull(lockVM);
                    Assert.Equal(LockLevel.ReadOnly, lockVM.Level);
                    Assert.Equal(vm.Id, lockVM.LockedResourceId, true);

                    // Verify resource group lock
                    Assert.NotNull(lockGroup);
                    lockGroup = authorizationManager.ManagementLocks.GetByResourceGroup(resourceGroup.Name, "rglock");
                    Assert.NotNull(lockGroup);
                    Assert.Equal(LockLevel.CanNotDelete, lockGroup.Level);
                    Assert.Equal(resourceGroup.Id, lockGroup.LockedResourceId, true);

                    // Verify storage account lock
                    Assert.Equal(2, authorizationManager.ManagementLocks.ListForResource(storage.Id).Count());

                    Assert.NotNull(lockStorage);
                    lockStorage = authorizationManager.ManagementLocks.GetById(lockStorage.Id);
                    Assert.NotNull(lockStorage);
                    Assert.Equal(LockLevel.CanNotDelete, lockStorage.Level);
                    Assert.Equal(storage.Id, lockStorage.LockedResourceId, true);

                    // Verify disk lock
                    Assert.Equal(3, authorizationManager.ManagementLocks.ListForResource(disk.Id).Count());

                    Assert.NotNull(lockDiskRO);
                    lockDiskRO = authorizationManager.ManagementLocks.GetById(lockDiskRO.Id);
                    Assert.NotNull(lockDiskRO);
                    Assert.Equal(LockLevel.ReadOnly, lockDiskRO.Level);
                    Assert.Equal(disk.Id, lockDiskRO.LockedResourceId, true);

                    Assert.NotNull(lockDiskDel);
                    lockDiskDel = authorizationManager.ManagementLocks.GetById(lockDiskDel.Id);
                    Assert.NotNull(lockDiskDel);
                    Assert.Equal(LockLevel.CanNotDelete, lockDiskDel.Level);
                    Assert.Equal(disk.Id, lockDiskDel.LockedResourceId, true);

                    // Verify subnet lock
                    Assert.Equal(2, authorizationManager.ManagementLocks.ListForResource(network.Id).Count());

                    lockSubnet = authorizationManager.ManagementLocks.GetById(lockSubnet.Id);
                    Assert.NotNull(lockSubnet);
                    Assert.Equal(LockLevel.ReadOnly, lockSubnet.Level);
                    Assert.Equal(subnet.Inner.Id, lockSubnet.LockedResourceId, true);

                    // Verify lock collection
                    var locksSubscription = authorizationManager.ManagementLocks.List();
                    var locksGroup = authorizationManager.ManagementLocks.ListByResourceGroup(vm.ResourceGroupName);
                    Assert.NotNull(locksSubscription);
                    Assert.NotNull(locksGroup);

                    int locksAllCount = locksSubscription.Count();
                    Assert.True(6 <= locksAllCount);

                    int locksGroupCount = locksGroup.Count();
                    Assert.Equal(6, locksGroup.Count());
                }
                finally
                {
                    try
                    {
                        if (resourceGroup != null)
                        {
                            if (lockGroup != null)
                            {
                                authorizationManager.ManagementLocks.DeleteById(lockGroup.Id);
                            }
                            if (lockVM != null)
                            {
                                authorizationManager.ManagementLocks.DeleteById(lockVM.Id);
                            }
                            if (lockDiskRO != null)
                            {
                                authorizationManager.ManagementLocks.DeleteById(lockDiskRO.Id);
                            }
                            if (lockDiskDel != null)
                            {
                                authorizationManager.ManagementLocks.DeleteById(lockDiskDel.Id);
                            }
                            if (lockStorage != null)
                            {
                                authorizationManager.ManagementLocks.DeleteById(lockStorage.Id);
                            }
                            if (lockSubnet != null)
                            {
                                authorizationManager.ManagementLocks.DeleteById(lockSubnet.Id);
                            }

                            managerResources.ResourceGroups.BeginDeleteByName(rgName);
                        }
                    }
                    catch { }
                }
            }
        }

        [Fact(Skip ="SPN requires write access to the scope to set a lock on ResourceGroup")]
        public void LocksRGBugfix()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {

                string rgName = SdkContext.RandomResourceName("lockBugFix", 15);

                var azure = TestHelper.CreateRollupClient();

                var resourceGroup = azure.ResourceGroups.Define(rgName)
                    .WithRegion(Region.USWestCentral)
                    .Create();

                var lockObject = azure.ManagementLocks.Define("lockname")
                    .WithLockedResourceGroup(resourceGroup.Name)
                    .WithLevel(LockLevel.CanNotDelete)
                    .Create();

                azure.ManagementLocks.DeleteById(lockObject.Id);

                azure.ResourceGroups.BeginDeleteByName(rgName);
            }
        }
    }
}