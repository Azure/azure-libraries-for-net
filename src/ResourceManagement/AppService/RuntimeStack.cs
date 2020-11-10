// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    /// <summary>
    /// Defines App service pricing tiers.
    /// </summary>
    public partial class RuntimeStack
    {
        public static readonly RuntimeStack NodeJS_LTS = new RuntimeStack("NODE", "lts");
        public static readonly RuntimeStack NodeJS_10_LTS = new RuntimeStack("NODE", "10-lts");
        public static readonly RuntimeStack NodeJS_8_LTS = new RuntimeStack("NODE", "8-lts");
        public static readonly RuntimeStack NodeJS_6_LTS = new RuntimeStack("NODE", "6-lts");
        public static readonly RuntimeStack NodeJS_10_14 = new RuntimeStack("NODE", "10.14");
        public static readonly RuntimeStack NodeJS_10_12 = new RuntimeStack("NODE", "10.12");
        public static readonly RuntimeStack NodeJS_10_10 = new RuntimeStack("NODE", "10.10");
        public static readonly RuntimeStack NodeJS_10_1 = new RuntimeStack("NODE", "10.1");
        public static readonly RuntimeStack NodeJS_9_4 = new RuntimeStack("NODE", "9.4");
        public static readonly RuntimeStack NodeJS_8_12 = new RuntimeStack("NODE", "8.12");
        public static readonly RuntimeStack NodeJS_8_11 = new RuntimeStack("NODE", "8.11");
        public static readonly RuntimeStack NodeJS_8_9 = new RuntimeStack("NODE", "8.9");
        public static readonly RuntimeStack NodeJS_8_8 = new RuntimeStack("NODE", "8.8");
        public static readonly RuntimeStack NodeJS_8_2 = new RuntimeStack("NODE", "8.2");
        public static readonly RuntimeStack NodeJS_8_1 = new RuntimeStack("NODE", "8.1");
        public static readonly RuntimeStack NodeJS_8_0 = new RuntimeStack("NODE", "8.0");
        public static readonly RuntimeStack NodeJS_6_11 = new RuntimeStack("NODE", "6.11");
        public static readonly RuntimeStack NodeJS_6_10 = new RuntimeStack("NODE", "6.10");
        public static readonly RuntimeStack NodeJS_6_9 = new RuntimeStack("NODE", "6.9");
        public static readonly RuntimeStack NodeJS_6_6 = new RuntimeStack("NODE", "6.6");
        public static readonly RuntimeStack NodeJS_6_2 = new RuntimeStack("NODE", "6.2");
        public static readonly RuntimeStack NodeJS_4_5 = new RuntimeStack("NODE", "4.5");
        public static readonly RuntimeStack NodeJS_4_4 = new RuntimeStack("NODE", "4.4");
        public static readonly RuntimeStack PHP_5_6 = new RuntimeStack("PHP", "5.6");
        public static readonly RuntimeStack PHP_7_0 = new RuntimeStack("PHP", "7.0");
        public static readonly RuntimeStack PHP_7_2 = new RuntimeStack("PHP", "7.2");
        public static readonly RuntimeStack PHP_7_3 = new RuntimeStack("PHP", "7.3");
        public static readonly RuntimeStack NETCore_V1_0 = new RuntimeStack("DOTNETCORE", "1.0");
        public static readonly RuntimeStack NETCore_V1_1 = new RuntimeStack("DOTNETCORE", "1.1");
        public static readonly RuntimeStack NETCore_V2_0 = new RuntimeStack("DOTNETCORE", "2.0");
        public static readonly RuntimeStack NETCore_V2_1 = new RuntimeStack("DOTNETCORE", "2.1");
        public static readonly RuntimeStack NETCore_V2_2 = new RuntimeStack("DOTNETCORE", "2.2");
        public static readonly RuntimeStack NETCore_V3_1 = new RuntimeStack("DOTNETCORE", "3.1");
        public static readonly RuntimeStack Ruby_2_3 = new RuntimeStack("RUBY", "2.3");
        public static readonly RuntimeStack Ruby_2_4 = new RuntimeStack("RUBY", "2.4");
        public static readonly RuntimeStack Ruby_2_5 = new RuntimeStack("RUBY", "2.5");
        public static readonly RuntimeStack Ruby_2_6 = new RuntimeStack("RUBY", "2.6");
        public static readonly RuntimeStack Java_8_Jre8 = new RuntimeStack("JAVA", "8-jre8");
        public static readonly RuntimeStack Java_11_Java11 = new RuntimeStack("JAVA", "11-java11");
        public static readonly RuntimeStack Tomcat_8_5_JRE8 = new RuntimeStack("TOMCAT", "8.5-jre8");
        public static readonly RuntimeStack Tomcat_8_5_JAVA11 = new RuntimeStack("TOMCAT", "8.5-java11");
        public static readonly RuntimeStack Tomcat_9_0_JRE8 = new RuntimeStack("TOMCAT", "9.0-jre8");
        public static readonly RuntimeStack Tomcat_9_0_JAVA11 = new RuntimeStack("TOMCAT", "9.0-java11");
        public static readonly RuntimeStack Python_2_7 = new RuntimeStack("PYTHON", "2.7");
        public static readonly RuntimeStack Python_3_6 = new RuntimeStack("PYTHON", "3.6");
        public static readonly RuntimeStack Python_3_7 = new RuntimeStack("PYTHON", "3.7");

        private string stack;
        private string version;

        public override bool Equals(object obj)
        {
            if (!(obj is RuntimeStack))
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }
            RuntimeStack rhs = (RuntimeStack)obj;
            return ToString().Equals(rhs.ToString());
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return stack + " " + version;
        }

        /// <return>The name of the language runtime stack.</return>
        public string Stack()
        {
            return stack;
        }

        /// <summary>
        /// Creates a custom app service pricing tier.
        /// </summary>
        /// <param name="stack">The name of the language stack.</param>
        /// <param name="version">The version of the runtime.</param>
        public  RuntimeStack(string stack, string version)
        {
            this.stack = stack;
            this.version = version;
        }

        /// <return>The version of the runtime stack.</return>
        public string Version()
        {
            return version;
        }
    }
}
