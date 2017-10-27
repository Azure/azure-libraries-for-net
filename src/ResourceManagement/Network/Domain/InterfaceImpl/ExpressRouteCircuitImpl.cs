// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ExpressRouteCircuit.Update;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    internal partial class ExpressRouteCircuitImpl 
    {
        ExpressRouteCircuit.Definition.IWithBandwidth ExpressRouteCircuit.Definition.IWithPeeringLocation.WithPeeringLocation(string location)
        {
            return this.WithPeeringLocation(location) as ExpressRouteCircuit.Definition.IWithBandwidth;
        }

        ExpressRouteCircuit.Update.IUpdate ExpressRouteCircuit.Update.IWithAllowClassicOperations.EnableClassicOperations
        {
            get
            {
                return this.EnableClassicOperations() as ExpressRouteCircuit.Update.IUpdate;
            }
        }

        ExpressRouteCircuit.Update.IUpdate ExpressRouteCircuit.Update.IWithAllowClassicOperations.DisableClassicOperations
        {
            get
            {
                return this.DisableClassicOperations() as ExpressRouteCircuit.Update.IUpdate;
            }
        }

        ExpressRouteCircuit.Definition.IWithCreate ExpressRouteCircuit.Definition.IWithAllowClassicOperations.EnableClassicOperations
        {
            get
            {
                return this.EnableClassicOperations() as ExpressRouteCircuit.Definition.IWithCreate;
            }
        }

        /// <summary>
        /// Gets the CircuitProvisioningState state of the resource.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit.CircuitProvisioningState
        {
            get
            {
                return this.CircuitProvisioningState();
            }
        }

        /// <summary>
        /// Gets the peerings associated with this express route circuit, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering> Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit.PeeringsMap
        {
            get
            {
                return this.PeeringsMap() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeering>;
            }
        }

        /// <summary>
        /// Gets the provisioning state of the express route circuit resource.
        /// </summary>
        /// <summary>
        /// Gets provisioningState.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the SKU type.
        /// </summary>
        Models.ExpressRouteCircuitSkuType Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit.Sku
        {
            get
            {
                return this.Sku() as Models.ExpressRouteCircuitSkuType;
            }
        }

        /// <summary>
        /// Gets the ServiceProviderNotes.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit.ServiceProviderNotes
        {
            get
            {
                return this.ServiceProviderNotes();
            }
        }

        /// <return>Entry point to manage express route peerings associated with express route circuit.</return>
        Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeerings Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit.Peerings()
        {
            return this.Peerings() as Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuitPeerings;
        }

        /// <summary>
        /// Gets the ServiceKey.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit.ServiceKey
        {
            get
            {
                return this.ServiceKey();
            }
        }

        /// <summary>
        /// Gets the ServiceProviderProperties.
        /// </summary>
        Models.ExpressRouteCircuitServiceProviderProperties Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit.ServiceProviderProperties
        {
            get
            {
                return this.ServiceProviderProperties() as Models.ExpressRouteCircuitServiceProviderProperties;
            }
        }

        /// <summary>
        /// Gets The ServiceProviderProvisioningState state of the resource.
        /// </summary>
        /// <summary>
        /// Gets serviceProviderProvisioningState.
        /// </summary>
        Models.ServiceProviderProvisioningState Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit.ServiceProviderProvisioningState
        {
            get
            {
                return this.ServiceProviderProvisioningState() as Models.ServiceProviderProvisioningState;
            }
        }

        /// <summary>
        /// Gets the flag indicating if classic operations allowed.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IExpressRouteCircuit.IsAllowClassicOperations
        {
            get
            {
                return this.IsAllowClassicOperations();
            }
        }

        ExpressRouteCircuit.Update.IUpdate ExpressRouteCircuit.Update.IWithBandwidth.WithBandwidthInMbps(int bandwidthInMbps)
        {
            return this.WithBandwidthInMbps(bandwidthInMbps) as ExpressRouteCircuit.Update.IUpdate;
        }

        ExpressRouteCircuit.Definition.IWithSku ExpressRouteCircuit.Definition.IWithBandwidth.WithBandwidthInMbps(int bandwidthInMbps)
        {
            return this.WithBandwidthInMbps(bandwidthInMbps) as ExpressRouteCircuit.Definition.IWithSku;
        }

        ExpressRouteCircuit.Definition.IWithPeeringLocation ExpressRouteCircuit.Definition.IWithServiceProvider.WithServiceProvider(string serviceProviderName)
        {
            return this.WithServiceProvider(serviceProviderName) as ExpressRouteCircuit.Definition.IWithPeeringLocation;
        }

        ExpressRouteCircuit.Update.IUpdate ExpressRouteCircuit.Update.IWithSku.WithSku(ExpressRouteCircuitSkuType sku)
        {
            return this.WithSku(sku) as ExpressRouteCircuit.Update.IUpdate;
        }

        ExpressRouteCircuit.Definition.IWithCreate ExpressRouteCircuit.Definition.IWithSku.WithSku(ExpressRouteCircuitSkuType skuType)
        {
            return this.WithSku(skuType) as ExpressRouteCircuit.Definition.IWithCreate;
        }
    }
}