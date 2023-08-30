// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.ResourceManager.Fluent.Deployment.Definition;
using Microsoft.Azure.Management.ResourceManager.Fluent.Deployment.Update;
using Microsoft.Azure.Management.ResourceManager.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    internal class DeploymentImpl :
        CreatableUpdatable<IDeployment, DeploymentExtendedInner, DeploymentImpl, IDeployment, Deployment.Update.IUpdate>,
        IDeployment,
        Deployment.Definition.IDefinition,
        Deployment.Update.IUpdate
    {
        private IResourceManager resourceManager;
        private string resourceGroupName;
        private ICreatable<IResourceGroup> creatableResourceGroup;
        private DeploymentInner createUpdateParamter = new DeploymentInner();

        internal DeploymentImpl(DeploymentExtendedInner innerModel, IResourceManager resourceManager) : base(innerModel.Name, innerModel)
        {
            resourceGroupName = ResourceUtils.GroupFromResourceId(innerModel.Id);
            this.resourceManager = resourceManager;
        }

        #region Getters

        public string ResourceGroupName
        {
            get
            {
                return resourceGroupName;
            }
        }

        public override string Name
        {
            get
            {
                return Inner.Name;
            }
        }

        public ProvisioningState ProvisioningState
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.ProvisioningState;
            }
        }

        public string CorrelationId
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.CorrelationId;
            }
        }

        public DateTime? Timestamp
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.Timestamp;
            }
        }

        public object Outputs
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.Outputs;
            }
        }

        public IList<IProvider> Providers
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return (from providerInner in Inner.Properties.Providers
                        select new ProviderImpl(providerInner)).ToList<IProvider>();
            }
        }

        public IList<Dependency> Dependencies
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.Dependencies;
            }
        }

        public TemplateLink TemplateLink
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.TemplateLink;
            }
        }

        public object Parameters
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.Parameters;
            }
        }

        public ParametersLink ParametersLink
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.ParametersLink;
            }
        }

        public DeploymentMode? Mode
        {
            get
            {
                if (Inner.Properties == null)
                {
                    return null;
                }
                return Inner.Properties.Mode;
            }
        }

        public IDeploymentOperationsFluent DeploymentOperations
        {
            get
            {
                return new DeploymentOperationsImpl(Manager.Inner.DeploymentOperations, this);
            }
        }

        public IResourceManager Manager
        {
            get
            {
                return resourceManager;
            }
        }


        #endregion

        #region Setters

        #region Definition Setters

        public Deployment.Definition.IWithTemplate WithNewResourceGroup(string resourceGroupName, Region region)
        {
            creatableResourceGroup = resourceManager.ResourceGroups
                .Define(resourceGroupName)
                .WithRegion(region);
            this.resourceGroupName = resourceGroupName;
            return this;
        }

        public Deployment.Definition.IWithTemplate WithNewResourceGroup(ICreatable<IResourceGroup> groupDefinition)
        {
            creatableResourceGroup = groupDefinition;
            resourceGroupName = creatableResourceGroup.Name;
            return this;
        }

        public Deployment.Definition.IWithTemplate WithExistingResourceGroup(string resourceGroupName)
        {
            this.resourceGroupName = resourceGroupName;
            return this;
        }

        public Deployment.Definition.IWithTemplate WithExistingResourceGroup(IResourceGroup group)
        {
            resourceGroupName = group.Name;
            return this;
        }

        public Deployment.Definition.IWithParameters WithTemplate(object template)
        {
            if (createUpdateParamter.Properties == null)
            {
                createUpdateParamter.Properties = new DeploymentProperties();
            }

            createUpdateParamter.Properties.Template = template;
            createUpdateParamter.Properties.TemplateLink = null;
            return this;
        }

        public Deployment.Definition.IWithParameters WithTemplate(string templateJson)
        {
            return WithTemplate(JsonConvert.DeserializeObject(templateJson));
        }

        public Deployment.Definition.IWithParameters WithTemplateLink(string uri, string contentVersion)
        {
            if (createUpdateParamter.Properties == null)
            {
                createUpdateParamter.Properties = new DeploymentProperties();
            }
            createUpdateParamter.Properties.TemplateLink = new TemplateLink();
            createUpdateParamter.Properties.TemplateLink.Uri = uri;
            createUpdateParamter.Properties.TemplateLink.ContentVersion = contentVersion;
            createUpdateParamter.Properties.Template = null;
            return this;
        }

        public Deployment.Definition.IWithMode WithParameters(object parameters)
        {
            if (createUpdateParamter.Properties == null)
            {
                createUpdateParamter.Properties = new DeploymentProperties();
            }
            createUpdateParamter.Properties.Parameters = parameters;
            createUpdateParamter.Properties.ParametersLink = null;
            return this;
        }

        public Deployment.Definition.IWithMode WithParameters(string parametersJson)
        {
            return WithParameters(JsonConvert.DeserializeObject(parametersJson));
        }

        public Deployment.Definition.IWithMode WithParametersLink(string uri, string contentVersion)
        {
            if (createUpdateParamter.Properties == null)
            {
                createUpdateParamter.Properties = new DeploymentProperties();
            }
            createUpdateParamter.Properties.ParametersLink = new ParametersLink(uri, contentVersion);
            createUpdateParamter.Properties.Parameters = null;
            return this;
        }

        public IWithCreate WithMode(DeploymentMode mode)
        {
            if (createUpdateParamter.Properties == null)
            {
                createUpdateParamter.Properties = new DeploymentProperties();
            }
            createUpdateParamter.Properties.Mode = mode;
            return this;
        }

        #endregion

        #region Update Setters

        IUpdate Deployment.Update.IWithTemplate.WithTemplate(object template)
        {
            if (createUpdateParamter.Properties == null)
            {
                createUpdateParamter.Properties = new DeploymentProperties();
            }

            createUpdateParamter.Properties.Template = template;
            createUpdateParamter.Properties.TemplateLink = null;
            return this;
        }

        IUpdate Deployment.Update.IWithTemplate.WithTemplate(string templateJson)
        {
            var that = (IUpdate)this;
            return that.WithTemplate(JsonConvert.DeserializeObject(templateJson));
        }

        IUpdate Deployment.Update.IWithTemplate.WithTemplateLink(string uri, string contentVersion)
        {
            if (createUpdateParamter.Properties == null)
            {
                createUpdateParamter.Properties = new DeploymentProperties();
            }
            createUpdateParamter.Properties.TemplateLink = new TemplateLink();
            createUpdateParamter.Properties.TemplateLink.Uri = uri;
            createUpdateParamter.Properties.TemplateLink.ContentVersion = contentVersion;
            createUpdateParamter.Properties.Template = null;
            return this;
        }

        IUpdate Deployment.Update.IWithParameters.WithParameters(object parameters)
        {
            if (createUpdateParamter.Properties == null)
            {
                createUpdateParamter.Properties = new DeploymentProperties();
            }
            createUpdateParamter.Properties.Parameters = parameters;
            createUpdateParamter.Properties.ParametersLink = null;
            return this;
        }

        IUpdate Deployment.Update.IWithParameters.WithParameters(string parametersJson)
        {
            var that = (IUpdate)this;
            return that.WithParameters(JsonConvert.DeserializeObject(parametersJson));
        }

        IUpdate Deployment.Update.IWithParameters.WithParametersLink(string uri, string contentVersion)
        {
            if (createUpdateParamter.Properties == null)
            {
                createUpdateParamter.Properties = new DeploymentProperties();
            }
            createUpdateParamter.Properties.ParametersLink = new ParametersLink(uri, contentVersion);
            createUpdateParamter.Properties.Parameters = null;
            return this;
        }

        IUpdate Deployment.Update.IWithMode.WithMode(DeploymentMode mode)
        {
            if (createUpdateParamter.Properties == null)
            {
                createUpdateParamter.Properties = new DeploymentProperties();
            }
            createUpdateParamter.Properties.Mode = mode;
            return this;
        }

        #endregion

        #endregion

        public override IUpdate Update()
        {
            object template = createUpdateParamter.Properties == null ? null : createUpdateParamter.Properties.Template;

            createUpdateParamter = new DeploymentInner();

            createUpdateParamter.Location = Inner.Location;
            createUpdateParamter.Tags = Inner.Tags;
            if (Inner.Properties != null)
            {
                createUpdateParamter.Properties = new DeploymentProperties();
                createUpdateParamter.Properties.DebugSetting = Inner.Properties.DebugSetting;
                createUpdateParamter.Properties.Mode = Inner.Properties.Mode ?? DeploymentMode.Incremental;
                createUpdateParamter.Properties.Parameters = Inner.Properties.Parameters;
                createUpdateParamter.Properties.ParametersLink = Inner.Properties.ParametersLink;
                createUpdateParamter.Properties.Template = template;
                createUpdateParamter.Properties.TemplateLink = Inner.Properties.TemplateLink;
                if (Inner.Properties.OnErrorDeployment != null)
                {
                    createUpdateParamter.Properties.OnErrorDeployment = new OnErrorDeployment();
                    createUpdateParamter.Properties.OnErrorDeployment.DeploymentName = Inner.Properties.OnErrorDeployment.DeploymentName;
                    createUpdateParamter.Properties.OnErrorDeployment.Type = Inner.Properties.OnErrorDeployment.Type;
                }
            }
            return base.Update();
        }


        public void Cancel()
        {
            Extensions.Synchronize(() => this.CancelAsync());
        }

        public async Task CancelAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Deployments.CancelAsync(resourceGroupName, Name, cancellationToken);
        }

        public IDeploymentExportResult ExportTemplate()
        {
            return Extensions.Synchronize(() => ExportTemplateAsync());
        }

        public async Task<IDeploymentExportResult> ExportTemplateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            DeploymentExportResultInner inner = await Manager.Inner.Deployments.ExportTemplateAsync(ResourceGroupName, Name, cancellationToken);
            return new DeploymentExportResultImpl(inner);
        }

        public IDeployment BeginCreate()
        {
            return Extensions.Synchronize(() => this.BeginCreateAsync());
        }

        public async Task<IDeployment> BeginCreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (creatableResourceGroup != null)
            {
                await creatableResourceGroup.CreateAsync(cancellationToken);
            }
            SetInner(await Manager.Inner.Deployments.BeginCreateOrUpdateAsync(resourceGroupName, Name, createUpdateParamter, cancellationToken));
            return this;
        }

        #region Implementation of ICreatable interface 

        public async override Task<IDeployment> CreateAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            if (creatableResourceGroup != null)
            {
                await creatableResourceGroup.CreateAsync(cancellationToken);
            }
            return await CreateResourceAsync(cancellationToken);
        }

        #endregion

        #region Implementation of IResourceCreator interface

        public async override Task<IDeployment> CreateResourceAsync(CancellationToken cancellationToken)
        {
            SetInner(await Manager.Inner.Deployments.CreateOrUpdateAsync(ResourceGroupName, Name, createUpdateParamter, cancellationToken));
            return this;
        }

        protected override async Task<DeploymentExtendedInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.Deployments.GetAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        #endregion

    }
}
