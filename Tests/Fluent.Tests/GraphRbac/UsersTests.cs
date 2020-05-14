// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Fluent.Tests.Common;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.KeyVault.Fluent.Models;
using System.Linq;
using Xunit;
using System;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Azure.Tests;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using System.Collections.Generic;

namespace Fluent.Tests.Graph.RBAC
{

    public class Users
    {

        [Fact(Skip = "Requires special tenant")]
        public void CanGetUserByEmail()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                IGraphRbacManager manager = TestHelper.CreateGraphRbacManager();
                var user = manager.Users.GetByName("admin@azuresdkteam.onmicrosoft.com");
                Assert.Equal("Admin", user.Name);
            }
        }

        [Fact(Skip = "Jianghao Lu doesn't exist in test tenant")]
        public void CanGetUserByForeignEmail()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                IGraphRbacManager manager = TestHelper.CreateGraphRbacManager();
                var user = manager.Users.GetByName("jianghlu@microsoft.com");
                Assert.Equal("Jianghao Lu", user.Name);
            }
        }

        [Fact]
        public void CanGetUserByDisplayName()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                IGraphRbacManager manager = TestHelper.CreateGraphRbacManager();
                var user = manager.Users.GetByName("Reader zero");
                Assert.Equal("Reader zero", user.Name);
            }
        }

        [Fact]
        public void CanCreateUser()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                IGraphRbacManager manager = TestHelper.CreateGraphRbacManager();
                var name = SdkContext.RandomResourceName("user", 16);
                var user = manager.Users.Define("Automatic " + name)
                        .WithEmailAlias(name)
                        .WithPassword("StrongPass!123")
                        .WithPromptToChangePasswordOnLogin(true)
                        .Create();

                Assert.NotNull(user);
                Assert.NotNull(user.Id);
            }
        }

        [Fact]
        public void CanUpdateUser()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                IGraphRbacManager manager = TestHelper.CreateGraphRbacManager();
                var name = SdkContext.RandomResourceName("user", 16);
                var user = manager.Users.Define("Test " + name)
                        .WithEmailAlias(name)
                        .WithPassword("StrongPass!123")
                        .Create();

                user = user.Update()
                        .WithUsageLocation(CountryISOCode.Australia)
                        .Apply();

                Assert.Equal(CountryISOCode.Australia, user.UsageLocation);
            }
        }

        [Fact(Skip = "list user emails")]
        public void CanListAll()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                IGraphRbacManager manager = TestHelper.CreateGraphRbacManager();
                IEnumerable<IActiveDirectoryUser> users = manager.Users.ListAsync(true).Result;
                // It might not be true in live.
                Assert.True(users.Count() > 100);
            }
        }
    }
}