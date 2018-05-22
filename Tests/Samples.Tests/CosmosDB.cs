// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class CosmosDB : Samples.Tests.TestBase
    {
        public CosmosDB(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Samples", "CosmosDB")]
        public void CosmosDBWithEventualConsistencyTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                CosmosDBWithEventualConsistency.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "CosmosDB")]
        public void CosmosDBWithIPRangeTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                CosmosDBWithIPRange.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "CosmosDB")]
        public void CosmosDBTableWithVnetRulesTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                CosmosDBTableWithVirtualNetworkRule.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "CosmosDB")]
        public void CosmosDBWithKindMongoDBTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                CosmosDBWithKindMongoDB.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "CosmosDB")]
        public void HACosmosDBTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                HACosmosDB.Program.RunSample(rollUpClient);
            }
        }
    }
}