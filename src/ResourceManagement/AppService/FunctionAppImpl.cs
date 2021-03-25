// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.FunctionApp.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using System;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent;
    using System.Net.Http;
    using Rest;
    using System.Collections.Generic;
    using System.Net;
    using Rest.Azure;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Collections.ObjectModel;
    using System.IO;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using System.Collections;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The implementation for FunctionApp.
    /// </summary>
    internal partial class FunctionAppImpl  :
        AppServiceBaseImpl<IFunctionApp,FunctionAppImpl,IWithCreate, INewAppServicePlanWithGroup, IWithCreate, IUpdate>,
        IFunctionApp,
        IDefinition,
        INewAppServicePlanWithGroup,
        IUpdate
    {
        private Fluent.IFunctionDeploymentSlots deploymentSlots;
        private ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable;
        private IStorageAccount storageAccountToSet;
        private IStorageAccount currentStorageAccount;
        private FunctionCredentials functionCredentials;

        public Fluent.IFunctionDeploymentSlots DeploymentSlots()
        {
            if (deploymentSlots == null)
            {
               deploymentSlots = new FunctionDeploymentSlotsImpl(this, Manager);
            }
            return deploymentSlots;
        }

        public IStorageAccount StorageAccount()
        {
            return currentStorageAccount;
        }

        public FunctionAppImpl WithoutDailyUsageQuota()
        {
            return WithDailyUsageQuota(0);
        }

        private FunctionAppImpl AutoSetAlwaysOn(PricingTier pricingTier)
        {
            SkuDescription description = pricingTier.SkuDescription;
            if (description.Tier.Equals("Basic", StringComparison.OrdinalIgnoreCase)
                || description.Tier.Equals("Standard", StringComparison.OrdinalIgnoreCase)
                || description.Tier.StartsWith("Premium", StringComparison.OrdinalIgnoreCase))
            {
                return WithWebAppAlwaysOn(true);
            }
            else
            {
                return WithWebAppAlwaysOn(false);
            }
        }

        public FunctionAppImpl WithDailyUsageQuota(int quota)
        {
            Inner.DailyMemoryTimeQuota = quota;
            return this;
        }

        internal  FunctionAppImpl(string name, SiteInner innerObject, SiteConfigResourceInner configObject,
            SiteLogsConfigInner logConfig, IAppServiceManager manager)
            : base(name, innerObject, configObject, logConfig, manager)
        {
            functionCredentials = new FunctionCredentials(this);
        }

        public FunctionAppImpl WithNewStorageAccount(string name, Storage.Fluent.Models.SkuName sku)
        {
            Storage.Fluent.StorageAccount.Definition.IWithGroup storageDefine = Manager.StorageManager.StorageAccounts
                .Define(name)
                .WithRegion(RegionName);
            if (newGroup != null && IsInCreateMode) {
                storageAccountCreatable = storageDefine.WithNewResourceGroup(newGroup)
                    .WithGeneralPurposeAccountKind()
                    .WithSku(sku);
            } else {
                storageAccountCreatable = storageDefine.WithExistingResourceGroup(ResourceGroupName)
                    .WithGeneralPurposeAccountKind()
                    .WithSku(sku);
            }
            AddCreatableDependency(storageAccountCreatable as IResourceCreator<IHasId>);
            return this;
        }

        public FunctionAppImpl WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            this.storageAccountToSet = storageAccount;
            return this;
        }

        internal override FunctionAppImpl WithNewAppServicePlan(OperatingSystem operatingSystem, PricingTier pricingTier)
        {
            return base.WithNewAppServicePlan(operatingSystem, pricingTier).AutoSetAlwaysOn(pricingTier);
        }

        public FunctionAppImpl WithRuntimeVersion(string version)
        {
            return WithAppSetting("FUNCTIONS_EXTENSION_VERSION", version.StartsWith("~") ? version : "~" + version);
        }

        public FunctionAppImpl WithNewConsumptionPlan()
        {
            return WithNewAppServicePlan(Fluent.OperatingSystem.Windows, new PricingTier("Dynamic", "Y1"));
        }

        internal override async Task<Models.SiteInner> SubmitAppSettingsAsync(SiteInner site, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (storageAccountCreatable != null && CreatedResource(storageAccountCreatable.Key) != null)
            {
                storageAccountToSet = (IStorageAccount) CreatedResource(storageAccountCreatable.Key);
            }
            if (storageAccountToSet == null)
            {
                return await base.SubmitAppSettingsAsync(site, cancellationToken);
            }
            else
            {
                AzureEnvironment environment = ResourceUtils.ExtractAzureEnvironment(Manager.RestClient) ?? AzureEnvironment.AzureGlobalCloud;
                string endpointSuffix = Regex.Replace(environment.StorageEndpointSuffix ?? AzureEnvironment.AzureGlobalCloud.StorageEndpointSuffix, "^\\.*", "");
                var servicePlanTask = Manager.AppServicePlans.GetByIdAsync(this.AppServicePlanId());
                var keys = await storageAccountToSet.GetKeysAsync(cancellationToken);
                var connectionString = string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};EndpointSuffix={2}",
                    storageAccountToSet.Name, keys[0].Value, endpointSuffix);
                AddAppSettingIfNotModified("AzureWebJobsStorage", connectionString);
                AddAppSettingIfNotModified("AzureWebJobsDashboard", connectionString);
                if (IsConsumptionAppServicePlan((await servicePlanTask)?.PricingTier))
                {
                    AddAppSettingIfNotModified("WEBSITE_CONTENTAZUREFILECONNECTIONSTRING", connectionString);
                    AddAppSettingIfNotModified("WEBSITE_CONTENTSHARE", SdkContext.RandomResourceName(Name, 32));
                }

                // clean up
                currentStorageAccount = storageAccountToSet;
                storageAccountToSet = null;
                storageAccountCreatable = null;

                return await base.SubmitAppSettingsAsync(site, cancellationToken);
            }
        }

        private void AddAppSettingIfNotModified(String key, String value)
        {
            if (!IsAppSettingModified(key))
            {
                WithAppSetting(key, value);
            }
        }

        private bool IsAppSettingModified(String key)
        {
            return (appSettingsToAdd != null && appSettingsToAdd.ContainsKey(key))
                || (appSettingsToRemove != null && appSettingsToRemove.Contains(key));
        }

        private bool IsConsumptionAppServicePlan(PricingTier pricingTier)
        {
            if (pricingTier == null || pricingTier.SkuDescription == null)
            {
                return true;
            }

            SkuDescription description = pricingTier.SkuDescription;
            return description.Tier.Equals(SkuName.Dynamic.Value, StringComparison.OrdinalIgnoreCase) || description.Tier.Equals(SkuName.ElasticPremium.Value, StringComparison.OrdinalIgnoreCase);
        }

        public override async Task<IFunctionApp> CreateAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            if (IsInCreateMode)
            {
                if (Inner.ServerFarmId == null)
                {
                    WithNewConsumptionPlan();
                }
                if (currentStorageAccount == null && storageAccountToSet == null && storageAccountCreatable == null)
                {
                    WithNewStorageAccount(SdkContext.RandomResourceName(Name, 20).Replace("-", String.Empty), Storage.Fluent.Models.SkuName.StandardGRS);
                }
            }
            return await base.CreateAsync(cancellationToken);
        }

        public override FunctionAppImpl WithExistingAppServicePlan(IAppServicePlan appServicePlan)
        {
            base.WithExistingAppServicePlan(appServicePlan);
            return AutoSetAlwaysOn(appServicePlan.PricingTier);
        }

        public FunctionAppImpl WithLatestRuntimeVersion()
        {
            return WithRuntimeVersion("latest");
        }

        public string GetMasterKey()
        {
            return Extensions.Synchronize(() => GetMasterKeyAsync());
        }

        /// <summary>
        /// This method is used to retrieve the master key for the function app. Once this method is added in the web app OpenAPI
        /// specs, this method will call that in WebAppsOperations.cs instead.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>the master key of the function app.</returns>
        public async Task<string> GetMasterKeyAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            string apiVersion = "2019-08-01";
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                var tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", ResourceGroupName);
                tracingParameters.Add("name", Name);
                tracingParameters.Add("apiVersion", apiVersion);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "Get", tracingParameters);
            }
            // Construct URL
            var _baseUrl = Manager.Inner.BaseUri.AbsoluteUri;
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/host/default/listkeys").ToString();
            _url = _url.Replace("{resourceGroupName}", System.Uri.EscapeDataString(ResourceGroupName));
            _url = _url.Replace("{name}", System.Uri.EscapeDataString(Name));
            _url = _url.Replace("{subscriptionId}", System.Uri.EscapeDataString(Manager.Inner.SubscriptionId));
            List<string> _queryParameters = new List<string>();
            if (apiVersion != null)
            {
                _queryParameters.Add(string.Format("api-version={0}", System.Uri.EscapeDataString(apiVersion)));
            }
            if (_queryParameters.Count > 0)
            {
                _url += (_url.Contains("?") ? "&" : "?") + string.Join("&", _queryParameters);
            }
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("POST");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (Manager.Inner.GenerateClientRequestId != null && Manager.Inner.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (Manager.Inner.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Manager.Inner.AcceptLanguage);
            }

            // Serialize Request
            string _requestContent = null;
            // Set Credentials
            if (Manager.Inner.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Manager.Inner.Credentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            }
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await ((WebSiteManagementClient) Manager.Inner).HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    CloudError _errorBody = Rest.Serialization.SafeJsonConvert.DeserializeObject<CloudError>(_responseContent, Manager.Inner.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex = new CloudException(_errorBody.Message);
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    ex.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    var map = Rest.Serialization.SafeJsonConvert.DeserializeObject<Dictionary<string, Object>>(_responseContent, Manager.Inner.DeserializationSettings);
                    return map["masterKey"] == null ? null : map["masterKey"].ToString();
                }
                catch (JsonException ex)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", _responseContent, ex);
                }
            }
            return null;
        }

        public System.Collections.Generic.IReadOnlyDictionary<string, string> ListFunctionKeys(string functionName)
        {
            return Extensions.Synchronize(() => ListFunctionKeysAsync(functionName));
        }

        /// <summary>
        /// This method is used to retrieve the function keys for a function. This is part of the KUDU APIs.
        /// </summary>
        /// <param name="functionName">the name of the function</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>the keys of the function</returns>
        public async Task<System.Collections.Generic.IReadOnlyDictionary<string, string>> ListFunctionKeysAsync(string functionName, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                var tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("functionName", functionName);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "Get", tracingParameters);
            }
            // Construct URL
            var _baseUrl = string.Format("https://{0}", DefaultHostName().Replace("http://", "").Replace("https://", ""));
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "admin/functions/{name}/keys").ToString();
            _url = _url.Replace("{name}", System.Uri.EscapeDataString(functionName));
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (Manager.Inner.GenerateClientRequestId != null && Manager.Inner.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (Manager.Inner.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Manager.Inner.AcceptLanguage);
            }

            // Serialize Request
            string _requestContent = null;
            // Set Credentials
            cancellationToken.ThrowIfCancellationRequested();
            await functionCredentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await ((WebSiteManagementClient)Manager.Inner).HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    CloudError _errorBody = Rest.Serialization.SafeJsonConvert.DeserializeObject<CloudError>(_responseContent, Manager.Inner.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex = new CloudException(_errorBody.Message);
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    ex.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    var result = Rest.Serialization.SafeJsonConvert.DeserializeObject<FunctionKeyListResult>(_responseContent, Manager.Inner.DeserializationSettings);
                    var ret = new Dictionary<string, string>();
                    foreach (var pair in result.keys)
                    {
                        ret.Add(pair.Name, pair.Value);
                    }
                    return new ReadOnlyDictionary<string, string>(ret);
                }
                catch (JsonException ex)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", _responseContent, ex);
                }
            }
            return null;
        }

        public NameValuePair AddFunctionKey(string functionName, string keyName, string keyValue = null)
        {
            return Extensions.Synchronize(() => AddFunctionKeyAsync(functionName, keyName, keyValue));
        }

        /// <summary>
        /// This method is used to add a function key to the function. This is part of the KUDU APIs.
        /// </summary>
        /// <param name="functionName">the name of the function</param>
        /// <param name="keyName">the name of the key to add</param>
        /// <param name="key">the name value pair of the key, containing the key value</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>the added key</returns>
        public async Task<NameValuePair> AddFunctionKeyAsync(string functionName, string keyName, string keyValue = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                var tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("functionName", functionName);
                tracingParameters.Add("keyName", keyName);
                tracingParameters.Add("key", keyValue);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "Get", tracingParameters);
            }
            // Construct URL
            var _baseUrl = string.Format("https://{0}", DefaultHostName().Replace("http://", "").Replace("https://", ""));
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "admin/functions/{name}/keys/{keyName}").ToString();
            _url = _url.Replace("{name}", System.Uri.EscapeDataString(functionName));
            _url = _url.Replace("{keyName}", System.Uri.EscapeDataString(keyName));
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            if (keyValue != null)
            {
                _httpRequest.Method = new HttpMethod("PUT");
            }
            else
            {
                _httpRequest.Method = new HttpMethod("POST");
            }
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (Manager.Inner.GenerateClientRequestId != null && Manager.Inner.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (Manager.Inner.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Manager.Inner.AcceptLanguage);
            }

            // Serialize Request
            string _requestContent = null;
            if (keyValue != null)
            {
                _requestContent = Rest.Serialization.SafeJsonConvert.SerializeObject(new NameValuePair
                {
                    Name = keyName,
                    Value = keyValue
                }, Manager.Inner.SerializationSettings);
                _httpRequest.Content = new StringContent(_requestContent, System.Text.Encoding.UTF8);
                _httpRequest.Content.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            }
            // Set Credentials
            cancellationToken.ThrowIfCancellationRequested();
            await functionCredentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await ((WebSiteManagementClient)Manager.Inner).HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200 && (int)_statusCode != 201)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    CloudError _errorBody = Rest.Serialization.SafeJsonConvert.DeserializeObject<CloudError>(_responseContent, Manager.Inner.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex = new CloudException(_errorBody.Message);
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    ex.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Deserialize Response
            if ((int)_statusCode == 200 || (int)_statusCode == 201)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    return Rest.Serialization.SafeJsonConvert.DeserializeObject<NameValuePair>(_responseContent, Manager.Inner.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", _responseContent, ex);
                }
            }
            return null;
        }

        public void RemoveFunctionKey(string functionName, string keyName)
        {
            Extensions.Synchronize(() => RemoveFunctionKeyAsync(functionName, keyName));
        }

        /// <summary>
        /// This method is used to remove a function key from the function. This is part of the KUDU APIs.
        /// </summary>
        /// <param name="functionName">the name of the function</param>
        /// <param name="keyName">the name of the key to remove</param>
        /// <param name="cancellationToken">The cancellation token</param>
        public async Task RemoveFunctionKeyAsync(string functionName, string keyName, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                var tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("functionName", functionName);
                tracingParameters.Add("keyName", keyName);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "Get", tracingParameters);
            }
            // Construct URL
            var _baseUrl = string.Format("https://{0}", DefaultHostName().Replace("http://", "").Replace("https://", ""));
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "admin/functions/{name}/keys/{keyName}").ToString();
            _url = _url.Replace("{name}", System.Uri.EscapeDataString(functionName));
            _url = _url.Replace("{keyName}", System.Uri.EscapeDataString(keyName));
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("DELETE");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (Manager.Inner.GenerateClientRequestId != null && Manager.Inner.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (Manager.Inner.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Manager.Inner.AcceptLanguage);
            }

            // Serialize Request
            string _requestContent = null;
            _requestContent = null;
            // Set Credentials
            cancellationToken.ThrowIfCancellationRequested();
            await functionCredentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await ((WebSiteManagementClient)Manager.Inner).HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200 && (int)_statusCode != 204)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    CloudError _errorBody = Rest.Serialization.SafeJsonConvert.DeserializeObject<CloudError>(_responseContent, Manager.Inner.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex = new CloudException(_errorBody.Message);
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    ex.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
        }

        public IReadOnlyList<IFunctionEnvelope> ListFunctions()
        {
            return WrapListFunctionEnvelope(Extensions.Synchronize(() => Manager.FunctionApps.Inner.ListFunctionsAsync(ResourceGroupName, Name))
                .AsContinuousCollection(link => Extensions.Synchronize(() => Manager.FunctionApps.Inner.ListFunctionsNextAsync(link))))
                .ToList().AsReadOnly();
        }

        public async Task<IPagedCollection<IFunctionEnvelope>> ListFunctionsAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IFunctionEnvelope, FunctionEnvelopeInner>.LoadPage(
                async (cancellation) => await Manager.FunctionApps.Inner.ListFunctionsAsync(ResourceGroupName, Name, cancellation),
                Manager.FunctionApps.Inner.ListFunctionsNextAsync,
                WrapModelFunctionEnvelope,
                loadAllPages,
                cancellationToken);
        }

        protected IFunctionEnvelope WrapModelFunctionEnvelope(FunctionEnvelopeInner inner)
        {
            return new FunctionEnvelopeImpl(inner);
        }

        protected IEnumerable<IFunctionEnvelope> WrapListFunctionEnvelope(IEnumerable<FunctionEnvelopeInner> innerList)
        {
            return innerList.Select(inner => WrapModelFunctionEnvelope(inner));
        }

        public void SyncTriggers()
        {
            Extensions.Synchronize(() => SyncTriggersAsync());
        }

        public async Task SyncTriggersAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                await Manager.Inner.WebApps.SyncFunctionTriggersAsync(ResourceGroupName, Name, cancellationToken);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode != HttpStatusCode.OK)
                {
                    throw e;
                }
            }
        }

        public override Stream StreamApplicationLogs()
        {
            return Extensions.Synchronize(() => StreamApplicationLogsAsync());
        }

        public override Stream StreamHttpLogs()
        {
            return Extensions.Synchronize(() => StreamHttpLogsAsync());
        }

        public override Stream StreamTraceLogs()
        {
            return Extensions.Synchronize(() => StreamTraceLogsAsync());
        }

        public override Stream StreamDeploymentLogs()
        {
            return Extensions.Synchronize(() => StreamDeploymentLogsAsync());
        }

        public override Stream StreamAllLogs()
        {
            return Extensions.Synchronize(() => StreamAllLogsAsync());
        }

        public async override Task<Stream> StreamApplicationLogsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.WhenAll(PingAsync(cancellationToken), GetHostStatusAsync(cancellationToken));
            return await base.StreamApplicationLogsAsync();
        }

        public async override Task<Stream> StreamHttpLogsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.WhenAll(PingAsync(cancellationToken), GetHostStatusAsync(cancellationToken));
            return await base.StreamHttpLogsAsync();
        }

        public async override Task<Stream> StreamTraceLogsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.WhenAll(PingAsync(cancellationToken), GetHostStatusAsync(cancellationToken));
            return await base.StreamTraceLogsAsync();
        }

        public async override Task<Stream> StreamDeploymentLogsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.WhenAll(PingAsync(cancellationToken), GetHostStatusAsync(cancellationToken));
            return await base.StreamDeploymentLogsAsync();
        }

        public async override Task<Stream> StreamAllLogsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.WhenAll(PingAsync(cancellationToken), GetHostStatusAsync(cancellationToken));
            return await base.StreamAllLogsAsync();
        }

        private async Task PingAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                var tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "Post", tracingParameters);
            }
            // Construct URL
            var _baseUrl = string.Format("http://{0}", DefaultHostName().Replace("http://", "").Replace("https://", ""));
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "admin/host/ping").ToString();
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("POST");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (Manager.Inner.GenerateClientRequestId != null && Manager.Inner.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (Manager.Inner.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Manager.Inner.AcceptLanguage);
            }

            // Serialize Request
            string _requestContent = null;
            _requestContent = null;
            // Set Credentials
            cancellationToken.ThrowIfCancellationRequested();
            await functionCredentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await ((WebSiteManagementClient)Manager.Inner).HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200 && (int)_statusCode != 202)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    CloudError _errorBody = Rest.Serialization.SafeJsonConvert.DeserializeObject<CloudError>(_responseContent, Manager.Inner.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex = new CloudException(_errorBody.Message);
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    ex.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
        }

        private async Task GetHostStatusAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                var tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "Get", tracingParameters);
            }
            // Construct URL
            var _baseUrl = string.Format("http://{0}", DefaultHostName().Replace("http://", "").Replace("https://", ""));
            var _url = new System.Uri(new System.Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "admin/host/status").ToString();
            // Create HTTP transport objects
            var _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");
            _httpRequest.RequestUri = new System.Uri(_url);
            // Set Headers
            if (Manager.Inner.GenerateClientRequestId != null && Manager.Inner.GenerateClientRequestId.Value)
            {
                _httpRequest.Headers.TryAddWithoutValidation("x-ms-client-request-id", System.Guid.NewGuid().ToString());
            }
            if (Manager.Inner.AcceptLanguage != null)
            {
                if (_httpRequest.Headers.Contains("accept-language"))
                {
                    _httpRequest.Headers.Remove("accept-language");
                }
                _httpRequest.Headers.TryAddWithoutValidation("accept-language", Manager.Inner.AcceptLanguage);
            }

            // Serialize Request
            string _requestContent = null;
            _requestContent = null;
            // Set Credentials
            cancellationToken.ThrowIfCancellationRequested();
            await functionCredentials.ProcessHttpRequestAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await ((WebSiteManagementClient)Manager.Inner).HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200 && (int)_statusCode != 202)
            {
                var ex = new CloudException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                try
                {
                    _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    CloudError _errorBody = Rest.Serialization.SafeJsonConvert.DeserializeObject<CloudError>(_responseContent, Manager.Inner.DeserializationSettings);
                    if (_errorBody != null)
                    {
                        ex = new CloudException(_errorBody.Message);
                        ex.Body = _errorBody;
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception
                }
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_httpResponse.Headers.Contains("x-ms-request-id"))
                {
                    ex.RequestId = _httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                }
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
        }
    }
}
