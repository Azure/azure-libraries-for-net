// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Samples.Tests
{
    public class ContainerService : Samples.Tests.TestBase
    {
        public ContainerService(ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait("Samples", "ContainerService")]
        public void ManageContainerServiceWithDockerSwarmOrchestratorTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                ManageContainerServiceWithDockerSwarmOrchestrator.Program.RunSample(rollUpClient);
            }
        }

        [Fact]
        [Trait("Samples", "ContainerService")]
        public void ManageContainerServiceWithKubernetesOrchestratorTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                if (Microsoft.Azure.Test.HttpRecorder.HttpMockServer.Mode == Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode.Playback)
                {
                    ManageContainerServiceWithKubernetesOrchestrator.Program.RunSample(rollUpClient, "clientId", "secret");
                }
                else
                {
                    ManageContainerServiceWithKubernetesOrchestrator.Program.RunSample(rollUpClient, "", "");
                }
            }
        }

        [Fact(Skip = "The deployment will record client id and secret")]
        [Trait("Samples", "ContainerService")]
        public void ManageKubernetesClusterTest()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                var rollUpClient = TestHelper.CreateRollupClient();
                if (Microsoft.Azure.Test.HttpRecorder.HttpMockServer.Mode == Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode.Playback)
                {
                    ManageKubernetesCluster.Program.RunSample(rollUpClient, "clientId", "secret");
                }
                else
                {
                    ManageKubernetesCluster.Program.RunSample(rollUpClient, "", "");
                }
            }
        }


    }
}
