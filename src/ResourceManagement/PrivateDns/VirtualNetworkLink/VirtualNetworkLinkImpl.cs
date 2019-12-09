// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    using Microsoft.Azure.Management.PrivateDns.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class VirtualNetworkLinkImpl :
        ExternalChildResource<IVirtualNetworkLink, VirtualNetworkLinkInner, IPrivateDnsZone, PrivateDnsZoneImpl>,
        IVirtualNetworkLink,
        VirtualNetworkLink.Definition.IDefinition<PrivateDnsZone.Definition.IWithCreate>,
        VirtualNetworkLink.UpdateDefinition.IUpdateDefinition<PrivateDnsZone.Update.IUpdate>,
        VirtualNetworkLink.Update.IUpdate
    {
        private ETagState eTagState = new ETagState();
        private VirtualNetworkLinkInner dataToRemove;
        internal VirtualNetworkLinkImpl(PrivateDnsZoneImpl parent, VirtualNetworkLinkInner innerModel)
            : base(innerModel.Name, parent, innerModel)
        {
            dataToRemove = new VirtualNetworkLinkInner()
            {
                Tags = new Dictionary<string, string>()
            };
        }

        internal static VirtualNetworkLinkImpl NewVirtualNetworkLink(string name, PrivateDnsZoneImpl parent)
        {
            return new VirtualNetworkLinkImpl(
                parent,
                new VirtualNetworkLinkInner(name: name, location:"global"));
        }

        /// <summary>
        /// Gets the etag associated with the virtual network link.
        /// </summary>
        public string ETag
        {
            get
            {
                return Inner.Etag;
            }
        }

        /// <summary>
        /// Gets the ID of referenced virtual network.
        /// </summary>
        public string ReferencedVirtualNetworkId
        {
            get
            {
                return Inner.VirtualNetwork == null ? null : Inner.VirtualNetwork.Id;
            }
        }

        /// <summary>
        /// Gets the flag whether auto-registration of virtual machine records in the
        /// virtual network in the Private DNS zone is enabled.
        /// </summary>
        public bool IsAutoRegistrationEnabled
        {
            get
            {
                return Inner.RegistrationEnabled.HasValue ? Inner.RegistrationEnabled.Value : false;
            }
        }

        /// <summary>
        /// Gets the status of the virtual network link to the Private DNS zone.
        /// </summary>
        public VirtualNetworkLinkState VirtualNetworkLinkState
        {
            get
            {
                return Inner.VirtualNetworkLinkState;
            }
        }

        /// <summary>
        /// Gets the provisioning state of the virtual network link.
        /// </summary>
        public ProvisioningState ProvisioningState
        {
            get
            {
                return Inner.ProvisioningState;
            }
        }

        /// <summary>
        /// Gets resource ID of the record set.
        /// </summary>
        public string Id
        {
            get
            {
                return Inner.Id;
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        PrivateDnsZone.Definition.IWithCreate ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<PrivateDnsZone.Definition.IWithCreate>.Attach()
        {
            return Parent;
        }

        public override async Task<IVirtualNetworkLink> CreateAsync(CancellationToken cancellationToken)
        {
            return await CreateOrUpdateAsync(Inner, cancellationToken);
        }

        public override async Task DeleteAsync(CancellationToken cancellationToken)
        {
            await Parent.Manager.Inner.VirtualNetworkLinks.DeleteAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                Name(),
                ifMatch: eTagState.IfMatchValueOnDelete(),
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Disables auto-registration for virtual network records.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkLink.Definition.IWithAttach<PrivateDnsZone.Definition.IWithCreate> VirtualNetworkLink.Definition.IWithAutoRegistration<PrivateDnsZone.Definition.IWithCreate>.DisableAutoRegistration()
        {
            return DisableAutoRegistrationInternal();
        }

        /// <summary>
        /// Enables auto-registration for virtual network records.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkLink.Definition.IWithAttach<PrivateDnsZone.Definition.IWithCreate> VirtualNetworkLink.Definition.IWithAutoRegistration<PrivateDnsZone.Definition.IWithCreate>.EnableAutoRegistration()
        {
            return EnableAutoRegistrationInternal();
        }

        public override async Task<IVirtualNetworkLink> UpdateAsync(CancellationToken cancellationToken)
        {
            var resource = await Parent.Manager.Inner.VirtualNetworkLinks.GetAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                Name(),
                cancellationToken);
            PrepareForUpdate(resource);
            return await CreateOrUpdateAsync(resource, cancellationToken);
        }

        private void PrepareForUpdate(VirtualNetworkLinkInner resource)
        {
            if(Inner.RegistrationEnabled != null)
            {
                resource.RegistrationEnabled = Inner.RegistrationEnabled;
            }
            if(Inner.Tags != null && Inner.Tags.Count > 0)
            {
                if(resource.Tags == null)
                {
                    resource.Tags = new Dictionary<string, string>();
                }
                foreach (var key in Inner.Tags.Keys)
                {
                    resource.Tags.Add(key, Inner.Tags[key]);
                }
            }
            if(dataToRemove.Tags.Count > 0)
            {
                foreach (var key in dataToRemove.Tags.Keys)
                {
                    resource.Tags.Remove(key);
                }
            }
        }

        /// <summary>
        /// Specifies If-None-Match header to prevent updating an existing virtual network link.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkLink.Definition.IWithAttach<PrivateDnsZone.Definition.IWithCreate> VirtualNetworkLink.Definition.IWithETagCheck<PrivateDnsZone.Definition.IWithCreate>.WithETagCheck()
        {
            return WithETagCheckInternal();
        }

        /// <summary>
        /// Specifies to set the reference of virtual network with value of ID.
        /// </summary>
        /// <param name="referencedVirtualNetworkId">The value of reference virtual network ID.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkLink.Definition.IWithAttach<PrivateDnsZone.Definition.IWithCreate> VirtualNetworkLink.Definition.IWithReferenceVirtualNetwork<PrivateDnsZone.Definition.IWithCreate>.WithReferencedVirtualNetworkId(string referencedVirtualNetworkId)
        {
            return WithReferencedVirtualNetworkIdInternal(referencedVirtualNetworkId);
        }

        /// <summary>
        /// Specifies where the virtual network link lives.
        /// </summary>
        /// <param name="regionName">The value of region name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkLink.Definition.IWithAttach<PrivateDnsZone.Definition.IWithCreate> VirtualNetworkLink.Definition.IWithRegion<PrivateDnsZone.Definition.IWithCreate>.WithRegion(string regionName)
        {
            return WithRegionInternal(regionName);
        }

        /// <summary>
        /// Specifies where the virtual network link lives.
        /// </summary>
        /// <param name="region">The value of region.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkLink.Definition.IWithAttach<PrivateDnsZone.Definition.IWithCreate> VirtualNetworkLink.Definition.IWithRegion<PrivateDnsZone.Definition.IWithCreate>.WithRegion(Region region)
        {
            return WithRegionInternal(region);
        }

        /// <summary>
        /// Specifies to add a tag to the virtual network link.
        /// </summary>
        /// <param name="key">the key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkLink.Definition.IWithAttach<PrivateDnsZone.Definition.IWithCreate> VirtualNetworkLink.Definition.IWithTags<PrivateDnsZone.Definition.IWithCreate>.WithTag(string key, string value)
        {
            return WithTagInternal(key, value);
        }

        /// <summary>
        /// Specifies the tags of virtual network link.
        /// </summary>
        /// <param name="tags">The value of tags.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkLink.Definition.IWithAttach<PrivateDnsZone.Definition.IWithCreate> VirtualNetworkLink.Definition.IWithTags<PrivateDnsZone.Definition.IWithCreate>.WithTags(IDictionary<string, string> tags)
        {
            return WithTagsInternal(tags);
        }

        protected override async Task<VirtualNetworkLinkInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Parent.Manager.Inner.VirtualNetworkLinks.GetAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                Name(),
                cancellationToken);
        }

        /// <summary>
        /// Attaches the child update to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent update.</return>
        PrivateDnsZone.Update.IUpdate ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<PrivateDnsZone.Update.IUpdate>.Attach()
        {
            return Parent;
        }

        /// <summary>
        /// Enables auto-registration for virtual network records.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkLink.UpdateDefinition.IWithAttach<PrivateDnsZone.Update.IUpdate> VirtualNetworkLink.UpdateDefinition.IWithAutoRegistration<PrivateDnsZone.Update.IUpdate>.EnableAutoRegistration()
        {
            return EnableAutoRegistrationInternal();
        }

        /// <summary>
        /// Disables auto-registration for virtual network records.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkLink.UpdateDefinition.IWithAttach<PrivateDnsZone.Update.IUpdate> VirtualNetworkLink.UpdateDefinition.IWithAutoRegistration<PrivateDnsZone.Update.IUpdate>.DisableAutoRegistration()
        {
            return DisableAutoRegistrationInternal();
        }

        /// <summary>
        /// Specifies If-None-Match header to prevent updating an existing virtual network link.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkLink.UpdateDefinition.IWithAttach<PrivateDnsZone.Update.IUpdate> VirtualNetworkLink.UpdateDefinition.IWithETagCheck<PrivateDnsZone.Update.IUpdate>.WithETagCheck()
        {
            return WithETagCheckInternal();
        }

        /// <summary>
        /// Specifies to set the reference of virtual network with value of ID.
        /// </summary>
        /// <param name="referencedVirtualNetworkId">The value of reference virtual network ID.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkLink.UpdateDefinition.IWithAttach<PrivateDnsZone.Update.IUpdate> VirtualNetworkLink.UpdateDefinition.IWithReferenceVirtualNetwork<PrivateDnsZone.Update.IUpdate>.WithReferencedVirtualNetworkId(string referencedVirtualNetworkId)
        {
            return WithReferencedVirtualNetworkIdInternal(referencedVirtualNetworkId);
        }

        /// <summary>
        /// Specifies where the virtual network link lives.
        /// </summary>
        /// <param name="regionName">The value of region name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkLink.UpdateDefinition.IWithAttach<PrivateDnsZone.Update.IUpdate> VirtualNetworkLink.UpdateDefinition.IWithRegion<PrivateDnsZone.Update.IUpdate>.WithRegion(string regionName)
        {
            return WithRegionInternal(regionName);
        }

        /// <summary>
        /// Specifies where the virtual network link lives.
        /// </summary>
        /// <param name="region">The value of region.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkLink.UpdateDefinition.IWithAttach<PrivateDnsZone.Update.IUpdate> VirtualNetworkLink.UpdateDefinition.IWithRegion<PrivateDnsZone.Update.IUpdate>.WithRegion(Region region)
        {
            return WithRegionInternal(region);
        }

        /// <summary>
        /// Specifies the tags of virtual network link.
        /// </summary>
        /// <param name="tags">The value of tags.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkLink.UpdateDefinition.IWithAttach<PrivateDnsZone.Update.IUpdate> VirtualNetworkLink.UpdateDefinition.IWithTags<PrivateDnsZone.Update.IUpdate>.WithTags(IDictionary<string, string> tags)
        {
            return WithTagsInternal(tags);
        }

        /// <summary>
        /// Specifies to add a tag to the virtual network link.
        /// </summary>
        /// <param name="key">the key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the definition.</return>
        VirtualNetworkLink.UpdateDefinition.IWithAttach<PrivateDnsZone.Update.IUpdate> VirtualNetworkLink.UpdateDefinition.IWithTags<PrivateDnsZone.Update.IUpdate>.WithTag(string key, string value)
        {
            return WithTagInternal(key, value);
        }

        PrivateDnsZone.Update.IUpdate ResourceManager.Fluent.Core.ChildResourceActions.ISettable<PrivateDnsZone.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        /// <summary>
        /// Enables auto-registration for virtual network records.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualNetworkLink.Update.IUpdate VirtualNetworkLink.Update.IWithAutoRegistration.EnableAutoRegistration()
        {
            return EnableAutoRegistrationInternal();
        }

        /// <summary>
        /// Disables auto-registration for virtual network records.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualNetworkLink.Update.IUpdate VirtualNetworkLink.Update.IWithAutoRegistration.DisableAutoRegistration()
        {
            return DisableAutoRegistrationInternal();
        }

        /// <summary>
        /// Specifies If-Match header to the current eTag value associated with the virtual network link.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualNetworkLink.Update.IUpdate VirtualNetworkLink.Update.IWithETagCheck.WithETagCheck()
        {
            return WithETagCheckInternal();
        }

        /// <summary>
        /// Specifies If-Match header to the given eTag value.
        /// </summary>
        /// <param name="eTagValue">The eTag value.</param>
        /// <return>The next stage of the update.</return>
        VirtualNetworkLink.Update.IUpdate VirtualNetworkLink.Update.IWithETagCheck.WithETagCheck(string eTagValue)
        {
            eTagState.WithExplicitETagCheckOnUpdate(eTagValue);
            return this;
        }

        /// <summary>
        /// Specifies the tags of virtual network link.
        /// </summary>
        /// <param name="tags">The value of tags.</param>
        /// <return>The next stage of the update.</return>
        VirtualNetworkLink.Update.IUpdate VirtualNetworkLink.Update.IWithTags.WithTags(IDictionary<string, string> tags)
        {
            return WithTagsInternal(tags);
        }

        /// <summary>
        /// Specifies to add a tag to the virtual network link.
        /// </summary>
        /// <param name="key">the key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the update.</return>
        VirtualNetworkLink.Update.IUpdate VirtualNetworkLink.Update.IWithTags.WithTag(string key, string value)
        {
            return WithTagInternal(key, value);
        }

        /// <summary>
        /// Removes a tag from the virtual network link.
        /// </summary>
        /// <param name="key">the key for the tag to remove.</param>
        /// <return>The next stage of the update.</return>
        VirtualNetworkLink.Update.IUpdate VirtualNetworkLink.Update.IWithTags.WithoutTag(string key)
        {
            dataToRemove.Tags.Add(key, null);
            return this;
        }

        private async Task<IVirtualNetworkLink> CreateOrUpdateAsync(VirtualNetworkLinkInner resource, CancellationToken cancellationToken)
        {
            VirtualNetworkLinkInner inner = await Parent.Manager.Inner.VirtualNetworkLinks.CreateOrUpdateAsync(
                Parent.ResourceGroupName,
                Parent.Name,
                Name(),
                resource,
                ifMatch: eTagState.IfMatchValueOnUpdate(resource.Etag),
                ifNoneMatch: eTagState.IfNonMatchValueOnCreate(),
                cancellationToken: cancellationToken);
            SetInner(inner);
            eTagState.Clear();
            return this;
        }

        internal VirtualNetworkLinkImpl WithETagOnDelete(string eTagValue)
        {
            eTagState.WithExplicitETagCheckOnDelete(eTagValue);
            return this;
        }

        private VirtualNetworkLinkImpl EnableAutoRegistrationInternal()
        {
            Inner.RegistrationEnabled = true;
            return this;
        }

        private VirtualNetworkLinkImpl DisableAutoRegistrationInternal()
        {
            Inner.RegistrationEnabled = false;
            return this;
        }

        private VirtualNetworkLinkImpl WithETagCheckInternal()
        {
            eTagState.WithImplicitETagCheckOnCreate();
            eTagState.WithImplicitETagCheckOnUpdate();
            return this;
        }

        private VirtualNetworkLinkImpl WithReferencedVirtualNetworkIdInternal(string referencedVirtualNetworkId)
        {
            Inner.VirtualNetwork = new ResourceManager.Fluent.SubResource(referencedVirtualNetworkId );
            return this;
        }

        private VirtualNetworkLinkImpl WithRegionInternal(string regionName)
        {
            Inner.Location = regionName;
            return this;
        }

        private VirtualNetworkLinkImpl WithRegionInternal(Region region)
        {
            Inner.Location = region == null ? null : region.Name;
            return this;
        }

        private VirtualNetworkLinkImpl WithTagsInternal(IDictionary<string, string> tags)
        {
            Inner.Tags = tags;
            return this;
        }

        private VirtualNetworkLinkImpl WithTagInternal(string key, string value)
        {
            if(Inner.Tags == null)
            {
                Inner.Tags = new Dictionary<string, string>();
            }
            Inner.Tags.Add(key, value);
            return this;
        }
    }
}
