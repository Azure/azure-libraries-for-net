// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    /// <summary>
    /// Defines values for ApplicationGatewayRedirectType.
    /// </summary>
    public partial class ApplicationGatewayRedirectType : ExpandableStringEnum<ApplicationGatewayRedirectType>
    {
        public static readonly ApplicationGatewayRedirectType Permanent = Parse("Permanent");
        public static readonly ApplicationGatewayRedirectType Found = Parse("Found");
        public static readonly ApplicationGatewayRedirectType SeeOther = Parse("SeeOther");
        public static readonly ApplicationGatewayRedirectType Temporary = Parse("Temporary");
    }
}


