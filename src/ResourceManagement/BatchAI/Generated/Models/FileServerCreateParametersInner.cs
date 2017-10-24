// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.BatchAI.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.BatchAI;
    using Microsoft.Azure.Management.BatchAI.Fluent;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Parameters supplied to the Create operation.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class FileServerCreateParametersInner
    {
        /// <summary>
        /// Initializes a new instance of the FileServerCreateParametersInner
        /// class.
        /// </summary>
        public FileServerCreateParametersInner()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the FileServerCreateParametersInner
        /// class.
        /// </summary>
        /// <param name="location">The region in which to create the File
        /// Server.</param>
        /// <param name="vmSize">The size of the virtual machine of the file
        /// server.</param>
        /// <param name="sshConfiguration">SSH settings for the file
        /// server.</param>
        /// <param name="dataDisks">Settings for the data disk which would be
        /// created for the file server.</param>
        /// <param name="tags">The user specified tags associated with the File
        /// Server.</param>
        /// <param name="subnet">Specifies the identifier of the
        /// subnet.</param>
        public FileServerCreateParametersInner(string location, string vmSize, SshConfiguration sshConfiguration, DataDisks dataDisks, IDictionary<string, string> tags = default(IDictionary<string, string>), ResourceId subnet = default(ResourceId))
        {
            Location = location;
            Tags = tags;
            VmSize = vmSize;
            SshConfiguration = sshConfiguration;
            DataDisks = dataDisks;
            Subnet = subnet;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the region in which to create the File Server.
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the user specified tags associated with the File
        /// Server.
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the size of the virtual machine of the file server.
        /// </summary>
        /// <remarks>
        /// For information about available VM sizes for fileservers from the
        /// Virtual Machines Marketplace, see Sizes for Virtual Machines
        /// (Linux).
        /// </remarks>
        [JsonProperty(PropertyName = "properties.vmSize")]
        public string VmSize { get; set; }

        /// <summary>
        /// Gets or sets SSH settings for the file server.
        /// </summary>
        [JsonProperty(PropertyName = "properties.sshConfiguration")]
        public SshConfiguration SshConfiguration { get; set; }

        /// <summary>
        /// Gets or sets settings for the data disk which would be created for
        /// the file server.
        /// </summary>
        [JsonProperty(PropertyName = "properties.dataDisks")]
        public DataDisks DataDisks { get; set; }

        /// <summary>
        /// Gets or sets specifies the identifier of the subnet.
        /// </summary>
        [JsonProperty(PropertyName = "properties.subnet")]
        public ResourceId Subnet { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Location == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Location");
            }
            if (VmSize == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "VmSize");
            }
            if (SshConfiguration == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "SshConfiguration");
            }
            if (DataDisks == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DataDisks");
            }
            if (SshConfiguration != null)
            {
                SshConfiguration.Validate();
            }
            if (DataDisks != null)
            {
                DataDisks.Validate();
            }
            if (Subnet != null)
            {
                Subnet.Validate();
            }
        }
    }
}