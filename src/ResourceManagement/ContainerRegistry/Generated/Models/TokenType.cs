// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Models
{
    /// <summary>
    /// Defines values for TokenType.
    /// </summary>
    public partial class TokenType : ExpandableStringEnum<TokenType>, IBeta
    {
        /// <summary>
        /// Static value QuickBuild for RunType.
        /// </summary>
        public static readonly TokenType PAT = Parse("PAT");

        /// <summary>
        /// Static value QuickRun for RunType.
        /// </summary>
        public static readonly TokenType OAuth = Parse("OAuth");
    }
}
