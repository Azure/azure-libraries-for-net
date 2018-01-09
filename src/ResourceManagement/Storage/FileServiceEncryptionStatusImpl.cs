// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// Implementation of StorageAccountEncryptionStatus for File service.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnN0b3JhZ2UuaW1wbGVtZW50YXRpb24uRmlsZVNlcnZpY2VFbmNyeXB0aW9uU3RhdHVzSW1wbA==
    internal partial class FileServiceEncryptionStatusImpl  :
        StorageAccountEncryptionStatusImpl
    {
        ///GENMHASH:3BF269643D6DD700597D4C8FA71BE0FE:8A39EA79F0EAA32E3B9637298A785CD9
        internal  FileServiceEncryptionStatusImpl(EncryptionServices encryptionServices) : base(encryptionServices)
        {
        }

        ///GENMHASH:D97A6A22274011CC9F2DE9E7287AE1CE:7EB9967F82AB29847D3BDF37F05B3DEB
        protected override EncryptionService EncryptionService()
        {
            if (this.encryptionServices == null)
            {
                return null;
            }
            else
            {
                return this.encryptionServices.File;
            }
        }

        ///GENMHASH:37A0EE464EE2C3F32288E8C35E06F1EA:5D5EFBFE420966F3B6BAC9791861AF84
        public override StorageService StorageService
        {
            get
            {
                return StorageService.File;
            }
        }
    }
}