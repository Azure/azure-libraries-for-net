// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Type representing access key of  DisasterRecoveryPairingAuthorizationRule.
    /// </summary>
    public interface IDisasterRecoveryPairingAuthorizationKey  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Management.EventHub.Fluent.Models.AccessKeysInner>
    {
        /// <summary>
        /// Gets secondary access key.
        /// </summary>
        string SecondaryKey { get; }

        /// <summary>
        /// Gets primary connection string.
        /// </summary>
        string PrimaryConnectionString { get; }

        /// <summary>
        /// Gets alias secondary connection string.
        /// </summary>
        string AliasSecondaryConnectionString { get; }

        /// <summary>
        /// Gets secondary connection string.
        /// </summary>
        string SecondaryConnectionString { get; }

        /// <summary>
        /// Gets alias primary connection string.
        /// </summary>
        string AliasPrimaryConnectionString { get; }

        /// <summary>
        /// Gets primary access key.
        /// </summary>
        string PrimaryKey { get; }
    }
}