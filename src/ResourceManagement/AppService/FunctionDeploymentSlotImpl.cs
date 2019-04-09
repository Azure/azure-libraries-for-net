// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using FunctionDeploymentSlot.Definition;
    using FunctionDeploymentSlot.Update;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
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
    /// The implementation for FunctionDeploymentSlot.
    /// </summary>
    internal partial class FunctionDeploymentSlotImpl :
        DeploymentSlotBaseImpl<
            IFunctionDeploymentSlot,
            FunctionDeploymentSlotImpl,
            object,
            object,
            FunctionDeploymentSlot.Update.IUpdate,
            IFunctionApp,
            FunctionAppImpl,
            FunctionApp.Definition.IWithCreate,
            FunctionApp.Definition.INewAppServicePlanWithGroup,
            FunctionApp.Definition.IWithCreate,
            FunctionApp.Update.IUpdate>,
        IFunctionDeploymentSlot,
        FunctionDeploymentSlot.Definition.IDefinition,
        FunctionDeploymentSlot.Update.IUpdate
    {
        public FunctionDeploymentSlotImpl(string name, SiteInner innerObject, SiteConfigResourceInner configObject,
            SiteLogsConfigInner logConfig, FunctionAppImpl parent, IAppServiceManager manager)
            : base(name, innerObject, configObject, logConfig, parent, manager)
        {
        }

        IFunctionApp IHasParent<IFunctionApp>.Parent => base.Parent();

        IWithCreate WithConfigurationFromParent()
        {
            return WithConfigurationFromFunctionApp(base.Parent());
        }

        IWithCreate WithConfigurationFromFunctionApp(IFunctionApp app)
        {
            this.SiteConfig = ((WebAppBaseImpl<IFunctionApp, FunctionAppImpl, FunctionApp.Definition.INewAppServicePlanWithGroup, FunctionApp.Definition.IWithCreate, FunctionApp.Update.IUpdate>)app).SiteConfig;
            base.configurationSource = app;
            return this;
        }
    }
}
