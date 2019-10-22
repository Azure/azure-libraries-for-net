// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Deployment information.
    /// </summary>
    public partial class DeploymentExtendedInner : Fluent.Resource
    {
        /// <summary>
        /// Initializes a new instance of the DeploymentExtendedInner class.
        /// </summary>
        public DeploymentExtendedInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DeploymentExtendedInner class.
        /// </summary>
        /// <param name="location">the location of the deployment.</param>
        /// <param name="properties">Deployment properties.</param>
        public DeploymentExtendedInner(string id = default(string), string name = default(string), string type = default(string), string location = default(string), DeploymentPropertiesExtended properties = default(DeploymentPropertiesExtended))
            : base(id, name, type)
        {
            Location = location;
            Properties = properties;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the location of the deployment.
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets deployment properties.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public DeploymentPropertiesExtended Properties { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Properties != null)
            {
                Properties.Validate();
            }
        }
    }
}
