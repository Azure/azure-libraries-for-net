// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The localizable string class.
    /// </summary>
    public interface ILocalizableString  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Monitor.Fluent.Models.LocalizableStringInner>
    {
        /// <summary>
        /// Gets the localizedValue value.
        /// </summary>
        /// <summary>
        /// Gets the localizedValue value.
        /// </summary>
        string LocalizedValue { get; }

        /// <summary>
        /// Gets the value value.
        /// </summary>
        /// <summary>
        /// Gets the value value.
        /// </summary>
        string Value { get; }
    }
}