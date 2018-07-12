// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Locks.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Locks.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Text;
    using System;
    using System.Linq;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Implementation for ManagementLocks.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmxvY2tzLmltcGxlbWVudGF0aW9uLk1hbmFnZW1lbnRMb2Nrc0ltcGw=
    internal partial class ManagementLocksImpl :
        CreatableResources<IManagementLock, ManagementLockImpl, Models.ManagementLockObjectInner>,
        IManagementLocks
    {
        private IAuthorizationManager manager;

        ///GENMHASH:836797384EAD11F4F592C5C904884C2A:D544D70B59C64F2C67EC02DE16CBAEF6
        internal ManagementLocksImpl(IAuthorizationManager manager)
        {
            this.manager = manager;
        }

        IManagementLocksOperations IHasInner<IManagementLocksOperations>.Inner
        {
            get
            {
                return Inner();
            }
        }

        ///GENMHASH:B6961E0C7CB3A9659DE0E1489F44A936:168EFDB95EECDB98D4BDFCCA32101AC1
        public IAuthorizationManager Manager()
        {
            return manager;
        }

        #region Get

        ///GENMHASH:7D93B4EC99C64989F97B3D17F88C3F2C:45E96D80A053DE48AD3DD26FC5CD83FF
        public IManagementLock GetByResourceGroup(string resourceGroupName, string name)
        {
            return Extensions.Synchronize(() => GetByResourceGroupAsync(resourceGroupName, name));
        }

        ///GENMHASH:5002116800CBAC02BBC1B4BF62BC4942:E5DB8B81D366BCF6A1B75F4B1D85B1F1
        public IManagementLock GetById(string id)
        {
            return Extensions.Synchronize(() => GetByIdAsync(id));
        }

        ///GENMHASH:E776888E46F8A3FC56D24DF4A74E5B74:FC67528805BD588653B69DE503549F4C
        public async Task<IManagementLock> GetByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            string resourceId = ResourceIdFromLockId(id);
            string lockName = ResourceUtils.NameFromResourceId(id);
            IManagementLock l = null;
            if (resourceId != null && lockName != null)
            {
                l = WrapModel(await Inner().GetByScopeAsync(resourceId, lockName, cancellationToken));
            }
            return l;
        }

        ///GENMHASH:2B19D171A02814189E0329A91320316B:E509DF22AA2F28442E1D34ACD9FCD647
        public async Task<IManagementLock> GetByResourceGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return WrapModel(await Inner().GetAtResourceGroupLevelAsync(resourceGroupName, name, cancellationToken));
        }

        #endregion

        #region Delete

        public override void DeleteById(string id)
        {
            Extensions.Synchronize(() => DeleteByIdAsync(id));
        }

        ///GENMHASH:4D33A73A344E127F784620E76B686786:DF0ACE79B69D4230630060F3C796E8A9
        public async override Task DeleteByIdAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            string scope = ResourceIdFromLockId(id);
            string lockName = ResourceUtils.NameFromResourceId(id);
            if (scope != null && lockName != null)
            {
                await Inner().DeleteByScopeAsync(scope, lockName, cancellationToken);
            }
        }

        ///GENMHASH:782853D3A86D961975AF25BD353144CE:F42FD335BA3F56DE82610403C83DB1CD
        public async Task<IEnumerable<string>> DeleteByIdsAsync(IList<string> ids, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (ids == null || ids.Count == 0)
            {
                return new List<string>();
            }

            IEnumerable<Task<string>> tasks = new List<Task<string>>();
            List<string> ids1 = new List<string>();
            var tts = new List<Task>();

            foreach (var id in ids)
            {
                string lockName = ResourceUtils.NameFromResourceId(id);
                string scopeName = ResourceIdFromLockId(id);
                if (lockName != null && scopeName != null)
                {
                    tts.Add(Task.Run(async () =>
                    {
                        try
                        {
                            await Inner().DeleteByScopeAsync(scopeName, lockName, cancellationToken);
                        }
                        catch(CloudException)
                        {

                        }
                        ids1.Add(id);
                    }));
                }
            }

            await Task.WhenAll(tts);
            return ids1;
        }

        ///GENMHASH:6761F083A3838E34703AD0305B873679:E05AE73A1CA90E964ED86C07093D463F
        public async Task<IEnumerable<string>> DeleteByIdsAsync(string[] ids, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await DeleteByIdsAsync(new List<string>(ids), cancellationToken);
        }

        ///GENMHASH:8B5750E68FCC626D3009EA1EAACB3C16:8E4631EFC6068BB521E67D3178D6E7B8
        public void DeleteByIds(IList<string> ids)
        {
            Extensions.Synchronize(() => DeleteByIdsAsync(ids));
        }

        ///GENMHASH:F65FF3868FDEB2B4896429AE1A0F14F4:8E4631EFC6068BB521E67D3178D6E7B8
        public void DeleteByIds(params string[] ids)
        {
            Extensions.Synchronize(() => DeleteByIdsAsync(ids));
        }

        ///GENMHASH:DE94604AE39A5722E2DA0AC4017FC2B9:EAFF99EE2BE784A51EF82B7277636D2B
        public void DeleteByResourceGroup(string resourceGroupName, string name)
        {
            Extensions.Synchronize(() => DeleteByResourceGroupAsync(resourceGroupName, name));
        }

        ///GENMHASH:9D38835F71DF2C39BF88CBB588420D30:FD7FA95DB661326602615F08FEA599EC
        public async Task DeleteByResourceGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner().DeleteAtResourceGroupLevelAsync(resourceGroupName, name, cancellationToken);
        }

        #endregion

        #region List

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:EFF74B68F06CBC4611C3EEE115E1A032
        public IEnumerable<IManagementLock> List()
        {
            return WrapList(Extensions.Synchronize(() => Inner().ListAtSubscriptionLevelAsync()));
        }

        ///GENMHASH:7F5BEBF638B801886F5E13E6CCFF6A4E:0984AC2110E1EAA73B752279C293E987
        public async Task<IPagedCollection<IManagementLock>> ListAsync(bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IManagementLock, ManagementLockObjectInner>.LoadPage(
                async (cancellation) => await Inner().ListAtSubscriptionLevelAsync(null, cancellationToken),
                Inner().ListAtSubscriptionLevelNextAsync,
                WrapModel,
                loadAllPages,
                cancellationToken);
        }

        ///GENMHASH:9C5B42FF47E71D8582BAB26BBDEC1E0B:6A20423BC9EF8328BE93DB0B8D897A58
        public async Task<IPagedCollection<IManagementLock>> ListByResourceGroupAsync(string resourceGroupName, bool loadAllPages = true, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IManagementLock, ManagementLockObjectInner>.LoadPage(
                async (cancellation) => await Inner().ListAtResourceGroupLevelAsync(resourceGroupName, null, cancellationToken),
                Inner().ListAtResourceLevelNextAsync,
                WrapModel,
                loadAllPages,
                cancellationToken);
        }

        ///GENMHASH:B41D0AFC2CE2E06B4071C02D9A475F18:3920DBCA07E0C928C7377009441C02F1
        public IEnumerable<IManagementLock> ListForResource(string resourceId)
        {
            var inners = Extensions.Synchronize(() => Inner().ListAtResourceLevelAsync(
                ResourceUtils.GroupFromResourceId(resourceId),
                ResourceUtils.ResourceProviderFromResourceId(resourceId),
                ResourceUtils.ParentRelativePathFromResourceId(resourceId),
                ResourceUtils.ResourceTypeFromResourceId(resourceId),
                ResourceUtils.NameFromResourceId(resourceId)));
            return WrapList(inners);
        }

        ///GENMHASH:75FEDF335D513029A4BA866C3E6BE131:B6A4EBD0DC3C36F9588173D7B2A63BA9
        public async Task<IPagedCollection<IManagementLock>> ListForResourceAsync(string resourceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await PagedCollection<IManagementLock, ManagementLockObjectInner>.LoadPage(
                async (cancellation) => await Inner().ListAtResourceLevelAsync(
                    ResourceUtils.GroupFromResourceId(resourceId),
                    ResourceUtils.ResourceProviderFromResourceId(resourceId),
                    ResourceUtils.ParentRelativePathFromResourceId(resourceId),
                    ResourceUtils.ResourceTypeFromResourceId(resourceId),
                    ResourceUtils.NameFromResourceId(resourceId),
                    null,
                    cancellationToken),
                Inner().ListAtResourceLevelNextAsync,
                WrapModel,
                false,
                cancellationToken);
        }

        ///GENMHASH:178BF162835B0E3978203EDEF988B6EB:2AF1AED874591A3A597F23BBE3B7C5CD
        public IEnumerable<IManagementLock> ListByResourceGroup(string resourceGroupName)
        {
            return WrapList(Extensions.Synchronize(() => Inner().ListAtResourceGroupLevelAsync(resourceGroupName)));
        }

        #endregion

        ///GENMHASH:CDBF9872F7A9C39DD4A1208B299D0D3E:133DC84E85B4401A0AB6374FF91C26A8
        internal static string[] LockIdParts(string lockId)
        {
            if (lockId == null)
            {
                return null;
            }

            // Format examples:
            // /subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/anu-abc/providers/Microsoft.Authorization/locks/lock-1
            // /subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/anu-abc/providers/Microsoft.Storage/storageAccounts/anustg234/providers/Microsoft.Authorization/locks/lock-2

            var parts = lockId.Split('/');
            if (parts.Length < 4)
            {
                // ID too short to be possibly a lock ID
                return null;
            }
            else if (!parts[parts.Length - 2].Equals("locks", StringComparison.OrdinalIgnoreCase)
                || !parts[parts.Length - 3].Equals("Microsoft.Authorization", StringComparison.OrdinalIgnoreCase)
                || !parts[parts.Length - 4].Equals("providers", StringComparison.OrdinalIgnoreCase))
            {
                // Not a lock ID
                return null;
            }
            else
            {
                return parts;
            }
        }

        /// <summary>
        /// Returns the part of the specified management lock resource ID representing the resource the lock is associated with.
        /// </summary>
        /// <param name="lockId">A lock resource ID.</param>
        /// <return>A resource ID.</return>
        ///GENMHASH:22CE38B390E4B2A046F6AA5EE62DD739:5AC7B757940FA1BFC39F298158A50C9B
        public static string ResourceIdFromLockId(string lockId)
        {
            var lockIdParts = LockIdParts(lockId);
            if (lockIdParts == null)
            {
                return null;
            }

            StringBuilder resourceId = new StringBuilder();
            for (int i = 0; i < lockIdParts.Length - 4; i++)
            {
                if (lockIdParts[i] != string.Empty) {
                    resourceId.Append("/").Append(lockIdParts[i]);
                }
            }
            return resourceId.ToString();
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:1623EDA2C355562842B44FD2E687707B
        public IManagementLocksOperations Inner()
        {
            return manager.Inner.ManagementLocks;
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public ManagementLockImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:56A9C5490F20084DBFD636B932B7F06B
        protected override ManagementLockImpl WrapModel(string name)
        {
            return new ManagementLockImpl(name, new ManagementLockObjectInner(), Manager());
        }

        ///GENMHASH:A461D6864EB7CB1DB406AFD2F9FFEF86:475DF4B0DBDD12D825C5DB54678ADA4A
        protected override IManagementLock WrapModel(ManagementLockObjectInner inner)
        {
            return (inner != null) ? new ManagementLockImpl(inner.Id, inner, Manager()) : null;
        }
    }
}
