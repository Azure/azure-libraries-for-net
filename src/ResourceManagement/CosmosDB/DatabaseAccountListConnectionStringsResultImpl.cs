// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.CosmosDB.Fluent
{
    using Microsoft.Azure.Management.CosmosDB.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// The implementation for DatabaseAccountListConnectionStringsResult.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvc21vc2RiLmltcGxlbWVudGF0aW9uLkRhdGFiYXNlQWNjb3VudExpc3RDb25uZWN0aW9uU3RyaW5nc1Jlc3VsdEltcGw=
    internal partial class DatabaseAccountListConnectionStringsResultImpl  :
        Wrapper<Models.DatabaseAccountListConnectionStringsResultInner>,
        IDatabaseAccountListConnectionStringsResult
    {

        ///GENMHASH:DF44AB977850C5E81C4748963ABBE14B:C0C35E00AF4E17F141675A2C05C7067B
        internal DatabaseAccountListConnectionStringsResultImpl(DatabaseAccountListConnectionStringsResultInner innerObject)
            : base(innerObject)
        {
        }

        ///GENMHASH:FA07D0476A4A7B9F0FDA17B8DF0095F1:E55076C141368AEFB417DF4F8AFB0C05
        public IReadOnlyList<Models.DatabaseAccountConnectionString> ConnectionStrings()
        {
            List<Models.DatabaseAccountConnectionString> result = new List<Models.DatabaseAccountConnectionString>();
            if(this.Inner != null && this.Inner.ConnectionStrings != null && this.Inner.ConnectionStrings.Count !=0)
            {
                result.AddRange(this.Inner.ConnectionStrings);
            }
            return result.AsReadOnly();
        }
    }
}