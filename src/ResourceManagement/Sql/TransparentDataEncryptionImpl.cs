// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Implementation for TransparentDataEncryption.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5UcmFuc3BhcmVudERhdGFFbmNyeXB0aW9uSW1wbA==
    internal partial class TransparentDataEncryptionImpl  :
        Wrapper<Models.TransparentDataEncryptionInner>,
        ITransparentDataEncryption
    {
        private string sqlServerName;
        private string resourceGroupName;
        private ISqlManager sqlServerManager;
        private ResourceId resourceId;

        ///GENMHASH:7297E392E9CB8A4F141D1D06AF6C4036:2195512CD9515F346E018CD0415C3ECF
        public TransparentDataEncryptionImpl(string resourceGroupName, string sqlServerName, TransparentDataEncryptionInner innerObject, ISqlManager sqlServerManager)
            : base(innerObject)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.sqlServerManager = sqlServerManager;
            this.resourceId = ResourceId.FromString(this.Inner.Id);
        }

        public ITransparentDataEncryption Refresh()
        {
            return Extensions.Synchronize(() => this.RefreshAsync());
        }

        public async Task<ITransparentDataEncryption> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.GetInnerAsync(cancellationToken));
            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:F84CD4BD399D8EB31B803F7EFA4D29A6
        protected async Task<Models.TransparentDataEncryptionInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.sqlServerManager.Inner.TransparentDataEncryptions.GetAsync(this.resourceGroupName, this.sqlServerName, this.DatabaseName(), cancellationToken);
        }

        ///GENMHASH:C183D7089E5DF699C59758CC103308DF:7868EC5FC12996B498AF572684C5339A
        public IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity> ListActivities()
        {
            return Extensions.Synchronize(() => this.ListActivitiesAsync());
        }

        ///GENMHASH:963770852AF9FA245B7756A9091BA5E1:B07801976DBB925452B1BA38235ED912
        public ITransparentDataEncryption UpdateStatus(TransparentDataEncryptionStatus transparentDataEncryptionStatus)
        {
            return Extensions.Synchronize(() => this.UpdateStatusAsync(transparentDataEncryptionStatus));
        }

        ///GENMHASH:BBAE2D48EA5C43449DBE61B80641DDF2:C760C066C2E0A08B68FCB68FC9D5E29F
        public async Task<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryption> UpdateStatusAsync(TransparentDataEncryptionStatus transparentDataEncryptionState, CancellationToken cancellationToken = default(CancellationToken))
        {
            this.SetInner(await this.sqlServerManager.Inner.TransparentDataEncryptions
                .CreateOrUpdateAsync(this.ResourceGroupName(), this.SqlServerName(), this.DatabaseName(), transparentDataEncryptionState, cancellationToken));

            return this;
        }

        ///GENMHASH:DEB77E33ECE966C507F45288C041CC34:C299CA81D22423E0B396DF5080B898B5
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity>> ListActivitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            List<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity> activities = new List<Microsoft.Azure.Management.Sql.Fluent.ITransparentDataEncryptionActivity>();
            var innerActivities = await this.sqlServerManager.Inner.TransparentDataEncryptionActivities
                .ListByConfigurationAsync(this.resourceGroupName, this.sqlServerName, this.DatabaseName(), cancellationToken);
            if (innerActivities != null)
            {
                foreach (var innerActivity in innerActivities)
                {
                    activities.Add(new TransparentDataEncryptionActivityImpl(innerActivity));
                }
            }

            return activities.AsReadOnly();
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            return this.resourceGroupName;
        }

        ///GENMHASH:E7ABDAFE895DE30905D46D515062DB59:4FF2FEC4B193B40F5666C7C0244DEB2E
        public string DatabaseName()
        {
            return resourceId.Parent.Name;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:998832D58C98F6DCF3637916D2CC70B9
        public string SqlServerName()
        {
            return this.sqlServerName;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:1ABA34EF946CBD0278FAD778141792B2
        public TransparentDataEncryptionStatus Status()
        {
            return this.Inner.Status.GetValueOrDefault();
        }
    }
}