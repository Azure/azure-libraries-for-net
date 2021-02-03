// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Redis.Fluent
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
    using System.Net;
    using System.Net.Http;

    /// <summary>
    /// REST API for Azure Redis Cache Service.
    /// </summary>
    public partial class RedisManagementClient : FluentServiceClientBase<RedisManagementClient>, IRedisManagementClient, IAzureClient
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
        /// Gets subscription credentials which uniquely identify the Microsoft Azure
        /// subscription. The subscription ID forms part of the URI for every service
        /// call.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Client Api Version.
        /// </summary>
        public string ApiVersion { get; private set; }

        /// <summary>
        /// Gets or sets the preferred language for the response.
        /// </summary>
        public string AcceptLanguage { get; set; }

        /// <summary>
        /// Gets or sets the retry timeout in seconds for Long Running Operations.
        /// Default value is 30.
        /// </summary>
        public int? LongRunningOperationRetryTimeout { get; set; }

        /// <summary>
        /// When set to true a unique x-ms-client-request-id value is generated and
        /// included in each request. Default is true.
        /// </summary>
        public bool? GenerateClientRequestId { get; set; }

        /// <summary>
        /// Gets the IOperations.
        /// </summary>
        public virtual IOperations Operations { get; private set; }

        /// <summary>
        /// Gets the IRedisOperations.
        /// </summary>
        public virtual IRedisOperations Redis { get; private set; }

        /// <summary>
        /// Gets the IFirewallRulesOperations.
        /// </summary>
        public virtual IFirewallRulesOperations FirewallRules { get; private set; }

        /// <summary>
        /// Gets the IPatchSchedulesOperations.
        /// </summary>
        public virtual IPatchSchedulesOperations PatchSchedules { get; private set; }

        /// <summary>
        /// Gets the ILinkedServerOperations.
        /// </summary>
        public virtual ILinkedServerOperations LinkedServer { get; private set; }

        /// <summary>
        /// Initializes a new instance of the RedisManagementClient class.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when a required parameter is null
        /// </exception>
        public RedisManagementClient(RestClient restClient) 
            : base(restClient)
        {
        }

        private RedisManagementClient(RestClient restClient, System.Net.Http.HttpClient httpClient) : base(restClient, httpClient)
        {
        }

        public static RedisManagementClient NewInstance(RestClient restClient)
        {
            return restClient.HttpClient == null ? new RedisManagementClient(restClient) : new RedisManagementClient(restClient, restClient.HttpClient);
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
            Redis = new RedisOperations(this);
            FirewallRules = new FirewallRulesOperations(this);
            PatchSchedules = new PatchSchedulesOperations(this);
            LinkedServer = new LinkedServerOperations(this);
            BaseUri = new System.Uri("https://management.azure.com");
            ApiVersion = "2018-03-01";
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
