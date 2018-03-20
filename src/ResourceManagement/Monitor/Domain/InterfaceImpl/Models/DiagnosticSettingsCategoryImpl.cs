// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    internal partial class DiagnosticSettingsCategoryImpl
    {
        /// <summary>
        /// Gets the diagnostic settings category name value.
        /// </summary>
        /// <summary>
        /// Gets the diagnostic settings category name.
        /// </summary>
        string Microsoft.Azure.Management.Monitor.Fluent.Models.IDiagnosticSettingsCategory.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Gets the categoryType value.
        /// </summary>
        /// <summary>
        /// Gets the categoryType value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.CategoryType Microsoft.Azure.Management.Monitor.Fluent.Models.IDiagnosticSettingsCategory.Type
        {
            get
            {
                return this.Type();
            }
        }
    }
}