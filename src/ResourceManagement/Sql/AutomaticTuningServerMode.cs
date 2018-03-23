// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Defines values for AutomaticTuningServerMode.
    /// </summary>
    public class AutomaticTuningServerMode : ExpandableStringEnum<AutomaticTuningServerMode>
    {
        public static readonly AutomaticTuningServerMode Custom = Parse("Custom");
        public static readonly AutomaticTuningServerMode Auto = Parse("Auto");
        public static readonly AutomaticTuningServerMode Unspecified = Parse("Unspecified");
    }
}
