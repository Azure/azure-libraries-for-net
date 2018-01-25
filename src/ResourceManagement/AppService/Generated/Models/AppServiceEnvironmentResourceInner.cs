// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.AppService.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.AppService;
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// App Service Environment ARM resource.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class AppServiceEnvironmentResourceInner : Microsoft.Azure.Management.ResourceManager.Fluent.Resource
    {
        /// <summary>
        /// Initializes a new instance of the
        /// AppServiceEnvironmentResourceInner class.
        /// </summary>
        public AppServiceEnvironmentResourceInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// AppServiceEnvironmentResourceInner class.
        /// </summary>
        /// <param name="appServiceEnvironmentResourceName">Name of the App
        /// Service Environment.</param>
        /// <param name="appServiceEnvironmentResourceLocation">Location of the
        /// App Service Environment, e.g. "West US".</param>
        /// <param name="virtualNetwork">Description of the Virtual
        /// Network.</param>
        /// <param name="workerPools">Description of worker pools with worker
        /// size IDs, VM sizes, and number of workers in each pool.</param>
        /// <param name="provisioningState">Provisioning state of the App
        /// Service Environment. Possible values include: 'Succeeded',
        /// 'Failed', 'Canceled', 'InProgress', 'Deleting'</param>
        /// <param name="status">Current status of the App Service Environment.
        /// Possible values include: 'Preparing', 'Ready', 'Scaling',
        /// 'Deleting'</param>
        /// <param name="vnetName">Name of the Virtual Network for the App
        /// Service Environment.</param>
        /// <param name="vnetResourceGroupName">Resource group of the Virtual
        /// Network.</param>
        /// <param name="vnetSubnetName">Subnet of the Virtual Network.</param>
        /// <param name="internalLoadBalancingMode">Specifies which endpoints
        /// to serve internally in the Virtual Network for the App Service
        /// Environment. Possible values include: 'None', 'Web',
        /// 'Publishing'</param>
        /// <param name="multiSize">Front-end VM size, e.g. "Medium",
        /// "Large".</param>
        /// <param name="multiRoleCount">Number of front-end instances.</param>
        /// <param name="ipsslAddressCount">Number of IP SSL addresses reserved
        /// for the App Service Environment.</param>
        /// <param name="databaseEdition">Edition of the metadata database for
        /// the App Service Environment, e.g. "Standard".</param>
        /// <param name="databaseServiceObjective">Service objective of the
        /// metadata database for the App Service Environment, e.g.
        /// "S0".</param>
        /// <param name="upgradeDomains">Number of upgrade domains of the App
        /// Service Environment.</param>
        /// <param name="subscriptionId">Subscription of the App Service
        /// Environment.</param>
        /// <param name="dnsSuffix">DNS suffix of the App Service
        /// Environment.</param>
        /// <param name="lastAction">Last deployment action on the App Service
        /// Environment.</param>
        /// <param name="lastActionResult">Result of the last deployment action
        /// on the App Service Environment.</param>
        /// <param name="allowedMultiSizes">List of comma separated strings
        /// describing which VM sizes are allowed for front-ends.</param>
        /// <param name="allowedWorkerSizes">List of comma separated strings
        /// describing which VM sizes are allowed for workers.</param>
        /// <param name="maximumNumberOfMachines">Maximum number of VMs in the
        /// App Service Environment.</param>
        /// <param name="vipMappings">Description of IP SSL mapping for the App
        /// Service Environment.</param>
        /// <param name="environmentCapacities">Current total, used, and
        /// available worker capacities.</param>
        /// <param name="networkAccessControlList">Access control list for
        /// controlling traffic to the App Service Environment.</param>
        /// <param name="environmentIsHealthy">True/false indicating whether
        /// the App Service Environment is healthy.</param>
        /// <param name="environmentStatus">Detailed message about with results
        /// of the last check of the App Service Environment.</param>
        /// <param name="resourceGroup">Resource group of the App Service
        /// Environment.</param>
        /// <param name="frontEndScaleFactor">Scale factor for
        /// front-ends.</param>
        /// <param name="defaultFrontEndScaleFactor">Default Scale Factor for
        /// FrontEnds.</param>
        /// <param name="apiManagementAccountId">API Management Account
        /// associated with the App Service Environment.</param>
        /// <param name="suspended">&lt;code&gt;true&lt;/code&gt; if the App
        /// Service Environment is suspended; otherwise,
        /// &lt;code&gt;false&lt;/code&gt;. The environment can be suspended,
        /// e.g. when the management endpoint is no longer available
        /// (most likely because NSG blocked the incoming traffic).</param>
        /// <param name="dynamicCacheEnabled">True/false indicating whether the
        /// App Service Environment is suspended. The environment can be
        /// suspended e.g. when the management endpoint is no longer available
        /// (most likely because NSG blocked the incoming traffic).</param>
        /// <param name="clusterSettings">Custom settings for changing the
        /// behavior of the App Service Environment.</param>
        public AppServiceEnvironmentResourceInner(string appServiceEnvironmentResourceName, string appServiceEnvironmentResourceLocation, VirtualNetworkProfile virtualNetwork, IList<WorkerPool> workerPools, string location = default(string), string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), ProvisioningState? provisioningState = default(ProvisioningState?), HostingEnvironmentStatus? status = default(HostingEnvironmentStatus?), string vnetName = default(string), string vnetResourceGroupName = default(string), string vnetSubnetName = default(string), InternalLoadBalancingMode? internalLoadBalancingMode = default(InternalLoadBalancingMode?), string multiSize = default(string), int? multiRoleCount = default(int?), int? ipsslAddressCount = default(int?), string databaseEdition = default(string), string databaseServiceObjective = default(string), int? upgradeDomains = default(int?), string subscriptionId = default(string), string dnsSuffix = default(string), string lastAction = default(string), string lastActionResult = default(string), string allowedMultiSizes = default(string), string allowedWorkerSizes = default(string), int? maximumNumberOfMachines = default(int?), IList<VirtualIPMapping> vipMappings = default(IList<VirtualIPMapping>), IList<StampCapacity> environmentCapacities = default(IList<StampCapacity>), IList<NetworkAccessControlEntry> networkAccessControlList = default(IList<NetworkAccessControlEntry>), bool? environmentIsHealthy = default(bool?), string environmentStatus = default(string), string resourceGroup = default(string), int? frontEndScaleFactor = default(int?), int? defaultFrontEndScaleFactor = default(int?), string apiManagementAccountId = default(string), bool? suspended = default(bool?), bool? dynamicCacheEnabled = default(bool?), IList<NameValuePair> clusterSettings = default(IList<NameValuePair>))
            : base(location, id, name, type, tags)
        {
            AppServiceEnvironmentResourceName = appServiceEnvironmentResourceName;
            AppServiceEnvironmentResourceLocation = appServiceEnvironmentResourceLocation;
            ProvisioningState = provisioningState;
            Status = status;
            VnetName = vnetName;
            VnetResourceGroupName = vnetResourceGroupName;
            VnetSubnetName = vnetSubnetName;
            VirtualNetwork = virtualNetwork;
            InternalLoadBalancingMode = internalLoadBalancingMode;
            MultiSize = multiSize;
            MultiRoleCount = multiRoleCount;
            WorkerPools = workerPools;
            IpsslAddressCount = ipsslAddressCount;
            DatabaseEdition = databaseEdition;
            DatabaseServiceObjective = databaseServiceObjective;
            UpgradeDomains = upgradeDomains;
            SubscriptionId = subscriptionId;
            DnsSuffix = dnsSuffix;
            LastAction = lastAction;
            LastActionResult = lastActionResult;
            AllowedMultiSizes = allowedMultiSizes;
            AllowedWorkerSizes = allowedWorkerSizes;
            MaximumNumberOfMachines = maximumNumberOfMachines;
            VipMappings = vipMappings;
            EnvironmentCapacities = environmentCapacities;
            NetworkAccessControlList = networkAccessControlList;
            EnvironmentIsHealthy = environmentIsHealthy;
            EnvironmentStatus = environmentStatus;
            ResourceGroup = resourceGroup;
            FrontEndScaleFactor = frontEndScaleFactor;
            DefaultFrontEndScaleFactor = defaultFrontEndScaleFactor;
            ApiManagementAccountId = apiManagementAccountId;
            Suspended = suspended;
            DynamicCacheEnabled = dynamicCacheEnabled;
            ClusterSettings = clusterSettings;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets name of the App Service Environment.
        /// </summary>
        [JsonProperty(PropertyName = "properties.name")]
        public string AppServiceEnvironmentResourceName { get; set; }

        /// <summary>
        /// Gets or sets location of the App Service Environment, e.g. "West
        /// US".
        /// </summary>
        [JsonProperty(PropertyName = "properties.location")]
        public string AppServiceEnvironmentResourceLocation { get; set; }

        /// <summary>
        /// Gets provisioning state of the App Service Environment. Possible
        /// values include: 'Succeeded', 'Failed', 'Canceled', 'InProgress',
        /// 'Deleting'
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public ProvisioningState? ProvisioningState { get; private set; }

        /// <summary>
        /// Gets current status of the App Service Environment. Possible values
        /// include: 'Preparing', 'Ready', 'Scaling', 'Deleting'
        /// </summary>
        [JsonProperty(PropertyName = "properties.status")]
        public HostingEnvironmentStatus? Status { get; private set; }

        /// <summary>
        /// Gets or sets name of the Virtual Network for the App Service
        /// Environment.
        /// </summary>
        [JsonProperty(PropertyName = "properties.vnetName")]
        public string VnetName { get; set; }

        /// <summary>
        /// Gets or sets resource group of the Virtual Network.
        /// </summary>
        [JsonProperty(PropertyName = "properties.vnetResourceGroupName")]
        public string VnetResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets subnet of the Virtual Network.
        /// </summary>
        [JsonProperty(PropertyName = "properties.vnetSubnetName")]
        public string VnetSubnetName { get; set; }

        /// <summary>
        /// Gets or sets description of the Virtual Network.
        /// </summary>
        [JsonProperty(PropertyName = "properties.virtualNetwork")]
        public VirtualNetworkProfile VirtualNetwork { get; set; }

        /// <summary>
        /// Gets or sets specifies which endpoints to serve internally in the
        /// Virtual Network for the App Service Environment. Possible values
        /// include: 'None', 'Web', 'Publishing'
        /// </summary>
        [JsonProperty(PropertyName = "properties.internalLoadBalancingMode")]
        public InternalLoadBalancingMode? InternalLoadBalancingMode { get; set; }

        /// <summary>
        /// Gets or sets front-end VM size, e.g. "Medium", "Large".
        /// </summary>
        [JsonProperty(PropertyName = "properties.multiSize")]
        public string MultiSize { get; set; }

        /// <summary>
        /// Gets or sets number of front-end instances.
        /// </summary>
        [JsonProperty(PropertyName = "properties.multiRoleCount")]
        public int? MultiRoleCount { get; set; }

        /// <summary>
        /// Gets or sets description of worker pools with worker size IDs, VM
        /// sizes, and number of workers in each pool.
        /// </summary>
        [JsonProperty(PropertyName = "properties.workerPools")]
        public IList<WorkerPool> WorkerPools { get; set; }

        /// <summary>
        /// Gets or sets number of IP SSL addresses reserved for the App
        /// Service Environment.
        /// </summary>
        [JsonProperty(PropertyName = "properties.ipsslAddressCount")]
        public int? IpsslAddressCount { get; set; }

        /// <summary>
        /// Gets edition of the metadata database for the App Service
        /// Environment, e.g. "Standard".
        /// </summary>
        [JsonProperty(PropertyName = "properties.databaseEdition")]
        public string DatabaseEdition { get; private set; }

        /// <summary>
        /// Gets service objective of the metadata database for the App Service
        /// Environment, e.g. "S0".
        /// </summary>
        [JsonProperty(PropertyName = "properties.databaseServiceObjective")]
        public string DatabaseServiceObjective { get; private set; }

        /// <summary>
        /// Gets number of upgrade domains of the App Service Environment.
        /// </summary>
        [JsonProperty(PropertyName = "properties.upgradeDomains")]
        public int? UpgradeDomains { get; private set; }

        /// <summary>
        /// Gets subscription of the App Service Environment.
        /// </summary>
        [JsonProperty(PropertyName = "properties.subscriptionId")]
        public string SubscriptionId { get; private set; }

        /// <summary>
        /// Gets or sets DNS suffix of the App Service Environment.
        /// </summary>
        [JsonProperty(PropertyName = "properties.dnsSuffix")]
        public string DnsSuffix { get; set; }

        /// <summary>
        /// Gets last deployment action on the App Service Environment.
        /// </summary>
        [JsonProperty(PropertyName = "properties.lastAction")]
        public string LastAction { get; private set; }

        /// <summary>
        /// Gets result of the last deployment action on the App Service
        /// Environment.
        /// </summary>
        [JsonProperty(PropertyName = "properties.lastActionResult")]
        public string LastActionResult { get; private set; }

        /// <summary>
        /// Gets list of comma separated strings describing which VM sizes are
        /// allowed for front-ends.
        /// </summary>
        [JsonProperty(PropertyName = "properties.allowedMultiSizes")]
        public string AllowedMultiSizes { get; private set; }

        /// <summary>
        /// Gets list of comma separated strings describing which VM sizes are
        /// allowed for workers.
        /// </summary>
        [JsonProperty(PropertyName = "properties.allowedWorkerSizes")]
        public string AllowedWorkerSizes { get; private set; }

        /// <summary>
        /// Gets maximum number of VMs in the App Service Environment.
        /// </summary>
        [JsonProperty(PropertyName = "properties.maximumNumberOfMachines")]
        public int? MaximumNumberOfMachines { get; private set; }

        /// <summary>
        /// Gets description of IP SSL mapping for the App Service Environment.
        /// </summary>
        [JsonProperty(PropertyName = "properties.vipMappings")]
        public IList<VirtualIPMapping> VipMappings { get; private set; }

        /// <summary>
        /// Gets current total, used, and available worker capacities.
        /// </summary>
        [JsonProperty(PropertyName = "properties.environmentCapacities")]
        public IList<StampCapacity> EnvironmentCapacities { get; private set; }

        /// <summary>
        /// Gets or sets access control list for controlling traffic to the App
        /// Service Environment.
        /// </summary>
        [JsonProperty(PropertyName = "properties.networkAccessControlList")]
        public IList<NetworkAccessControlEntry> NetworkAccessControlList { get; set; }

        /// <summary>
        /// Gets true/false indicating whether the App Service Environment is
        /// healthy.
        /// </summary>
        [JsonProperty(PropertyName = "properties.environmentIsHealthy")]
        public bool? EnvironmentIsHealthy { get; private set; }

        /// <summary>
        /// Gets detailed message about with results of the last check of the
        /// App Service Environment.
        /// </summary>
        [JsonProperty(PropertyName = "properties.environmentStatus")]
        public string EnvironmentStatus { get; private set; }

        /// <summary>
        /// Gets resource group of the App Service Environment.
        /// </summary>
        [JsonProperty(PropertyName = "properties.resourceGroup")]
        public string ResourceGroup { get; private set; }

        /// <summary>
        /// Gets or sets scale factor for front-ends.
        /// </summary>
        [JsonProperty(PropertyName = "properties.frontEndScaleFactor")]
        public int? FrontEndScaleFactor { get; set; }

        /// <summary>
        /// Gets default Scale Factor for FrontEnds.
        /// </summary>
        [JsonProperty(PropertyName = "properties.defaultFrontEndScaleFactor")]
        public int? DefaultFrontEndScaleFactor { get; private set; }

        /// <summary>
        /// Gets or sets API Management Account associated with the App Service
        /// Environment.
        /// </summary>
        [JsonProperty(PropertyName = "properties.apiManagementAccountId")]
        public string ApiManagementAccountId { get; set; }

        /// <summary>
        /// Gets or sets &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt; if the
        /// App Service Environment is suspended; otherwise,
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt;. The environment can
        /// be suspended, e.g. when the management endpoint is no longer
        /// available
        /// (most likely because NSG blocked the incoming traffic).
        /// </summary>
        [JsonProperty(PropertyName = "properties.suspended")]
        public bool? Suspended { get; set; }

        /// <summary>
        /// Gets or sets true/false indicating whether the App Service
        /// Environment is suspended. The environment can be suspended e.g.
        /// when the management endpoint is no longer available
        /// (most likely because NSG blocked the incoming traffic).
        /// </summary>
        [JsonProperty(PropertyName = "properties.dynamicCacheEnabled")]
        public bool? DynamicCacheEnabled { get; set; }

        /// <summary>
        /// Gets or sets custom settings for changing the behavior of the App
        /// Service Environment.
        /// </summary>
        [JsonProperty(PropertyName = "properties.clusterSettings")]
        public IList<NameValuePair> ClusterSettings { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (AppServiceEnvironmentResourceName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "AppServiceEnvironmentResourceName");
            }
            if (AppServiceEnvironmentResourceLocation == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "AppServiceEnvironmentResourceLocation");
            }
            if (VirtualNetwork == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "VirtualNetwork");
            }
            if (WorkerPools == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "WorkerPools");
            }
        }
    }
}
