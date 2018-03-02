// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// Response containing the SQL Active Directory administrator.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxBY3RpdmVEaXJlY3RvcnlBZG1pbmlzdHJhdG9ySW1wbA==
    internal partial class SqlActiveDirectoryAdministratorImpl  :
        Wrapper<Models.ServerAzureADAdministratorInner>,
        ISqlActiveDirectoryAdministrator
    {
        ///GENMHASH:22EDA2B7146DD780C4115EB6C889D2C4:C0C35E00AF4E17F141675A2C05C7067B
        public SqlActiveDirectoryAdministratorImpl(ServerAzureADAdministratorInner innerObject) : base(innerObject)
        {
        }

        ///GENMHASH:A150E806D025822AB5DF5438B386C9F2:B57EB0926464C7E25E314111FEEF4D87
        public string SignInName()
        {
            return this.Inner.Login;
        }

        ///GENMHASH:CBA0FE4A7AC3C49BD23AD5035748F401:664EA762DB8F1F388D91C38B7679B17B
        public string AdministratorType()
        {
            return ServerAzureADAdministratorInner.AdministratorType;
        }

        ///GENMHASH:DA183CCEBC00D21096D59D1B439F4E2F:E273F7B2E546B4FDC30F7121431B63AB
        public string TenantId()
        {
            return this.Inner.TenantId.ToString();
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:52272CFD5C4B050017799A62A991DBDB
        public string Id()
        {
            return this.Inner.Sid.ToString();
        }
    }
}