// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Rest;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Models
{
    /// <summary>
    /// The properties of a task step.
    /// </summary>
    [Newtonsoft.Json.JsonObject("Docker")]
    public partial class DockerTaskStep : TaskStepProperties
    {
        /// <summary>
        /// Initializes a new instance of the DockerTaskStep class.
        /// </summary>
        public DockerTaskStep()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DockerTaskStep class.
        /// </summary>
        /// <param name="dockerFilePath">the The Docker file path relative to the source context</param>
        /// <param name="baseImageDependencies">List of base image dependencies for a step.</param>
        /// <param name="contextPath">The URL(absolute or relative) of the source context for the task step.</param>
        /// <param name="contextAccessToken">The token (git PAT or SAS token of storage account blob) associated with the context for a step.</param>
        /// <param name="imageNames">the fully qualified image names including the repository and tag</param>
        /// <param name="isPushEnabled">indicates whether the image built should be pushed to the registry or not</param>
        /// <param name="noCache">indicates whether the image cache is enabled or not</param>
        /// <param name="arguments">the collection of override arguments to be used when executing this build step</param>
        public DockerTaskStep(string dockerFilePath, 
            IList<BaseImageDependency> baseImageDependencies = default(IList<BaseImageDependency>), 
            string contextPath = default(string), 
            string contextAccessToken = default(string), 
            IList<string> imageNames = default(IList<string>), 
            bool isPushEnabled = default(bool), 
            bool noCache = default(bool),
            IList<Argument> arguments = default(IList<Argument>))
    :       base(baseImageDependencies, contextPath, contextAccessToken)
        {
            DockerFilePath = dockerFilePath;
            ImageNames = imageNames;
            IsPushEnabled = isPushEnabled;
            NoCache = noCache;
            Arguments = arguments;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults.
        /// </summary>
        partial void CustomInit();

        /// <summary>
        ///  Gets or sets the The Docker file path relative to the source context.
        /// </summary>
        [JsonProperty(PropertyName = "dockerFilePath")]
        public string DockerFilePath { get; set; }

        /// <summary>
        /// Gets or sets the fully qualified image names including the repository and tag.
        /// </summary>
        [JsonProperty(PropertyName = "imageNames")]
        public IList<string> ImageNames { get; set; }

        /// <summary>
        /// Gets or sets the value of the property indicates whether the image built should be pushed to the registry or not.
        /// </summary>
        [JsonProperty(PropertyName = "isPushEnabled")]
        public bool? IsPushEnabled { get; set; }

        /// <summary>
        ///  Gets or sets the value of the property indicates whether the image cache is enabled or not.
        /// </summary>
        [JsonProperty(PropertyName = "noCache")]
        public bool? NoCache { get; set; }

        /// <summary>
        ///  Gets or sets the collection of override arguments to be used when executing this build step.
        /// </summary>
        [JsonProperty(PropertyName = "arguments")]
        public IList<Argument> Arguments { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (DockerFilePath == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "DockerFilePath");
            }
            if (Arguments != null)
            {
                foreach (var element in Arguments)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
