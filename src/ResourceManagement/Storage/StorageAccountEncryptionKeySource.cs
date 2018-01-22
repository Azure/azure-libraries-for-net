// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Azure storage account encryption key sources.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnN0b3JhZ2UuU3RvcmFnZUFjY291bnRFbmNyeXB0aW9uS2V5U291cmNl
    public class StorageAccountEncryptionKeySource  : ExpandableStringEnum<StorageAccountEncryptionKeySource>
    {
        /// <summary>
        /// Static value Microsoft.Storage for StorageAccountEncryptionKeySource.
        /// </summary>
        public static readonly StorageAccountEncryptionKeySource Microsoft_Storage = Parse("Microsoft.Storage");

        /// <summary>
        /// Static value Microsoft.Keyvault for StorageAccountEncryptionKeySource.
        /// </summary>
        public static readonly StorageAccountEncryptionKeySource Microsoft_KeyVault = Parse("Microsoft.Keyvault");
    }
}