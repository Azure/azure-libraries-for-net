// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Authentication
{
    /// <summary>
    /// Exception represents failure in MSI login.
    /// </summary>
    public class MSILoginException : Exception
    {
        private MSILoginException(string response, string message) : base($"{message} {response}")
        {
        }

        public static MSILoginException TokenTypeNotFound(string response)
        {
            return new MSILoginException(response, "token_type property not found in the response");
        }

        public static MSILoginException AccessTokenNotFound(string response)
        {
            return new MSILoginException(response, "access_token property not found in the response");
        }
    }
}
