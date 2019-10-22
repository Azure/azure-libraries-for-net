// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Specifies Windows operating system settings on the virtual machine.
    /// </summary>
    public partial class WindowsConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the WindowsConfiguration class.
        /// </summary>
        public WindowsConfiguration()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the WindowsConfiguration class.
        /// </summary>
        /// <param name="provisionVMAgent">Indicates whether virtual machine
        /// agent should be provisioned on the virtual machine.
        /// &lt;br&gt;&lt;br&gt; When this property is not specified in the
        /// request body, default behavior is to set it to true.  This will
        /// ensure that VM Agent is installed on the VM so that extensions can
        /// be added to the VM later.</param>
        /// <param name="enableAutomaticUpdates">Indicates whether Automatic
        /// Updates is enabled for the Windows virtual machine. Default value
        /// is true. &lt;br&gt;&lt;br&gt; For virtual machine scale sets, this
        /// property can be updated and updates will take effect on OS
        /// reprovisioning.</param>
        /// <param name="timeZone">Specifies the time zone of the virtual
        /// machine. e.g. "Pacific Standard Time"</param>
        /// <param name="additionalUnattendContent">Specifies additional
        /// base-64 encoded XML formatted information that can be included in
        /// the Unattend.xml file, which is used by Windows Setup.</param>
        /// <param name="winRM">Specifies the Windows Remote Management
        /// listeners. This enables remote Windows PowerShell.</param>
        public WindowsConfiguration(bool? provisionVMAgent = default(bool?), bool? enableAutomaticUpdates = default(bool?), string timeZone = default(string), IList<AdditionalUnattendContent> additionalUnattendContent = default(IList<AdditionalUnattendContent>), WinRMConfiguration winRM = default(WinRMConfiguration))
        {
            ProvisionVMAgent = provisionVMAgent;
            EnableAutomaticUpdates = enableAutomaticUpdates;
            TimeZone = timeZone;
            AdditionalUnattendContent = additionalUnattendContent;
            WinRM = winRM;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets indicates whether virtual machine agent should be
        /// provisioned on the virtual machine.
        /// &amp;lt;br&amp;gt;&amp;lt;br&amp;gt; When this property is not
        /// specified in the request body, default behavior is to set it to
        /// true.  This will ensure that VM Agent is installed on the VM so
        /// that extensions can be added to the VM later.
        /// </summary>
        [JsonProperty(PropertyName = "provisionVMAgent")]
        public bool? ProvisionVMAgent { get; set; }

        /// <summary>
        /// Gets or sets indicates whether Automatic Updates is enabled for the
        /// Windows virtual machine. Default value is true.
        /// &amp;lt;br&amp;gt;&amp;lt;br&amp;gt; For virtual machine scale
        /// sets, this property can be updated and updates will take effect on
        /// OS reprovisioning.
        /// </summary>
        [JsonProperty(PropertyName = "enableAutomaticUpdates")]
        public bool? EnableAutomaticUpdates { get; set; }

        /// <summary>
        /// Gets or sets specifies the time zone of the virtual machine. e.g.
        /// "Pacific Standard Time"
        /// </summary>
        [JsonProperty(PropertyName = "timeZone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets or sets specifies additional base-64 encoded XML formatted
        /// information that can be included in the Unattend.xml file, which is
        /// used by Windows Setup.
        /// </summary>
        [JsonProperty(PropertyName = "additionalUnattendContent")]
        public IList<AdditionalUnattendContent> AdditionalUnattendContent { get; set; }

        /// <summary>
        /// Gets or sets specifies the Windows Remote Management listeners.
        /// This enables remote Windows PowerShell.
        /// </summary>
        [JsonProperty(PropertyName = "winRM")]
        public WinRMConfiguration WinRM { get; set; }

    }
}
