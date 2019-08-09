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
    /// NAT rule collection resource.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class AzureFirewallNatRuleCollectionInner : Management.ResourceManager.Fluent.SubResource
    {
        /// <summary>
        /// Initializes a new instance of the
        /// AzureFirewallNatRuleCollectionInner class.
        /// </summary>
        public AzureFirewallNatRuleCollectionInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// AzureFirewallNatRuleCollectionInner class.
        /// </summary>
        /// <param name="priority">Priority of the NAT rule collection
        /// resource.</param>
        /// <param name="action">The action type of a NAT rule
        /// collection.</param>
        /// <param name="rules">Collection of rules used by a NAT rule
        /// collection.</param>
        /// <param name="provisioningState">The provisioning state of the
        /// resource. Possible values include: 'Succeeded', 'Updating',
        /// 'Deleting', 'Failed'</param>
        /// <param name="name">Gets name of the resource that is unique within
        /// a resource group. This name can be used to access the
        /// resource.</param>
        /// <param name="etag">Gets a unique read-only string that changes
        /// whenever the resource is updated.</param>
        public AzureFirewallNatRuleCollectionInner(string id = default(string), int? priority = default(int?), AzureFirewallNatRCAction action = default(AzureFirewallNatRCAction), IList<AzureFirewallNatRule> rules = default(IList<AzureFirewallNatRule>), ProvisioningState provisioningState = default(ProvisioningState), string name = default(string), string etag = default(string))
            : base(id)
        {
            Priority = priority;
            Action = action;
            Rules = rules;
            ProvisioningState = provisioningState;
            Name = name;
            Etag = etag;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets priority of the NAT rule collection resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// Gets or sets the action type of a NAT rule collection.
        /// </summary>
        [JsonProperty(PropertyName = "properties.action")]
        public AzureFirewallNatRCAction Action { get; set; }

        /// <summary>
        /// Gets or sets collection of rules used by a NAT rule collection.
        /// </summary>
        [JsonProperty(PropertyName = "properties.rules")]
        public IList<AzureFirewallNatRule> Rules { get; set; }

        /// <summary>
        /// Gets or sets the provisioning state of the resource. Possible
        /// values include: 'Succeeded', 'Updating', 'Deleting', 'Failed'
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public ProvisioningState ProvisioningState { get; set; }

        /// <summary>
        /// Gets name of the resource that is unique within a resource group.
        /// This name can be used to access the resource.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

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
            if (Priority > 65000)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Priority", 65000);
            }
            if (Priority < 100)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Priority", 100);
            }
        }
    }
}
