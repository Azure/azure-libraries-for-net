// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The implementation for DatabaseAccountListKeysResult.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvc21vc2RiLmltcGxlbWVudGF0aW9uLkRhdGFiYXNlQWNjb3VudExpc3RLZXlzUmVzdWx0SW1wbA==
    internal partial class DatabaseAccountListKeysResultImpl  :
        Wrapper<Models.DatabaseAccountListKeysResultInner>,
        IDatabaseAccountListKeysResult
    {
        ///GENMHASH:3D69430D618BF8E9982C0544A367FC33:C0C35E00AF4E17F141675A2C05C7067B
        internal DatabaseAccountListKeysResultImpl(DatabaseAccountListKeysResultInner innerObject)
            : base(innerObject)
        {
        }

        ///GENMHASH:5DD0B81655419F79BE8931A2C20550A1:8BF0245F1CE456357A2B7FA28EDC6504
        public string PrimaryMasterKey()
        {
            return this.Inner.PrimaryMasterKey;
        }

        ///GENMHASH:87D1FDC1FACCEAED0BAA0AD3CD12D996:DA85EACEBDB0CED1EE22C3485FB5BA5C
        public string SecondaryMasterKey()
        {
            return this.Inner.SecondaryMasterKey;
        }

        ///GENMHASH:91B5039FC62F1B0077060634CC75BC8D:1C170D6614C9BD61613BE15D7E84C795
        public string SecondaryReadonlyMasterKey()
        {
            return this.Inner.SecondaryReadonlyMasterKey;
        }

        ///GENMHASH:93F137BA2C2C7DB68AAE2E6DD665B40B:66EE7D0DA38AF4284AF5CC68A5C999FA
        public string PrimaryReadonlyMasterKey()
        {
            return this.Inner.PrimaryReadonlyMasterKey;
        }
    }
}