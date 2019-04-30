// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.AppService.Fluent
{

    /// <summary>
    /// Defines values for JavaVersion.
    /// </summary>
    public class JavaVersion : ExpandableStringEnum<JavaVersion>
    {
        public static readonly JavaVersion Off = Parse("null");
        public static readonly JavaVersion V7Newest = Parse("1.7");
        public static readonly JavaVersion V7_51 = Parse("1.7.0_51");
        public static readonly JavaVersion V7_71 = Parse("1.7.0_71");
        public static readonly JavaVersion V7_80 = Parse("1.7.0_80");
        public static readonly JavaVersion ZuluV7_191 = Parse("1.7.0_191_ZULU");
        public static readonly JavaVersion V8Newest = Parse("1.8");
        public static readonly JavaVersion V8_25 = Parse("1.8.0_25");
        public static readonly JavaVersion V8_60 = Parse("1.8.0_60");
        public static readonly JavaVersion V8_73 = Parse("1.8.0_73");
        public static readonly JavaVersion V8_111 = Parse("1.8.0_111");
        public static readonly JavaVersion V8_172 = Parse("1.8.0_172");
        public static readonly JavaVersion V8_181 = Parse("1.8.0_181");
        public static readonly JavaVersion V8_202 = Parse("1.8.0_202");
        public static readonly JavaVersion ZuluV8_172 = Parse("1.8.0_172_ZULU");
        public static readonly JavaVersion ZuluV8_181 = Parse("1.8.0_181_ZULU");
        public static readonly JavaVersion ZuluV8_202 = Parse("1.8.0_202_ZULU");
        public static readonly JavaVersion ZuluV8_92 = Parse("1.8.0_92");
        public static readonly JavaVersion ZuluV8_102 = Parse("1.8.0_102");
        public static readonly JavaVersion ZuluV8_144 = Parse("1.8.0_144");
        public static readonly JavaVersion V11Newest = Parse("11");
        public static readonly JavaVersion ZuluV11_2 = Parse("11.0.2_ZULU");
    }
}
