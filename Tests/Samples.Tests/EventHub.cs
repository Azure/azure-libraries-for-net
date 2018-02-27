// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class EventHub : Samples.Tests.TestBase
    {
        public EventHub(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Samples", "EventHub")]
        public void ManageEventHubTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageEventHub.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "EventHub")]
        public void ManageEventHubGeoDisasterRecoveryTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageEventHub.Program.RunSample(rollUpClient);
            }
        }
    }
}
