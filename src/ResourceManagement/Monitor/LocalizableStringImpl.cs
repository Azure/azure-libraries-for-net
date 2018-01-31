// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    internal class LocalizableStringImpl : Wrapper<LocalizableString>, ILocalizableString
    {
        public LocalizableStringImpl(LocalizableString innerObject)
            : base(innerObject)
        {
        }

        public string Value
        {
            get
            {
                return this.Inner.Value;
            }
        }

        public string LocalizedValue
        {
            get
            {
                return this.Inner.LocalizedValue;
            }
        }
    }
}
