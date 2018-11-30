// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.TrafficManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition;
    using Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Definition;
    using System.Collections.Generic;
    using MonitorConfigExpectedStatusCodeRangesItem = Microsoft.Azure.Management.TrafficManager.Fluent.Models.MonitorConfigExpectedStatusCodeRangesItem;
    using MonitorConfigCustomHeadersItem = Microsoft.Azure.Management.TrafficManager.Fluent.Models.MonitorConfigCustomHeadersItem;

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for the resource to be created
    /// (via  WithCreate.create()), but also allows for any other optional settings to be specified.
    /// </summary>
    public interface IWithCreate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.TrafficManager.Fluent.ITrafficManagerProfile>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate>,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithMonitoringConfiguration,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithTtl,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithProfileStatus,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithTrafficViewEnrollment,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint
    {
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to disable the profile.
    /// </summary>
    public interface IWithProfileStatus
    {
        /// <summary>
        /// Specify that the profile needs to be disabled.
        /// Disabling the profile will disables traffic to all endpoints in the profile.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate WithProfileStatusDisabled();
    }

    /// <summary>
    /// The entirety of the traffic manager profile definition.
    /// </summary>
    public interface IDefinition :
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IBlank,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithLeafDomainLabel,
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithTrafficRoutingMethod,        
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate
    {
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to specify the traffic routing method
    /// for the profile.
    /// </summary>
    public interface IWithTrafficRoutingMethod
    {
        /// <summary>
        /// Specifies that end user traffic should be distributed to the endpoints based on the weight assigned
        /// to the endpoint.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint WithWeightBasedRouting();

        /// <summary>
        /// Specifies that end user traffic should be routed to the endpoint based on its priority
        /// i.e. use the endpoint with highest priority and if it is not available fallback to next highest
        /// priority endpoint.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint WithPriorityBasedRouting();

        /// <summary>
        /// Specify the traffic routing method for the profile.
        /// </summary>
        /// <param name="routingMethod">The traffic routing method for the profile.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint WithTrafficRoutingMethod(TrafficRoutingMethod routingMethod);

        /// <summary>
        /// Specifies that end user traffic should be routed based on the closest available endpoint in terms
        /// of the lowest network latency.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint WithPerformanceBasedRouting();

        /// <summary>
        /// Specifies that end user traffic should be routed to the endpoint that is designated to serve users
        /// geographic region.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint WithGeographicBasedRouting();

        /// <summary>
        /// Specifies that end user traffic should return multiple address values
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint WithMultiValueBasedRouting();

        /// <summary>
        /// Specifies that end user traffic should return multiple address values
        /// </summary>
        /// <param name="maxReturn">max number of address to be returned</param>
        /// <returns></returns>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint WithMultiValueBasedRouting(int maxReturn);

        /// <summary>
        /// Subnet traffic-routing method to map sets of end-user IP address ranges to a specific endpoint within a Traffic Manager profile. 
        /// When a request is received, the endpoint returned will be the one mapped for that request’s source IP address
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithEndpoint WithSubnetBasedRouting();
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to specify the endpoint monitoring configuration.
    /// </summary>
    public interface IWithMonitoringConfiguration
    {
        /// <summary>
        /// Specify to use HTTP monitoring for the endpoints that checks for HTTP 200 response from the path '/'
        /// at regular intervals, using port 80.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate WithHttpMonitoring();

        /// <summary>
        /// Specify the HTTP monitoring for the endpoints that checks for HTTP 200 response from the specified
        /// path at regular intervals, using the specified port.
        /// </summary>
        /// <param name="port">The monitoring port.</param>
        /// <param name="path">The monitoring path.</param>
        /// <param name="probingInterval">The probing interval in seconds.</param>
        /// <param name="probeTimeout">The probe timeout before failure in seconds.</param>
        /// <param name="toleratedNumberOfFailures">The total number of failures tolerated before endpoint is disabled.</param>
        /// <param name="expectedStatusCodeRanges">The expected status code ranges for a successful probe.</param>
        /// <param name="customHeaderSettings">The custom headers to be used with probing.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate WithHttpMonitoring(int port, string path, long? probingInterval = null, long? probeTimeout = null, long? toleratedNumberOfFailures = null, IEnumerable<MonitorConfigExpectedStatusCodeRangesItem> expectedStatusCodeRanges = null, IEnumerable<MonitorConfigCustomHeadersItem> customHeaderSettings = null);

        /// <summary>
        /// Specify to use HTTPS monitoring for the endpoints that checks for HTTPS 200 response from the path '/'
        /// at regular intervals, using port 443.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate WithHttpsMonitoring();

        /// <summary>
        /// Specify the HTTPS monitoring for the endpoints that checks for HTTPS 200 response from the specified
        /// path at regular intervals, using the specified port.
        /// </summary>
        /// <param name="port">The monitoring port.</param>
        /// <param name="path">The monitoring path.</param>
        /// <param name="probingInterval">The probing interval in seconds.</param>
        /// <param name="probeTimeout">The probe timeout before failure in seconds.</param>
        /// <param name="toleratedNumberOfFailures">The total number of failures tolerated before endpoint is disabled.</param>
        /// <param name="expectedStatusCodeRanges">The expected status code ranges for a successful probe.</param>
        /// <param name="customHeaderSettings">The custom headers to be used with probing.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate WithHttpsMonitoring(int port, string path, long? probingInterval = null, long? probeTimeout = null, long? toleratedNumberOfFailures = null, IEnumerable<MonitorConfigExpectedStatusCodeRangesItem> expectedStatusCodeRanges = null, IEnumerable<MonitorConfigCustomHeadersItem> customHeaderSettings = null);
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to specify the resource group.
    /// </summary>
    public interface IBlank :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.GroupableResource.Definition.IWithGroupAndRegion<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithLeafDomainLabel>
    {
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to specify the relative DNS name.
    /// </summary>
    public interface IWithLeafDomainLabel
    {
        /// <summary>
        /// Specify the relative DNS name of the profile.
        /// The fully qualified domain name (FQDN)
        /// will be constructed automatically by appending the rest of the domain to this label.
        /// </summary>
        /// <param name="dnsLabel">The relative DNS name of the profile.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithTrafficRoutingMethod WithLeafDomainLabel(string dnsLabel);
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to specify the DNS TTL.
    /// </summary>
    public interface IWithTtl
    {
        /// <summary>
        /// Specify the DNS TTL in seconds.
        /// </summary>
        /// <param name="ttlInSeconds">DNS TTL in seconds.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate WithTimeToLive(int ttlInSeconds);
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to specify endpoint.
    /// </summary>
    public interface IWithEndpoint
    {
        /// <summary>
        /// Specifies definition of an nested profile endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Definition.INestedProfileTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate> DefineNestedTargetEndpoint(string name);

        /// <summary>
        /// Specifies definition of an external endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Definition.IExternalTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate> DefineExternalTargetEndpoint(string name);

        /// <summary>
        /// Specifies definition of an Azure endpoint to be attached to the traffic manager profile.
        /// </summary>
        /// <param name="name">The name for the endpoint.</param>
        /// <return>The stage representing configuration for the endpoint.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerEndpoint.Definition.IAzureTargetEndpointBlank<Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate> DefineAzureTargetEndpoint(string name);
    }

    /// <summary>
    /// The stage of the traffic manager profile definition allowing to disable the traffic view feature.
    /// </summary>
    public interface IWithTrafficViewEnrollment
    {
        /// <summary>
        /// Specify that the traffic view feature needs to be disabled.        
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate WithTrafficViewDisabled();

        /// <summary>
        /// Specify that the traffic view feature needs to be enabled.        
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.TrafficManager.Fluent.TrafficManagerProfile.Definition.IWithCreate WithTrafficViewEnabled();
    }
}