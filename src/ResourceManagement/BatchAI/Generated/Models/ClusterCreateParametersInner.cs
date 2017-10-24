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
    public partial class ClusterCreateParametersInner
    {
        /// <summary>
        /// Initializes a new instance of the ClusterCreateParametersInner
        /// class.
        /// </summary>
        public ClusterCreateParametersInner()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ClusterCreateParametersInner
        /// class.
        /// </summary>
        /// <param name="location">The region in which to create the
        /// cluster.</param>
        /// <param name="vmSize">The size of the virtual machines in the
        /// cluster.</param>
        /// <param name="userAccountSettings">Settings for user account that
        /// will be created on all compute nodes of the cluster.</param>
        /// <param name="tags">The user specified tags associated with the
        /// Cluster.</param>
        /// <param name="vmPriority">dedicated or lowpriority.</param>
        /// <param name="scaleSettings">Desired scale for the cluster.</param>
        /// <param name="virtualMachineConfiguration">Settings for OS image and
        /// mounted data volumes.</param>
        /// <param name="nodeSetup">Setup to be done on all compute nodes in
        /// the cluster.</param>
        /// <param name="subnet">Specifies the identifier of the subnet.
        /// </param>
        public ClusterCreateParametersInner(string location, string vmSize, UserAccountSettings userAccountSettings, IDictionary<string, string> tags = default(IDictionary<string, string>), VmPriority? vmPriority = default(VmPriority?), ScaleSettings scaleSettings = default(ScaleSettings), VirtualMachineConfiguration virtualMachineConfiguration = default(VirtualMachineConfiguration), NodeSetup nodeSetup = default(NodeSetup), ResourceId subnet = default(ResourceId))
        {
            Location = location;
            Tags = tags;
            VmSize = vmSize;
            VmPriority = vmPriority;
            ScaleSettings = scaleSettings;
            VirtualMachineConfiguration = virtualMachineConfiguration;
            NodeSetup = nodeSetup;
            UserAccountSettings = userAccountSettings;
            Subnet = subnet;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the region in which to create the cluster.
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the user specified tags associated with the Cluster.
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Gets or sets the size of the virtual machines in the cluster.
        /// </summary>
        /// <remarks>
        /// All virtual machines in a cluster are the same size. For
        /// information about available VM sizes for clusters using images from
        /// the Virtual Machines Marketplace (see Sizes for Virtual Machines
        /// (Linux) or Sizes for Virtual Machines (Windows). Batch AI service
        /// supports all Azure VM sizes except STANDARD_A0 and those with
        /// premium storage (STANDARD_GS, STANDARD_DS, and STANDARD_DSV2
        /// series).
        /// </remarks>
        [JsonProperty(PropertyName = "properties.vmSize")]
        public string VmSize { get; set; }

        /// <summary>
        /// Gets or sets dedicated or lowpriority.
        /// </summary>
        /// <remarks>
        /// Default is dedicated. Possible values include: 'dedicated',
        /// 'lowpriority'
        /// </remarks>
        [JsonProperty(PropertyName = "properties.vmPriority")]
        public VmPriority? VmPriority { get; set; }

        /// <summary>
        /// Gets or sets desired scale for the cluster.
        /// </summary>
        [JsonProperty(PropertyName = "properties.scaleSettings")]
        public ScaleSettings ScaleSettings { get; set; }

        /// <summary>
        /// Gets or sets settings for OS image and mounted data volumes.
        /// </summary>
        [JsonProperty(PropertyName = "properties.virtualMachineConfiguration")]
        public VirtualMachineConfiguration VirtualMachineConfiguration { get; set; }

        /// <summary>
        /// Gets or sets setup to be done on all compute nodes in the cluster.
        /// </summary>
        [JsonProperty(PropertyName = "properties.nodeSetup")]
        public NodeSetup NodeSetup { get; set; }

        /// <summary>
        /// Gets or sets settings for user account that will be created on all
        /// compute nodes of the cluster.
        /// </summary>
        [JsonProperty(PropertyName = "properties.userAccountSettings")]
        public UserAccountSettings UserAccountSettings { get; set; }

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
            if (UserAccountSettings == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "UserAccountSettings");
            }
            if (ScaleSettings != null)
            {
                ScaleSettings.Validate();
            }
            if (VirtualMachineConfiguration != null)
            {
                VirtualMachineConfiguration.Validate();
            }
            if (NodeSetup != null)
            {
                NodeSetup.Validate();
            }
            if (UserAccountSettings != null)
            {
                UserAccountSettings.Validate();
            }
            if (Subnet != null)
            {
                Subnet.Validate();
            }
        }
    }
}
