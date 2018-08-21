// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class BatchAI : Samples.Tests.TestBase
    {
        public BatchAI(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact(Skip = "Using Storage API calls that cannot be recorded")]
        [Trait("Samples", "BatchAI")]
        public void ManageBatchAITest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageBatchAI.Program.RunSample(rollUpClient);
            }
        }
    }
}

