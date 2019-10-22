// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    /// <summary>
    /// Implementation for SQL replication link interface.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5SZXBsaWNhdGlvbkxpbmtJbXBs
    internal partial class ReplicationLinkImpl  :
        Wrapper<Models.ReplicationLinkInner>,
        IReplicationLink
    {
        private string sqlServerName;
        private string resourceGroupName;
        private ISqlManager sqlServerManager;
        private ResourceId resourceId;

        ///GENMHASH:5DEC8568283F2E20241D12E11ECD4AC2:2195512CD9515F346E018CD0415C3ECF
        public ReplicationLinkImpl(string resourceGroupName, string sqlServerName, ReplicationLinkInner innerObject, ISqlManager sqlServerManager) : base(innerObject)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.sqlServerManager = sqlServerManager;
            this.resourceId = ResourceId.FromString(this.Inner.Id);
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:21B47052EB40357CA6B2CE98AA63C28E
        protected async Task<Models.ReplicationLinkInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServerManager.Inner.ReplicationLinks
                .GetAsync(this.resourceGroupName, this.sqlServerName, this.DatabaseName(), this.Name(), cancellationToken: cancellationToken);
        }

        public IReplicationLink Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<IReplicationLink> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync());
            return this;
        }

        ///GENMHASH:02F7EEF0FED95778A75B4E645D2DFAD1:E400A2E207AAA7A05E32DCA2BBA5405B
        public string ReplicationMode()
        {
            return this.Inner.ReplicationMode;
        }

        ///GENMHASH:59D8987F7EC078423F8247D1F7D40FBD:D2670680EF14BA9058384CB186AA4289
        public ReplicationState ReplicationState()
        {
            return this.Inner.ReplicationState;
        }

        ///GENMHASH:7DDE9B1BB82467D17BDE73EEF70FC15A:FD23977BD91FE98C3065B6E757B7B31A
        public ReplicationRole Role()
        {
            return this.Inner.Role.GetValueOrDefault();
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            return this.resourceGroupName;
        }

        ///GENMHASH:E7ABDAFE895DE30905D46D515062DB59:E469BC0EB728512D322663135CC847D6
        public string DatabaseName()
        {
            return this.resourceId.Parent.Name;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:998832D58C98F6DCF3637916D2CC70B9
        public string SqlServerName()
        {
            return this.sqlServerName;
        }

        ///GENMHASH:A6FB40DB55DA08C2751F5BBFFCD06BA6:0BD76FC865DFF06EA7CB878F1666969B
        public string PartnerServer()
        {
            return this.Inner.PartnerServer;
        }

        ///GENMHASH:663AECE9E2B94E49177C45542A675796:6FCFDC6E0E888975E162F9E3A6690673
        public ReplicationRole PartnerRole()
        {
            return this.Inner.PartnerRole.GetValueOrDefault();
        }

        ///GENMHASH:2FC49EAB039E94EB44E51D11B75A548E:CD941CF02484A9AF4A0A964B2D99D846
        public async Task FailoverAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.ReplicationLinks
                .FailoverAsync(this.resourceGroupName, this.sqlServerName, this.DatabaseName(), this.Name(), cancellationToken);
        }

        ///GENMHASH:64FDD7DAC0F2CAB9406652DA7545E8AA:3F5BF88EAEB847CE67B8C16A5FDD2D28
        public int PercentComplete()
        {
            return this.Inner.PercentComplete.GetValueOrDefault();
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:4B3BB881456972AC9F7FDBA8BC689A6A
        public void Delete()
        {
            Extensions.Synchronize(() => this.sqlServerManager.Inner.ReplicationLinks
                .DeleteAsync(this.resourceGroupName, this.sqlServerName, this.DatabaseName(), this.Name()));
        }

        ///GENMHASH:DD6979366C7B4F3C6845144DBE9E011A:3A2790280A71E249789F2B84BB4C07B8
        public void ForceFailoverAllowDataLoss()
        {
            Extensions.Synchronize(() => this.ForceFailoverAllowDataLossAsync());

        }

        ///GENMHASH:75146396042F3B3D55B973EBEDF73CD2:5A1D5C41A75E757911AE5D6439A2646A
        public void Failover()
        {
            Extensions.Synchronize(() => this.FailoverAsync());
        }

        ///GENMHASH:5AB0C3BAD9CCF0911C7056C035A80A5E:83EEA6B4DF949E684B01A15783C41931
        public async Task ForceFailoverAllowDataLossAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.sqlServerManager.Inner.ReplicationLinks
                .FailoverAllowDataLossAsync(this.resourceGroupName, this.sqlServerName, this.DatabaseName(), this.Name());
        }

        ///GENMHASH:D1AA514022A702178FC60111EBA279F9:23D982D34E0AA0229B0409AE0E6C9099
        public string PartnerDatabase()
        {
            return this.Inner.PartnerDatabase;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:F7EC7AAB45EBE6E09D4229A636C32057:190D97C3A63BC44A465BFBD32060DB26
        public bool IsTerminationAllowed()
        {
            return this.Inner.IsTerminationAllowed ?? false;
        }

        ///GENMHASH:8550B4F26F41D82222F735D9324AEB6D:42AE1A0453935D9BF88147F2F9C3EC20
        public DateTime? StartTime()
        {
            return this.Inner.StartTime;
        }

        ///GENMHASH:A85BBC58BA3B783F90EB92B75BD97D51:3054A3D10ED7865B89395E7C007419C9
        public string Location()
        {
            return this.Inner.Location;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:868B2F3C33B56DD970703291B23E174D:DF14267C442E5344D77EF314AD1B4A87
        public string PartnerLocation()
        {
            return this.Inner.PartnerLocation;
        }
    }
}