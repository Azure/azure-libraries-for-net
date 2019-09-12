// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines options for WebApp deletion.
    /// </summary>
    public class WebAppDeleteOption : IBeta
    {
        /// <summary>
        /// If true, web app metrics are also deleted.
        /// </summary>
        public bool? DeleteMetrics { get; set; }

        /// <summary>
        /// Specify true if the App Service plan will be empty after app
        /// deletion and you want to delete the empty App Service plan.
        /// </summary>
        public bool? DeleteEmptyServerFarm { get; set; }
    }
}
