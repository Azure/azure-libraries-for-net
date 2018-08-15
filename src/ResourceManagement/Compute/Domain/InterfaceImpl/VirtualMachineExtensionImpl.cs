// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Update;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.Update;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachineExtension.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal partial class VirtualMachineExtensionImpl
    {
        /// <summary>
        /// Gets true if this extension is configured to upgrade automatically when a new minor version of the
        /// extension image that this extension based on is published.
        /// </summary>
        bool Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.AutoUpgradeMinorVersionEnabled
        {
            get
            {
                return this.AutoUpgradeMinorVersionEnabled();
            }
        }

        /// <summary>
        /// Gets the provisioning state of the virtual machine extension.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.ProvisioningState
        {
            get
            {
                return this.ProvisioningState();
            }
        }

        /// <summary>
        /// Gets the public settings of the virtual machine extension as key value pairs.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, object> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.PublicSettings
        {
            get
            {
                return this.PublicSettings();
            }
        }

        /// <summary>
        /// Gets the public settings of the virtual machine extension as a JSON string.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.PublicSettingsAsJsonString
        {
            get
            {
                return this.PublicSettingsAsJsonString();
            }
        }

        /// <summary>
        /// Gets the publisher name of the virtual machine extension image this extension is created from.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.PublisherName
        {
            get
            {
                return this.PublisherName();
            }
        }

        /// <summary>
        /// Gets the tags for this virtual machine extension.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string, string> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.Tags
        {
            get
            {
                return this.Tags();
            }
        }

        /// <summary>
        /// Gets the type name of the virtual machine extension image this extension is created from.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.TypeName
        {
            get
            {
                return this.TypeName();
            }
        }

        /// <summary>
        /// Gets the version name of the virtual machine extension image this extension is created from.
        /// </summary>
        string Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtensionBase.VersionName
        {
            get
            {
                return this.VersionName();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        VirtualMachine.Update.IUpdate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<VirtualMachine.Update.IUpdate>.Attach()
        {
            return this.Attach();
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        VirtualMachine.Definition.IWithCreate Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<VirtualMachine.Definition.IWithCreate>.Attach()
        {
            return this.Attach();
        }

        /// <return>The instance view of the virtual machine extension.</return>
        Models.VirtualMachineExtensionInstanceView Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension.GetInstanceView()
        {
            return this.GetInstanceView();
        }

        /// <return>A representation of the deferred computation of this call returning the virtual machine extension instance view.</return>
        async Task<Models.VirtualMachineExtensionInstanceView> Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension.GetInstanceViewAsync(CancellationToken cancellationToken)
        {
            return await this.GetInstanceViewAsync(cancellationToken);
        }

        /// <summary>
        /// Specifies the virtual machine extension image to use.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate> VirtualMachineExtension.Definition.IWithImageOrPublisher<VirtualMachine.Definition.IWithCreate>.WithImage(IVirtualMachineExtensionImage image)
        {
            return this.WithImage(image);
        }

        /// <summary>
        /// Specifies the virtual machine extension image to use.
        /// </summary>
        /// <param name="image">The image.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate> VirtualMachineExtension.UpdateDefinition.IWithImageOrPublisher<VirtualMachine.Update.IUpdate>.WithImage(IVirtualMachineExtensionImage image)
        {
            return this.WithImage(image);
        }

        /// <summary>
        /// Enables auto upgrade of the extension.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineExtension.Update.IUpdate VirtualMachineExtension.Update.IWithAutoUpgradeMinorVersion.WithMinorVersionAutoUpgrade()
        {
            return this.WithMinorVersionAutoUpgrade();
        }

        /// <summary>
        /// Enables auto upgrade of the extension.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate> VirtualMachineExtension.Definition.IWithAutoUpgradeMinorVersion<VirtualMachine.Definition.IWithCreate>.WithMinorVersionAutoUpgrade()
        {
            return this.WithMinorVersionAutoUpgrade();
        }

        /// <summary>
        /// Enables auto upgrade of the extension.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate> VirtualMachineExtension.UpdateDefinition.IWithAutoUpgradeMinorVersion<VirtualMachine.Update.IUpdate>.WithMinorVersionAutoUpgrade()
        {
            return this.WithMinorVersionAutoUpgrade();
        }

        /// <summary>
        /// Enables auto upgrade of the extension.
        /// </summary>
        /// <return>The next stage of the update.</return>
        VirtualMachineExtension.Update.IUpdate VirtualMachineExtension.Update.IWithAutoUpgradeMinorVersion.WithoutMinorVersionAutoUpgrade()
        {
            return this.WithoutMinorVersionAutoUpgrade();
        }

        /// <summary>
        /// Disables auto upgrade of the extension.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate> VirtualMachineExtension.Definition.IWithAutoUpgradeMinorVersion<VirtualMachine.Definition.IWithCreate>.WithoutMinorVersionAutoUpgrade()
        {
            return this.WithoutMinorVersionAutoUpgrade();
        }

        /// <summary>
        /// Disables auto upgrade of the extension.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate> VirtualMachineExtension.UpdateDefinition.IWithAutoUpgradeMinorVersion<VirtualMachine.Update.IUpdate>.WithoutMinorVersionAutoUpgrade()
        {
            return this.WithoutMinorVersionAutoUpgrade();
        }

        /// <summary>
        /// Removes a tag from the virtual machine extension.
        /// </summary>
        /// <param name="key">The key of the tag to remove.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineExtension.Update.IUpdate VirtualMachineExtension.Update.IWithTags.WithoutTag(string key)
        {
            return this.WithoutTag(key);
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">The key of a private settings entry.</param>
        /// <param name="value">The value of the private settings entry.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineExtension.Update.IUpdate VirtualMachineExtension.Update.IWithSettings.WithProtectedSetting(string key, object value)
        {
            return this.WithProtectedSetting(key, value);
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">The key of a private settings entry.</param>
        /// <param name="value">The value of the private settings entry.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate> VirtualMachineExtension.Definition.IWithSettings<VirtualMachine.Definition.IWithCreate>.WithProtectedSetting(string key, object value)
        {
            return this.WithProtectedSetting(key, value);
        }

        /// <summary>
        /// Specifies a private settings entry.
        /// </summary>
        /// <param name="key">The key of a private settings entry.</param>
        /// <param name="value">The value of the private settings entry.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate> VirtualMachineExtension.UpdateDefinition.IWithSettings<VirtualMachine.Update.IUpdate>.WithProtectedSetting(string key, object value)
        {
            return this.WithProtectedSetting(key, value);
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">The private settings.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineExtension.Update.IUpdate VirtualMachineExtension.Update.IWithSettings.WithProtectedSettings(IDictionary<string, object> settings)
        {
            return this.WithProtectedSettings(settings);
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">The private settings.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate> VirtualMachineExtension.Definition.IWithSettings<VirtualMachine.Definition.IWithCreate>.WithProtectedSettings(IDictionary<string, object> settings)
        {
            return this.WithProtectedSettings(settings);
        }

        /// <summary>
        /// Specifies private settings.
        /// </summary>
        /// <param name="settings">The private settings.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate> VirtualMachineExtension.UpdateDefinition.IWithSettings<VirtualMachine.Update.IUpdate>.WithProtectedSettings(IDictionary<string, object> settings)
        {
            return this.WithProtectedSettings(settings);
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">The key of a public settings entry.</param>
        /// <param name="value">The value of the public settings entry.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineExtension.Update.IUpdate VirtualMachineExtension.Update.IWithSettings.WithPublicSetting(string key, object value)
        {
            return this.WithPublicSetting(key, value);
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">The key of a public settings entry.</param>
        /// <param name="value">The value of the public settings entry.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate> VirtualMachineExtension.Definition.IWithSettings<VirtualMachine.Definition.IWithCreate>.WithPublicSetting(string key, object value)
        {
            return this.WithPublicSetting(key, value);
        }

        /// <summary>
        /// Specifies a public settings entry.
        /// </summary>
        /// <param name="key">The key of a public settings entry.</param>
        /// <param name="value">The value of the public settings entry.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate> VirtualMachineExtension.UpdateDefinition.IWithSettings<VirtualMachine.Update.IUpdate>.WithPublicSetting(string key, object value)
        {
            return this.WithPublicSetting(key, value);
        }

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">The public settings.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineExtension.Update.IUpdate VirtualMachineExtension.Update.IWithSettings.WithPublicSettings(IDictionary<string, object> settings)
        {
            return this.WithPublicSettings(settings);
        }

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">The public settings.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate> VirtualMachineExtension.Definition.IWithSettings<VirtualMachine.Definition.IWithCreate>.WithPublicSettings(IDictionary<string, object> settings)
        {
            return this.WithPublicSettings(settings);
        }

        /// <summary>
        /// Specifies public settings.
        /// </summary>
        /// <param name="settings">The public settings.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate> VirtualMachineExtension.UpdateDefinition.IWithSettings<VirtualMachine.Update.IUpdate>.WithPublicSettings(IDictionary<string, object> settings)
        {
            return this.WithPublicSettings(settings);
        }

        /// <summary>
        /// Specifies the name of the virtual machine extension image publisher.
        /// </summary>
        /// <param name="extensionImagePublisherName">The publisher name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.Definition.IWithType<VirtualMachine.Definition.IWithCreate> VirtualMachineExtension.Definition.IWithPublisher<VirtualMachine.Definition.IWithCreate>.WithPublisher(string extensionImagePublisherName)
        {
            return this.WithPublisher(extensionImagePublisherName);
        }

        /// <summary>
        /// Specifies the name of the virtual machine extension image publisher.
        /// </summary>
        /// <param name="extensionImagePublisherName">The publisher name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.UpdateDefinition.IWithType<VirtualMachine.Update.IUpdate> VirtualMachineExtension.UpdateDefinition.IWithPublisher<VirtualMachine.Update.IUpdate>.WithPublisher(string extensionImagePublisherName)
        {
            return this.WithPublisher(extensionImagePublisherName);
        }

        /// <summary>
        /// Adds a tag to the virtual machine extension.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate> VirtualMachineExtension.Definition.IWithTags<VirtualMachine.Definition.IWithCreate>.WithTag(string key, string value)
        {
            return this.WithTag(key, value);
        }

        /// <summary>
        /// Adds a tag to the resource.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate> VirtualMachineExtension.UpdateDefinition.IWithTags<VirtualMachine.Update.IUpdate>.WithTag(string key, string value)
        {
            return this.WithTag(key, value);
        }

        /// <summary>
        /// Adds a tag to the virtual machine extension.
        /// </summary>
        /// <param name="key">The key for the tag.</param>
        /// <param name="value">The value for the tag.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineExtension.Update.IUpdate VirtualMachineExtension.Update.IWithTags.WithTag(string key, string value)
        {
            return this.WithTag(key, value);
        }

        /// <summary>
        /// Specifies tags for the virtual machine extension.
        /// </summary>
        /// <param name="tags">The tags to associate.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate> VirtualMachineExtension.Definition.IWithTags<VirtualMachine.Definition.IWithCreate>.WithTags(IDictionary<string, string> tags)
        {
            return this.WithTags(tags);
        }

        /// <summary>
        /// Specifies tags for the resource.
        /// </summary>
        /// <param name="tags">Tags to associate with the resource.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate> VirtualMachineExtension.UpdateDefinition.IWithTags<VirtualMachine.Update.IUpdate>.WithTags(IDictionary<string, string> tags)
        {
            return this.WithTags(tags);
        }

        /// <summary>
        /// Specifies tags for the virtual machine extension.
        /// </summary>
        /// <param name="tags">Tags indexed by name.</param>
        /// <return>The next stage of the update.</return>
        VirtualMachineExtension.Update.IUpdate VirtualMachineExtension.Update.IWithTags.WithTags(IDictionary<string, string> tags)
        {
            return this.WithTags(tags);
        }

        /// <summary>
        /// Specifies the type of the virtual machine extension image.
        /// </summary>
        /// <param name="extensionImageTypeName">The image type name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.Definition.IWithVersion<VirtualMachine.Definition.IWithCreate> VirtualMachineExtension.Definition.IWithType<VirtualMachine.Definition.IWithCreate>.WithType(string extensionImageTypeName)
        {
            return this.WithType(extensionImageTypeName);
        }

        /// <summary>
        /// Specifies the type of the virtual machine extension image.
        /// </summary>
        /// <param name="extensionImageTypeName">The image type name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.UpdateDefinition.IWithVersion<VirtualMachine.Update.IUpdate> VirtualMachineExtension.UpdateDefinition.IWithType<VirtualMachine.Update.IUpdate>.WithType(string extensionImageTypeName)
        {
            return this.WithType(extensionImageTypeName);
        }

        /// <summary>
        /// Specifies the version of the virtual machine image extension.
        /// </summary>
        /// <param name="extensionImageVersionName">The version name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.Definition.IWithAttach<VirtualMachine.Definition.IWithCreate> VirtualMachineExtension.Definition.IWithVersion<VirtualMachine.Definition.IWithCreate>.WithVersion(string extensionImageVersionName)
        {
            return this.WithVersion(extensionImageVersionName);
        }

        /// <summary>
        /// Specifies the version of the virtual machine image extension.
        /// </summary>
        /// <param name="extensionImageVersionName">The version name.</param>
        /// <return>The next stage of the definition.</return>
        VirtualMachineExtension.UpdateDefinition.IWithAttach<VirtualMachine.Update.IUpdate> VirtualMachineExtension.UpdateDefinition.IWithVersion<VirtualMachine.Update.IUpdate>.WithVersion(string extensionImageVersionName)
        {
            return this.WithVersion(extensionImageVersionName);
        }
    }
}