// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.PolicyDefinition.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.PolicyDefinition.Update;
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PolicyDefinitionImpl :
        CreatableUpdatable<IPolicyDefinition, PolicyDefinitionInner, PolicyDefinitionImpl, IPolicyDefinition, IUpdate>,
        IPolicyDefinition,
        IDefinition,
        IUpdate
    {
        private readonly IPolicyDefinitionsOperations client;

        internal PolicyDefinitionImpl(PolicyDefinitionInner innerModel, IPolicyDefinitionsOperations client) :
            base(innerModel.Name, innerModel)
        {
            this.client = client;
        }

        public string Description
        {
            get
            {
                return Inner.Description;
            }
        }

        public string DisplayName
        {
            get
            {
                return Inner.DisplayName;
            }
        }

        public string Mode
        {
            get
            {
                return Inner.Mode;
            }
        }

        public object PolicyRule
        {
            get
            {
                return Inner.PolicyRule;
            }
        }

        public PolicyType PolicyType
        {
            get
            {
                return Inner.PolicyType;
            }
        }

        public string Id
        {
            get
            {
                return Inner.Id;
            }
        }

        public async override Task<IPolicyDefinition> CreateResourceAsync(CancellationToken cancellationToken)
        {
            PolicyDefinitionInner inner = new PolicyDefinitionInner
            {
                DisplayName = DisplayName,
                Description = Description,
                Mode = Mode,
                PolicyRule = PolicyRule,
                PolicyType = PolicyType
            };
            await client.CreateOrUpdateAsync(Name, inner, cancellationToken);
            return this;
        }

        public IWithCreate WithBuiltInPolicyType()
        {
            Inner.PolicyType = PolicyType.BuiltIn;
            return this;
        }

        public IWithCreate WithCustomPolicyType()
        {
            Inner.PolicyType = PolicyType.Custom;
            return this;
        }

        public IWithCreate WithDescription(string description)
        {
            Inner.Description = description;
            return this;
        }

        public IWithCreate WithDisplayName(string displayName)
        {
            Inner.DisplayName = displayName;
            return this;
        }

        public IWithCreate WithMode(string mode)
        {
            Inner.Mode = mode;
            return this;
        }

        public IWithCreate WithNotSpecifiedPolicyType()
        {
            Inner.PolicyType = PolicyType.NotSpecified;
            return this;
        }

        public IUpdate WithoutPolicyType()
        {
            Inner.PolicyType = null;
            return this;
        }

        public IWithCreate WithPolicyRule(object policyRule)
        {
            Inner.PolicyRule = policyRule;
            return this;
        }

        public IWithCreate WithPolicyRuleJson(string policyRuleJson)
        {
            Inner.PolicyRule = JsonConvert.DeserializeObject(policyRuleJson);
            return this;
        }

        protected async override Task<PolicyDefinitionInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await client.GetAsync(Name, cancellationToken);
        }

        IUpdate PolicyDefinition.Update.IWithPolicyType.WithBuiltInPolicyType()
        {
            Inner.PolicyType = PolicyType.BuiltIn;
            return this;
        }

        IUpdate PolicyDefinition.Update.IWithPolicyType.WithCustomPolicyType()
        {
            Inner.PolicyType = PolicyType.Custom;
            return this;
        }

        IUpdate PolicyDefinition.Update.IWithDescription.WithDescription(string description)
        {
            Inner.Description = description;
            return this;
        }

        IUpdate PolicyDefinition.Update.IWithDisplayName.WithDisplayName(string displayName)
        {
            Inner.DisplayName = displayName;
            return this;
        }

        IUpdate PolicyDefinition.Update.IWithMode.WithMode(string mode)
        {
            Inner.Mode = mode;
            return this;
        }

        IUpdate PolicyDefinition.Update.IWithPolicyType.WithNotSpecifiedPolicyType()
        {
            Inner.PolicyType = PolicyType.NotSpecified;
            return this;
        }

        IUpdate PolicyDefinition.Update.IWithPolicyRule.WithPolicyRule(object policyRule)
        {
            Inner.PolicyRule = policyRule;
            return this;
        }
    }
}
