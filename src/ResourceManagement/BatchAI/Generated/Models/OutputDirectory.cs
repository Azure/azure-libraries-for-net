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
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Output directory for the job.
    /// </summary>
    public partial class OutputDirectory
    {
        /// <summary>
        /// Initializes a new instance of the OutputDirectory class.
        /// </summary>
        public OutputDirectory()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the OutputDirectory class.
        /// </summary>
        /// <param name="id">The name for the output directory.</param>
        /// <param name="pathPrefix">The prefix path where the output directory
        /// will be created.</param>
        /// <param name="pathSuffix">The suffix path where the output directory
        /// will be created.</param>
        /// <param name="type">An enumeration, which specifies the type of job
        /// output directory.</param>
        /// <param name="createNew">True to create new directory.</param>
        public OutputDirectory(string id, string pathPrefix, string pathSuffix = default(string), string type = default(string), bool? createNew = default(bool?))
        {
            Id = id;
            PathPrefix = pathPrefix;
            PathSuffix = pathSuffix;
            Type = type;
            CreateNew = createNew;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the name for the output directory.
        /// </summary>
        /// <remarks>
        /// It will be available for the job as an environment variable under
        /// AZ_BATCHAI_OUTPUT_id.
        /// </remarks>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the prefix path where the output directory will be
        /// created.
        /// </summary>
        /// <remarks>
        /// NOTE: This is an absolute path to prefix. E.g.
        /// $AZ_BATCHAI_MOUNT_ROOT/MyNFS/MyLogs.
        /// </remarks>
        [JsonProperty(PropertyName = "pathPrefix")]
        public string PathPrefix { get; set; }

        /// <summary>
        /// Gets or sets the suffix path where the output directory will be
        /// created.
        /// </summary>
        /// <remarks>
        /// The suffix path where the output directory will be created.
        /// </remarks>
        [JsonProperty(PropertyName = "pathSuffix")]
        public string PathSuffix { get; set; }

        /// <summary>
        /// Gets or sets an enumeration, which specifies the type of job output
        /// directory.
        /// </summary>
        /// <remarks>
        /// Default value is Custom. The possible values are Model, Logs,
        /// Summary, and Custom. Users can use multiple enums for a single
        /// directory. Eg. outPutType='Model,Logs, Summary'. Possible values
        /// include: 'model', 'logs', 'summary', 'custom'
        /// </remarks>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets true to create new directory.
        /// </summary>
        /// <remarks>
        /// Default is true. If false, then the directory is not created and
        /// can be any directory path that the user specifies.
        /// </remarks>
        [JsonProperty(PropertyName = "createNew")]
        public bool? CreateNew { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Id == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Id");
            }
            if (PathPrefix == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "PathPrefix");
            }
        }
    }
}
