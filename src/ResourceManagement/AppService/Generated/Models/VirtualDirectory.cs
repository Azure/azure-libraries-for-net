// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.AppService.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.AppService;
    using Microsoft.Azure.Management.AppService.Fluent;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Directory for virtual application.
    /// </summary>
    public partial class VirtualDirectory
    {
        /// <summary>
        /// Initializes a new instance of the VirtualDirectory class.
        /// </summary>
        public VirtualDirectory()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the VirtualDirectory class.
        /// </summary>
        /// <param name="virtualPath">Path to virtual application.</param>
        /// <param name="physicalPath">Physical path.</param>
        public VirtualDirectory(string virtualPath = default(string), string physicalPath = default(string))
        {
            VirtualPath = virtualPath;
            PhysicalPath = physicalPath;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets path to virtual application.
        /// </summary>
        [JsonProperty(PropertyName = "virtualPath")]
        public string VirtualPath { get; set; }

        /// <summary>
        /// Gets or sets physical path.
        /// </summary>
        [JsonProperty(PropertyName = "physicalPath")]
        public string PhysicalPath { get; set; }

    }
}
