// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Authentication
{
    /// <summary>
    /// Type to hold MSI configuration.
    /// </summary>
    public class MSILoginInformation : IBeta
    {
        public int Port
        {
            get; set;
        }
    }
}
