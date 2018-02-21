// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    internal partial class EventHubAuthorizationKeyImpl 
    {
        /// <summary>
        /// Gets primary connection string.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey.PrimaryConnectionString
        {
            get
            {
                return this.PrimaryConnectionString();
            }
        }

        /// <summary>
        /// Gets primary access key.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey.PrimaryKey
        {
            get
            {
                return this.PrimaryKey();
            }
        }

        /// <summary>
        /// Gets secondary access key.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey.SecondaryKey
        {
            get
            {
                return this.SecondaryKey();
            }
        }

        /// <summary>
        /// Gets secondary connection string.
        /// </summary>
        string Microsoft.Azure.Management.Eventhub.Fluent.IEventHubAuthorizationKey.SecondaryConnectionString
        {
            get
            {
                return this.SecondaryConnectionString();
            }
        }
    }
}