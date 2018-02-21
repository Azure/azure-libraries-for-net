// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.Txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Fluent.Tests.EventHub
{
    public class EventHub
    {
        [Fact]
        public void CanManage()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgns");

                var azure = TestHelper.CreateRollupClient();
                try
                {
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact]
        public void CanManageConusmerGroups()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgns");

                var azure = TestHelper.CreateRollupClient();
                try
                {
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact]
        public void CanManageAuthorizationRules()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgns");

                var azure = TestHelper.CreateRollupClient();
                try
                {
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact]
        public void CanConfigureDataCapturing()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgns");

                var azure = TestHelper.CreateRollupClient();
                try
                {
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch
                    { }
                }
            }
        }

        [Fact]
        public void CanEnableDataCaptureOnUpdate()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var region = Region.USEast;
                var groupName = TestUtilities.GenerateName("rgns");

                var azure = TestHelper.CreateRollupClient();
                try
                {
                }
                finally
                {
                    try
                    {
                        azure.ResourceGroups.BeginDeleteByName(groupName);
                    }
                    catch
                    { }
                }
            }
        }
    }
}
