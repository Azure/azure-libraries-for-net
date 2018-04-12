// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A DDoS protection plan in a resource group.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class DdosProtectionPlanInner : Management.ResourceManager.Fluent.Resource
    {
        /// <summary>
        /// Initializes a new instance of the DdosProtectionPlanInner class.
        /// </summary>
        public DdosProtectionPlanInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DdosProtectionPlanInner class.
        /// </summary>
        /// <param name="resourceGuid">The resource GUID property of the DDoS
        /// protection plan resource. It uniquely identifies the resource, even
        /// if the user changes its name or migrate the resource across
        /// subscriptions or resource groups.</param>
        /// <param name="provisioningState">The provisioning state of the DDoS
        /// protection plan resource. Possible values are: 'Succeeded',
        /// 'Updating', 'Deleting', and 'Failed'.</param>
        /// <param name="virtualNetworks">The list of virtual networks
        /// associated with the DDoS protection plan resource. This list is
        /// read-only.</param>
        /// <param name="etag">A unique read-only string that changes whenever
        /// the resource is updated.</param>
        public DdosProtectionPlanInner(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string resourceGuid = default(string), string provisioningState = default(string), IList<Management.ResourceManager.Fluent.SubResource> virtualNetworks = default(IList<Management.ResourceManager.Fluent.SubResource>), string etag = default(string))
            : base(location, id, name, type, tags)
        {
            ResourceGuid = resourceGuid;
            ProvisioningState = provisioningState;
            VirtualNetworks = virtualNetworks;
            Etag = etag;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the resource GUID property of the DDoS protection plan
        /// resource. It uniquely identifies the resource, even if the user
        /// changes its name or migrate the resource across subscriptions or
        /// resource groups.
        /// </summary>
        [JsonProperty(PropertyName = "properties.resourceGuid")]
        public string ResourceGuid { get; private set; }

        /// <summary>
        /// Gets the provisioning state of the DDoS protection plan resource.
        /// Possible values are: 'Succeeded', 'Updating', 'Deleting', and
        /// 'Failed'.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Gets the list of virtual networks associated with the DDoS
        /// protection plan resource. This list is read-only.
        /// </summary>
        [JsonProperty(PropertyName = "properties.virtualNetworks")]
        public IList<Management.ResourceManager.Fluent.SubResource> VirtualNetworks { get; private set; }

        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
        }
    }
}
