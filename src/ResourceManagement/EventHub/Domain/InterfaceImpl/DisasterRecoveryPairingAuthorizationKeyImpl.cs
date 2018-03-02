// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class DisasterRecoveryPairingAuthorizationKeyImpl 
    {
        /// <summary>
        /// Gets primary connection string.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationKey.PrimaryConnectionString
        {
            get
            {
                return this.PrimaryConnectionString();
            }
        }

        /// <summary>
        /// Gets primary access key.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationKey.PrimaryKey
        {
            get
            {
                return this.PrimaryKey();
            }
        }

        /// <summary>
        /// Gets secondary access key.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationKey.SecondaryKey
        {
            get
            {
                return this.SecondaryKey();
            }
        }

        /// <summary>
        /// Gets alias primary connection string.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationKey.AliasPrimaryConnectionString
        {
            get
            {
                return this.AliasPrimaryConnectionString();
            }
        }

        /// <summary>
        /// Gets secondary connection string.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationKey.SecondaryConnectionString
        {
            get
            {
                return this.SecondaryConnectionString();
            }
        }

        /// <summary>
        /// Gets alias secondary connection string.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IDisasterRecoveryPairingAuthorizationKey.AliasSecondaryConnectionString
        {
            get
            {
                return this.AliasSecondaryConnectionString();
            }
        }
    }
}