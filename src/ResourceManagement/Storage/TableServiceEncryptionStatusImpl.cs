// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// Implementation of StorageAccountEncryptionStatus for Table service.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnN0b3JhZ2UuaW1wbGVtZW50YXRpb24uVGFibGVTZXJ2aWNlRW5jcnlwdGlvblN0YXR1c0ltcGw=
    internal partial class TableServiceEncryptionStatusImpl  :
        StorageAccountEncryptionStatusImpl
    {
        ///GENMHASH:1BBD5AA11DE417618F6FD5C9F77A4121:8A39EA79F0EAA32E3B9637298A785CD9
        internal TableServiceEncryptionStatusImpl(EncryptionServices encryptionServices) : base(encryptionServices)
        {
        }

        ///GENMHASH:D97A6A22274011CC9F2DE9E7287AE1CE:710934CB805D465755C619E1C691E1FE
        protected override EncryptionService EncryptionService()
        {
            if (this.encryptionServices == null)
            {
                return null;
            }
            else
            {
                return this.encryptionServices.Table;
            }
        }

        ///GENMHASH:37A0EE464EE2C3F32288E8C35E06F1EA:55CB18B464239801AAD97F01970B3810
        public override StorageService StorageService
        {
            get
            {
                return StorageService.Blob;
            }
        }
    }
}