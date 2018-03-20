// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    /// <summary>
    /// The Azure event log entries are of type DiagnosticSettingsCategory.
    /// </summary>
    public interface IDiagnosticSettingsCategory :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Monitor.Fluent.Models.DiagnosticSettingsCategoryResourceInner>
    {

        /// <summary>
        /// Gets the diagnostic settings category name value.
        /// </summary>
        /// <summary>
        /// Gets the diagnostic settings category name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the categoryType value.
        /// </summary>
        /// <summary>
        /// Gets the categoryType value.
        /// </summary>
        Microsoft.Azure.Management.Monitor.Fluent.Models.CategoryType Type { get; }
    }
}