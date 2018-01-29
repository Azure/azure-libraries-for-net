// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListComputeSkus
{
    /**
     * Azure Compute sample for managing Compute SKUs -
     *  - List all compute SKUs in the subscription
     *  - List compute SKUs for a specific compute resource type (VirtualMachines) in a region
     *  - List compute SKUs for a specific compute resource type (Disks).
     */
    public class Program
    {
        public static void RunSample(IAzure azure)
        {
            //=================================================================
            // List all compute SKUs in the subscription
            //
            Utilities.Log("Listing Compute SKU in the subscription");
            String format = "{0,-22} {1,-22} {2,-22} {3}";

            Utilities.Log(String.Format(format, "Name", "ResourceType", "Size", "Regions [zones]"));
            Utilities.Log("============================================================================");

            HashSet<string> hashSet = new HashSet<string>();

            var skus = azure.ComputeSkus.List();
            foreach (IComputeSku sku in skus)
            {
                String size = null;
                if (sku.ResourceType.Equals(ComputeResourceType.VirtualMachines))
                {
                    size = sku.VirtualMachineSizeType?.ToString();
                }
                else if (sku.ResourceType.Equals(ComputeResourceType.AvailabilitySets))
                {
                    size = sku.AvailabilitySetSkuType?.ToString();
                }
                else if (sku.ResourceType.Equals(ComputeResourceType.Disks))
                {
                    size = sku.DiskSkuType?.ToString();
                }
                else if (sku.ResourceType.Equals(ComputeResourceType.Snapshots))
                {
                    size = sku.DiskSkuType?.ToString();
                }
                var regionZones = sku.Zones;
                Utilities.Log(String.Format(format, sku.Name, sku.ResourceType, size, RegionZoneToString(regionZones)));
            }

            //=================================================================
            // List compute SKUs for a specific compute resource type (VirtualMachines) in a region
            //
            Utilities.Log("Listing compute SKUs for a specific compute resource type (VirtualMachines) in a region (US East2)");
            format = "{0,-22} {1,-22} {2}";

            Utilities.Log(String.Format(format, "Name", "Size", "Regions [zones]"));
            Utilities.Log("============================================================================");

            skus = azure.ComputeSkus
                    .ListbyRegionAndResourceType(Region.USEast2, ComputeResourceType.VirtualMachines);
            foreach (IComputeSku sku in skus)
            {
                var line = String.Format(format, sku.Name, sku.VirtualMachineSizeType, RegionZoneToString(sku.Zones));
                Utilities.Log(line);
            }

            //=================================================================
            // List compute SKUs for a specific compute resource type (Disks)
            //
            Utilities.Log("Listing compute SKUs for a specific compute resource type (Disks)");
            format = "{0,-22} {1,-22} {2}";

            Utilities.Log(String.Format(format, "Name", "Size", "Regions [zones]"));
            Utilities.Log("============================================================================");

            skus = azure.ComputeSkus
                    .ListByResourceType(ComputeResourceType.Disks);
            foreach (IComputeSku sku in skus)
            {
                var line = String.Format(format, sku.Name, sku.DiskSkuType, RegionZoneToString(sku.Zones));
                Utilities.Log(line);
            }
        }

        private static String RegionZoneToString(IReadOnlyDictionary<Region, ISet<AvailabilityZoneId>> regionZonesMap)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var regionZones in regionZonesMap)
            {
                builder.Append(regionZones.Key.ToString());
                builder.Append(" [ ");
                foreach (AvailabilityZoneId zone in regionZones.Value)
                {
                    builder.Append(zone).Append(" ");
                }
                builder.Append("] ");
            }
            return builder.ToString();
        }

        public static void Main(string[] args)
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
    }
}
