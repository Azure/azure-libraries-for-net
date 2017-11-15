// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using DeploymentSlot.Definition;
    using DeploymentSlot.Update;
    using Models;
    using ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
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
        public DeploymentSlotImpl(string name, SiteInner innerObject, SiteConfigResourceInner configObject, WebAppImpl parent, IAppServiceManager manager)
            : base(name, innerObject, configObject, parent, manager)
        {
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
    }
}
