// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// The properties for updating the source code repository.
    /// </summary>
    public partial class SourceUpdateParameters
    {
        /// <summary>
        /// Initializes a new instance of the SourceUpdateParameters class.
        /// </summary>
        public SourceUpdateParameters()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SourceUpdateParameters class.
        /// </summary>
        /// <param name="sourceControlType">The type of source control service.
        /// Possible values include: 'Github',
        /// 'VisualStudioTeamService'</param>
        /// <param name="repositoryUrl">The full URL to the source code
        /// respository</param>
        /// <param name="branch">The branch name of the source code.</param>
        /// <param name="sourceControlAuthProperties">The authorization
        /// properties for accessing the source code repository and to set up
        /// webhooks for notifications.</param>
        public SourceUpdateParameters(string sourceControlType = default(string), string repositoryUrl = default(string), string branch = default(string), AuthInfoUpdateParameters sourceControlAuthProperties = default(AuthInfoUpdateParameters))
        {
            SourceControlType = sourceControlType;
            RepositoryUrl = repositoryUrl;
            Branch = branch;
            SourceControlAuthProperties = sourceControlAuthProperties;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the type of source control service. Possible values
        /// include: 'Github', 'VisualStudioTeamService'
        /// </summary>
        [JsonProperty(PropertyName = "sourceControlType")]
        public string SourceControlType { get; set; }

        /// <summary>
        /// Gets or sets the full URL to the source code respository
        /// </summary>
        [JsonProperty(PropertyName = "repositoryUrl")]
        public string RepositoryUrl { get; set; }

        /// <summary>
        /// Gets or sets the branch name of the source code.
        /// </summary>
        [JsonProperty(PropertyName = "branch")]
        public string Branch { get; set; }

        /// <summary>
        /// Gets or sets the authorization properties for accessing the source
        /// code repository and to set up
        /// webhooks for notifications.
        /// </summary>
        [JsonProperty(PropertyName = "sourceControlAuthProperties")]
        public AuthInfoUpdateParameters SourceControlAuthProperties { get; set; }

    }
}
