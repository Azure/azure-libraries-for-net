// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    public partial class LegalHoldImpl 
    {
        /// <summary>
        /// Gets the hasLegalHold value.
        /// </summary>
        bool? Microsoft.Azure.Management.Storage.Fluent.ILegalHold.HasLegalHold
        {
            get
            {
                return this.HasLegalHold();
            }
        }

        /// <summary>
        /// Gets the tags value.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.Storage.Fluent.ILegalHold.Tags
        {
            get
            {
                return this.Tags();
            }
        }
    }
}