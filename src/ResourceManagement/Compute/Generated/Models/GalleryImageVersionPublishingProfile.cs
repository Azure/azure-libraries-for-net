// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The publishing profile of a gallery image version.
    /// </summary>
    public partial class GalleryImageVersionPublishingProfile : GalleryArtifactPublishingProfileBase
    {
        /// <summary>
        /// Initializes a new instance of the
        /// GalleryImageVersionPublishingProfile class.
        /// </summary>
        public GalleryImageVersionPublishingProfile()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// GalleryImageVersionPublishingProfile class.
        /// </summary>
        /// <param name="regions">The regions where the artifact is going to be
        /// published.</param>
        /// <param name="scaleTier">The scale tier of the gallery image
        /// version. Valid values are 'S30' and 'S100'. Possible values
        /// include: 'S30', 'S100'</param>
        /// <param name="excludeFromLatest">The flag means that if it is set to
        /// true, people deploying VMs with 'latest' as version will not use
        /// this version.</param>
        /// <param name="publishedDate">The time when the gallery image version
        /// is published.</param>
        /// <param name="endOfLifeDate">The end of life date of the gallery
        /// image version.</param>
        public GalleryImageVersionPublishingProfile(IList<string> regions = default(IList<string>), GalleryArtifactSource source = default(GalleryArtifactSource), ScaleTier scaleTier = default(ScaleTier), bool? excludeFromLatest = default(bool?), System.DateTime? publishedDate = default(System.DateTime?), System.DateTime? endOfLifeDate = default(System.DateTime?))
            : base(regions, source)
        {
            ScaleTier = scaleTier;
            ExcludeFromLatest = excludeFromLatest;
            PublishedDate = publishedDate;
            EndOfLifeDate = endOfLifeDate;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the scale tier of the gallery image version. Valid
        /// values are 'S30' and 'S100'. Possible values include: 'S30', 'S100'
        /// </summary>
        [JsonProperty(PropertyName = "scaleTier")]
        public ScaleTier ScaleTier { get; set; }

        /// <summary>
        /// Gets or sets the flag means that if it is set to true, people
        /// deploying VMs with 'latest' as version will not use this version.
        /// </summary>
        [JsonProperty(PropertyName = "excludeFromLatest")]
        public bool? ExcludeFromLatest { get; set; }

        /// <summary>
        /// Gets the time when the gallery image version is published.
        /// </summary>
        [JsonProperty(PropertyName = "publishedDate")]
        public System.DateTime? PublishedDate { get; private set; }

        /// <summary>
        /// Gets or sets the end of life date of the gallery image version.
        /// </summary>
        [JsonProperty(PropertyName = "endOfLifeDate")]
        public System.DateTime? EndOfLifeDate { get; set; }

    }
}
