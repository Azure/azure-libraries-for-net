// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerInstance.Fluent
{
    using Microsoft.Azure.Management.ContainerInstance.Fluent.Models;
    using Microsoft.Azure.Management.ContainerInstance.Fluent.ContainerGroup.Definition;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for container group's volume definition stages interface.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcmluc3RhbmNlLmltcGxlbWVudGF0aW9uLlZvbHVtZUltcGw=
    internal partial class VolumeImpl :
        IVolumeDefinition<ContainerGroup.Definition.IWithVolume>
    {
        private Volume innerVolume;
        private ContainerGroupImpl parent;

        ///GENMHASH:58AD2109DE49A21089D219327AB34729:A24F436CF7F24D91E89F7155872C668C
        internal VolumeImpl(ContainerGroupImpl parent, string volumeName)
        {
            this.parent = parent;
            this.innerVolume = new Volume { Name = volumeName };
        }

        ///GENMHASH:1D5A37DFB991B90DE83B301E1FCB379E:025288B52D0EDDFBEC55734236D78DEC
        public VolumeImpl WithStorageAccountName(string storageAccountName)
        {
            var azureFileVolume = this.EnsureAzureFileVolume();
            azureFileVolume.StorageAccountName = storageAccountName;

            return this;
        }

        ///GENMHASH:5119FFB804FCA8B0C4EE81F99B57C5C0:ABF544BF72627CBE85238805F5B9E871
        public VolumeImpl WithGitUrl(string gitUrl)
        {
            this.innerVolume.GitRepo = new GitRepoVolume();
            this.innerVolume.GitRepo.Repository = gitUrl;

            return this;
        }

        ///GENMHASH:9698E538C219A650EEA3DBBA01FC5C1B:A449899983D0C3D7AEFDFF4ED8FB04AE
        public VolumeImpl WithGitDirectoryName(string gitDirectoryName)
        {
            if (this.innerVolume.GitRepo == null)
            {
                this.innerVolume.GitRepo = new GitRepoVolume();
            }
            this.innerVolume.GitRepo.Directory = gitDirectoryName;

            return this;
        }

        ///GENMHASH:08692DD2A9C6AAF727D8397DABB4C833:54E9F65BD3A7D18DD3409B3AEFFF8EA5
        public VolumeImpl WithGitRevision(string gitRevision)
        {
            if (this.innerVolume.GitRepo == null)
            {
                this.innerVolume.GitRepo = new GitRepoVolume();
            }
            this.innerVolume.GitRepo.Revision = gitRevision;

            return this;
        }

        ///GENMHASH:C3BEE33E51121CBAF2861DB3C9FE8E00:FD1669E86C4F7C3C91337F9EBBB7A285
        public VolumeImpl WithStorageAccountKey(string storageAccountKey)
        {
            var azureFileVolume = this.EnsureAzureFileVolume();
            azureFileVolume.StorageAccountKey = storageAccountKey;

            return this;
        }

        ///GENMHASH:9467EFF6B0BC2CE3447C4AAC840262AE:8FDCDE287ED3A18DF7EE774EC05B2634
        public VolumeImpl WithExistingReadWriteAzureFileShare(string shareName)
        {
            var azureFileVolume = this.EnsureAzureFileVolume();
            azureFileVolume.ShareName = shareName;
            azureFileVolume.ReadOnlyProperty = false;

            return this;
        }

        ///GENMHASH:F75F8EB1FB5E69A3305EC890FAE92837:21284A740F71497AF7DB2358141743F9
        public VolumeImpl WithExistingReadOnlyAzureFileShare(string shareName)
        {
            var azureFileVolume = this.EnsureAzureFileVolume();
            azureFileVolume.ShareName = shareName;
            azureFileVolume.ReadOnlyProperty = true;

            return this;
        }

        ///GENMHASH:A277DF005889B3EFB297E1BD1948FD0F:929D27DCF79FAF83EBF014C36E5605C0
        public VolumeImpl WithSecrets(IDictionary<string,string> secrets)
        {
            this.innerVolume.Secret = secrets;

            return this;
        }

        ///GENMHASH:806528B4E8306F96D8D8B59FBEEC50D9:92DE3D44A00B96B446737E32FB695D1A
        private AzureFileVolume EnsureAzureFileVolume()
        {
            if (innerVolume.AzureFile == null)
            {
                innerVolume.AzureFile = new AzureFileVolume();
            }

            return innerVolume.AzureFile;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:9F82274A47A307BCD4EFC0D2AFD33F1B
        public ContainerGroupImpl Attach()
        {
            if (parent.Inner.Volumes == null)
            {
                parent.Inner.Volumes = new List<Volume>();
            }
            parent.Inner.Volumes.Add(innerVolume);

            return parent;
        }
    }
}