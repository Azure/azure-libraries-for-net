// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Specifies information about the dedicated host. Only tags,
    /// autoReplaceOnFailure and licenseType may be updated.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class DedicatedHostUpdate : UpdateResource
    {
        /// <summary>
        /// Initializes a new instance of the DedicatedHostUpdate class.
        /// </summary>
        public DedicatedHostUpdate()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DedicatedHostUpdate class.
        /// </summary>
        /// <param name="tags">Resource tags</param>
        /// <param name="platformFaultDomain">Fault domain of the dedicated
        /// host within a dedicated host group.</param>
        /// <param name="autoReplaceOnFailure">Specifies whether the dedicated
        /// host should be replaced automatically in case of a failure. The
        /// value is defaulted to 'true' when not provided.</param>
        /// <param name="hostId">A unique id generated and assigned to the
        /// dedicated host by the platform. &lt;br&gt;&lt;br&gt; Does not
        /// change throughout the lifetime of the host.</param>
        /// <param name="virtualMachines">A list of references to all virtual
        /// machines in the Dedicated Host.</param>
        /// <param name="licenseType">Specifies the software license type that
        /// will be applied to the VMs deployed on the dedicated host.
        /// &lt;br&gt;&lt;br&gt; Possible values are: &lt;br&gt;&lt;br&gt;
        /// **None** &lt;br&gt;&lt;br&gt; **Windows_Server_Hybrid**
        /// &lt;br&gt;&lt;br&gt; **Windows_Server_Perpetual**
        /// &lt;br&gt;&lt;br&gt; Default: **None**. Possible values include:
        /// 'None', 'Windows_Server_Hybrid', 'Windows_Server_Perpetual'</param>
        /// <param name="provisioningTime">The date when the host was first
        /// provisioned.</param>
        /// <param name="provisioningState">The provisioning state, which only
        /// appears in the response.</param>
        /// <param name="instanceView">The dedicated host instance
        /// view.</param>
        public DedicatedHostUpdate(IDictionary<string, string> tags = default(IDictionary<string, string>), int? platformFaultDomain = default(int?), bool? autoReplaceOnFailure = default(bool?), string hostId = default(string), IList<SubResourceReadOnly> virtualMachines = default(IList<SubResourceReadOnly>), DedicatedHostLicenseTypes? licenseType = default(DedicatedHostLicenseTypes?), System.DateTime? provisioningTime = default(System.DateTime?), string provisioningState = default(string), DedicatedHostInstanceView instanceView = default(DedicatedHostInstanceView))
            : base(tags)
        {
            PlatformFaultDomain = platformFaultDomain;
            AutoReplaceOnFailure = autoReplaceOnFailure;
            HostId = hostId;
            VirtualMachines = virtualMachines;
            LicenseType = licenseType;
            ProvisioningTime = provisioningTime;
            ProvisioningState = provisioningState;
            InstanceView = instanceView;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets fault domain of the dedicated host within a dedicated
        /// host group.
        /// </summary>
        [JsonProperty(PropertyName = "properties.platformFaultDomain")]
        public int? PlatformFaultDomain { get; set; }

        /// <summary>
        /// Gets or sets specifies whether the dedicated host should be
        /// replaced automatically in case of a failure. The value is defaulted
        /// to 'true' when not provided.
        /// </summary>
        [JsonProperty(PropertyName = "properties.autoReplaceOnFailure")]
        public bool? AutoReplaceOnFailure { get; set; }

        /// <summary>
        /// Gets a unique id generated and assigned to the dedicated host by
        /// the platform. &amp;lt;br&amp;gt;&amp;lt;br&amp;gt; Does not change
        /// throughout the lifetime of the host.
        /// </summary>
        [JsonProperty(PropertyName = "properties.hostId")]
        public string HostId { get; private set; }

        /// <summary>
        /// Gets a list of references to all virtual machines in the Dedicated
        /// Host.
        /// </summary>
        [JsonProperty(PropertyName = "properties.virtualMachines")]
        public IList<SubResourceReadOnly> VirtualMachines { get; private set; }

        /// <summary>
        /// Gets or sets specifies the software license type that will be
        /// applied to the VMs deployed on the dedicated host.
        /// &amp;lt;br&amp;gt;&amp;lt;br&amp;gt; Possible values are:
        /// &amp;lt;br&amp;gt;&amp;lt;br&amp;gt; **None**
        /// &amp;lt;br&amp;gt;&amp;lt;br&amp;gt; **Windows_Server_Hybrid**
        /// &amp;lt;br&amp;gt;&amp;lt;br&amp;gt; **Windows_Server_Perpetual**
        /// &amp;lt;br&amp;gt;&amp;lt;br&amp;gt; Default: **None**. Possible
        /// values include: 'None', 'Windows_Server_Hybrid',
        /// 'Windows_Server_Perpetual'
        /// </summary>
        [JsonProperty(PropertyName = "properties.licenseType")]
        public DedicatedHostLicenseTypes? LicenseType { get; set; }

        /// <summary>
        /// Gets the date when the host was first provisioned.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningTime")]
        public System.DateTime? ProvisioningTime { get; private set; }

        /// <summary>
        /// Gets the provisioning state, which only appears in the response.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Gets the dedicated host instance view.
        /// </summary>
        [JsonProperty(PropertyName = "properties.instanceView")]
        public DedicatedHostInstanceView InstanceView { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (PlatformFaultDomain < 0)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "PlatformFaultDomain", 0);
            }
        }
    }
}
