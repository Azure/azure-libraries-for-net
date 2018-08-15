// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The implementation of BatchAIUsage.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmJhdGNoYWkuaW1wbGVtZW50YXRpb24uQmF0Y2hBSVVzYWdlSW1wbA==
    internal partial class BatchAIUsageImpl  :
        Wrapper<UsageInner>,
        IBatchAIUsage
    {

        ///GENMHASH:05754D28FEEAAAFD3E5610246508C918:C0C35E00AF4E17F141675A2C05C7067B
        internal  BatchAIUsageImpl(UsageInner innerObject) : base(innerObject)
        {
        }

        ///GENMHASH:4CC577A7C618816C07F6CE452B96D1E6:45736D55DD750DB588D0BFED6A1C9F6E
        public int CurrentValue()
        {
            return Inner.CurrentValue.GetValueOrDefault();
        }

        ///GENMHASH:9D196E486CC1E35756FD0BEDAB3F3BE4:C4C8970BE357CD0ECDFA60C67B17D51F
        public long Limit()
        {
            return Inner.Limit.GetValueOrDefault();
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:0EDBC6F12844C2F2056BFF916F51853B
        public UsageName Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:98D67B93923AC46ECFE338C62748BCCB:D1F0AC3814BC079D6D64A1420781A355
        public UsageUnit Unit()
        {
            return Inner.Unit;
        }
    }
}