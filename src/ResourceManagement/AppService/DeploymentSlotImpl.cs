// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using DeploymentSlot.Definition;
    using DeploymentSlot.Update;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Rest.Azure;
    using Models;
    using ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for DeploymentSlot.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uRGVwbG95bWVudFNsb3RJbXBs
    internal partial class DeploymentSlotImpl :
        DeploymentSlotBaseImpl<
            IDeploymentSlot,
            DeploymentSlotImpl,
            object,
            object,
            IUpdate,
            IWebApp,
            WebAppImpl,
            WebApp.Definition.IWithCreate,
            WebApp.Definition.INewAppServicePlanWithGroup,
            WebApp.Definition.IWithNewAppServicePlan,
            WebApp.Update.IUpdate>,
        IDeploymentSlot,
        IDefinition,
        IUpdate
    {
        private KuduClient kuduClient;

        public DeploymentSlotImpl(string name, SiteInner innerObject, SiteConfigResourceInner configObject,
            SiteLogsConfigInner logConfig, WebAppImpl parent, IAppServiceManager manager)
            : base(name, innerObject, configObject, logConfig, parent, manager)
        {
            kuduClient = new KuduClient(this);
        }

        IWebApp IHasParent<IWebApp>.Parent => base.Parent();

        IWithCreate WithConfigurationFromParent()
        {
            return WithConfigurationFromWebApp(Parent());
        }

        IWithCreate WithConfigurationFromWebApp(IWebApp webApp)
        {
            this.SiteConfig = ((WebAppBaseImpl<IWebApp, WebAppImpl, WebApp.Definition.INewAppServicePlanWithGroup, WebApp.Definition.IWithNewAppServicePlan, WebApp.Update.IUpdate>)webApp).SiteConfig;
            base.configurationSource = webApp;
            return this;
        }

        public void WarDeploy(FileInfo warFile)
        {
            Extensions.Synchronize(() => WarDeployAsync(warFile));
        }

        public async Task WarDeployAsync(FileInfo warFile, CancellationToken cancellationToken = default(CancellationToken))
        {
            int limit = 30;
            while (true)
            {
                try
                {
                    await kuduClient.WarDeployAsync(warFile, cancellationToken);
                    break;
                }
                catch (CloudException e)
                {
                    if (--limit < 0)
                    {
                        throw e;
                    }
                    else if (HttpStatusCode.BadGateway == e.Response.StatusCode || HttpStatusCode.Forbidden == e.Response.StatusCode)
                    {
                        await SdkContext.DelayProvider.DelayAsync((30 - limit) * 1000, cancellationToken);
                    }
                    else
                    {
                        throw e;
                    }
                }
            }
        }
    }
}
