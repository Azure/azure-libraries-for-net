// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Fluent.Tests
{
    // For serialzation to Page<T>
    [JsonObject]
    public class MockPage<T>
    {
        [JsonProperty("nextLink")]
        public string NextPageLink { get; set; }

        [JsonProperty("value")]
        public IList<T> Items { get; set; }
    }

    public class PagedCollection
    {
        [Fact]
        public void CanLoadEmptyPageWithNextLink()
        {
            var taskLoadPage = PagedCollection<string, string>.LoadPage(
                // first page, valid nextLink
                (cancellation) => Task.FromResult(ConvertToPage(new MockPage<string> { Items = new List<string> { "1", "2" }, NextPageLink = "2" })),
                (nextLink, cancellation) => 
                {
                    if (nextLink == "2")
                    {
                        // empty values, valid nextLink
                        return Task.FromResult(ConvertToPage(new MockPage<string> { Items = new List<string>(), NextPageLink = "3" }));
                    }
                    else if (nextLink == "3")
                    {
                        // non-empty values, null nextLink
                        return Task.FromResult(ConvertToPage(new MockPage<string> { Items = new List<string> { "3", "4", "5" }, NextPageLink = null }));
                    }
                    else
                    {
                        Assert.False(true);
                        return Task.FromResult(ConvertToPage(new MockPage<string> { Items = new List<string> (), NextPageLink = null }));
                    }
                },
                (str) => str, true, CancellationToken.None);

            Assert.Equal(new List<string> { "1", "2", "3", "4", "5" }, taskLoadPage.Result);
        }

        private static IPage<T> ConvertToPage<T>(MockPage<T> mockPage)
        {
            return Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<Page<T>>(Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(mockPage));
        }
    }
}
