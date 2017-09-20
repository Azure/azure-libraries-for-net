// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class ContainerInstance : Samples.Tests.TestBase
    {
        public ContainerInstance(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact(Skip = "Storage plane calls can not be played back")]
        [Trait("Samples", "ContainerInstance")]
        public void ManageContainerInstanceWithAzureFileShareMountTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageContainerInstanceWithAzureFileShareMount.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "Storage plane calls can not be played back")]
        [Trait("Samples", "ContainerInstance")]
        public void ManageContainerInstanceWithManualAzureFileShareMountCreationTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageContainerInstanceWithManualAzureFileShareMountCreation.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "ContainerInstance")]
        public void ManageContainerInstanceWithMultipleContainerImagesTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageContainerInstanceWithMultipleContainerImages.Program.RunSample(rollUpClient);
            }
        }

        [Fact(Skip = "Docker .Net client and SSHShell require real network connections to be made")]
        [Trait("Samples", "ContainerInstance")]
        public void ManageContainerInstanceWithAzureContainerRegistryTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageContainerInstanceWithAzureContainerRegistry.Program.RunSample(rollUpClient);
            }
        }
    }
}
