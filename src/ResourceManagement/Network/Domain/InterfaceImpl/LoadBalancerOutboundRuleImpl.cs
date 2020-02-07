// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using System;
    using System.Collections.Generic;

    internal class LoadBalancerOutboundRuleImpl :
        ChildResource<OutboundRuleInner, LoadBalancerImpl, ILoadBalancer>,
        ILoadBalancerOutboundRule,
        LoadBalancerOutboundRule.Definition.IDefinition<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>,
        LoadBalancerOutboundRule.UpdateDefinition.IUpdateDefinition<LoadBalancer.Update.IUpdate>,
        LoadBalancerOutboundRule.Update.IUpdate
    {
        internal LoadBalancerOutboundRuleImpl(OutboundRuleInner inner, LoadBalancerImpl parent) : base(inner, parent)
        {
        }

        public override string Name()
        {
            return Inner.Name;
        }

        public IReadOnlyList<ILoadBalancerFrontend> Frontends
        {
            get
            {
                IList<SubResource> frontendRefs = Inner.FrontendIPConfigurations;
                List<ILoadBalancerFrontend> frontends = new List<ILoadBalancerFrontend>();
                if (frontendRefs != null)
                {
                    foreach (SubResource frontendRef in frontendRefs)
                    {
                        string name = ResourceUtils.NameFromResourceId(frontendRef.Id);
                        ILoadBalancerFrontend frontend;
                        Parent.Frontends().TryGetValue(name, out frontend);
                        if (frontend != null)
                        {
                            frontends.Add(frontend);
                        }
                    }
                }
                return frontends;
            }
        }

        public ILoadBalancerBackend Backend
        {
            get
            {
                SubResource backendRef = Inner.BackendAddressPool;
                if (backendRef == null)
                {
                    return null;
                }
                else
                {
                    string backendName = ResourceUtils.NameFromResourceId(backendRef.Id);
                    ILoadBalancerBackend backend;
                    Parent.Backends().TryGetValue(backendName, out backend);
                    return backend;
                }
            }
        }

        public int IdleTimeoutInMinutes
        {
            get
            {
                return Inner.IdleTimeoutInMinutes ?? 0;
            }
        }

        public bool TcpResetEnabled
        {
            get
            {
                return Inner.EnableTcpReset ?? false;
            }
        }

        public LoadBalancerOutboundRuleProtocol Protocol
        {
            get
            {
                return Inner.Protocol;
            }
        }

        LoadBalancer.Definition.IWithLBRuleOrNatOrCreate IInDefinition<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>.Attach()
        {
            return this.AttachInternal();
        }

        LoadBalancerOutboundRule.Definition.IWithFrontend<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> LoadBalancerOutboundRule.Definition.IWithBackend<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>.FromBackend(string backendName)
        {
            return this.FromBackendInternal(backendName);
        }

        LoadBalancerOutboundRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> LoadBalancerOutboundRule.Definition.IWithFrontend<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>.ToFrontend(string frontendName)
        {
            return this.ToFrontendsInternal(new List<string>() { frontendName });
        }

        LoadBalancerOutboundRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> LoadBalancerOutboundRule.Definition.IWithFrontend<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>.ToFrontends(params string[] frontendNames)
        {
            return this.ToFrontendsInternal(frontendNames);
        }

        LoadBalancerOutboundRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> LoadBalancerOutboundRule.Definition.IWithTcpReset<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>.WithEnableTcpReset()
        {
            return this.WithEnableTcpResetInternal(true);
        }

        LoadBalancerOutboundRule.Definition.IWithAttach<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> LoadBalancerOutboundRule.Definition.IWithIdleTimeout<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>.WithIdleTimeoutInMinutes(int minutes)
        {
            return this.WithIdleTimeoutInMinutesInternal(minutes);
        }

        LoadBalancerOutboundRule.Definition.IWithBackend<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate> HasProtocol.Definition.IWithProtocol<LoadBalancerOutboundRule.Definition.IWithBackend<LoadBalancer.Definition.IWithLBRuleOrNatOrCreate>, LoadBalancerOutboundRuleProtocol>.WithProtocol(LoadBalancerOutboundRuleProtocol protocol)
        {
            return this.WithProtocolInternal(protocol);
        }

        LoadBalancer.Update.IUpdate IInDefinition<LoadBalancer.Update.IUpdate>.Attach()
        {
            return this.AttachInternal();
        }

        LoadBalancerOutboundRule.UpdateDefinition.IWithFrontend<LoadBalancer.Update.IUpdate> LoadBalancerOutboundRule.UpdateDefinition.IWithBackend<LoadBalancer.Update.IUpdate>.FromBackend(string backendName)
        {
            return this.FromBackendInternal(backendName);
        }

        LoadBalancerOutboundRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancerOutboundRule.UpdateDefinition.IWithFrontend<LoadBalancer.Update.IUpdate>.ToFrontend(string frontendName)
        {
            return this.ToFrontendsInternal(new List<string>() { frontendName });
        }

        LoadBalancerOutboundRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancerOutboundRule.UpdateDefinition.IWithFrontend<LoadBalancer.Update.IUpdate>.ToFrontends(params string[] frontendNames)
        {
            return this.ToFrontendsInternal(frontendNames);
        }

        LoadBalancerOutboundRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancerOutboundRule.UpdateDefinition.IWithTcpReset<LoadBalancer.Update.IUpdate>.WithEnableTcpReset()
        {
            return this.WithEnableTcpResetInternal(true);
        }

        LoadBalancerOutboundRule.UpdateDefinition.IWithAttach<LoadBalancer.Update.IUpdate> LoadBalancerOutboundRule.UpdateDefinition.IWithIdleTimeout<LoadBalancer.Update.IUpdate>.WithIdleTimeoutInMinutes(int minutes)
        {
            return this.WithIdleTimeoutInMinutesInternal(minutes);
        }

        LoadBalancerOutboundRule.UpdateDefinition.IWithBackend<LoadBalancer.Update.IUpdate> HasProtocol.Definition.IWithProtocol<LoadBalancerOutboundRule.UpdateDefinition.IWithBackend<LoadBalancer.Update.IUpdate>, LoadBalancerOutboundRuleProtocol>.WithProtocol(LoadBalancerOutboundRuleProtocol protocol)
        {
            return this.WithProtocolInternal(protocol);
        }

        LoadBalancer.Update.IUpdate ISettable<LoadBalancer.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        LoadBalancerOutboundRule.Update.IUpdate LoadBalancerOutboundRule.Update.IWithBackend.FromBackend(string backendName)
        {
            return this.FromBackendInternal(backendName);
        }

        LoadBalancerOutboundRule.Update.IUpdate LoadBalancerOutboundRule.Update.IWithFrontend.ToFrontend(string frontendName)
        {
            return this.ToFrontendsInternal(new List<string>() { frontendName });
        }

        LoadBalancerOutboundRule.Update.IUpdate LoadBalancerOutboundRule.Update.IWithFrontend.ToFrontends(params string[] frontendNames)
        {
            return this.ToFrontendsInternal(frontendNames);
        }

        LoadBalancerOutboundRule.Update.IUpdate LoadBalancerOutboundRule.Update.IWithTcpReset.WithEnableTcpReset(bool enable)
        {
            return this.WithEnableTcpResetInternal(enable);
        }

        LoadBalancerOutboundRule.Update.IUpdate LoadBalancerOutboundRule.Update.IWithIdleTimeout.WithIdleTimeoutInMinutes(int minutes)
        {
            return this.WithIdleTimeoutInMinutesInternal(minutes);
        }

        LoadBalancerOutboundRule.Update.IUpdate HasProtocol.Definition.IWithProtocol<LoadBalancerOutboundRule.Update.IUpdate, LoadBalancerOutboundRuleProtocol>.WithProtocol(LoadBalancerOutboundRuleProtocol protocol)
        {
            return this.WithProtocolInternal(protocol);
        }

        private LoadBalancerImpl AttachInternal()
        {
            return Parent.WithOutboundRule(this);
        }

        private LoadBalancerOutboundRuleImpl FromBackendInternal(string backendName)
        {
            // Ensure existence of backend, creating one if needed
            Parent.DefineBackend(backendName).Attach();

            SubResource backendRef = new SubResource()
            {
                Id = Parent.FutureResourceId() + "/backendAddressPools/" + backendName
            };
            Inner.BackendAddressPool = backendRef;
            return this;
        }

        private LoadBalancerOutboundRuleImpl ToFrontendsInternal(IEnumerable<string> frontendNames)
        {
            if (frontendNames == null || !frontendNames.GetEnumerator().MoveNext())
            {
                throw new ArgumentException("Load balancer outbound rule requires at least 1 frontend.");
            }

            IList<SubResource> frontendRefs = new List<SubResource>();
            foreach (string frontendName in frontendNames)
            {
                SubResource frontendRef = new SubResource()
                {
                    Id = Parent.FutureResourceId() + "/frontendIPConfigurations/" + frontendName
                };
                frontendRefs.Add(frontendRef);
            }
            Inner.FrontendIPConfigurations = frontendRefs;
            return this;
        }

        private LoadBalancerOutboundRuleImpl WithEnableTcpResetInternal(bool enable)
        {
            Inner.EnableTcpReset = enable;
            return this;
        }

        private LoadBalancerOutboundRuleImpl WithIdleTimeoutInMinutesInternal(int minutes)
        {
            Inner.IdleTimeoutInMinutes = minutes;
            return this;
        }

        private LoadBalancerOutboundRuleImpl WithProtocolInternal(LoadBalancerOutboundRuleProtocol protocol)
        {
            Inner.Protocol = protocol;
            return this;
        }
    }
}
