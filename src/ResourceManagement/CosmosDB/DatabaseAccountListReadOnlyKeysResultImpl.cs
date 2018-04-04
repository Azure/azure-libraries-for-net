// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The implementation for DatabaseAccountListReadOnlyKeysResult.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvc21vc2RiLmltcGxlbWVudGF0aW9uLkRhdGFiYXNlQWNjb3VudExpc3RSZWFkT25seUtleXNSZXN1bHRJbXBs
    internal partial class DatabaseAccountListReadOnlyKeysResultImpl  :
        Wrapper<Models.DatabaseAccountListReadOnlyKeysResultInner>,
        IDatabaseAccountListReadOnlyKeysResult
    {
        ///GENMHASH:066031D2E69F135430AA6C7665A4DDE1:C0C35E00AF4E17F141675A2C05C7067B
        internal DatabaseAccountListReadOnlyKeysResultImpl(DatabaseAccountListReadOnlyKeysResultInner innerObject)
            : base(innerObject)
        {
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