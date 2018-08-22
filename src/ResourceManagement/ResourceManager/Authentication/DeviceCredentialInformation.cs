// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
#if !NET45
using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Authentication
{
    public class DeviceCredentialInformation
    {
        public string ClientId { get; set; }

        public Func<DeviceCodeResult, bool> DeviceCodeFlowHandler { get; set; }
    }
}
#endif