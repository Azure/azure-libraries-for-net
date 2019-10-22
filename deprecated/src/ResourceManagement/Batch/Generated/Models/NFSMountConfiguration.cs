// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Batch.Fluent.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Information used to connect to an NFS file system.
    /// </summary>
    public partial class NFSMountConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the NFSMountConfiguration class.
        /// </summary>
        public NFSMountConfiguration()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the NFSMountConfiguration class.
        /// </summary>
        /// <param name="source">The URI of the file system to mount.</param>
        /// <param name="relativeMountPath">The relative path on the compute
        /// node where the file system will be mounted</param>
        /// <param name="mountOptions">Additional command line options to pass
        /// to the mount command.</param>
        public NFSMountConfiguration(string source, string relativeMountPath, string mountOptions = default(string))
        {
            Source = source;
            RelativeMountPath = relativeMountPath;
            MountOptions = mountOptions;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the URI of the file system to mount.
        /// </summary>
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the relative path on the compute node where the file
        /// system will be mounted
        /// </summary>
        /// <remarks>
        /// All file systems are mounted relative to the Batch mounts
        /// directory, accessible via the AZ_BATCH_NODE_MOUNTS_DIR environment
        /// variable.
        /// </remarks>
        [JsonProperty(PropertyName = "relativeMountPath")]
        public string RelativeMountPath { get; set; }

        /// <summary>
        /// Gets or sets additional command line options to pass to the mount
        /// command.
        /// </summary>
        /// <remarks>
        /// These are 'net use' options in Windows and 'mount' options in
        /// Linux.
        /// </remarks>
        [JsonProperty(PropertyName = "mountOptions")]
        public string MountOptions { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Source == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Source");
            }
            if (RelativeMountPath == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "RelativeMountPath");
            }
        }
    }
}
