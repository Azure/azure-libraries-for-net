namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class WebAppBaseSimpleImpl : IWebAppSimple
    {
        private Models.SiteInner inner;

        public WebAppBaseSimpleImpl(Models.SiteInner inner)
        {
            this.inner = inner;
        }

        public string Id => Inner.Id;

        public string Name => Inner.Name;

        public string ResourceGroupName => Inner.ResourceGroup;

        public SiteInner Inner => inner;

        public IList<string> HostNames => Inner.HostNames;

        public string RepositorySiteName => Inner.RepositorySiteName;

        public UsageState? UsageState => Inner.UsageState;

        public bool? Enabled => Inner.Enabled;

        public IList<string> EnabledHostNames => Inner.EnabledHostNames;

        public SiteAvailabilityState? AvailabilityState => Inner.AvailabilityState;

        public IList<HostNameSslState> HostNameSslStates => Inner.HostNameSslStates;

        public string ServerFarmId => Inner.ServerFarmId;

        public bool? Reserved => Inner.Reserved;

        public bool? IsXenon => Inner.IsXenon;

        public bool? HyperV => Inner.HyperV;

        public DateTime? LastModifiedTimeUtc => Inner.LastModifiedTimeUtc;

        public IList<string> TrafficManagerHostNames => Inner.TrafficManagerHostNames;

        public bool? ScmSiteAlsoStopped => Inner.ScmSiteAlsoStopped;

        public string TargetSwapSlot => Inner.TargetSwapSlot;

        public HostingEnvironmentProfile HostingEnvironmentProfile => Inner.HostingEnvironmentProfile;

        public bool? ClientAffinityEnabled => Inner.ClientAffinityEnabled;

        public bool? ClientCertEnabled => Inner.ClientCertEnabled;

        public string ClientCertExclusionPaths => Inner.ClientCertExclusionPaths;

        public bool? HostNamesDisabled => Inner.HostNamesDisabled;

        public string OutboundIpAddresses => Inner.OutboundIpAddresses;

        public string PossibleOutboundIpAddresses => Inner.PossibleOutboundIpAddresses;

        public int? ContainerSize => Inner.ContainerSize;

        public int? DailyMemoryTimeQuota => Inner.DailyMemoryTimeQuota;

        public DateTime? SuspendedTill => Inner.SuspendedTill;

        public int? MaxNumberOfWorkers => Inner.MaxNumberOfWorkers;

        public CloningInfo CloningInfo => Inner.CloningInfo;

        public bool? IsDefaultContainer => Inner.IsDefaultContainer;

        public string DefaultHostName => Inner.DefaultHostName;

        public SlotSwapStatus SlotSwapStatus => Inner.SlotSwapStatus;

        public bool? HttpsOnly => Inner.HttpsOnly;

        public RedundancyMode? RedundancyMode => Inner.RedundancyMode;

        public ManagedServiceIdentity Identity => Inner.Identity;

        public string Kind => Inner.Kind;

        public OperatingSystem OperatingSystem
        {
            get
            {
                if (Inner.Kind.ToLower().Contains("linux"))
                {
                    return OperatingSystem.Linux;
                }
                else
                {
                    return OperatingSystem.Windows;
                }
            }
        }
    }
}
