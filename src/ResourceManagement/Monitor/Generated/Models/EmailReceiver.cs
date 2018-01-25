// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// An email receiver.
    /// </summary>
    public partial class EmailReceiver
    {
        /// <summary>
        /// Initializes a new instance of the EmailReceiver class.
        /// </summary>
        public EmailReceiver()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the EmailReceiver class.
        /// </summary>
        /// <param name="name">The name of the email receiver. Names must be
        /// unique across all receivers within an action group.</param>
        /// <param name="emailAddress">The email address of this
        /// receiver.</param>
        /// <param name="status">The receiver status of the e-mail. Possible
        /// values include: 'NotSpecified', 'Enabled', 'Disabled'</param>
        public EmailReceiver(string name, string emailAddress, ReceiverStatus? status = default(ReceiverStatus?))
        {
            Name = name;
            EmailAddress = emailAddress;
            Status = status;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the name of the email receiver. Names must be unique
        /// across all receivers within an action group.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email address of this receiver.
        /// </summary>
        [JsonProperty(PropertyName = "emailAddress")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets the receiver status of the e-mail. Possible values include:
        /// 'NotSpecified', 'Enabled', 'Disabled'
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public ReceiverStatus? Status { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (EmailAddress == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "EmailAddress");
            }
        }
    }
}
