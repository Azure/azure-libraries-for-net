// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition
{
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// The stage of an application gateway probe definition allowing to specify healthy HTTP response status code ranges.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithHealthyHttpResponseStatusCodeRanges<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithHealthyHttpResponseStatusCodeRangesBeta<ReturnT>
    {
    }

    /// <summary>
    /// The first stage of an application gateway probe definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithHost<ParentT>
    {
    }

    /// <summary>
    /// Stage of an application gateway probe definition allowing to specify the path to send the probe to.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithPath<ParentT>
    {
        /// <summary>
        /// Specifies the relative path for the probe to call.
        /// A probe is sent to &lt;protocol&gt;://&lt;host&gt;:&lt;port&gt;&lt;path&gt;.
        /// </summary>
        /// <param name="path">A relative path.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithProtocol<ParentT> WithPath(string path);
    }

    /// <summary>
    /// Stage of an application gateway probe definition allowing to specify the protocol of the probe.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithProtocol<ParentT> :
        Microsoft.Azure.Management.Network.Fluent.HasProtocol.UpdateDefinition.IWithProtocol<Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithTimeout<ParentT>, Microsoft.Azure.Management.Network.Fluent.Models.ApplicationGatewayProtocol>
    {
        /// <summary>
        /// Specifies HTTP as the probe protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithTimeout<ParentT> WithHttp();

        /// <summary>
        /// Specifies HTTPS as the probe protocol.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithTimeout<ParentT> WithHttps();
    }

    /// <summary>
    /// The stage of an application gateway probe definition allowing to specify the body contents of a healthy HTTP response to a probe.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithHealthyHttpResponseBodyContents<ReturnT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithHealthyHttpResponseBodyContentsBeta<ReturnT>
    {
    }

    /// <summary>
    /// The entirety of an application gateway probe definition as part of an application gateway update.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IUpdateDefinition<ParentT> :
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IBlank<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithProtocol<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithPath<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithHost<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithTimeout<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithInterval<ParentT>
    {
    }

    /// <summary>
    /// The final stage of an application gateway probe definition.
    /// At this stage, any remaining optional settings can be specified, or the probe definition
    /// can be attached to the parent application gateway definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway definition to return to after attaching this definition.</typeparam>
    public interface IWithAttach<ParentT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions.IInUpdateAlt<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithInterval<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithRetries<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithHealthyHttpResponseStatusCodeRanges<ParentT>,
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithHealthyHttpResponseBodyContents<ParentT>
    {
    }

    /// <summary>
    /// Stage of an application gateway probe definition allowing to specify the number of retries before the server is considered unhealthy.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithRetries<ParentT>
    {
        /// <summary>
        /// Specifies the number of retries before the server is considered unhealthy.
        /// </summary>
        /// <param name="retryCount">A number between 1 and 20.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithAttach<ParentT> WithRetriesBeforeUnhealthy(int retryCount);
    }

    /// <summary>
    /// Stage of an application gateway probe definition allowing to specify the time interval between consecutive probes.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithInterval<ParentT>
    {
        /// <summary>
        /// Specifies the time interval in seconds between consecutive probes.
        /// </summary>
        /// <param name="seconds">A number of seconds between 1 and 86400.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithAttach<ParentT> WithTimeBetweenProbesInSeconds(int seconds);
    }

    /// <summary>
    /// Stage of an application gateway probe definition allowing to specify the host to send the probe to.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithHost<ParentT>
    {
        /// <summary>
        /// Specifies the host name to send the probe to.
        /// </summary>
        /// <param name="host">A host name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithPath<ParentT> WithHost(string host);
    }

    /// <summary>
    /// Stage of an application gateway probe definition allowing to specify the amount of time to after which the probe is considered failed.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithTimeout<ParentT>
    {
        /// <summary>
        /// Specifies the amount of time in seconds waiting for a response before the probe is considered failed.
        /// </summary>
        /// <param name="seconds">A number of seconds between 1 and 86400.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithAttach<ParentT> WithTimeoutInSeconds(int seconds);
    }

    /// <summary>
    /// The stage of an application gateway probe definition allowing to specify healthy HTTP response status code ranges.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithHealthyHttpResponseStatusCodeRangesBeta<ReturnT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Adds the specified range of the backend's HTTP response status codes that are to be considered healthy.
        /// </summary>
        /// <param name="range">A number range expressed in the format "###-###", for example "200-399", which is the default.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithAttach<ReturnT> WithHealthyHttpResponseStatusCodeRange(string range);

        /// <summary>
        /// Adds the specified range of the backend's HTTP response status codes that are to be considered healthy.
        /// </summary>
        /// <param name="from">The lowest number in the range.</param>
        /// <param name="to">The highest number in the range.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithAttach<ReturnT> WithHealthyHttpResponseStatusCodeRange(int from, int to);

        /// <summary>
        /// Specifies the ranges of the backend's HTTP response status codes that are to be considered healthy.
        /// </summary>
        /// <param name="ranges">Number ranges expressed in the format "###-###", for example "200-399", which is the default.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithAttach<ReturnT> WithHealthyHttpResponseStatusCodeRanges(ISet<string> ranges);
    }

    /// <summary>
    /// The stage of an application gateway probe definition allowing to specify the body contents of a healthy HTTP response to a probe.
    /// </summary>
    /// <typeparam name="ReturnT">The stage of the parent application gateway update to return to after attaching this definition.</typeparam>
    public interface IWithHealthyHttpResponseBodyContentsBeta<ReturnT> :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies the content, if any, to look for in the body of an HTTP response to a probe to determine the health status of the backend.
        /// </summary>
        /// <param name="text">Contents to look for.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayProbe.UpdateDefinition.IWithAttach<ReturnT> WithHealthyHttpResponseBodyContents(string text);
    }
}