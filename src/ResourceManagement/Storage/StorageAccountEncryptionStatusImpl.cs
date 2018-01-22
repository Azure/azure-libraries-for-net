// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System;

    /// <summary>
    /// Shared implementation of StorageAccountEncryptionStatus.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnN0b3JhZ2UuaW1wbGVtZW50YXRpb24uU3RvcmFnZUFjY291bnRFbmNyeXB0aW9uU3RhdHVzSW1wbA==
    internal abstract partial class StorageAccountEncryptionStatusImpl :
        IStorageAccountEncryptionStatus
    {
        protected EncryptionServices encryptionServices;

        ///GENMHASH:AFBF75B8C2F05405FEC5D79F56277FBD:1AACE820D8910F7BD0F84AAA4D78CCA7
        protected StorageAccountEncryptionStatusImpl(EncryptionServices encryptionServices)
        {
            this.encryptionServices = encryptionServices;
        }

        ///GENMHASH:383E4E95C2764D4EF94A2DE388852F09:53DCC067101B13A21EE567A072307B56
        public DateTime? LastEnabledTime()
        {
            EncryptionService encryptionService = this.EncryptionService();
            if (encryptionService == null)
            {
                return null;
            }
            else
            {
                return encryptionService.LastEnabledTime;
            }
        }

        ///GENMHASH:3F2076D33F84FDFAB700A1F0C8C41647:4BA9FCF5109851CAEE354BC80FD6F4D9
        public bool IsEnabled()
        {
            EncryptionService encryptionService = this.EncryptionService();
            if (encryptionService == null)
            {
                return false;
            }
            else if (encryptionService.Enabled != null)
            {
                return encryptionService.Enabled.Value;
            }
            else
            {
                return false;
            }
        }

        public abstract Microsoft.Azure.Management.Storage.Fluent.StorageService StorageService { get; }

        ///GENMHASH:D97A6A22274011CC9F2DE9E7287AE1CE:27E486AB74A10242FF421C0798DDC450
        protected abstract EncryptionService EncryptionService();
    }
}