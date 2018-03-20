// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The  LocalizableString wrapper class implementation.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uTG9jYWxpemFibGVTdHJpbmdJbXBs
    internal partial class LocalizableStringImpl :
        Wrapper<LocalizableString>,
        ILocalizableString
    {

        ///GENMHASH:7C6732797C19572A729925ABAED13A7E:C0C35E00AF4E17F141675A2C05C7067B
        internal LocalizableStringImpl(LocalizableString innerObject)
            : base(innerObject)
        {
        }

        ///GENMHASH:03D420AB01306D12ED425614FEC1B22A:ED7F2F5D538D617424C31B1C1A188DF6
        public string LocalizedValue()
        {
            return this.Inner.LocalizedValue;
        }

        ///GENMHASH:C1D104519E98AFA1614D0BFD517E6100:5D75252F5F257CF62CF274ECAF7D0506
        public string Value()
        {
            return this.Inner.Value;
        }
    }
}
