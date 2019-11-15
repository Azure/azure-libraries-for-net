// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.PolicyAssignment.Definition;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PolicyAssignmentImpl :
        Creatable<IPolicyAssignment, PolicyAssignmentInner, PolicyAssignmentImpl, IPolicyAssignment>,
        IPolicyAssignment,
        IDefinition
    {
        private readonly IPolicyAssignmentsOperations client;
        internal PolicyAssignmentImpl(PolicyAssignmentInner innerModel, IPolicyAssignmentsOperations client) :
            base(innerModel.Name, innerModel)
        {
            this.client = client;
        }

        public string Description
        {
            get
            {
                return this.Inner.Description;
            }
        }

        public string DisplayName
        {
            get
            {
                return this.Inner.DisplayName;
            }
        }

        public EnforcementMode EnforcementMode
        {
            get
            {
                return this.Inner.EnforcementMode;
            }
        }

        public string Scope
        {
            get
            {
                return this.Inner.Scope;
            }
        }

        public string PolicyDefinitionId
        {
            get
            {
                return this.Inner.PolicyDefinitionId;
            }
        }

        public string Id
        {
            get
            {
                return this.Inner.Id;
            }
        }

        public async override Task<IPolicyAssignment> CreateResourceAsync(CancellationToken cancellationToken)
        {
            PolicyAssignmentInner inner = new PolicyAssignmentInner
            {
                DisplayName = DisplayName,
                Description = Description,
                EnforcementMode = EnforcementMode,
                PolicyDefinitionId = PolicyDefinitionId
            };
            await client.CreateAsync(Scope, Name, inner, cancellationToken);
            return this;
        }

        public IWithPolicyDefinition ForResource(IGenericResource genericResource)
        {
            Inner.Scope = genericResource.Id;
            return this;
        }

        public IWithPolicyDefinition ForResourceGroup(IResourceGroup resourceGroup)
        {
            Inner.Scope = resourceGroup.Id;
            return this;
        }

        public IWithPolicyDefinition ForScope(string scope)
        {
            Inner.Scope = scope;
            return this;
        }

        public IWithCreate WithDefaultMode()
        {
            Inner.EnforcementMode = EnforcementMode.Default;
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

        public IWithCreate WithDoNotEnforceMode()
        {
            Inner.EnforcementMode = EnforcementMode.DoNotEnforce;
            return this;
        }

        public IWithCreate WithPolicyDefinition(IPolicyDefinition policyDefinition)
        {
            Inner.PolicyDefinitionId = policyDefinition.Id;
            return this;
        }

        public IWithCreate WithPolicyDefinitionId(string policyDefinitionId)
        {
            Inner.PolicyDefinitionId = policyDefinitionId;
            return this;
        }

        protected async override Task<PolicyAssignmentInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await client.GetAsync(Scope, Name, cancellationToken);
        }
    }
}
