// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// Implementation for Azure SQL Server's Service Objective.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TZXJ2aWNlT2JqZWN0aXZlSW1wbA==
    internal partial class ServiceObjectiveImpl  :
        Wrapper<Models.ServiceObjectiveInner>,
        IServiceObjective
    {
        private SqlServerImpl sqlServer;

        ///GENMHASH:FF79A768968F7A66C9EE48197F8A7D44:7EA48F168814C86A7C06DEF2A48D1466
        public ServiceObjectiveImpl(ServiceObjectiveInner innerObject, SqlServerImpl sqlServer) : base(innerObject)
        {
            this.sqlServer = sqlServer;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:D745165A398B3C1291619D85FD0411EB
        protected async Task<Models.ServiceObjectiveInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServer.Manager.Inner.ServiceObjectives
                .GetAsync(this.ResourceGroupName(), this.SqlServerName(), this.Name(), cancellationToken);
        }

        public IServiceObjective Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<IServiceObjective> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync(cancellationToken));
            return this;
        }

        ///GENMHASH:889A7F8637F19A4ED19E45F820660A34:B16DDC09F7A2219086D4252E79738610
        public bool IsSystem()
        {
            return this.Inner.IsSystem;
        }

        ///GENMHASH:CDF93F9784B71C89BE4A0C05251822C7:B800FA8E3517BE137F6E49C8775C0FA6
        public bool IsDefault()
        {
            return this.Inner.IsDefault;
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:519395817AF6BD69D3CFD68045AED5AE
        public string ResourceGroupName()
        {
            return this.sqlServer.ResourceGroupName;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:3520E9B0814A37469465F84246F9FB4C
        public string SqlServerName()
        {
            return this.sqlServer.Name;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:D0058F471249EF9DC848FC249DF641F9:896ECA7AFE82035F26A379486227ABF8
        public string ServiceObjectiveName()
        {
            return this.Inner.ServiceObjectiveName;
        }

        ///GENMHASH:7B3CA3D467253D93C6FF7587C3C0D0B7:F5293CC540B22E551BB92F6FCE17DE2C
        public string Description()
        {
            return this.Inner.Description;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:1703877FCECC33D73EA04EEEF89045EF:D9D302D7384414CD7579755B13976527
        public bool Enabled()
        {
            return this.Inner.Enabled;
        }
    }
}