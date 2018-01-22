// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// Implementation of StorageAccountEncryptionStatus for Blob service.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnN0b3JhZ2UuaW1wbGVtZW50YXRpb24uQmxvYlNlcnZpY2VFbmNyeXB0aW9uU3RhdHVzSW1wbA==
    internal partial class BlobServiceEncryptionStatusImpl  :
        StorageAccountEncryptionStatusImpl
    {
        ///GENMHASH:DAB5602D433411FC81DD4AE9FB169399:8A39EA79F0EAA32E3B9637298A785CD9
        internal  BlobServiceEncryptionStatusImpl(EncryptionServices encryptionServices) : base(encryptionServices)
        {
        }

        ///GENMHASH:D97A6A22274011CC9F2DE9E7287AE1CE:5F296BBF9823F08BDC308F9A5164B5BE
        protected override EncryptionService EncryptionService()
        {
            if (this.encryptionServices == null)
            {
                return null;
            }
            else
            {
                return  this.encryptionServices.Blob;
            }
        }

        ///GENMHASH:37A0EE464EE2C3F32288E8C35E06F1EA:A33D634F8782BF7783613105DEEC75A4
        public override StorageService StorageService
        {
            get
            {
                return StorageService.Blob;
            }
        }
    }
}