// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Samples.ServiceFabric;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class ServiceFabric : Samples.Tests.TestBase
    {
        public ServiceFabric(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Samples", "Service Fabric")]
        public void CreateBasicCluster()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ProductionCluster.RunSample(rollUpClient);
            }
        }

    }
}
