// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Monitor.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Defines values for RecurrenceFrequency.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm1vbml0b3IuRXZlbnREYXRhUHJvcGVydHlOYW1l
    public sealed partial class RecurrenceFrequency : ExpandableStringEnum<RecurrenceFrequency>
    {
        public static readonly RecurrenceFrequency None = Parse("None");
        public static readonly RecurrenceFrequency Second = Parse("Second");
        public static readonly RecurrenceFrequency Minute = Parse("Minute");
        public static readonly RecurrenceFrequency Hour = Parse("Hour");
        public static readonly RecurrenceFrequency Day = Parse("Day");
        public static readonly RecurrenceFrequency Week = Parse("Week");
        public static readonly RecurrenceFrequency Month = Parse("Month");
        public static readonly RecurrenceFrequency Year = Parse("Year");
    }
}
