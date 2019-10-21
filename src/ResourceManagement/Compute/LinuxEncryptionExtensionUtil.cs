// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Compute.Fluent.Models;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;

    public partial class LinuxEncryptionExtensionUtil
    {

        /// <summary>
        /// Retrieves the data disk encryption status from the given instance view.
        /// </summary>
        /// <param name="instanceView">Encryption extension instance view.</param>
        /// <return>Data disk status.</return>
        internal static EncryptionStatus DataDiskStatus(VirtualMachineExtensionInstanceView instanceView)
        {
            string subStatusJson = InstanceViewFirstSubStatus(instanceView);
            if (subStatusJson == null)
            {
                return EncryptionStatus.Unknown;
            }
            JObject jObject = JObject.Parse(subStatusJson);
            if (jObject["data"] == null)
            {
                return EncryptionStatus.Unknown;
            }
            return EncryptionStatus.Parse((string)jObject["data"]);
        }

        /// <summary>
        /// The first sub-status from instance view sub-status collection associated with the provided
        /// encryption extension.
        /// </summary>
        /// <param name="instanceView">The extension instance view.</param>
        /// <return>The first sub-status.</return>
        internal static string InstanceViewFirstSubStatus(VirtualMachineExtensionInstanceView instanceView)
        {
            if (instanceView == null
                || instanceView.Substatuses == null)
            {
                return null;
            }
            IList<InstanceViewStatus> instanceViewSubStatuses = instanceView.Substatuses;
            if (instanceViewSubStatuses.Count == 0)
            {
                return null;
            }

            return instanceViewSubStatuses[0].Message;
        }

        /// <summary>
        /// The instance view status collection associated with the provided encryption extension.
        /// </summary>
        /// <param name="instanceView">The extension instance view.</param>
        /// <return>Status collection.</return>
        internal static IList<InstanceViewStatus> InstanceViewStatuses(VirtualMachineExtensionInstanceView instanceView)
        {
            if (instanceView == null
            || instanceView.Statuses == null)
            {
                return new List<InstanceViewStatus>();
            }
            return instanceView.Statuses;
        }

        /// <summary>
        /// Retrieves the operating system disk encryption status from the given instance view.
        /// </summary>
        /// <param name="instanceView">Encryption extension instance view.</param>
        /// <return>Os disk status.</return>
        internal static EncryptionStatus OSDiskStatus(VirtualMachineExtensionInstanceView instanceView)
        {
            string subStatusJson = InstanceViewFirstSubStatus(instanceView);
            if (subStatusJson == null)
            {
                return EncryptionStatus.Unknown;
            }
            JObject jObject = JObject.Parse(subStatusJson);
            if (jObject["os"] == null)
            {
                return EncryptionStatus.Unknown;
            }
            return EncryptionStatus.Parse((string)jObject["os"]);
        }

        /// <summary>
        /// Gets the encryption progress message.
        /// </summary>
        /// <param name="instanceView">Encryption extension instance view.</param>
        /// <return>The encryption progress message.</return>
        internal static string ProgressMessage(VirtualMachineExtensionInstanceView instanceView)
        {
            IList<InstanceViewStatus> statuses = InstanceViewStatuses(instanceView);
            if (statuses.Count == 0)
            {
                return null;
            }
            return statuses[0].Message;
        }
    }
}