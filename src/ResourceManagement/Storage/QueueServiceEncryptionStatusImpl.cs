// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// Implementation of StorageAccountEncryptionStatus for Queue service.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnN0b3JhZ2UuaW1wbGVtZW50YXRpb24uUXVldWVTZXJ2aWNlRW5jcnlwdGlvblN0YXR1c0ltcGw=
    internal partial class QueueServiceEncryptionStatusImpl  :
        StorageAccountEncryptionStatusImpl
    {
        ///GENMHASH:504CA456A019C5BF50BE787895363D30:8A39EA79F0EAA32E3B9637298A785CD9
        internal QueueServiceEncryptionStatusImpl(EncryptionServices encryptionServices) : base(encryptionServices)
        {
        }

        ///GENMHASH:D97A6A22274011CC9F2DE9E7287AE1CE:9D276E63DDD38842055BC0961B867140
        protected override EncryptionService EncryptionService()
        {
            if (this.encryptionServices == null)
            {
                return null;
            }
            else
            {
                return this.encryptionServices.Queue;
            }
        }

        ///GENMHASH:37A0EE464EE2C3F32288E8C35E06F1EA:84CE79FE2E30C84E4127AE3232C3EFD2
        public override StorageService StorageService
        {
            get
            {
                return StorageService.Queue;
            }
        }
    }
}