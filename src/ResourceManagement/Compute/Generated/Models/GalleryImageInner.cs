// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Specifies information about the gallery image that you want to create
    /// or update.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class GalleryImageInner : Management.ResourceManager.Fluent.Resource
    {
        /// <summary>
        /// Initializes a new instance of the GalleryImageInner class.
        /// </summary>
        public GalleryImageInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the GalleryImageInner class.
        /// </summary>
        /// <param name="description">The description of this gallery image
        /// resource.</param>
        /// <param name="eula">The Eula agreement for the gallery
        /// image.</param>
        /// <param name="privacyStatementUri">The privacy statement
        /// uri.</param>
        /// <param name="releaseNoteUri">The release note uri.</param>
        /// <param name="osType">This property allows you to specify the type
        /// of the OS that is included in the disk if creating a VM from
        /// user-image or a specialized VHD. &lt;br&gt;&lt;br&gt; Possible
        /// values are: &lt;br&gt;&lt;br&gt; **Windows** &lt;br&gt;&lt;br&gt;
        /// **Linux**. Possible values include: 'Windows', 'Linux'</param>
        /// <param name="osState">The OS State. Possible values include:
        /// 'Generalized', 'Specialized'</param>
        /// <param name="endOfLifeDate">The end of life of this gallery
        /// image.</param>
        /// <param name="provisioningState">The current state of the gallery
        /// image.</param>
        public GalleryImageInner(string location, string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string description = default(string), string eula = default(string), string privacyStatementUri = default(string), string releaseNoteUri = default(string), OperatingSystemTypes? osType = default(OperatingSystemTypes?), OperatingSystemStateTypes? osState = default(OperatingSystemStateTypes?), System.DateTime? endOfLifeDate = default(System.DateTime?), GalleryImageIdentifier identifier = default(GalleryImageIdentifier), RecommendedMachineConfiguration recommended = default(RecommendedMachineConfiguration), Disallowed disallowed = default(Disallowed), ImagePurchasePlan purchasePlan = default(ImagePurchasePlan), ProvisioningState provisioningState = default(ProvisioningState))
            : base(location, id, name, type, tags)
        {
            Description = description;
            Eula = eula;
            PrivacyStatementUri = privacyStatementUri;
            ReleaseNoteUri = releaseNoteUri;
            OsType = osType;
            OsState = osState;
            EndOfLifeDate = endOfLifeDate;
            Identifier = identifier;
            Recommended = recommended;
            Disallowed = disallowed;
            PurchasePlan = purchasePlan;
            ProvisioningState = provisioningState;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the description of this gallery image resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Eula agreement for the gallery image.
        /// </summary>
        [JsonProperty(PropertyName = "properties.eula")]
        public string Eula { get; set; }

        /// <summary>
        /// Gets or sets the privacy statement uri.
        /// </summary>
        [JsonProperty(PropertyName = "properties.privacyStatementUri")]
        public string PrivacyStatementUri { get; set; }

        /// <summary>
        /// Gets or sets the release note uri.
        /// </summary>
        [JsonProperty(PropertyName = "properties.releaseNoteUri")]
        public string ReleaseNoteUri { get; set; }

        /// <summary>
        /// Gets or sets this property allows you to specify the type of the OS
        /// that is included in the disk if creating a VM from user-image or a
        /// specialized VHD. &amp;lt;br&amp;gt;&amp;lt;br&amp;gt; Possible
        /// values are: &amp;lt;br&amp;gt;&amp;lt;br&amp;gt; **Windows**
        /// &amp;lt;br&amp;gt;&amp;lt;br&amp;gt; **Linux**. Possible values
        /// include: 'Windows', 'Linux'
        /// </summary>
        [JsonProperty(PropertyName = "properties.osType")]
        public OperatingSystemTypes? OsType { get; set; }

        /// <summary>
        /// Gets or sets the OS State. Possible values include: 'Generalized',
        /// 'Specialized'
        /// </summary>
        [JsonProperty(PropertyName = "properties.osState")]
        public OperatingSystemStateTypes? OsState { get; set; }

        /// <summary>
        /// Gets or sets the end of life of this gallery image.
        /// </summary>
        [JsonProperty(PropertyName = "properties.endOfLifeDate")]
        public System.DateTime? EndOfLifeDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties.identifier")]
        public GalleryImageIdentifier Identifier { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties.recommended")]
        public RecommendedMachineConfiguration Recommended { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties.disallowed")]
        public Disallowed Disallowed { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "properties.purchasePlan")]
        public ImagePurchasePlan PurchasePlan { get; set; }

        /// <summary>
        /// Gets the current state of the gallery image.
        /// </summary>
        /// <remarks>
        /// The provisioning state, which only appears in the response.
        /// Possible values include: 'Creating', 'Updating', 'Failed',
        /// 'Succeeded', 'Deleting', 'Migrating'
        /// </remarks>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public ProvisioningState ProvisioningState { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
