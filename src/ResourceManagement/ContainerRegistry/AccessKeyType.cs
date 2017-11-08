// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Defines values for admin user access key names.
    /// </summary>
    public class AccessKeyType : ExpandableStringEnum<AccessKeyType>
    {
        public static readonly AccessKeyType Primary = Parse("password");
        public static readonly AccessKeyType Secondary = Parse("password2");

        public PasswordName ToPasswordName()
        {
            switch (this.Value)
            {
                case "password":
                    return PasswordName.Password;
                case "password2":
                    return PasswordName.Password2;
                default:
                    return PasswordName.Password;
            }
        }
    }
}