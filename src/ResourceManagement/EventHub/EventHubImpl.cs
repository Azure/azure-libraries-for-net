// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Definition;
    using Microsoft.Azure.Management.Eventhub.Fluent.EventHub.Update;
    using Microsoft.Azure.Management.EventHub.Fluent;
    using Microsoft.Azure.Management.EventHub.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Storage.Fluent;
    using Microsoft.WindowsAzure.Storage;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for  EventHub.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLkV2ZW50SHViSW1wbA==
    internal partial class EventHubImpl  :
        NestedResourceImpl<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub,
            EventhubInner,
            Microsoft.Azure.Management.Eventhub.Fluent.EventHubImpl, 
            IUpdate>,
        IEventHub,
        IDefinition,
        IUpdate
    {
        private readonly IStorageManager storageManager;
        private OneAncestor ancestor;
        private CaptureSettings captureSettings;
        //
        // Track the work to be executed after the creation of EventHub
        //
        private IList<Func<CancellationToken, Task>> postRunWorks = new List<Func<CancellationToken, Task>>();


        ///GENMHASH:AF64DA9001EBD64CFAA3ED4BA39E56DA:FBA6065F3BD99006157838C414D2E48D
        internal EventHubImpl(string name, EventhubInner inner, IEventHubManager manager, IStorageManager storageManager) : base(name, inner, manager)
        {
            this.ancestor = new OneAncestor(inner.Id);
            this.storageManager = storageManager;
            this.captureSettings = new CaptureSettings(this.Inner, storageManager);
        }

        ///GENMHASH:DBB8A8EF35C6B60A028BCD065974A80D:48F9D1BC97AC5522B59B3EB61641C90E
        internal EventHubImpl(string name, IEventHubManager manager, IStorageManager storageManager) : base(name, new EventhubInner(), manager)
        {
            this.storageManager = storageManager;
            this.captureSettings = new CaptureSettings(this.Inner, storageManager);
        }

        ///GENMHASH:BC796D0A7EFEEA08ADC9653640ACCBCF:E2D0E9C2E913034FE2F5B8204F5797F5
        public string NamespaceResourceGroupName()
        {
            return this.Ancestor().ResourceGroupName;
        }

        ///GENMHASH:D3F702AA57575010CE18E03437B986D8:44D93BEB0AEB0D232B2497DD293956E3
        public string NamespaceName()
        {
            return this.Ancestor().Ancestor1Name;
        }

        ///GENMHASH:C46E7D14DC04B767ED8FEE1B2480967D:CC5C061B75C2FD04CB51682F8DDE54D5
        public bool IsDataCaptureEnabled()
        {
            if (this.Inner.CaptureDescription?.Enabled != null)
            {
                return this.Inner.CaptureDescription.Enabled.Value;
            }
            return false;
        }

        ///GENMHASH:413962625FAAB9D45A54A7306D081A0D:BF1AD1A1F43F73817AA833B1AC55DBE7
        public int DataCaptureWindowSizeInSeconds()
        {
            if (this.Inner.CaptureDescription?.SizeLimitInBytes != null)
            {
                return this.Inner.CaptureDescription.IntervalInSeconds.Value;
            }
            return 0;
        }

        ///GENMHASH:B6930744702E626F564BDAD8ECCFFDEF:5F8325B3C941DE0FDAC2C45D093B01FF
        public int DataCaptureWindowSizeInMB()
        {
            if (this.Inner.CaptureDescription?.SizeLimitInBytes != null)
            {
                return this.Inner.CaptureDescription.SizeLimitInBytes.Value / (1024 * 1024);
            }
            return 0;
        }


        public bool DataCaptureSkipEmptyArchives()
        {
            if (this.Inner.CaptureDescription?.SkipEmptyArchives != null)
            {
                return this.Inner.CaptureDescription.SkipEmptyArchives.Value;
            }
            return false;
        }

        ///GENMHASH:983D09DB57D14F32384D91C0EC81C8A2:109AC2E4737271E0E67422F073A4FBA1
        public string DataCaptureFileNameFormat()
        {
            if (this.Inner.CaptureDescription?.Destination?.ArchiveNameFormat != null)
            {
                return this.Inner.CaptureDescription.Destination.ArchiveNameFormat;
            }
            return null;
        }


        ///GENMHASH:878C662D030030763F29556145B87E07:4A0127C55741A494DB9949A72C68C20E
        public Destination CaptureDestination()
        {
            if (this.Inner.CaptureDescription?.Destination != null)
            {
                return this.Inner.CaptureDescription.Destination;
            }
            return null;
        }

        ///GENMHASH:A81E23E1FF99483D58C57E5A97A610EA:99883E5FFF57867D1B9FCD54CCCDC2FA
        public EventHubImpl WithDataCaptureWindowSizeInSeconds(int sizeInSeconds)
        {
            this.captureSettings.WithDataCaptureWindowSizeInSeconds(sizeInSeconds);
            return this;
        }


        ///GENMHASH:76D8DB8A194A6E9A554ED4D44E51AB32:4BE88A6290EDC4192519F1A039F4AB44
        public IReadOnlyCollection<string> PartitionIds()
        {
            if (this.Inner.PartitionIds == null)
            {
                return new List<string>();
            }
            else
            {
                return new List<string>(this.Inner.PartitionIds);
            }
        }

        ///GENMHASH:14D1EDFC493E2BB7CC5E1480311D8ED8:D611BE19ECBE27FC04E119DDC9504D6F
        public long MessageRetentionPeriodInDays()
        {
            if (this.Inner.MessageRetentionInDays != null)
            {
                return this.Inner.MessageRetentionInDays.Value;
            }
            else
            {
                return 0;
            }
        }

        ///GENMHASH:6369056F27BCEB7CF168B7771AFF9AF7:25F30D04BAADB2D9857456903299E903
        public EventHubImpl WithNewNamespace(ICreatable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubNamespace> namespaceCreatable)
        {
            this.AddCreatableDependency(namespaceCreatable as IResourceCreator<IHasId>);
            EventHubNamespaceImpl ehNamespace = ((EventHubNamespaceImpl) namespaceCreatable);
            this.ancestor = new OneAncestor(ehNamespace.ResourceGroupName, namespaceCreatable.Name);
            return this;
        }

        ///GENMHASH:08506310D187BABA4C2239668F739FDC:CE786D4FB6D8E17D92A67502DF4FD6E0
        public EventHubImpl WithExistingNamespaceId(string namespaceId)
        {
            this.ancestor = new OneAncestor(SelfId(namespaceId));
            return this;
        }

        ///GENMHASH:C0BC49DC1543321A2DF43F4658EB9912:EDA80D678FC3FF2592A13E3E96233046
        public EventHubImpl WithExistingNamespace(IEventHubNamespace nhNamespace)
        {
            this.ancestor = new OneAncestor(SelfId(nhNamespace.Id));
            return this;
        }

        ///GENMHASH:9298FB756A759A518143F3CB15689B52:3F7E53D855C5660E045E1F2614E2F3C8
        public EventHubImpl WithExistingNamespace(string resourceGroupName, string namespaceName)
        {
            this.ancestor = new OneAncestor(resourceGroupName, namespaceName);
            return this;
        }

        ///GENMHASH:7EC7263977FF1ECADB7B046E165FF424:F7FBD99AC48DDD539E763730BF437754
        public EventHubImpl WithNewStorageAccountForCapturedData(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> storageAccountCreatable, string containerName)
        {
            this.captureSettings.WithNewStorageAccountForCapturedData(storageAccountCreatable, containerName);
            return this;
        }

        ///GENMHASH:FE78AAEC8A3F18AD3D30F2F674958269:FEAE7C5EDC8B0DDC022045F56D258F16
        public EventHubImpl WithExistingStorageAccountForCapturedData(IStorageAccount storageAccount, string containerName)
        {
            this.captureSettings.WithExistingStorageAccountForCapturedData(storageAccount, containerName);
            return this;
        }

        ///GENMHASH:3A21C655B603C8713B6003EE2AFD58AA:4CF9CB646B07DC745BA9A52F2D15C47F
        public EventHubImpl WithExistingStorageAccountForCapturedData(string storageAccountId, string containerName)
        {
            this.captureSettings.WithExistingStorageAccountForCapturedData(storageAccountId, containerName);
            return this;
        }

        ///GENMHASH:235045FA9E3B824D8ADBD207C00DD31B:322178F149E5B14B965B4AE60A3CA60E
        public EventHubImpl WithDataCaptureDisabled()
        {
            this.captureSettings.WithDataCaptureDisabled();
            return this;
        }

        ///GENMHASH:7ACB98F534A2273DD4A204117C1CDCD1:A32F2E3E2BA1F4EB1E4186535655EE00
        public EventHubImpl WithDataCaptureEnabled()
        {
            this.captureSettings.WithDataCaptureEnabled();
            return this;
        }

        ///GENMHASH:FE8D975AA8B56E2F7E79F9BC191E1B39:42671D0511381AF574D754AEB978BF21
        public EventHubImpl WithDataCaptureFileNameFormat(string format)
        {
            this.captureSettings.WithDataCaptureFileNameFormat(format);
            return this;
        }

        ///GENMHASH:5E917ACE2BE12A2264A269E5C7F593EA:8B487D8A3BE67416DAC776B0941B90EF
        public EventHubImpl WithDataCaptureWindowSizeInMB(int sizeInMB)
        {
            this.captureSettings.WithDataCaptureWindowSizeInMB(sizeInMB);
            return this;
        }

        public EventHubImpl WithDataCaptureSkipEmptyArchives(bool skipEmptyArchives)
        {
            this.captureSettings.WithDataCaptureSkipEmptyArchives(skipEmptyArchives);
            return this;
        }

        ///GENMHASH:CF2CF801A7E4A9CAE7624D815E5EE4F4:97B3FE29F78328721A16D67464BCA22A
        public EventHubImpl WithNewListenRule(string ruleName)
        {
            postRunWorks.Add(async (CancellationToken cancellation) => {
                await Manager.EventHubAuthorizationRules
                    .Define(ruleName)
                    .WithExistingEventHub(Ancestor().ResourceGroupName, Ancestor().Ancestor1Name, Name)
                    .WithListenAccess()
                    .CreateAsync(cancellation);
            });
            return this;
        }

        ///GENMHASH:41482A7907F5C3C16FDB1A8E3CEB3B9F:70B09C6210E8E8D5267C3F3CD2BD4FF6
        public EventHubImpl WithNewSendRule(string ruleName)
        {
            postRunWorks.Add(async (CancellationToken cancellation) =>
            {
                await Manager.EventHubAuthorizationRules
                    .Define(ruleName)
                    .WithExistingEventHub(Ancestor().ResourceGroupName, Ancestor().Ancestor1Name, Name)
                    .WithSendAccess()
                    .CreateAsync(cancellation);
            });
            return this;
        }

        ///GENMHASH:396C89E2447B0E70C3C95439926DFC1A:D0F5D5AD9F219E6C48C4D703A358A628
        public EventHubImpl WithNewManageRule(string ruleName)
        {
            postRunWorks.Add(async (CancellationToken cancellation) =>
            {
                await Manager.EventHubAuthorizationRules
                    .Define(ruleName)
                    .WithExistingEventHub(Ancestor().ResourceGroupName, Ancestor().Ancestor1Name, Name)
                    .WithManageAccess()
                    .CreateAsync(cancellation);
            });
            return this;
        }

        ///GENMHASH:7701B5E45C28C739B5610C34A2EF5559:E41DFE995C94CE9ACD85675BE87B47EF
        public EventHubImpl WithoutAuthorizationRule(string ruleName)
        {
            postRunWorks.Add(async (CancellationToken cancellation) =>
            {
                await Manager.EventHubAuthorizationRules
                    .DeleteByNameAsync(Ancestor().ResourceGroupName, Ancestor().Ancestor1Name, Name, ruleName, cancellation);
            });
            return this;
        }

        ///GENMHASH:54471CB5799BB52E75AF176275F26F91:7913599F441842D75B98A0BBA89FECBC
        public EventHubImpl WithNewConsumerGroup(string name)
        {
            postRunWorks.Add(async (CancellationToken cancellation) =>
            {
                await Manager.ConsumerGroups
                    .Define(name)
                    .WithExistingEventHub(Ancestor().ResourceGroupName, Ancestor().Ancestor1Name, Name)
                    .CreateAsync(cancellation);
            });
            return this;
        }

        ///GENMHASH:D242A752F37DB430160FA56E80B1EB27:70026407BF17E0F7EAE48978E0DB98CF
        public EventHubImpl WithNewConsumerGroup(string name, string metadata)
        {
            postRunWorks.Add(async (CancellationToken cancellation) =>
            {
                await Manager.ConsumerGroups
                    .Define(name)
                    .WithExistingEventHub(Ancestor().ResourceGroupName, Ancestor().Ancestor1Name, Name)
                    .WithUserMetadata(metadata)
                    .CreateAsync(cancellation);
            });
            return this;
        }

        ///GENMHASH:A35BEF47A45B1D7756D492C5633CEB45:AE5D67C1ECDF88220EC8E9F938D284C8
        public EventHubImpl WithoutConsumerGroup(string name)
        {
            postRunWorks.Add(async (CancellationToken cancellation) =>
            {
                await Manager.ConsumerGroups
                    .DeleteByNameAsync(Ancestor().ResourceGroupName, Ancestor().Ancestor1Name, Name, name, cancellation);
            });
            return this;
        }

        ///GENMHASH:ECA69A2F1DAF6AB733CBE2D4370E7A3A:C14279DB8AB759A43B1610F403824FAC
        public EventHubImpl WithPartitionCount(long count)
        {
            this.Inner.PartitionCount = count;
            return this;
        }

        ///GENMHASH:0B00FA43C0D8A98E25BC80204F79C8F2:5EF5DEC8DF0806A635BD46FB5C94D8E3
        public EventHubImpl WithRetentionPeriodInDays(long period)
        {
            this.Inner.MessageRetentionInDays = period;
            return this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:E9C82E871775C006317A8045858D2833
        public override async Task<Microsoft.Azure.Management.Eventhub.Fluent.IEventHub> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                this.Inner.CaptureDescription = this.captureSettings.ValidateAndGetSettings();
                await this.captureSettings.PrepareCaptureStorageAsync(cancellationToken);
                var inner = await this.Manager.Inner.EventHubs.
                    CreateOrUpdateAsync(Ancestor().ResourceGroupName, Ancestor().Ancestor1Name, Name, this.Inner, cancellationToken);
                this.SetInner(inner);
                await Task.WhenAll(this.postRunWorks.Select(p => p(cancellationToken)).ToArray());
            }
            finally
            {
                this.postRunWorks.Clear();
            }
            return this;
        }

        ///GENMHASH:6BCE517E09457FF033728269C8936E64:989843BC32A052B19F1B1B37A37498C4
        public override EventHub.Update.IUpdate Update()
        {
            this.captureSettings = new CaptureSettings(this.Inner, storageManager);
            return base.Update();
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:C853C0C6E68EFB335138917CB5C0867A
        protected override async Task<EventhubInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.Inner.EventHubs.GetAsync(Ancestor().ResourceGroupName, Ancestor().Ancestor1Name, Name, cancellationToken);
        }

        ///GENMHASH:83B18B40DCF82ECAB50C9B48076D9892:8C2E8EBD71AB8531A72B44F1C03F6AC3
        public async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup>> ListConsumerGroupsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.ConsumerGroups
                .ListByEventHubAsync(Ancestor().ResourceGroupName, Ancestor().Ancestor1Name, Name, cancellationToken);
        }

        ///GENMHASH:AE782FFCB25205E53537C597392EFE1B:EF8853628F07C590FFB57C6BA885CD36
        public IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubConsumerGroup> ListConsumerGroups()
        {
            return this.Manager.ConsumerGroups
                .ListByEventHub(Ancestor().ResourceGroupName, Ancestor().Ancestor1Name, Name);
        }

        ///GENMHASH:2FAF2208689547C6A4D62711AACA378B:57E558DB2C0858CA36A3547A98234A66
        public IEnumerable<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule> ListAuthorizationRules()
        {
            return this.Manager.EventHubAuthorizationRules
                .ListByEventHub(Ancestor().ResourceGroupName, Ancestor().Ancestor1Name, Name);
        }

        ///GENMHASH:362D73D3A0A345883DD0DA56D35DF38D:29653799632DB5FFEB4D55A8D05C3E8F
        public async Task<IPagedCollection<Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationRule>> ListAuthorizationRulesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.Manager.EventHubAuthorizationRules
            .ListByEventHubAsync(Ancestor().ResourceGroupName, Ancestor().Ancestor1Name, Name, cancellationToken);
        }

        ///GENMHASH:784B68605E207509447B184BA254B28A:672FDADCD18A3B2A31177B23B25B052D
        private OneAncestor Ancestor()
        {
            return this.ancestor ?? throw new ArgumentNullException("this.ancestor");
        }

        ///GENMHASH:BE19D5FA60872E55D3B07FEE99BE7B1F:10601432F6DDE1B223E1B12CAD395BCA
        private string SelfId(string parentId)
        {
            return $"{parentId}/eventhubs/{this.Name}";
        }
    }

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmV2ZW50aHViLmltcGxlbWVudGF0aW9uLkV2ZW50SHViSW1wbC5DYXB0dXJlU2V0dGluZ3M=
    internal partial class CaptureSettings 
    {
        private readonly IStorageManager storageManager;
        private readonly CaptureDescription currentSettings;
        private CaptureDescription newSettings;
        private IList<Func<CancellationToken, Task>> works;


        ///GENMHASH:4A2506B258DCD069BEF25E848169A42D:5FB10EA9887E2818CBB3F553DF9768CB
        internal CaptureSettings(EventhubInner eventhubInner, IStorageManager storageManager)
        {
            this.currentSettings = eventhubInner.CaptureDescription;
            this.storageManager = storageManager;
            this.works = new List<Func<CancellationToken, Task>>();
        }

        ///GENMHASH:FE78AAEC8A3F18AD3D30F2F674958269:7ED5AECE914463EEBA6B29669B365AA0
        internal CaptureSettings WithExistingStorageAccountForCapturedData(IStorageAccount storageAccount, string containerName)
        {
            this.EnsureSettings().Destination.StorageAccountResourceId = storageAccount.Id;
            this.EnsureSettings().Destination.BlobContainer = containerName;
            works.Add(async (CancellationToken cancellation) =>
            {
                await CreateContainerIfNotExistsAsync(storageAccount, containerName, cancellation);
            });
            return this;
        }

        ///GENMHASH:3A21C655B603C8713B6003EE2AFD58AA:466513B905978F143977319707CA3AD1
        internal CaptureSettings WithExistingStorageAccountForCapturedData(string storageAccountId, string containerName)
        {
            this.EnsureSettings().Destination.StorageAccountResourceId = storageAccountId;
            this.EnsureSettings().Destination.BlobContainer = containerName;
            works.Add(async (CancellationToken token) =>
            {
                var storageAccount = await storageManager.StorageAccounts.GetByIdAsync(storageAccountId, token);
                if (storageAccount == null)
                {
                    throw new ArgumentException($"Storage account with id {storageAccountId} not found (storing captured data)");
                }
                await CreateContainerIfNotExistsAsync(storageAccount, containerName, token);
            });
            return this;
        }


        ///GENMHASH:7EC7263977FF1ECADB7B046E165FF424:183CE50E3A3AA226A74F1F233B5BE50D
        internal CaptureSettings WithNewStorageAccountForCapturedData(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatableStorageAccount, string containerName)
        {
            this.EnsureSettings().Destination.StorageAccountResourceId = "temp-id";
            this.EnsureSettings().Destination.BlobContainer = containerName;
            works.Add(async (CancellationToken token) =>
            {
                var storageAccount = await creatableStorageAccount.CreateAsync(token);
                this.EnsureSettings().Destination.StorageAccountResourceId = storageAccount.Id;
                await CreateContainerIfNotExistsAsync(storageAccount, containerName, token);
            });
            return this;
        }

        ///GENMHASH:FE8D975AA8B56E2F7E79F9BC191E1B39:6E90B5C64576B4040AD09D7F3F7C8B31
        internal CaptureSettings WithDataCaptureFileNameFormat(string format)
        {
            this.EnsureSettings().Destination.ArchiveNameFormat = format;
            return this;
        }

        ///GENMHASH:A81E23E1FF99483D58C57E5A97A610EA:14234F4A9077957499905BAEABB0B9B4
        internal CaptureSettings WithDataCaptureWindowSizeInSeconds(int sizeInSeconds)
        {
            this.EnsureSettings().IntervalInSeconds = sizeInSeconds;
            return this;
        }

        ///GENMHASH:235045FA9E3B824D8ADBD207C00DD31B:07E5CF5808D9D2ED548A952E2FC2E0DD
        internal CaptureSettings WithDataCaptureDisabled()
        {
            this.EnsureSettings().Enabled = false;
            return this;
        }

        ///GENMHASH:7ACB98F534A2273DD4A204117C1CDCD1:3992DCFEAC4957FE34E4F83A2CE69716
        internal CaptureSettings WithDataCaptureEnabled()
        {
            this.EnsureSettings().Enabled = true;
            return this;
        }

        ///GENMHASH:5E917ACE2BE12A2264A269E5C7F593EA:9CDB6B59A9AA4C0DA24171E686EAD2FC
        internal CaptureSettings WithDataCaptureWindowSizeInMB(int sizeInMB)
        {
            this.EnsureSettings().SizeLimitInBytes = sizeInMB * 1024 * 1024;
            return this;
        }

        internal CaptureSettings WithDataCaptureSkipEmptyArchives(bool skipEmptyArchives)
        {
            this.EnsureSettings().SkipEmptyArchives = skipEmptyArchives;
            return this;
        }

        ///GENMHASH:B7E277DC1BCC6D83BABD97FDB2D04F28:DFBCF03C2F6DB7363E63D42008D83A0A
        internal CaptureDescription ValidateAndGetSettings()
        {
            if (this.newSettings == null)
            {
                return this.currentSettings;
            }
            else if (this.newSettings.Destination == null
                || this.newSettings.Destination.StorageAccountResourceId == null
                || this.newSettings.Destination.BlobContainer == null)
            {
                    throw new ArgumentException("Setting any of the capture properties requires capture destination [StorageAccount, DataLake] to be specified");
            }
            if (this.newSettings.Destination.Name == null)
            {
                this.newSettings.Destination.Name = "EventHubArchive.AzureBlockBlob";
            }
            if (this.newSettings.Encoding == null)
            {
                this.newSettings.Encoding = EncodingCaptureDescription.Avro;
            }
            return this.newSettings;
        }

        internal async Task PrepareCaptureStorageAsync(CancellationToken cancellationToken)
        {
            try
            {
                await Task.WhenAll(this.works.Select(p => p(cancellationToken)).ToArray());
            }
            finally
            {
                works.Clear();
            }
        }

        ///GENMHASH:E6B603961EBB7673A4FCE2FF57FFD887:3E9D667DC332932DBD8876ED30B87263
        private CaptureDescription EnsureSettings()
        {
            if (this.newSettings != null)
            {
                return this.newSettings;
            }
            else if (this.currentSettings == null)
            {
                this.newSettings = new CaptureDescription
                {
                    Destination = new Destination()
                };
                return this.newSettings;
            }
            else
            {
                // Clone the current settings to new settings (one time)
                //
                this.newSettings = CloneCurrentSettings();
                return this.newSettings;
            }
        }

        ///GENMHASH:ABF901A96C194317F2128DAAA2AC323A:E84AFD285616868A9D7189B18889D122
        private CaptureDescription CloneCurrentSettings()
        {
            if (this.currentSettings == null)
            {
                throw new ArgumentNullException("currentSettings");
            }

            CaptureDescription clone = new CaptureDescription
            {
                SizeLimitInBytes = this.currentSettings.SizeLimitInBytes,
                IntervalInSeconds = this.currentSettings.IntervalInSeconds,
                Enabled = this.currentSettings.Enabled,
                Encoding = this.currentSettings.Encoding
            };

            if (this.currentSettings.Destination != null)
            {
                clone.Destination = new Destination
                {
                    ArchiveNameFormat = this.currentSettings.Destination.ArchiveNameFormat,
                    BlobContainer = this.currentSettings.Destination.BlobContainer,
                    Name = this.currentSettings.Destination.Name,
                    StorageAccountResourceId = this.currentSettings.Destination.StorageAccountResourceId
                };
            }
            else
            {
                clone.Destination = new Destination();
            }
            return clone;
        }

        ///GENMHASH:E57B7C8F0964999B03C8233B7678D75F:35867B5C8AA1E69EFFB6625C59841587
        private async Task<CloudStorageAccount> GetCloudStorageAsync(IStorageAccount storageAccount, CancellationToken cancellationToken = default(CancellationToken))
        {
            var storageAccountKeys = await storageAccount.GetKeysAsync();
            var storageAccountkey = storageAccountKeys[0];
            return CloudStorageAccount.Parse($"DefaultEndpointsProtocol=https;AccountName={storageAccount.Name};AccountKey={storageAccountkey.Value};EndpointSuffix=core.Windows.net");
        }

        ///GENMHASH:D59639B51DEFFDBBB2553D41ECC9DE24:D0C118D05A212AC72DC19241D824872A
        private async Task<bool> CreateContainerIfNotExistsAsync(IStorageAccount storageAccount, string containerName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var cloudStorageAccount = await this.GetCloudStorageAsync(storageAccount, cancellationToken);
            var blobClient = cloudStorageAccount.CreateCloudBlobClient();
            var containerReference = blobClient.GetContainerReference(containerName);
            return await containerReference.CreateIfNotExistsAsync();
        }
    }
}