// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent
{
    using Microsoft.Azure.Management.Monitor.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for  MetricAlerts.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uQWxlcnRSdWxlc0ltcGw=
    internal partial class AlertRulesImpl :
        IAlertRules
    {
        private IActivityLogAlerts activityLogAlerts;
        private IMetricAlerts metricAlerts;

        ///GENMHASH:663ED2772152A9775CBC5082E9A08E46:DF54C9CD850E0683A875A7EC0984252D
        internal AlertRulesImpl(MonitorManager monitorManager)
        {
            metricAlerts = new MetricAlertsImpl(monitorManager);
            activityLogAlerts = new ActivityLogAlertsImpl(monitorManager);
        }

        ///GENMHASH:972DF153947D1B922E1568AE220C3995:99905ADFACEA67EDC6EEB5495D444BF0
        public IActivityLogAlerts ActivityLogAlerts()
        {
            return activityLogAlerts;
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:EE47E97226D9264B03F1FE5C2279EC56
        public MonitorManager Manager()
        {
            return this.metricAlerts.Manager;
        }

        ///GENMHASH:8BF4F2A13538FA6760052DBA83D81E18:E731B38EE96A17959E696C52C073499C
        public IMetricAlerts MetricAlerts()
        {
            return metricAlerts;
        }
    }
}