// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    /// <summary>
    /// An internal type expose utility methods around encryption extension identifier.
    /// </summary>
    public partial class EncryptionExtensionIdentifier
    {
        private const string ENCRYPTION_EXTENSION_PUBLISHER = "Microsoft.Azure.Security";

        private const string LINUX_LEGACY_ENCRYPTION_EXTENSION_VERSION = "0.1";
        private const string LINUX_NOAAD_ENCRYPTION_EXTENSION_VERSION = "1.1";

        private const string WINDOWS_LEGACY_ENCRYPTION_EXTENSION_VERSION = "1.1";
        private const string WINDOWS_NOAAD_ENCRYPTION_EXTENSION_VERSION = "2.2";

        private const string LINUX_ENCRYPTION_TYPE_NAME = "AzureDiskEncryptionForLinux";
        private const string WINDOWS_ENCRYPTION_TYPE_NAME = "AzureDiskEncryption";

        /// <summary>
        /// Return encryption extension publisher name.
        /// </summary>
        /// <returns>encryption extension publisher name</returns>
        internal static string GetPublisherName()
        {
            return ENCRYPTION_EXTENSION_PUBLISHER;
        }

        /// <summary>
        /// Return OS specific encryption extension type.
        /// </summary>
        /// <param name="osType">OS Type</param>
        /// <returns>OS specific encryption extension type</returns>
        internal static string GetTypeName(OperatingSystemTypes osType)
        {
            if (osType == OperatingSystemTypes.Linux)
            {
                return LINUX_ENCRYPTION_TYPE_NAME;
            }
            else
            {
                return WINDOWS_ENCRYPTION_TYPE_NAME;
            }
        }

        /// <summary>
        /// Given os type and no aad flag return the encryption extension version.
        /// </summary>
        /// <param name="osType">OS Type</param>
        /// <param name="isNoAAD">no aad flag</param>
        /// <returns>the encryption extension version</returns>
        internal static string GetVersion(OperatingSystemTypes osType, bool isNoAAD)
        {
            if (osType == OperatingSystemTypes.Linux)
            {
                return isNoAAD ? LINUX_NOAAD_ENCRYPTION_EXTENSION_VERSION : LINUX_LEGACY_ENCRYPTION_EXTENSION_VERSION;
            }
            else
            {
                return isNoAAD ? WINDOWS_NOAAD_ENCRYPTION_EXTENSION_VERSION : WINDOWS_LEGACY_ENCRYPTION_EXTENSION_VERSION;
            }
        }

        /// <summary>
        /// Checks whether the given version is a legacy extension version or no-aad extension version
        /// for the given OS type.
        /// </summary>
        /// <param name="osType">OS Type</param>
        /// <param name="version">extension version</param>
        /// <returns>true if no-aad</returns>
        internal static bool IsNoAADVersion(OperatingSystemTypes osType, string version)
        {
            if (version == null)
            {
                return false;
            }
            string majorVersion = version.Split('.')[0];
            if (osType == OperatingSystemTypes.Linux)
            {
                return majorVersion.Equals(LINUX_NOAAD_ENCRYPTION_EXTENSION_VERSION.Split('.')[0]);
            }
            else
            {
                return majorVersion.Equals(WINDOWS_NOAAD_ENCRYPTION_EXTENSION_VERSION.Split('.')[0]);
            }
        }

        /// <summary>
        /// Checks whether the given publisher name is encryption publisher name.
        /// </summary>
        /// <param name="publisherName">publisher name</param>
        /// <returns>true if the given publisher name is encryption publisher name</returns>
        internal static bool IsEncryptionPublisherName(string publisherName)
        {
            if (publisherName == null)
            {
                return false;
            }
            return publisherName.Equals(GetPublisherName(), System.StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Checks whether the given type name is an encryption type name for given OS type.
        /// </summary>
        /// <param name="typeName">type name</param>
        /// <param name="osType">OS Type</param>
        /// <returns>true if the given type name is encryption type name</returns>
        internal static bool IsEncryptionTypeName(string typeName, OperatingSystemTypes osType)
        {
            if (typeName == null)
            {
                return false;
            }
            return typeName.Equals(GetTypeName(osType), System.StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Given disk instance view status code, check whether it is encryption status code if yes map it to EncryptionStatus.
        /// </summary>
        /// <param name="code">The encryption status code.</param>
        /// <return>Mapped EncryptionStatus if given code is encryption status code, null otherwise.</return>
        internal static EncryptionStatus GetEncryptionStatusFromCode(string code)
        {
            if (code != null && code.ToLower().StartsWith("encryptionstate"))
            {
                // e.g. "code": "EncryptionState/encrypted"
                //      "code": "EncryptionState/notEncrypted"
                string[] parts = code.Split('/');
                if (parts.Length != 2)
                {
                    return EncryptionStatus.Unknown;
                }
                else
                {
                    return EncryptionStatus.Parse(parts[1]);
                }
            }
            return null;
        }
    }
}