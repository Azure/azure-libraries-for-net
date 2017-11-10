// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class Locks : TestBase
    {
        public Locks(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Samples", "Locks")]
        public void ManageLocksTest()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageLocks.Program.RunSample(rollUpClient);
            }
        }
    }
}
