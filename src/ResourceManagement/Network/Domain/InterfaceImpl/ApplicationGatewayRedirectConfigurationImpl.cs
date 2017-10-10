// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Definition;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.Update;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayRedirectConfiguration.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System.Collections.Generic;

    internal partial class ApplicationGatewayRedirectConfigurationImpl 
    {
        /// <summary>
        /// Specifies the redirection type.
        /// </summary>
        /// <param name="redirectType">A redirection type.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRedirectConfiguration.Definition.IWithTarget<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayRedirectConfiguration.Definition.IWithType<ApplicationGateway.Definition.IWithCreate>.WithType(ApplicationGatewayRedirectType redirectType)
        {
            return this.WithType(redirectType) as ApplicationGatewayRedirectConfiguration.Definition.IWithTarget<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the redirection type.
        /// </summary>
        /// <param name="redirectType">A redirection type.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRedirectConfiguration.UpdateDefinition.IWithTarget<ApplicationGateway.Update.IUpdate> ApplicationGatewayRedirectConfiguration.UpdateDefinition.IWithType<ApplicationGateway.Update.IUpdate>.WithType(ApplicationGatewayRedirectType redirectType)
        {
            return this.WithType(redirectType) as ApplicationGatewayRedirectConfiguration.UpdateDefinition.IWithTarget<ApplicationGateway.Update.IUpdate>;
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
        /// Specifies that the query string should be included in the redirected URL.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRedirectConfiguration.Update.IUpdate ApplicationGatewayRedirectConfiguration.Update.IWithQueryStringIncluded.WithQueryStringIncluded()
        {
            return this.WithQueryStringIncluded() as ApplicationGatewayRedirectConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that the query string should not be included in the redirected URL.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRedirectConfiguration.Update.IUpdate ApplicationGatewayRedirectConfiguration.Update.IWithQueryStringIncluded.WithoutQueryStringIncluded()
        {
            return this.WithoutQueryStringIncluded() as ApplicationGatewayRedirectConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Removes the reference to the target URL.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRedirectConfiguration.Update.IUpdate ApplicationGatewayRedirectConfiguration.Update.IWithTarget.WithoutTargetUrl()
        {
            return this.WithoutTargetUrl() as ApplicationGatewayRedirectConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Removes the reference to the target listener.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRedirectConfiguration.Update.IUpdate ApplicationGatewayRedirectConfiguration.Update.IWithTarget.WithoutTargetListener()
        {
            return this.WithoutTargetListener() as ApplicationGatewayRedirectConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the URL to redirect to.
        /// </summary>
        /// <param name="url">A URL.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRedirectConfiguration.Update.IUpdate ApplicationGatewayRedirectConfiguration.Update.IWithTarget.WithTargetUrl(string url)
        {
            return this.WithTargetUrl(url) as ApplicationGatewayRedirectConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the listener on this application gateway to redirect to.
        /// </summary>
        /// <param name="name">The name of a listener on this application gateway.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRedirectConfiguration.Update.IUpdate ApplicationGatewayRedirectConfiguration.Update.IWithTarget.WithTargetListener(string name)
        {
            return this.WithTargetListener(name) as ApplicationGatewayRedirectConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies the URL to redirect to.
        /// </summary>
        /// <param name="url">A URL.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRedirectConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayRedirectConfiguration.Definition.IWithTarget<ApplicationGateway.Definition.IWithCreate>.WithTargetUrl(string url)
        {
            return this.WithTargetUrl(url) as ApplicationGatewayRedirectConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the listener on this application gateway to redirect to.
        /// </summary>
        /// <param name="name">The name of a listener on this application gateway.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRedirectConfiguration.Definition.IWithAttachAndPath<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayRedirectConfiguration.Definition.IWithTarget<ApplicationGateway.Definition.IWithCreate>.WithTargetListener(string name)
        {
            return this.WithTargetListener(name) as ApplicationGatewayRedirectConfiguration.Definition.IWithAttachAndPath<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies the URL to redirect to.
        /// </summary>
        /// <param name="url">A URL.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRedirectConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayRedirectConfiguration.UpdateDefinition.IWithTarget<ApplicationGateway.Update.IUpdate>.WithTargetUrl(string url)
        {
            return this.WithTargetUrl(url) as ApplicationGatewayRedirectConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies the listener on this application gateway to redirect to.
        /// </summary>
        /// <param name="name">The name of a listener on this application gateway.</param>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRedirectConfiguration.UpdateDefinition.IWithAttachAndPath<ApplicationGateway.Update.IUpdate> ApplicationGatewayRedirectConfiguration.UpdateDefinition.IWithTarget<ApplicationGateway.Update.IUpdate>.WithTargetListener(string name)
        {
            return this.WithTargetListener(name) as ApplicationGatewayRedirectConfiguration.UpdateDefinition.IWithAttachAndPath<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies that the path should not be included in the redirected URL.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRedirectConfiguration.Update.IUpdate ApplicationGatewayRedirectConfiguration.Update.IWithPathIncluded.WithoutPathIncluded()
        {
            return this.WithoutPathIncluded() as ApplicationGatewayRedirectConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Specifies that the path should be included in the redirected URL.
        /// Note that this setting is valid only when the target of the redirection is a listener, not a URL.
        /// </summary>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRedirectConfiguration.Update.IUpdate ApplicationGatewayRedirectConfiguration.Update.IWithPathIncluded.WithPathIncluded()
        {
            return this.WithPathIncluded() as ApplicationGatewayRedirectConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ApplicationGateway.Update.IUpdate>.Attach()
        {
            return this.Attach() as ApplicationGateway.Update.IUpdate;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        ApplicationGateway.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ApplicationGateway.Definition.IWithCreate>.Attach()
        {
            return this.Attach() as ApplicationGateway.Definition.IWithCreate;
        }

        /// <summary>
        /// Specifies the redirection type.
        /// </summary>
        /// <param name="redirectType">A redirection type.</param>
        /// <return>The next stage of the update.</return>
        ApplicationGatewayRedirectConfiguration.Update.IUpdate ApplicationGatewayRedirectConfiguration.Update.IWithType.WithType(ApplicationGatewayRedirectType redirectType)
        {
            return this.WithType(redirectType) as ApplicationGatewayRedirectConfiguration.Update.IUpdate;
        }

        /// <summary>
        /// Gets true if the query string is included in the redirected URL, otherwise false.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRedirectConfiguration.IsQueryStringIncluded
        {
            get
            {
                return this.IsQueryStringIncluded();
            }
        }

        /// <summary>
        /// Gets the target URL network traffic is redirected to.
        /// </summary>
        string Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRedirectConfiguration.TargetUrl
        {
            get
            {
                return this.TargetUrl();
            }
        }

        /// <summary>
        /// Gets the type of redirection.
        /// </summary>
        Models.ApplicationGatewayRedirectType Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRedirectConfiguration.Type
        {
            get
            {
                return this.Type() as Models.ApplicationGatewayRedirectType;
            }
        }

        /// <summary>
        /// Gets the target listener on this application network traffic is redirected to.
        /// </summary>
        Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRedirectConfiguration.TargetListener
        {
            get
            {
                return this.TargetListener() as Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayListener;
            }
        }

        /// <summary>
        /// Gets true if the path is included in the redirected URL, otherwise false.
        /// </summary>
        bool Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRedirectConfiguration.IsPathIncluded
        {
            get
            {
                return this.IsPathIncluded();
            }
        }

        /// <summary>
        /// Gets request routing rules on this application referencing this redirect configuration, indexed by name.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule> Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRedirectConfiguration.RequestRoutingRules
        {
            get
            {
                return this.RequestRoutingRules() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Network.Fluent.IApplicationGatewayRequestRoutingRule>;
            }
        }

        /// <summary>
        /// Specifies that the path should be included in the redirected URL.
        /// Note that this setting is valid only when the target of the redirection is a listener, not a URL.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRedirectConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayRedirectConfiguration.Definition.IWithPathIncluded<ApplicationGateway.Definition.IWithCreate>.WithPathIncluded()
        {
            return this.WithPathIncluded() as ApplicationGatewayRedirectConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies that the path should be included in the redirected URL.
        /// Note that this setting is valid only when the target of the redirection is a listener, not a URL.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRedirectConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayRedirectConfiguration.UpdateDefinition.IWithPathIncluded<ApplicationGateway.Update.IUpdate>.WithPathIncluded()
        {
            return this.WithPathIncluded() as ApplicationGatewayRedirectConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }

        /// <summary>
        /// Specifies that the query string should be included in the redirected URL.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRedirectConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate> ApplicationGatewayRedirectConfiguration.Definition.IWithQueryStringIncluded<ApplicationGateway.Definition.IWithCreate>.WithQueryStringIncluded()
        {
            return this.WithQueryStringIncluded() as ApplicationGatewayRedirectConfiguration.Definition.IWithAttach<ApplicationGateway.Definition.IWithCreate>;
        }

        /// <summary>
        /// Specifies that the query string should be included in the redirected URL.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ApplicationGatewayRedirectConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate> ApplicationGatewayRedirectConfiguration.UpdateDefinition.IWithQueryStringIncluded<ApplicationGateway.Update.IUpdate>.WithQueryStringIncluded()
        {
            return this.WithQueryStringIncluded() as ApplicationGatewayRedirectConfiguration.UpdateDefinition.IWithAttach<ApplicationGateway.Update.IUpdate>;
        }
    }
}