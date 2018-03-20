// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The Azure  DiagnosticSettingsCategory wrapper class implementation.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuaW1wbGVtZW50YXRpb24uRGlhZ25vc3RpY1NldHRpbmdzQ2F0ZWdvcnlJbXBs
    internal partial class DiagnosticSettingsCategoryImpl :
        Wrapper<Microsoft.Azure.Management.Monitor.Fluent.Models.DiagnosticSettingsCategoryResourceInner>,
        IDiagnosticSettingsCategory
    {

        ///GENMHASH:E3CACCB294745BB2CAE40EA6EEE991BD:C0C35E00AF4E17F141675A2C05C7067B
        internal DiagnosticSettingsCategoryImpl(DiagnosticSettingsCategoryResourceInner innerObject)
            : base(innerObject)
        {
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:7DA2BFC813B4E08F49E31A0D74C1FF67
        public string Name()
        {
            return this.Inner.Name;
        }

        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:789AA043CDBDBA6398FA32836AC7078A
        public CategoryType Type()
        {
            return this.Inner.CategoryType;
        }
    }
}