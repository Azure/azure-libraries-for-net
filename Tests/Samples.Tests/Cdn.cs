// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class Cdn : Samples.Tests.TestBase
    {
        public Cdn(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact(Skip ="Fails with server side issue, need to follow up with the CDN service team")]
        [Trait("Samples", "Cdn")]
        public void ManageCdnTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageCdn.Program.RunSample(rollUpClient);
            }
        }
    }
}
