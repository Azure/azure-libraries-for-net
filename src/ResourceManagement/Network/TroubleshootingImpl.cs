// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.Troubleshooting.Definition;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Implementation of Troubleshooting interface.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uVHJvdWJsZXNob290aW5nSW1wbA==
    internal partial class TroubleshootingImpl :
        Executable<Microsoft.Azure.Management.Network.Fluent.ITroubleshooting>,
        ITroubleshooting,
        IDefinition
    {
        private NetworkWatcherImpl parent;
        private TroubleshootingParameters parameters = new TroubleshootingParameters();
        private TroubleshootingResultInner result;
        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public INetworkWatcher Parent()
        {
            return parent;
        }

        ///GENMHASH:9167A56971CBBB9DBAE843BD16B55E09:C23773F385731040CA57BB607D6CCFE8
        public string Code()
        {
            return result.Code;
        }

        ///GENMHASH:34214CDA694B09312AB4062B1B86A083:AE24A5922CFF2464667B4434294D34C5
        public TroubleshootingImpl WithStorageAccount(string storageAccountId)
        {
            parameters.StorageId = storageAccountId;
            return this;
        }

        ///GENMHASH:DE2309F0433E6440B607ADF68B95E3C6:D6EED079B4F833CC4BCDBCF8CD8719CC
        public TroubleshootingImpl WithTargetResourceId(string targetResourceId)
        {
            parameters.TargetResourceId = targetResourceId;
            return this;
        }

        ///GENMHASH:1DD40F99DD74D7573B3C190ECBAC19EE:2F3A955A541CEB977CCEF3EDE35252B2
        public string StoragePath()
        {
            return parameters.StoragePath;
        }

        ///GENMHASH:FE79E38E5D355183291E05FDB7F83D32:022492BE61BF65D558A50DC42D7B9D5C
        public TroubleshootingImpl WithStoragePath(string storagePath)
        {
            parameters.StoragePath = storagePath;
            return this;
        }

        ///GENMHASH:54FF9EAE063A707BF467152E850B0B04:F49B330AD57E90EA0F9724A089EC8897
        public string TargetResourceId()
        {
            return parameters.TargetResourceId;
        }

        ///GENMHASH:8550B4F26F41D82222F735D9324AEB6D:6DE5F99ABF2A46D2506D498C0AFBD12C
        public DateTime? StartTime()
        {
            return result.StartTime;
        }

        ///GENMHASH:3C1909F3137E91E93C57B90768BECD1A:51918A08538F03EA730DAAC0786E9C7E
        public DateTime? EndTime()
        {
            return result.EndTime;
        }

        ///GENMHASH:634F75DCD20DBDC8E72E3AB5D494DAA1:57CD1F016BE333B5679C095D04AE516C
        public IReadOnlyList<Models.TroubleshootingDetails> Results()
        {
            return result.Results.ToList().AsReadOnly();
        }

        ///GENMHASH:637F0A3522F2C635C23E54FAAD79CBEA:1F36906E27039EA83FB1A9B1F447C877
        public override async Task<Microsoft.Azure.Management.Network.Fluent.ITroubleshooting> ExecuteAsync(CancellationToken cancellationToken = default(CancellationToken), bool multiThreaded = true)
        {
            this.result = await parent.Manager.Inner.NetworkWatchers
                .GetTroubleshootingAsync(parent.ResourceGroupName, parent.Name, parameters);
            return this;
        }

        ///GENMHASH:CC7472AC3252D1A440E780CC02E6671F:425AAA90FA44C25BF65D98CF87FB3E57
        internal TroubleshootingImpl(NetworkWatcherImpl parent)
        {
            this.parent = parent;
        }

        ///GENMHASH:377F5AE3B24673ACE3FC01FC20F6ABBD:9969FE45777D8764FC717038B664AA0E
        public string StorageId()
        {
            return parameters.StorageId;
        }
    }
}