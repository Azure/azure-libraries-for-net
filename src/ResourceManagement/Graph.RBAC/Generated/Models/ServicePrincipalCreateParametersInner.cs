// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Graph.RBAC.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Graph;
    using Microsoft.Azure.Management.Graph.RBAC;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Request parameters for creating a new service principal.
    /// </summary>
    public partial class ServicePrincipalCreateParametersInner
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ServicePrincipalCreateParametersInner class.
        /// </summary>
        public ServicePrincipalCreateParametersInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ServicePrincipalCreateParametersInner class.
        /// </summary>
        /// <param name="appId">application Id</param>
        /// <param name="accountEnabled">Whether the account is enabled</param>
        /// <param name="keyCredentials">A collection of KeyCredential
        /// objects.</param>
        /// <param name="passwordCredentials">A collection of
        /// PasswordCredential objects</param>
        public ServicePrincipalCreateParametersInner(string appId, bool accountEnabled, IList<KeyCredential> keyCredentials = default(IList<KeyCredential>), IList<PasswordCredential> passwordCredentials = default(IList<PasswordCredential>))
        {
            AppId = appId;
            AccountEnabled = accountEnabled;
            KeyCredentials = keyCredentials;
            PasswordCredentials = passwordCredentials;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets application Id
        /// </summary>
        [JsonProperty(PropertyName = "appId")]
        public string AppId { get; set; }

        /// <summary>
        /// Gets or sets whether the account is enabled
        /// </summary>
        [JsonProperty(PropertyName = "accountEnabled")]
        public bool AccountEnabled { get; set; }

        /// <summary>
        /// Gets or sets a collection of KeyCredential objects.
        /// </summary>
        [JsonProperty(PropertyName = "keyCredentials")]
        public IList<KeyCredential> KeyCredentials { get; set; }

        /// <summary>
        /// Gets or sets a collection of PasswordCredential objects
        /// </summary>
        [JsonProperty(PropertyName = "passwordCredentials")]
        public IList<PasswordCredential> PasswordCredentials { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (AppId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "AppId");
            }
        }
    }
}
