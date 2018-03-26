// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.BatchAI.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Additional parameters for List operation.
    /// </summary>
    public partial class JobsListOptionsInner
    {
        /// <summary>
        /// Initializes a new instance of the JobsListOptionsInner class.
        /// </summary>
        public JobsListOptionsInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the JobsListOptionsInner class.
        /// </summary>
        /// <param name="filter">An OData $filter clause.. Used to filter
        /// results that are returned in the GET respnose.</param>
        /// <param name="select">An OData $select clause. Used to select the
        /// properties to be returned in the GET respnose.</param>
        /// <param name="maxResults">The maximum number of items to return in
        /// the response. A maximum of 1000 files can be returned.</param>
        public JobsListOptionsInner(string filter = default(string), string select = default(string), int? maxResults = default(int?))
        {
            Filter = filter;
            Select = select;
            MaxResults = maxResults;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets an OData $filter clause.. Used to filter results that
        /// are returned in the GET respnose.
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string Filter { get; set; }

        /// <summary>
        /// Gets or sets an OData $select clause. Used to select the properties
        /// to be returned in the GET respnose.
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string Select { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of items to return in the response.
        /// A maximum of 1000 files can be returned.
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public int? MaxResults { get; set; }

    }
}
