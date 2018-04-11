// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.SqlEncryptionProtector.Update
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent;

    /// <summary>
    /// The template for a SQL Encryption Protector update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate  :
        Microsoft.Azure.Management.Sql.Fluent.SqlEncryptionProtector.Update.IWithServerKeyNameAndType,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<Microsoft.Azure.Management.Sql.Fluent.ISqlEncryptionProtector>
    {
    }

    /// <summary>
    /// The SQL Encryption Protector update definition to set the server key name and type.
    /// </summary>
    public interface IWithServerKeyNameAndType  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Updates the Encryption Protector to use the default service managed server key.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlEncryptionProtector.Update.IUpdate WithServiceManagedServerKey();

        /// <summary>
        /// Updates the Encryption Protector to use an AzureKeyVault server key.
        /// </summary>
        /// <param name="serverKeyName">The server key name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Sql.Fluent.SqlEncryptionProtector.Update.IUpdate WithAzureKeyVaultServerKey(string serverKeyName);
    }
}