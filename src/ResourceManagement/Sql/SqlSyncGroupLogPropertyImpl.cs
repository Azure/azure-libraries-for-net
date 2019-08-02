// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;
    using System;

    /// <summary>
    /// Implementation for SqlSyncGroupLogProperty.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5TcWxTeW5jR3JvdXBMb2dQcm9wZXJ0eUltcGw=
    internal partial class SqlSyncGroupLogPropertyImpl  :
        Wrapper<Models.SyncGroupLogProperties>,
        ISqlSyncGroupLogProperty
    {
        ///GENMHASH:B774F0903926E93143C234E1C63EB4FB:C0C35E00AF4E17F141675A2C05C7067B
        internal SqlSyncGroupLogPropertyImpl(SyncGroupLogProperties innerObject)
            : base(innerObject)
        {
        }

        ///GENMHASH:5FC871CDC06C6A2731D49555B4087783:97828D43B75006DA9AA60D313E23723B
        public string TracingId()
        {
            return this.Inner.TracingId?.ToString();
        }

        ///GENMHASH:8FCA98B25FDA8E6B393435D1C1196710:2FD6B2AB4A8EE541992A3D918D89E656
        public string OperationStatus()
        {
            return this.Inner.OperationStatus;
        }

        ///GENMHASH:F09D64F33FB3CA67604DBA9672C199CD:B7C816E9B048A98B16595F3E42A34832
        public string Details()
        {
            return this.Inner.Details;
        }

        ///GENMHASH:32ABF27B7A32286845C5FAFE717F8E4D:4F746FA90680C6D396784582E1F8A549
        public string Source()
        {
            return this.Inner.Source;
        }

        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:605B8FC69F180AFC7CE18C754024B46C
        public SyncGroupLogType Type()
        {
            return this.Inner.Type;
        }

        ///GENMHASH:45859958AA9C08487DCBDC7C1E9A55FD:8448E68448674491FD1723B68F87EB9D
        public DateTime? Timestamp()
        {
            return this.Inner.Timestamp;
        }
    }
}