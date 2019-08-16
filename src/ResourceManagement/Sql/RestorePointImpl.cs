// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    /// <summary>
    /// Implementation for Restore point interface.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5SZXN0b3JlUG9pbnRJbXBs
    internal partial class RestorePointImpl  :
        Wrapper<Models.RestorePointInner>,
        IRestorePoint
    {
        private ResourceId resourceId;
        private string sqlServerName;
        private string resourceGroupName;

        ///GENMHASH:8BF35069264E47CDD42CDDEF7F56D9A0:FE22A3B9FE8FEA30A8F2D84276879172
        public RestorePointImpl(string resourceGroupName, string sqlServerName, RestorePointInner innerObject) : base(innerObject)
        {
            this.resourceGroupName = resourceGroupName;
            this.sqlServerName = sqlServerName;
            this.resourceId = ResourceId.FromString(this.Inner.Id);
        }

        ///GENMHASH:E9EDBD2E8DC2C547D1386A58778AA6B9:7EBD4102FEBFB0AD7091EA1ACBD84F8B
        public string ResourceGroupName()
        {
            return this.resourceGroupName;
        }

        ///GENMHASH:E7ABDAFE895DE30905D46D515062DB59:4FF2FEC4B193B40F5666C7C0244DEB2E
        public string DatabaseName()
        {
            return resourceId.Parent.Name;
        }

        ///GENMHASH:5D8C32D2751B491914616D667B547A6C:7EDB4220F88516901344158E2ED52A30
        public DateTime? RestorePointCreationDate()
        {
            return this.Inner.RestorePointCreationDate;
        }

        ///GENMHASH:61F5809AB3B985C61AC40B98B1FBC47E:998832D58C98F6DCF3637916D2CC70B9
        public string SqlServerName()
        {
            return this.sqlServerName;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:41180B8AE28244EF8581E555D8B35D2B:BDE89E5566556E98EB317C0625517B0F
        public string DatabaseId()
        {
            return resourceId.Parent.Id;
        }

        ///GENMHASH:F2ABE029F6A55328DAF428566FF166D9:AA34FA1E27583C49DDBE6DC99C3A871E
        public Models.RestorePointType RestorePointType()
        {
            return this.Inner.RestorePointType.GetValueOrDefault();
        }

        ///GENMHASH:FA6C4C8AE7729C6D128F00A0883B7A82:050D474227760B6267EFCEC6085DD2B2
        public DateTime? EarliestRestoreDate()
        {
            return this.Inner.EarliestRestoreDate;
        }
    }
}