// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// Implementation for SqlDatabaseImportExportResponse.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxEYXRhYmFzZUltcG9ydEV4cG9ydFJlc3BvbnNlSW1wbA==
    internal partial class SqlDatabaseImportExportResponseImpl  :
        Wrapper<Models.ImportExportResponseInner>,
        ISqlDatabaseImportExportResponse
    {
        private string key;

        ///GENMHASH:DF5070CC0911A10D9AF3A4D384895BCF:0348450E13F50AE1A527DEF8E5E33A3A
        public SqlDatabaseImportExportResponseImpl(ImportExportResponseInner innerObject) : base(innerObject)
        {
            this.key = SdkContext.RandomGuid();
        }

        ///GENMHASH:5ED618DE41DCDE9DBC9F8179EF143BC3:8E2B796492A899DDFDE11B0D7360B3FE
        public string LastModifiedTime()
        {
            return this.Inner.LastModifiedTime;
        }

        ///GENMHASH:AD8B566005958FF6E758A8E060D3A079:B4B32303D6D890B3085173EAD9B5BBBE
        public string QueuedTime()
        {
            return this.Inner.QueuedTime;
        }

        ///GENMHASH:5B3834A48693AF42FF724A56409D0493:23B981C96436043025C154CA336B01DE
        public string RequestType()
        {
            return this.Inner.RequestType;
        }

        ///GENMHASH:E7ABDAFE895DE30905D46D515062DB59:44F5F71CD9996FE437F3FF8F3E8E46F9
        public string DatabaseName()
        {
            return this.Inner.DatabaseName;
        }

        ///GENMHASH:7EC64CE674517E507F9E7D72F93A7DF6:83C9FF1F82052A9E5127DEA47990F4A0
        public string ErrorMessage()
        {
            return this.Inner.ErrorMessage;
        }

        ///GENMHASH:20676CF3647D516CBCCD0807065BACB9:55F0618BF6BD745C131C2BBD910CE4A0
        public string ServerName()
        {
            return this.Inner.ServerName;
        }

        ///GENMHASH:4029ACDA8183141D0A32A703181D3AC7:E1EE4805B49D721D3F6642843EF81C19
        public string RequestId()
        {
            return this.Inner.RequestId.ToString();
        }

        ///GENMHASH:AFC355B4308B5448287F81B2FC310B2D:5F3D4F34310CF18DE1CB91254B6BCEFF
        public string BlobUri()
        {
            return this.Inner.BlobUri;
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

        ///GENMHASH:3199B79470C9D13993D729B188E94A46:6653B80313D99B59B1A1B07C544D1CB7
        public string Key()
        {
            return this.key;
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:1ABA34EF946CBD0278FAD778141792B2
        public string Status()
        {
            return this.Inner.Status;
        }
    }
}