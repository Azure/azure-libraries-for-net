// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Stage of an application gateway probe update allowing to specify the path to send the probe to.
    /// </summary>
    public interface IWithPath
    {
        /// <summary>
        /// Specifies the relative path for the probe to call.
        /// A probe is sent to &lt;protocol&gt;://&lt;host&gt;:&lt;port&gt;&lt;path&gt;.
        /// </summary>
        /// <param name="path">A relative path.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IUpdate WithPath(string path);
    }

    /// <summary>
    /// Stage of an application gateway probe update allowing to specify the protocol of the probe.
    /// </summary>
    public interface IWithProtocol :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.Update.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IUpdate, Microsoft.Azure.Management.Network.Fluent.Models.ApplicationGatewayProtocol>
    {
        /// <summary>
        /// Specifies HTTP as the probe protocol.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IUpdate WithHttp();

        /// <summary>
        /// Specifies HTTPS as the probe protocol.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IUpdate WithHttps();
    }

    /// <summary>
    /// Stage of an application gateway probe update allowing to specify the number of retries before the server is considered unhealthy.
    /// </summary>
    public interface IWithRetries
    {
        /// <summary>
        /// Specifies the number of retries before the server is considered unhealthy.
        /// </summary>
        /// <param name="retryCount">A number between 1 and 20.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IUpdate WithRetriesBeforeUnhealthy(int retryCount);
    }

    /// <summary>
    /// Stage of an application gateway probe update allowing to specify the host to send the probe to.
    /// </summary>
    public interface IWithHost
    {
        /// <summary>
        /// Specifies the host name to send the probe to.
        /// </summary>
        /// <param name="host">A host name.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IUpdate WithHost(string host);
    }

    /// <summary>
    /// The stage of an application gateway probe update allowing to specify the body contents of a healthy HTTP response to a probe.
    /// </summary>
    public interface IWithHealthyHttpResponseBodyContents :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IWithHealthyHttpResponseBodyContentsBeta
    {
    }

    /// <summary>
    /// Stage of an application gateway probe update allowing to specify the time interval between consecutive probes.
    /// </summary>
    public interface IWithInterval
    {
        /// <summary>
        /// Specifies the time interval in seconds between consecutive probes.
        /// </summary>
        /// <param name="seconds">A number of seconds between 1 and 86400.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IUpdate WithTimeBetweenProbesInSeconds(int seconds);
    }

    /// <summary>
    /// Stage of an application gateway probe update allowing to specify the amount of time to after which the probe is considered failed.
    /// </summary>
    public interface IWithTimeout
    {
        /// <summary>
        /// Specifies the amount of time in seconds waiting for a response before the probe is considered failed.
        /// </summary>
        /// <param name="seconds">A number of seconds between 1 and 86400.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IUpdate WithTimeoutInSeconds(int seconds);
    }

    /// <summary>
    /// The stage of an application gateway probe update allowing to specify healthy HTTP response status code ranges.
    /// </summary>
    public interface IWithHealthyHttpResponseStatusCodeRanges :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IWithHealthyHttpResponseStatusCodeRangesBeta
    {
    }

    /// <summary>
    /// The entirety of an application gateway probe update as part of an application gateway update.
    /// </summary>
    public interface IUpdate :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.ISettable<Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update.IUpdate>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IWithProtocol,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IWithPath,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IWithHost,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IWithTimeout,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IWithInterval,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IWithRetries,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IWithHealthyHttpResponseStatusCodeRanges,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IWithHealthyHttpResponseBodyContents
    {
    }

    /// <summary>
    /// The stage of an application gateway probe update allowing to specify the body contents of a healthy HTTP response to a probe.
    /// </summary>
    public interface IWithHealthyHttpResponseBodyContentsBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the content, if any, to look for in the body of an HTTP response to a probe to determine the health status of the backend.
        /// </summary>
        /// <param name="text">Contents to look for.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IUpdate WithHealthyHttpResponseBodyContents(string text);
    }

    /// <summary>
    /// The stage of an application gateway probe update allowing to specify healthy HTTP response status code ranges.
    /// </summary>
    public interface IWithHealthyHttpResponseStatusCodeRangesBeta :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Adds the specified range of the backend's HTTP response status codes that are to be considered healthy.
        /// </summary>
        /// <param name="range">A number range expressed in the format "###-###", for example "200-399", which is the default.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IUpdate WithHealthyHttpResponseStatusCodeRange(string range);

        /// <summary>
        /// Adds the specified range of the backend's HTTP response status codes that are to be considered healthy.
        /// </summary>
        /// <param name="from">The lowest number in the range.</param>
        /// <param name="to">The highest number in the range.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IUpdate WithHealthyHttpResponseStatusCodeRange(int from, int to);

        /// <summary>
        /// Specifies the ranges of the backend's HTTP response status codes that are to be considered healthy.
        /// </summary>
        /// <param name="ranges">Number ranges expressed in the format "###-###", for example "200-399", which is the default.</param>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IUpdate WithHealthyHttpResponseStatusCodeRanges(ISet<string> ranges);

        /// <summary>
        /// Removes all healthy HTTP status response code ranges.
        /// </summary>
        /// <return>The next stage of the update.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.Update.IUpdate WithoutHealthyHttpResponseStatusCodeRanges();
    }
}