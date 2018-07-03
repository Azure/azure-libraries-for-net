// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Definition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using System.Collections.Generic;

    internal partial class ApplicationGatewayProbeImpl
    {
        /// <summary>
        /// Specifies the time interval in seconds between consecutive probes.
        /// </summary>
        /// <param name="seconds">A number of seconds between 1 and 86400.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayProbe.Update.IUpdate ApplicationGatewayProbe.Update.IWithInterval.WithTimeBetweenProbesInSeconds(int seconds)
        {
            return this.WithTimeBetweenProbesInSeconds(seconds);
        }

        /// <summary>
        /// Specifies the amount of time in seconds waiting for a response before the probe is considered failed.
        /// </summary>
        /// <param name="seconds">A number of seconds between 1 and 86400.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayProbe.UpdateDefinition.IWithTimeout<ApplicationGateway.Update.IUpdate>.WithTimeoutInSeconds(int seconds)
        {
            return this.WithTimeoutInSeconds(seconds);
        }

        /// <summary>
        /// Specifies the amount of time in seconds waiting for a response before the probe is considered failed.
        /// </summary>
        /// <param name="seconds">A number of seconds, between 1 and 86400.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayProbe.Definition.IWithTimeout<ApplicationGateway.Definition.IWithCreate>.WithTimeoutInSeconds(int seconds)
        {
            return this.WithTimeoutInSeconds(seconds);
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayProbe.Update.IUpdate HasProtocol.Update.IWithProtocol<ApplicationGatewayProbe.Update.IUpdate, Models.ApplicationGatewayProtocol>.WithProtocol(ApplicationGatewayProtocol protocol)
        {
            return this.WithProtocol(protocol);
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.UpdateDefinition.IWithTimeout<ApplicationGateway.Update.IUpdate> HasProtocol.UpdateDefinition.IWithProtocol<ApplicationGatewayProbe.UpdateDefinition.IWithTimeout<ApplicationGateway.Update.IUpdate>, Models.ApplicationGatewayProtocol>.WithProtocol(ApplicationGatewayProtocol protocol)
        {
            return this.WithProtocol(protocol);
        }

        /// <summary>
        /// Specifies the transport protocol.
        /// </summary>
        /// <param name="protocol">A transport protocol.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.Definition.IWithTimeout<ApplicationGateway.Definition.IWithCreate> HasProtocol.Definition.IWithProtocol<ApplicationGatewayProbe.Definition.IWithTimeout<ApplicationGateway.Definition.IWithCreate>, Models.ApplicationGatewayProtocol>.WithProtocol(ApplicationGatewayProtocol protocol)
        {
            return this.WithProtocol(protocol);
        }

        /// <summary>
        /// Gets the body contents of an HTTP response to a probe to check for to determine backend health, or null if none specified.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayProbeBeta.HealthyHttpResponseBodyContents
        {
            get
            {
                return this.HealthyHttpResponseBodyContents();
            }
        }

        /// <summary>
        /// Gets the number of seconds waiting for a response after which the probe times out and it is marked as failed
        /// Acceptable values are from 1 to 86400 seconds.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayProbe.TimeoutInSeconds
        {
            get
            {
                return this.TimeoutInSeconds();
            }
        }

        /// <summary>
        /// Gets HTTP response code ranges in the format ###-### returned by the backend which the probe considers healthy.
        /// </summary>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayProbeBeta.HealthyHttpResponseStatusCodeRanges
        {
            get
            {
                return this.HealthyHttpResponseStatusCodeRanges();
            }
        }

        /// <summary>
        /// Gets host name to send the probe to.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayProbe.Host
        {
            get
            {
                return this.Host();
            }
        }

        /// <summary>
        /// Gets the number of seconds between probe retries.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayProbe.TimeBetweenProbesInSeconds
        {
            get
            {
                return this.TimeBetweenProbesInSeconds();
            }
        }

        /// <summary>
        /// Gets the relative path to be called by the probe.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayProbe.Path
        {
            get
            {
                return this.Path();
            }
        }

        /// <summary>
        /// Gets the number of failed retry probes before the backend server is marked as being down
        /// Acceptable values are from 1 second to 20.
        /// </summary>
        int Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayProbe.RetriesBeforeUnhealthy
        {
            get
            {
                return this.RetriesBeforeUnhealthy();
            }
        }

        /// <summary>
        /// Specifies HTTP as the probe protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.UpdateDefinition.IWithTimeout<ApplicationGateway.Update.IUpdate> ApplicationGatewayProbe.UpdateDefinition.IWithProtocol<ApplicationGateway.Update.IUpdate>.WithHttp()
        {
            return this.WithHttp();
        }

        /// <summary>
        /// Specifies HTTPS as the probe protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.UpdateDefinition.IWithTimeout<ApplicationGateway.Update.IUpdate> ApplicationGatewayProbe.UpdateDefinition.IWithProtocol<ApplicationGateway.Update.IUpdate>.WithHttps()
        {
            return this.WithHttps();
        }

        /// <summary>
        /// Specifies HTTP as the probe protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.Definition.IWithTimeout<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayProbe.Definition.IWithProtocol<ApplicationGateway.Definition.IWithCreate>.WithHttp()
        {
            return this.WithHttp();
        }

        /// <summary>
        /// Specifies HTTPS as the probe protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.Definition.IWithTimeout<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayProbe.Definition.IWithProtocol<ApplicationGateway.Definition.IWithCreate>.WithHttps()
        {
            return this.WithHttps();
        }

        /// <summary>
        /// Specifies the number of retries before the server is considered unhealthy.
        /// </summary>
        /// <param name="retryCount">A number between 1 and 20.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayProbe.UpdateDefinition.IWithRetries<ApplicationGateway.Update.IUpdate>.WithRetriesBeforeUnhealthy(int retryCount)
        {
            return this.WithRetriesBeforeUnhealthy(retryCount);
        }

        /// <summary>
        /// Specifies the number of retries before the server is considered unhealthy.
        /// </summary>
        /// <param name="retryCount">A number between 1 and 20.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayProbe.Definition.IWithRetries<ApplicationGateway.Definition.IWithCreate>.WithRetriesBeforeUnhealthy(int retryCount)
        {
            return this.WithRetriesBeforeUnhealthy(retryCount);
        }

        /// <summary>
        /// Specifies the amount of time in seconds waiting for a response before the probe is considered failed.
        /// </summary>
        /// <param name="seconds">A number of seconds between 1 and 86400.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayProbe.Update.IUpdate ApplicationGatewayProbe.Update.IWithTimeout.WithTimeoutInSeconds(int seconds)
        {
            return this.WithTimeoutInSeconds(seconds);
        }

        /// <summary>
        /// Specifies the host name to send the probe to.
        /// </summary>
        /// <param name="host">A host name.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.UpdateDefinition.IWithPath<ApplicationGateway.Update.IUpdate> ApplicationGatewayProbe.UpdateDefinition.IWithHost<ApplicationGateway.Update.IUpdate>.WithHost(string host)
        {
            return this.WithHost(host);
        }

        /// <summary>
        /// Specifies the host name to send the probe to.
        /// </summary>
        /// <param name="host">A host name.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.Definition.IWithPath<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayProbe.Definition.IWithHost<ApplicationGateway.Definition.IWithCreate>.WithHost(string host)
        {
            return this.WithHost(host);
        }

        /// <summary>
        /// Specifies the number of retries before the server is considered unhealthy.
        /// </summary>
        /// <param name="retryCount">A number between 1 and 20.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayProbe.Update.IUpdate ApplicationGatewayProbe.Update.IWithRetries.WithRetriesBeforeUnhealthy(int retryCount)
        {
            return this.WithRetriesBeforeUnhealthy(retryCount);
        }

        /// <summary>
        /// Specifies the host name to send the probe to.
        /// </summary>
        /// <param name="host">A host name.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayProbe.Update.IUpdate ApplicationGatewayProbe.Update.IWithHost.WithHost(string host)
        {
            return this.WithHost(host);
        }

        /// <summary>
        /// Adds the specified range of the backend's HTTP response status codes that are to be considered healthy.
        /// </summary>
        /// <param name="range">A number range expressed in the format "###-###", for example "200-399", which is the default.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayProbe.UpdateDefinition.IWithHealthyHttpResponseStatusCodeRangesBeta<ApplicationGateway.Update.IUpdate>.WithHealthyHttpResponseStatusCodeRange(string range)
        {
            return this.WithHealthyHttpResponseStatusCodeRange(range);
        }

        /// <summary>
        /// Adds the specified range of the backend's HTTP response status codes that are to be considered healthy.
        /// </summary>
        /// <param name="from">The lowest number in the range.</param>
        /// <param name="to">The highest number in the range.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayProbe.UpdateDefinition.IWithHealthyHttpResponseStatusCodeRangesBeta<ApplicationGateway.Update.IUpdate>.WithHealthyHttpResponseStatusCodeRange(int from, int to)
        {
            return this.WithHealthyHttpResponseStatusCodeRange(from, to);
        }

        /// <summary>
        /// Specifies the ranges of the backend's HTTP response status codes that are to be considered healthy.
        /// </summary>
        /// <param name="ranges">Number ranges expressed in the format "###-###", for example "200-399", which is the default.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayProbe.UpdateDefinition.IWithHealthyHttpResponseStatusCodeRangesBeta<ApplicationGateway.Update.IUpdate>.WithHealthyHttpResponseStatusCodeRanges(ISet<string> ranges)
        {
            return this.WithHealthyHttpResponseStatusCodeRanges(ranges);
        }

        /// <summary>
        /// Adds the specified range of the backend's HTTP response status codes that are to be considered healthy.
        /// </summary>
        /// <param name="range">A number range expressed in the format "###-###", for example "200-399", which is the default.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayProbe.Definition.IWithHealthyHttpResponseStatusCodeRangesBeta<ApplicationGateway.Definition.IWithCreate>.WithHealthyHttpResponseStatusCodeRange(string range)
        {
            return this.WithHealthyHttpResponseStatusCodeRange(range);
        }

        /// <summary>
        /// Adds the specified range of the backend's HTTP response status codes that are to be considered healthy.
        /// </summary>
        /// <param name="from">The lowest number in the range.</param>
        /// <param name="to">The highest number in the range.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayProbe.Definition.IWithHealthyHttpResponseStatusCodeRangesBeta<ApplicationGateway.Definition.IWithCreate>.WithHealthyHttpResponseStatusCodeRange(int from, int to)
        {
            return this.WithHealthyHttpResponseStatusCodeRange(from, to);
        }

        /// <summary>
        /// Specifies the ranges of the backend's HTTP response status codes that are to be considered healthy.
        /// </summary>
        /// <param name="ranges">Number ranges expressed in the format "###-###", for example "200-399", which is the default.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayProbe.Definition.IWithHealthyHttpResponseStatusCodeRangesBeta<ApplicationGateway.Definition.IWithCreate>.WithHealthyHttpResponseStatusCodeRanges(ISet<string> ranges)
        {
            return this.WithHealthyHttpResponseStatusCodeRanges(ranges);
        }

        /// <summary>
        /// Specifies the relative path for the probe to call.
        /// A probe is sent to &lt;protocol&gt;://&lt;host&gt;:&lt;port&gt;&lt;path&gt;.
        /// </summary>
        /// <param name="path">A relative path.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayProbe.Update.IUpdate ApplicationGatewayProbe.Update.IWithPath.WithPath(string path)
        {
            return this.WithPath(path);
        }

        /// <summary>
        /// Specifies the content, if any, to look for in the body of an HTTP response to a probe to determine the health status of the backend.
        /// </summary>
        /// <param name="text">Contents to look for.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayProbe.UpdateDefinition.IWithHealthyHttpResponseBodyContentsBeta<ApplicationGateway.Update.IUpdate>.WithHealthyHttpResponseBodyContents(string text)
        {
            return this.WithHealthyHttpResponseBodyContents(text);
        }

        /// <summary>
        /// Specifies the content, if any, to look for in the body of an HTTP response to a probe to determine the health status of the backend.
        /// </summary>
        /// <param name="text">Contents to look for.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayProbe.Definition.IWithHealthyHttpResponseBodyContentsBeta<ApplicationGateway.Definition.IWithCreate>.WithHealthyHttpResponseBodyContents(string text)
        {
            return this.WithHealthyHttpResponseBodyContents(text);
        }

        /// <summary>
        /// Specifies the relative path for the probe to call.
        /// A probe is sent to &lt;protocol&gt;://&lt;host&gt;:&lt;port&gt;&lt;path&gt;.
        /// </summary>
        /// <param name="path">A relative path.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.UpdateDefinition.IWithProtocol<ApplicationGateway.Update.IUpdate> ApplicationGatewayProbe.UpdateDefinition.IWithPath<ApplicationGateway.Update.IUpdate>.WithPath(string path)
        {
            return this.WithPath(path);
        }

        /// <summary>
        /// Specifies the relative path for the probe to call.
        /// A probe is sent to &lt;protocol&gt;://&lt;host&gt;:&lt;port&gt;&lt;path&gt;.
        /// </summary>
        /// <param name="path">A relative path.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.Definition.IWithProtocol<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayProbe.Definition.IWithPath<ApplicationGateway.Definition.IWithCreate>.WithPath(string path)
        {
            return this.WithPath(path);
        }

        /// <summary>
        /// Specifies HTTP as the probe protocol.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayProbe.Update.IUpdate ApplicationGatewayProbe.Update.IWithProtocol.WithHttp()
        {
            return this.WithHttp();
        }

        /// <summary>
        /// Specifies HTTPS as the probe protocol.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayProbe.Update.IUpdate ApplicationGatewayProbe.Update.IWithProtocol.WithHttps()
        {
            return this.WithHttps();
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Specifies the content, if any, to look for in the body of an HTTP response to a probe to determine the health status of the backend.
        /// </summary>
        /// <param name="text">Contents to look for.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.Update.IUpdate ApplicationGatewayProbe.Update.IWithHealthyHttpResponseBodyContentsBeta.WithHealthyHttpResponseBodyContents(string text)
        {
            return this.WithHealthyHttpResponseBodyContents(text);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definition.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.IInDefinitionAlt<ApplicationGateway.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Removes all healthy HTTP status response code ranges.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayProbe.Update.IUpdate ApplicationGatewayProbe.Update.IWithHealthyHttpResponseStatusCodeRangesBeta.WithoutHealthyHttpResponseStatusCodeRanges()
        {
            return this.WithoutHealthyHttpResponseStatusCodeRanges();
        }

        /// <summary>
        /// Adds the specified range of the backend's HTTP response status codes that are to be considered healthy.
        /// </summary>
        /// <param name="range">A number range expressed in the format "###-###", for example "200-399", which is the default.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayProbe.Update.IUpdate ApplicationGatewayProbe.Update.IWithHealthyHttpResponseStatusCodeRangesBeta.WithHealthyHttpResponseStatusCodeRange(string range)
        {
            return this.WithHealthyHttpResponseStatusCodeRange(range);
        }

        /// <summary>
        /// Adds the specified range of the backend's HTTP response status codes that are to be considered healthy.
        /// </summary>
        /// <param name="from">The lowest number in the range.</param>
        /// <param name="to">The highest number in the range.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayProbe.Update.IUpdate ApplicationGatewayProbe.Update.IWithHealthyHttpResponseStatusCodeRangesBeta.WithHealthyHttpResponseStatusCodeRange(int from, int to)
        {
            return this.WithHealthyHttpResponseStatusCodeRange(from, to);
        }

        /// <summary>
        /// Specifies the ranges of the backend's HTTP response status codes that are to be considered healthy.
        /// </summary>
        /// <param name="ranges">Number ranges expressed in the format "###-###", for example "200-399", which is the default.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayProbe.Update.IUpdate ApplicationGatewayProbe.Update.IWithHealthyHttpResponseStatusCodeRangesBeta.WithHealthyHttpResponseStatusCodeRanges(ISet<string> ranges)
        {
            return this.WithHealthyHttpResponseStatusCodeRanges(ranges);
        }

        /// <summary>
        /// Specifies the time interval in seconds between consecutive probes.
        /// </summary>
        /// <param name="seconds">A number of seconds between 1 and 86400.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayProbe.UpdateDefinition.IWithInterval<ApplicationGateway.Update.IUpdate>.WithTimeBetweenProbesInSeconds(int seconds)
        {
            return this.WithTimeBetweenProbesInSeconds(seconds);
        }

        /// <summary>
        /// Specifies the time interval in seconds between consecutive probes.
        /// </summary>
        /// <param name="seconds">A number of seconds between 1 and 86400.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayProbe.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayProbe.Definition.IWithInterval<ApplicationGateway.Definition.IWithCreate>.WithTimeBetweenProbesInSeconds(int seconds)
        {
            return this.WithTimeBetweenProbesInSeconds(seconds);
        }

        /// <summary>
        /// Gets the protocol.
        /// </summary>
        Models.ApplicationGatewayProtocol Microsoft.Azure.Management.Network.Fluent.IHasProtocol<Models.ApplicationGatewayProtocol>.Protocol
        {
            get
            {
                return this.Protocol();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.IInUpdateAlt<ApplicationGateway.Update.IUpdate>.Attach()
        {
            return this.Attach();
        }
    }
}