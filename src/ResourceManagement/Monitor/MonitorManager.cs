// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    public class MonitorManager : Manager<IMonitorManagementClient>, IMonitorManager, IBeta
    {
        private IActivityLogs activityLogs;
        private IMetricDefinitions metricDefinitions;
        private IDiagnosticSettings diagnosticSettings;
        private IActionGroups actionGroups;
        private IAlertRules alertRules;
        private IAutoscaleSettings autoscaleSettings;

        private static IMonitorManagementClient GetInnerClient(RestClient restClient, string subscriptionId)
        {
            return new MonitorManagementClient(restClient)
            {
                SubscriptionId = subscriptionId
            };
        }

        private MonitorManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, GetInnerClient(restClient, subscriptionId))
        {
        }

        /// <summary>
        /// Creates an instance of MonitorManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="credentials">the credentials to use</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the MonitorManager</returns>
        public static IMonitorManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return Authenticate(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                        .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                    .Build(), subscriptionId);
        }

        /// <summary>
        /// Creates an instance of MonitorManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="restClient">the RestClient to be used for API calls.</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the MonitorManager</returns>
        public static IMonitorManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new MonitorManager(restClient, subscriptionId);
        }

        /// <summary>
        /// Get a Configurable instance that can be used to create StorageManager with optional configuration.
        /// </summary>
        /// <returns>the instance allowing configurations</returns>
        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        /// <summary>
        /// The inteface allowing configurations to be set.
        /// </summary>
        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IMonitorManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            /// <summary>
            /// Creates an instance of MonitorManager that exposes Monitor management API entry points.
            /// </summary>
            /// <param name="credentials">credentials the credentials to use</param>
            /// <param name="subscriptionId">The subscription UUID</param>
            /// <returns>the interface exposing Monitor management API entry points that work in a subscription</returns>
            public IMonitorManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new MonitorManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        public IActivityLogs ActivityLogs
        {
            get
            {
                if (this.activityLogs == null)
                {
                    this.activityLogs = new ActivityLogsImpl(this);
                }
                return this.activityLogs;
            }
        }

        public IMetricDefinitions MetricDefinitions
        {
            get
            {
                if (this.metricDefinitions == null)
                {
                    this.metricDefinitions = new MetricDefinitionsImpl(this);
                }
                return this.metricDefinitions;
            }
        }

        public IDiagnosticSettings DiagnosticSettings
        {
            get
            {
                if (this.diagnosticSettings == null)
                {
                    this.diagnosticSettings = new DiagnosticSettingsImpl(this);
                }
                return this.diagnosticSettings;
            }
        }

        public IActionGroups ActionGroups
        {
            get
            {
                if (this.actionGroups == null)
                {
                    this.actionGroups = new ActionGroupsImpl(this);
                }
                return this.actionGroups;
            }
        }

        public IAlertRules AlertRules
        {
            get
            {
                if (this.alertRules == null)
                {
                    this.alertRules = new AlertRulesImpl(this);
                }
                return this.alertRules;
            }
        }

        public IAutoscaleSettings AutoscaleSettings
        {
            get
            {
                if(this.autoscaleSettings == null)
                {
                    this.autoscaleSettings = new AutoscaleSettingsImpl(this);
                }
                return this.autoscaleSettings;
            }
        }
    }

    /// <summary>
    /// Entry point to Azure Monitor.
    /// </summary>
    public interface IMonitorManager : IManager<IMonitorManagementClient>
    {
        /// <summary>
        /// Gets the Azure Activity Logs API entry point.
        /// </summary>
        IActivityLogs ActivityLogs { get; }

        /// <summary>
        /// Gets the Azure Metric Definitions API entry point
        /// </summary>
        IMetricDefinitions MetricDefinitions { get; }

        /// <summary>
        /// Gets the Azure Diagnostic Settings API entry point
        /// </summary>
        IDiagnosticSettings DiagnosticSettings { get; }

        /// <summary>
        /// Gets the Azure Action Groups API entry point
        /// </summary>
        IActionGroups ActionGroups { get; }

        /// <summary>
        /// Gets the Alert Rules Groups API entry point.
        /// </summary>
        IAlertRules AlertRules { get; }

        /// <summary>
        /// Gets the Autoscale Settings API entry point.
        /// </summary>
        IAutoscaleSettings AutoscaleSettings { get; }
    }
}
