// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent;
using Xunit;

namespace Fluent.Tests.ResourceManager
{
    public class AzureEnvironmentTests
    {

        [Fact]
        public void FromName()
        {
            Assert.Equal(AzureEnvironment.AzureGlobalCloud, AzureEnvironment.FromName("AzureGlobalCloud"));
            Assert.Equal(AzureEnvironment.AzureChinaCloud, AzureEnvironment.FromName("AzureChinaCloud"));

            Assert.Equal(AzureEnvironment.AzureGlobalCloud, AzureEnvironment.FromName("AzuregLobalCloud"));
            Assert.Equal(AzureEnvironment.AzureGlobalCloud, AzureEnvironment.FromName("azureglobalcloud"));
        }

        [Theory(Skip = "Temporary skipping to enable live test run")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("a1")]
        public void FromNameWithNonexistingName(string name)
        {
            Assert.Null(AzureEnvironment.FromName(name));
        }
    }
}
