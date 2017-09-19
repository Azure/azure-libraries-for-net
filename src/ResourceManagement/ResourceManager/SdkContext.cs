// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    public static class SdkContext
    {
        public delegate IResourceNamer ResourceNamerCreator(string name);

        public static AzureCredentialsFactory AzureCredentialsFactory { get; set; } = new AzureCredentialsFactory();

        public static ResourceNamerCreator CreateResourceNamer { get; set; } = new ResourceNamerCreator((name) => new ResourceNamer(name));

        public static DelayProvider DelayProvider { get; set; } = new DelayProvider();

        /// <summary>
        /// Generates the specified number of random resource names with the same prefix.
        /// </summary>
        /// <param name="prefix">the prefix to be used if possible</param>
        /// <param name="maxLen">the maximum length for the random generated name</param>
        /// <param name="count">the number of names to generate</param>
        /// <returns>random names</returns>
        public static string[] RandomResourceNames(string prefix, int maxLen, int count)
        {
            string[] names = new string[count];
            var resourceNamer = SdkContext.CreateResourceNamer("");
            for (int i = 0; i < count; i++)
            {
                names[i] = resourceNamer.RandomName(prefix, maxLen);
            }
            return names;
        }

        public static string RandomResourceName(string prefix, int maxLen)
        {
            var namer = CreateResourceNamer("");
            return namer.RandomName(prefix, maxLen);
        }
        public static string RandomGuid()
        {
            var namer = CreateResourceNamer("");
            return namer.RandomGuid();
        }
    }
}
