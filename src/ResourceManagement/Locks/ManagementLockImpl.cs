// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Locks.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Definition;
    using Microsoft.Azure.Management.Locks.Fluent.ManagementLock.Update;
    using Microsoft.Azure.Management.Locks.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System;

    /// <summary>
    /// Implementation for ManagementLock and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmxvY2tzLmltcGxlbWVudGF0aW9uLk1hbmFnZW1lbnRMb2NrSW1wbA==
    internal partial class ManagementLockImpl  :
        CreatableUpdatable<IManagementLock, ManagementLockObjectInner, ManagementLockImpl, IHasId, IUpdate>,
        IManagementLock,
        IDefinition,
        IUpdate
    {
        private IAuthorizationManager manager;
        private string lockedResourceId;

        ///GENMHASH:47161CA708999022D4C72DB9BA286AEA:F8A1098E1FC48E04FD33C0945B9D9CA4
        internal  ManagementLockImpl(string name, ManagementLockObjectInner innerModel, IAuthorizationManager lockManager) : base(name, innerModel)
        {
            manager = lockManager;
        }

        ///GENMHASH:2A0A00CDCDBE85E76A744476D9C5DE6A:9F9412F9297C15DDB4651FEEA8C44DAF
        public string Notes()
        {
            return Inner.Notes;
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:168EFDB95EECDB98D4BDFCCA32101AC1
        public IAuthorizationManager Manager()
        {
            return manager;
        }

        ///GENMHASH:76EDE6DBF107009D2B06F19698F6D5DB:19C4BD8FCE58F39FC1CCEB1A6C862717
        public bool IsInCreateMode()
        {
            return Inner.Id == null;
        }

        ///GENMHASH:CDB75282F99C92A566E39254F670EF12:9FAE75E920E3F72AB54825C7B6562D8A
        public LockLevel Level()
        {
            return LockLevel.Parse(Inner.Level);
        }

        ///GENMHASH:27F1B3D7EB2E0F91AF83173279E7FA96:9C9831FCEC83B409757383F3CDF99744
        public ManagementLockImpl WithLevel(LockLevel level)
        {
            Inner.Level = level.Value;
            return this;
        }

        ///GENMHASH:5AD91481A0966B059A478CD4E9DD9466:2252977E8E81E15955133EF4D9829EDE
        protected override async Task<ManagementLockObjectInner> GetInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await manager.Inner.ManagementLocks.GetByScopeAsync(LockedResourceId(), Name, cancellationToken);
        }

        ///GENMHASH:3513A533142751151F1DDB6B852F4240:71F7EAA1F4FF7E923EAB47041E86EE95
        public string LockedResourceId()
        {
            return ManagementLocksImpl.ResourceIdFromLockId(Inner.Id);
        }

        ///GENMHASH:867D0AD83A8AC8B1EFD41E588EFD1B10:5C819CC1AD65107E63CACA90ABF9FDE9
        public ManagementLockImpl WithNotes(string notes)
        {
            Inner.Notes = notes;
            return this;
        }

        ///GENMHASH:5ADDF35879E44C64A314E1510333AEFC:9685C9E48A54BFEB8A0B16BB6516EF6B
        public ManagementLockImpl WithLockedResourceGroup(string resourceGroupName)
        {
            return WithLockedResource("/subscriptions/" + Manager().SubscriptionId + "/resourceGroups/" + resourceGroupName);
        }

        ///GENMHASH:D5B5CE2DFAF050C55CE88CAC28B76A44:0F92E54F7B9C66E5DD4A807996D1C453
        public ManagementLockImpl WithLockedResourceGroup(IResourceGroup resourceGroup)
        {
            if (resourceGroup != null)
            {
                lockedResourceId = resourceGroup.Id;
            }
            else
            {
                throw new ArgumentNullException("Missing resource group ID.");
            }
            return this;
        }

        ///GENMHASH:95B80667BF3C81739CB667CDDB0B7B66:0AAB3F24F56D0718E73FEF49C5867A7A
        public ManagementLockImpl WithLockedResource(string resourceId)
        {
            lockedResourceId = resourceId;
            return this;
        }

        ///GENMHASH:3DB048A774BDDD8AB4F32397049EFAD5:6F4641C5943A4F8DDFC0F91479FFFB4E
        public ManagementLockImpl WithLockedResource(IResource resource)
        {
            if (resource != null)
            {
                lockedResourceId = resource.Id;
            }
            else
            {
                throw new ArgumentNullException("Missing resource ID.");
            }
            return this;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return Inner.Id;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:B25D1A2293FFAAEA018C81BC35FAA9F3
        public override async Task<IManagementLock> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var inner = await Manager().Inner.ManagementLocks.CreateOrUpdateByScopeAsync(lockedResourceId, Name, Inner, cancellationToken);
            SetInner(inner);
            return this;
        }
    }
}