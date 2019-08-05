// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Storage.Fluent.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.Storage.Fluent
{
    /// <summary>
    /// Helper to operate on storage account encryption (StorageAccountInner.encryption) property.
    /// </summary>
    internal class StorageEncryptionHelper
    {
        private bool isInCreateMode;
        private StorageAccountInner inner;
        private StorageAccountCreateParameters createParameters;
        private StorageAccountUpdateParameters updateParameters;

        /// <summary>
        /// Creates StorageEncryptionHelper.
        /// </summary>
        /// <param name="createParameters">the model representing payload for storage account create</param>
        internal StorageEncryptionHelper(StorageAccountCreateParameters createParameters)
        {
            this.isInCreateMode = true;
            this.createParameters = createParameters;
            this.updateParameters = null;
            this.inner = null;
        }

        /// <summary>
        /// Creates StorageEncryptionHelper.
        /// </summary>
        /// <param name="updateParameters">the model representing the payload for storage account update</param>
        /// <param name="inner">the current state of storage account</param>
        internal StorageEncryptionHelper(StorageAccountUpdateParameters updateParameters, StorageAccountInner inner)
        {
            this.isInCreateMode = false;
            this.createParameters = null;
            this.updateParameters = updateParameters;
            this.inner = inner;
        }

        /// <summary>
        /// Gets the encryption key source.
        /// </summary>
        /// <param name="inner">the storage account</param>
        /// <returns>the encryption key source type</returns>
        internal static StorageAccountEncryptionKeySource EncryptionKeySource(StorageAccountInner inner)
        {
            if (inner.Encryption == null || inner.Encryption.KeySource == null)
            {
                return null;
            }
            return StorageAccountEncryptionKeySource.Parse(inner.Encryption.KeySource.ToString());
        }

        /// <summary>
        /// Gets the encryption statuses of various storage services.
        /// </summary>
        /// <param name="inner">the storage accounts</param>
        /// <returns>the dictionary containing the encryption statuses indexed by service name</returns>
        internal static IDictionary<StorageService, IStorageAccountEncryptionStatus> EncryptionStatuses(StorageAccountInner inner)
        {
            IDictionary<StorageService, IStorageAccountEncryptionStatus> statuses = new Dictionary<StorageService, IStorageAccountEncryptionStatus>();
            EncryptionServices services = null;
            if (inner.Encryption != null)
            {
                services = inner.Encryption.Services;
            }
            statuses.Add(StorageService.Blob, new BlobServiceEncryptionStatusImpl(services));
            statuses.Add(StorageService.File, new FileServiceEncryptionStatusImpl(services));
            statuses.Add(StorageService.Table, new TableServiceEncryptionStatusImpl(services));
            statuses.Add(StorageService.Queue, new QueueServiceEncryptionStatusImpl(services));
            return statuses;
        }

        /// <summary>
        /// Specifies that storage blob encryption should be enabled.
        /// </summary>
        /// <returns>StorageEncryptionHelper</returns>
        internal StorageEncryptionHelper WithBlobEncryption()
        {
            var encryption = GetEncryptionConfig(true);
            if (encryption.Services == null)
            {
                encryption.Services = new EncryptionServices();
            }
            // Enable encryption for blob service
            //
            if (encryption.Services.Blob == null)
            {
                encryption.Services.Blob = new EncryptionService();
            }
            encryption.Services.Blob.Enabled = true;
            if (encryption.KeySource == null)
            {
                encryption.KeySource = KeySource.MicrosoftStorage;
            }
            return this;
        }

        /// <summary>
        /// Specifies that storage file encryption should be enabled.
        /// </summary>
        /// <returns>StorageEncryptionHelper</returns>
        internal StorageEncryptionHelper WithFileEncryption()
        {
            var encryption = GetEncryptionConfig(true);
            if (encryption.Services == null)
            {
                encryption.Services = new EncryptionServices();
            }
            // Enable encryption for file service
            //
            if (encryption.Services.File == null)
            {
                encryption.Services.File = new EncryptionService();
            }
            encryption.Services.File.Enabled = true;
            if (encryption.KeySource == null)
            {
                encryption.KeySource = KeySource.MicrosoftStorage;
            }
            return this;
        }

        /// <summary>
        /// Specifies that storage blob encryption should be disabled for storage blob.
        /// </summary>
        /// <returns>StorageEncryptionHelper</returns>
        internal StorageEncryptionHelper WithoutBlobEncryption()
        {
            var encryption = GetEncryptionConfig(true);
            if (encryption.Services == null)
            {
                encryption.Services = new EncryptionServices();
            }
            // Enable encryption for blob service
            //
            if (encryption.Services.Blob == null)
            {
                encryption.Services.Blob = new EncryptionService();
            }
            encryption.Services.Blob.Enabled = false;
            if (encryption.KeySource == null)
            {
                encryption.KeySource = KeySource.MicrosoftStorage;
            }
            return this;
        }

        /// <summary>
        /// Specifies that storage blob encryption should be disabled for storage file.
        /// </summary>
        /// <returns>StorageEncryptionHelper</returns>
        internal StorageEncryptionHelper WithoutFileEncryption()
        {
            var encryption = GetEncryptionConfig(true);
            if (encryption.Services == null)
            {
                encryption.Services = new EncryptionServices();
            }
            // Enable encryption for file service
            //
            if (encryption.Services.File == null)
            {
                encryption.Services.File = new EncryptionService();
            }
            encryption.Services.File.Enabled = false;
            if (encryption.KeySource == null)
            {
                encryption.KeySource = KeySource.MicrosoftStorage;
            }
            return this;
        }

        /// <summary>
        /// Specifies the key vault key to be used to encrypt the blobs and files.
        /// </summary>
        /// <param name="keyVaultUri">key vault url</param>
        /// <param name="keyName">key vault key name</param>
        /// <param name="keyVersion">key vault key version</param>
        /// <returns>StorageEncryptionHelper</returns>
        internal StorageEncryptionHelper WithEncryptionKeyFromKeyVault(string keyVaultUri, string keyName, string keyVersion)
        {
            Encryption encryption = GetEncryptionConfig(true);
            encryption.KeySource = KeySource.MicrosoftKeyvault;
            encryption.KeyVaultProperties = new KeyVaultProperties
            {
                KeyVaultUri = keyVaultUri,
                KeyName = keyName,
                KeyVersion = keyVersion
            };
            return this;
        }


        /// <summary>
        /// Gets the encryption configuration.
        /// </summary>
        /// <param name="createIfNotExists">flag indicating whether to create an encryption config if it does not exists already</param>
        /// <returns>the encryption configuration</returns>
        private Encryption GetEncryptionConfig(bool createIfNotExists)
        {
            if (this.isInCreateMode)
            {
                if (this.createParameters.Encryption == null)
                {
                    if (createIfNotExists)
                    {
                        this.createParameters.Encryption = new Encryption();
                    }
                    else
                    {
                        return null; 
                    }
                }
                return this.createParameters.Encryption;
            }
            else
            {
                if (this.updateParameters.Encryption == null)
                {
                    if (this.inner.Encryption == null)
                    {
                        if (createIfNotExists)
                        {
                            this.updateParameters.Encryption = new Encryption();
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        // Create a clone of the current encryption
                        //
                        Encryption clonedEncryption = new Encryption
                        {
                            KeySource = this.inner.Encryption.KeySource
                        };
                        if (this.inner.Encryption.KeyVaultProperties != null)
                        {
                            clonedEncryption.KeyVaultProperties = new KeyVaultProperties
                            {
                                KeyName = this.inner.Encryption.KeyVaultProperties.KeyName,
                                KeyVaultUri = this.inner.Encryption.KeyVaultProperties.KeyVaultUri,
                                KeyVersion = this.inner.Encryption.KeyVaultProperties.KeyVersion
                            };
                        }
                        if (this.inner.Encryption.Services != null)
                        {
                            clonedEncryption.Services = new EncryptionServices();
                            if (this.inner.Encryption.Services.Blob != null)
                            {
                                clonedEncryption.Services.Blob = new EncryptionService
                                {
                                    Enabled = this.inner.Encryption.Services.Blob.Enabled
                                };
                            }
                            if (this.inner.Encryption.Services.File != null)
                            {
                                clonedEncryption.Services.File = new EncryptionService
                                {
                                    Enabled = this.inner.Encryption.Services.File.Enabled
                                };
                            }
                        }
                        this.updateParameters.Encryption = clonedEncryption;
                    }
                }
                return this.updateParameters.Encryption;
            }
        }
    }
}
