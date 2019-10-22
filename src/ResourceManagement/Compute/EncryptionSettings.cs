// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    /// <summary>
    /// Internal base type exposing settings to enable and disable disk encryption extension.
    /// </summary>
    public abstract partial class EncryptionSettings
    {

        /// <return>Encryption extension protected settings.</return>
        abstract internal DiskEncryptionSettings StorageProfileEncryptionSettings { get; }

        /// <return>Encryption extension public settings.</return>
        abstract internal IDictionary<string, object> ExtensionPublicSettings { get; }

        /// <return>Encryption specific settings to be set on virtual machine storage profile.</return>
        abstract internal IDictionary<string, object> ExtensionProtectedSettings { get; }

        /// <summary>
        /// Creates an instance of type representing settings to disable encryption.
        /// </summary>
        /// <param name="volumeType">The disk volume that user required to disable encryption for.</param>
        /// <return>Disable settings.</return>
        internal static Disable CreateDisable(DiskVolumeType volumeType)
        {
            return new EncryptionSettings.Disable(volumeType);
        }

        /// <summary>
        /// Creates an instance of type representing settings to enable encryption.
        /// </summary>
        /// <param name="config">The user provided encryption configuration.</param>
        /// <return>Enable settings.</return>
        internal static Enable<T> CreateEnable<T>(VirtualMachineEncryptionConfiguration<T> config)
            where T : VirtualMachineEncryptionConfiguration<T>
        {
            return new EncryptionSettings.Enable<T>(config);
        }


        /// <summary>
        /// Internal type exposing settings for disabling disk encryption.
        /// </summary>
        public partial class Disable : EncryptionSettings
        {

            private readonly DiskVolumeType volumeType;

            internal Disable(DiskVolumeType volumeType)
            {
                this.volumeType = volumeType;
            }

            internal override IDictionary<string, object> ExtensionProtectedSettings
            {
                get
                {
                    return new Dictionary<string, object>();
                }
            }

            internal override IDictionary<string, object> ExtensionPublicSettings
            {
                get
                {
                    Dictionary<string, object> publicSettings = new Dictionary<string, object>();
                    publicSettings.Add("EncryptionOperation", "DisableEncryption");
                    publicSettings.Add("SequenceVersion", Guid.NewGuid());
                    publicSettings.Add("VolumeType", this.volumeType);
                    return publicSettings;
                }
            }

            internal override DiskEncryptionSettings StorageProfileEncryptionSettings
            {
                get
                {
                    DiskEncryptionSettings diskEncryptionSettings = new DiskEncryptionSettings();
                    diskEncryptionSettings.Enabled = false;
                    return diskEncryptionSettings;
                }
            }
        }

        /// <summary>
        /// Internal type exposing settings for enabling disk encryption.
        /// </summary>
        /// <param>T</param>
        public partial class Enable<T> : EncryptionSettings
            where T : VirtualMachineEncryptionConfiguration<T>
        {
            private readonly VirtualMachineEncryptionConfiguration<T> config;

            internal Enable(VirtualMachineEncryptionConfiguration<T> config)
            {
                this.config = config;
            }

            /// <return>The encryption version based on user selected OS and encryption extension.</return>
            internal string EncryptionExtensionVersion
            {
                get
                {
                    return EncryptionExtensionIdentifier.GetVersion(this.config.OsType(), RequestedForNoAADEncryptExtension);
                }
            }

            internal override IDictionary<string, object> ExtensionProtectedSettings
            {
                get
                {
                    if (this.RequestedForLegacyEncryptExtension)
                    {
                        Dictionary<string, object> protectedSettings = new Dictionary<string, object>();
                        // Legacy-Encrypt-Extension requires AAD credentials (AADClientID in PublicSettings & AADClientSecret in ProtectedSettings) to access KeyVault.
                        protectedSettings.Add("AADClientSecret", config.AadSecret());
                        if (config.OsType() == OperatingSystemTypes.Linux
                        && config.LinuxPassPhrase() != null)
                        {
                            protectedSettings.Add("Passphrase", config.LinuxPassPhrase());
                        }
                        return protectedSettings;
                    }
                    else
                    {
                        // No protected settings for NoAAD-Encrypt-Extension.
                        return new Dictionary<string, object>();
                    }
                }
            }

            internal override IDictionary<string, object> ExtensionPublicSettings
            {
                get
                {
                    Dictionary<string, object> publicSettings = new Dictionary<string, object>();
                    publicSettings.Add("EncryptionOperation", "EnableEncryption");
                    publicSettings.Add("KeyEncryptionAlgorithm", config.VolumeEncryptionKeyEncryptAlgorithm());
                    publicSettings.Add("KeyVaultURL", config.KeyVaultUrl()); // KeyVault to hold "Disk Encryption Key".
                    publicSettings.Add("VolumeType", config.VolumeType().ToString());
                    publicSettings.Add("SequenceVersion", Guid.NewGuid());
                    if (config.KeyEncryptionKeyURL() != null)
                    {
                        publicSettings.Add("KeyEncryptionKeyURL", config.KeyEncryptionKeyURL()); // KeyVault to hold Key for encrypting "Disk Encryption Key" (aka kek).
                    }
                    if (this.RequestedForLegacyEncryptExtension)
                    {
                        // Legacy-Encrypt-Extension requires AAD credentials (AADClientID in PublicSettings & AADClientSecret in ProtectedSettings) to access KeyVault.
                        publicSettings.Add("AADClientID", config.AadClientId());
                    }
                    else
                    {
                        // Without AAD credentials (AADClientID in PublicSettings & AADClientSecret in ProtectedSettings) to access KeyVault,
                        // ARM resource id of KeyVaults are required.
                        //
                        publicSettings.Add("KeyVaultResourceId", config.KeyVaultId());
                        if (config.KeyEncryptionKeyURL() != null && config.KeyEncryptionKeyVaultId() != null)
                        {
                            publicSettings.Add("KekVaultResourceId", config.KeyEncryptionKeyVaultId());
                        }
                    }
                    return publicSettings;
                }
            }

            /// <return>True if user requested for Legacy-Encrypt-Extension.</return>
            internal bool RequestedForLegacyEncryptExtension
            {
                get
                {
                    return !RequestedForNoAADEncryptExtension;
                }

            }

            /// <return>True if user requested for NoAAD-Encrypt-Extension.</return>
            internal bool RequestedForNoAADEncryptExtension
            {
                get
                {
                    return this.config.AadClientId() == null && this.config.AadSecret() == null;
                }
            }

            internal override DiskEncryptionSettings StorageProfileEncryptionSettings
            {
                get
                {
                    KeyVaultKeyReference keyEncryptionKey = null;
                    if (config.KeyEncryptionKeyURL() != null)
                    {
                        keyEncryptionKey = new KeyVaultKeyReference();
                        keyEncryptionKey.KeyUrl = config.KeyEncryptionKeyURL();
                        if (config.KeyEncryptionKeyVaultId() != null)
                        {
                            keyEncryptionKey.SourceVault = new SubResource(config.KeyEncryptionKeyVaultId());
                        }
                    }
                    DiskEncryptionSettings diskEncryptionSettings =
                        new DiskEncryptionSettings(new KeyVaultSecretReference(config.KeyVaultUrl(), new SubResource(config.KeyVaultId())), keyEncryptionKey, true);
                    return diskEncryptionSettings;
                }
            }
        }
    }
}
