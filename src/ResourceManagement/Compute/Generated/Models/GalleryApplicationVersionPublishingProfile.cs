// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The publishing profile of a gallery Image Version.
    /// </summary>
    public partial class GalleryApplicationVersionPublishingProfile : GalleryArtifactPublishingProfileBase
    {
        /// <summary>
        /// Initializes a new instance of the
        /// GalleryApplicationVersionPublishingProfile class.
        /// </summary>
        public GalleryApplicationVersionPublishingProfile()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// GalleryApplicationVersionPublishingProfile class.
        /// </summary>
        /// <param name="targetRegions">The target regions where the Image
        /// Version is going to be replicated to. This property is
        /// updatable.</param>
        /// <param name="replicaCount">The number of replicas of the Image
        /// Version to be created per region. This property would take effect
        /// for a region when regionalReplicaCount is not specified. This
        /// property is updatable.</param>
        /// <param name="excludeFromLatest">If set to true, Virtual Machines
        /// deployed from the latest version of the Image Definition won't use
        /// this Image Version.</param>
        /// <param name="publishedDate">The timestamp for when the gallery
        /// Image Version is published.</param>
        /// <param name="endOfLifeDate">The end of life date of the gallery
        /// Image Version. This property can be used for decommissioning
        /// purposes. This property is updatable.</param>
        /// <param name="storageAccountType">Specifies the storage account type
        /// to be used to store the image. This property is not updatable.
        /// Possible values include: 'Standard_LRS', 'Standard_ZRS',
        /// 'Premium_LRS'</param>
        /// <param name="contentType">Optional. May be used to help process
        /// this file. The type of file contained in the source, e.g. zip,
        /// json, etc.</param>
        /// <param name="enableHealthCheck">Optional. Whether or not this
        /// application reports health.</param>
        public GalleryApplicationVersionPublishingProfile(UserArtifactSource source, IList<TargetRegion> targetRegions = default(IList<TargetRegion>), int? replicaCount = default(int?), bool? excludeFromLatest = default(bool?), System.DateTime? publishedDate = default(System.DateTime?), System.DateTime? endOfLifeDate = default(System.DateTime?), StorageAccountType storageAccountType = default(StorageAccountType), string contentType = default(string), bool? enableHealthCheck = default(bool?))
            : base(targetRegions, replicaCount, excludeFromLatest, publishedDate, endOfLifeDate, storageAccountType)
        {
            Source = source;
            ContentType = contentType;
            EnableHealthCheck = enableHealthCheck;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "source")]
        public UserArtifactSource Source { get; set; }

        /// <summary>
        /// Gets or sets optional. May be used to help process this file. The
        /// type of file contained in the source, e.g. zip, json, etc.
        /// </summary>
        [JsonProperty(PropertyName = "contentType")]
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets optional. Whether or not this application reports
        /// health.
        /// </summary>
        [JsonProperty(PropertyName = "enableHealthCheck")]
        public bool? EnableHealthCheck { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Source == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Source");
            }
            if (Source != null)
            {
                Source.Validate();
            }
        }
    }
}
