// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Serialization;
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provides operations for working with resources and resource groups.
    /// </summary>
    public partial class ResourceManagementClient : Fluent.Core.FluentServiceClientBase<ResourceManagementClient>, IResourceManagementClient, IAzureClient
    {
        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        public JsonSerializerSettings SerializationSettings { get; private set; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        public JsonSerializerSettings DeserializationSettings { get; private set; }

        /// <summary>
        /// The ID of the target subscription.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// The API version to use for this operation.
        /// </summary>
        public string ApiVersion { get; private set; }

        /// <summary>
        /// The preferred language for the response.
        /// </summary>
        public string AcceptLanguage { get; set; }

        /// <summary>
        /// The retry timeout in seconds for Long Running Operations. Default value is
        /// 30.
        /// </summary>
        public int? LongRunningOperationRetryTimeout { get; set; }

        /// <summary>
        /// Whether a unique x-ms-client-request-id should be generated. When set to
        /// true a unique x-ms-client-request-id value is generated and included in
        /// each request. Default is true.
        /// </summary>
        public bool? GenerateClientRequestId { get; set; }

        /// <summary>
        /// Gets the IOperations.
        /// </summary>
        public virtual IOperations Operations { get; private set; }

        /// <summary>
        /// Gets the IDeploymentsOperations.
        /// </summary>
        public virtual IDeploymentsOperations Deployments { get; private set; }

        /// <summary>
        /// Gets the IProvidersOperations.
        /// </summary>
        public virtual IProvidersOperations Providers { get; private set; }

        /// <summary>
        /// Gets the IProviderResourceTypesOperations.
        /// </summary>
        public virtual IProviderResourceTypesOperations ProviderResourceTypes { get; private set; }

        /// <summary>
        /// Gets the IResourcesOperations.
        /// </summary>
        public virtual IResourcesOperations Resources { get; private set; }

        /// <summary>
        /// Gets the IResourceGroupsOperations.
        /// </summary>
        public virtual IResourceGroupsOperations ResourceGroups { get; private set; }

        /// <summary>
        /// Gets the ITagsOperations.
        /// </summary>
        public virtual ITagsOperations Tags { get; private set; }

        /// <summary>
        /// Gets the IDeploymentOperations.
        /// </summary>
        public virtual IDeploymentOperations DeploymentOperations { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ResourceManagementClient class.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public ResourceManagementClient(RestClient restClient) : base(restClient)
        {
        }

        private ResourceManagementClient(RestClient restClient, System.Net.Http.HttpClient httpClient) : base(restClient, httpClient)
        {
        }

        public static ResourceManagementClient NewInstance(RestClient restClient)
        {
            return restClient.HttpClient == null ? new ResourceManagementClient(restClient) : new ResourceManagementClient(restClient, restClient.HttpClient);
        }

    /// <summary>
    /// An optional partial-method to perform custom initialization.
    /// </summary>
    partial void CustomInitialize();
        /// <summary>
        /// Initializes client properties.
        /// </summary>
        protected override void Initialize()
        {
            Operations = new Operations(this);
            Deployments = new DeploymentsOperations(this);
            Providers = new ProvidersOperations(this);
            ProviderResourceTypes = new ProviderResourceTypesOperations(this);
            Resources = new ResourcesOperations(this);
            ResourceGroups = new ResourceGroupsOperations(this);
            Tags = new TagsOperations(this);
            DeploymentOperations = new DeploymentOperations(this);
            this.BaseUri = new System.Uri("https://management.azure.com");
            ApiVersion = "2021-01-01";
            AcceptLanguage = "en-US";
            LongRunningOperationRetryTimeout = 30;
            GenerateClientRequestId = true;
            SerializationSettings = new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            SerializationSettings.Converters.Add(new TransformationJsonConverter());
            DeserializationSettings = new JsonSerializerSettings
            {
                DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver(),
                Converters = new List<JsonConverter>
                    {
                        new Iso8601TimeSpanConverter()
                    }
            };
            CustomInitialize();
            DeserializationSettings.Converters.Add(new TransformationJsonConverter());
            DeserializationSettings.Converters.Add(new CloudErrorJsonConverter());
        }
    }
}
