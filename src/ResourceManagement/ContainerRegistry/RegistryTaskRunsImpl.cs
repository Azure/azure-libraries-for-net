// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistryTaskRun.Definition;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLlJlZ2lzdHJ5VGFza1J1bnNJbXBs
    internal partial class RegistryTaskRunsImpl  :
        IRegistryTaskRuns
    {
        private IRegistryManager registryManager;

        ///GENMHASH:C20A4C6092C094D9F582AF41A61BBEEE:6BB7F98668B697E6F973980EB0493963
        internal  RegistryTaskRunsImpl(IRegistryManager registryManager)
        {
            this.registryManager = registryManager;
        }

        ///GENMHASH:E444E59EA6E339F222A60E48B613B03A:556B0668F654DBF4EB9E776753D9FBD5
        private RegistryTaskRunImpl WrapModel(RunInner innerModel)
        {
            return new RegistryTaskRunImpl(registryManager, innerModel);
        }

        ///GENMHASH:286B40EBA6A05A24D1D9720506FFAB9D:46F6E9247619AF0F83FC15022EE6518C
        public void Cancel(string rgName, string acrName, string runId)
        {
            Extensions.Synchronize(() => this.CancelAsync(rgName, acrName, runId));
        }

        ///GENMHASH:6FD155057CF118F88E3285A7802F4B73:A6FE5A885DEB4B230148979B61F43C00
        public async Task CancelAsync(string rgName, string acrName, string runId, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.registryManager.Inner.Runs.CancelAsync(rgName, acrName, runId, cancellationToken);
        }

        ///GENMHASH:94129ECC754C1DD1EF1772B248EEF720:067DB1343479056F45EE26CC0DB448F2
        public string GetLogSasUrl(string rgName, string acrName, string runId)
        {
            return Extensions.Synchronize(() => this.GetLogSasUrlAsync(rgName, acrName, runId));
        }

        ///GENMHASH:E269B7C09CAB19AB090C1AD23FF7DDCC:BBEE9E56843C1D9DB9509969290C9257
        public async Task<string> GetLogSasUrlAsync(string rgName, string acrName, string runId, CancellationToken cancellationToken = default(CancellationToken))
        {
            RunGetLogResultInner runGetLogResultInner = await this.registryManager.Inner.Runs.GetLogSasUrlAsync(rgName, acrName, runId, cancellationToken);
            return runGetLogResultInner.LogLink;
        }

        ///GENMHASH:FCBF9C2437A6D098F5E7317EDABA98B2:1DAD16A5835B56CBCD48685D7E7AC6F2
        public IEnumerable<Microsoft.Azure.Management.ContainerRegistry.Fluent.IRegistryTaskRun> ListByRegistry(string rgName, string acrName)
        {
            return Extensions.Synchronize(() => ListByRegistryAsync(rgName, acrName));
        }

        ///GENMHASH:41B994B3002BFC0F257FFEC7D6C8CE3C:2AC273AE2283F4A49BA7BAA7A6D655D1
        public async Task<IPagedCollection<IRegistryTaskRun>> ListByRegistryAsync(string rgName, string acrName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IRegistryTaskRun, RunInner>.LoadPage(
                async (cancellation) => await this.registryManager.Inner.Runs.ListAsync(rgName, acrName, null, cancellation),
                this.registryManager.Inner.Runs.ListNextAsync,
                WrapModel,
                loadAllPages,
                cancellationToken);
        }

        ///GENMHASH:697DA3A2AFA39E4F1F646DF4F73DE4A6:AA46C10739FBB862B264D83802CF6440
        public IBlankFromRuns ScheduleRun()
        {
            return new RegistryTaskRunImpl(registryManager, new RunInner());
        }
    }
}