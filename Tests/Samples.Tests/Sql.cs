// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class Sql : Samples.Tests.TestBase
    {
        public Sql(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Samples", "Sql")]
        public void ManageSqlDatabaseTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageSqlDatabase.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Sql")]
        public void ManageSqlDatabaseInElasticPoolTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageSqlDatabaseInElasticPool.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Sql")]
        public void ManageSqlDatabasesAcrossDifferentDataCentersTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageSqlDatabasesAcrossDifferentDataCenters.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "Sql")]
        public void ManageSqlFirewallRulesTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageSqlFirewallRules.Program.RunSample(rollUpClient);
            }
        }

//        [Fact(Skip = "Manual only test: requires couple hours to finish")]
        [Fact]
        [Trait("Samples", "Sql")]
        public void ManageSqlWithRecoveredOrRestoredDatabaseTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageSqlWithRecoveredOrRestoredDatabase.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "Manual only test: requires http calls to storage data plane")]
        [Trait("Samples", "Sql")]
        public void ManageSqlImportExportDatabaseTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageSqlImportExportDatabase.Program.RunSample(rollUpClient);
            }
        }
    }
}
