// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Serialization;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;

    /// <summary>
    /// Compute Client
    /// </summary>
    public partial class ComputeManagementClient : FluentServiceClientBase<ComputeManagementClient>, IComputeManagementClient, IAzureClient
    {
        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        public JsonSerializerSettings SerializationSettings { get; private set; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        public JsonSerializerSettings DeserializationSettings { get; private set; }

        /// <summary>
        /// Subscription credentials which uniquely identify Microsoft Azure
        /// subscription. The subscription ID forms part of the URI for every service
        /// call.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// The preferred language for the response.
        /// </summary>
        public string AcceptLanguage { get; set; }

        /// <summary>
        /// The retry timeout in seconds for Long Running Operations. Default value is
        /// 30.
        /// </summary>
        public int? LongRunningOperationRetryTimeout { get; set; }

        /// <summary>
        /// Whether a unique x-ms-client-request-id should be generated. When set to
        /// true a unique x-ms-client-request-id value is generated and included in
        /// each request. Default is true.
        /// </summary>
        public bool? GenerateClientRequestId { get; set; }

        /// <summary>
        /// Gets the IOperations.
        /// </summary>
        public virtual IOperations Operations { get; private set; }

        /// <summary>
        /// Gets the IAvailabilitySetsOperations.
        /// </summary>
        public virtual IAvailabilitySetsOperations AvailabilitySets { get; private set; }

        /// <summary>
        /// Gets the IVirtualMachineExtensionImagesOperations.
        /// </summary>
        public virtual IVirtualMachineExtensionImagesOperations VirtualMachineExtensionImages { get; private set; }

        /// <summary>
        /// Gets the IVirtualMachineExtensionsOperations.
        /// </summary>
        public virtual IVirtualMachineExtensionsOperations VirtualMachineExtensions { get; private set; }

        /// <summary>
        /// Gets the IVirtualMachineImagesOperations.
        /// </summary>
        public virtual IVirtualMachineImagesOperations VirtualMachineImages { get; private set; }

        /// <summary>
        /// Gets the IUsageOperations.
        /// </summary>
        public virtual IUsageOperations Usage { get; private set; }

        /// <summary>
        /// Gets the IVirtualMachinesOperations.
        /// </summary>
        public virtual IVirtualMachinesOperations VirtualMachines { get; private set; }

        /// <summary>
        /// Gets the IVirtualMachineSizesOperations.
        /// </summary>
        public virtual IVirtualMachineSizesOperations VirtualMachineSizes { get; private set; }

        /// <summary>
        /// Gets the IImagesOperations.
        /// </summary>
        public virtual IImagesOperations Images { get; private set; }

        /// <summary>
        /// Gets the IVirtualMachineScaleSetsOperations.
        /// </summary>
        public virtual IVirtualMachineScaleSetsOperations VirtualMachineScaleSets { get; private set; }

        /// <summary>
        /// Gets the IVirtualMachineScaleSetExtensionsOperations.
        /// </summary>
        public virtual IVirtualMachineScaleSetExtensionsOperations VirtualMachineScaleSetExtensions { get; private set; }

        /// <summary>
        /// Gets the IVirtualMachineScaleSetRollingUpgradesOperations.
        /// </summary>
        public virtual IVirtualMachineScaleSetRollingUpgradesOperations VirtualMachineScaleSetRollingUpgrades { get; private set; }

        /// <summary>
        /// Gets the IVirtualMachineScaleSetVMsOperations.
        /// </summary>
        public virtual IVirtualMachineScaleSetVMsOperations VirtualMachineScaleSetVMs { get; private set; }

        /// <summary>
        /// Gets the ILogAnalyticsOperations.
        /// </summary>
        public virtual ILogAnalyticsOperations LogAnalytics { get; private set; }

        /// <summary>
        /// Gets the IVirtualMachineRunCommandsOperations.
        /// </summary>
        public virtual IVirtualMachineRunCommandsOperations VirtualMachineRunCommands { get; private set; }

        /// <summary>
        /// Gets the IResourceSkusOperations.
        /// </summary>
        public virtual IResourceSkusOperations ResourceSkus { get; private set; }

        /// <summary>
        /// Gets the IDisksOperations.
        /// </summary>
        public virtual IDisksOperations Disks { get; private set; }

        /// <summary>
        /// Gets the ISnapshotsOperations.
        /// </summary>
        public virtual ISnapshotsOperations Snapshots { get; private set; }

        /// <summary>
        /// Gets the IGalleriesOperations.
        /// </summary>
        public virtual IGalleriesOperations Galleries { get; private set; }

        /// <summary>
        /// Gets the IGalleryImagesOperations.
        /// </summary>
        public virtual IGalleryImagesOperations GalleryImages { get; private set; }

        /// <summary>
        /// Gets the IGalleryImageVersionsOperations.
        /// </summary>
        public virtual IGalleryImageVersionsOperations GalleryImageVersions { get; private set; }

        /// <summary>
        /// Gets the IContainerServicesOperations.
        /// </summary>
        public virtual IContainerServicesOperations ContainerServices { get; private set; }


        /// <summary>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public ComputeManagementClient(RestClient restClient) 
            : base(restClient)
        {
        }

        /// <summary>
        /// Initializes client properties.
        /// </summary>
        protected override void Initialize()
        {
            Operations = new Operations(this);
            AvailabilitySets = new AvailabilitySetsOperations(this);
            VirtualMachineExtensionImages = new VirtualMachineExtensionImagesOperations(this);
            VirtualMachineExtensions = new VirtualMachineExtensionsOperations(this);
            VirtualMachineImages = new VirtualMachineImagesOperations(this);
            Usage = new UsageOperations(this);
            VirtualMachines = new VirtualMachinesOperations(this);
            VirtualMachineSizes = new VirtualMachineSizesOperations(this);
            Images = new ImagesOperations(this);
            VirtualMachineScaleSets = new VirtualMachineScaleSetsOperations(this);
            VirtualMachineScaleSetExtensions = new VirtualMachineScaleSetExtensionsOperations(this);
            VirtualMachineScaleSetRollingUpgrades = new VirtualMachineScaleSetRollingUpgradesOperations(this);
            VirtualMachineScaleSetVMs = new VirtualMachineScaleSetVMsOperations(this);
            LogAnalytics = new LogAnalyticsOperations(this);
            VirtualMachineRunCommands = new VirtualMachineRunCommandsOperations(this);
            ResourceSkus = new ResourceSkusOperations(this);
            Disks = new DisksOperations(this);
            Snapshots = new SnapshotsOperations(this);
            Galleries = new GalleriesOperations(this);
            GalleryImages = new GalleryImagesOperations(this);
            GalleryImageVersions = new GalleryImageVersionsOperations(this);
            ContainerServices = new ContainerServicesOperations(this);
            BaseUri = new System.Uri("https://management.azure.com");
            AcceptLanguage = "en-US";
            LongRunningOperationRetryTimeout = 30;
            GenerateClientRequestId = true;
            SerializationSettings = new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            SerializationSettings.Converters.Add(new TransformationJsonConverter());
            DeserializationSettings = new JsonSerializerSettings
            {
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            
            DeserializationSettings.Converters.Add(new TransformationJsonConverter());
            DeserializationSettings.Converters.Add(new CloudErrorJsonConverter());
        }
    }
}
