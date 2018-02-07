// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class Monitor : TestBase
    {
        public Monitor(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact(Skip = "Live only sample due to the need to query metrics at the current execution time which is always variable.")]
        [Trait("Samples", "Monitor")]
        public void QueryMetricsAndActivityLogsTest()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                QueryMetricsAndActivityLogs.Program.RunSample(rollUpClient);
            }
        }
    }
}
