// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    /// <summary>
    /// Defines an overriding argument that overrides arguments passed in for RegistryDockerTaskStep and RegistryDockerTaskRunRequest.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5Lk92ZXJyaWRpbmdBcmd1bWVudA==
    public partial class OverridingArgument 
    {
        private bool isSecret;
        private string value;

        /// <summary>
        /// Constructor that defines an OverridingArgument.
        /// </summary>
        /// <param name="value">The value of the overriding argument.</param>
        /// <param name="isSecret">Whether the overriding argument will be secret.</param>
        ///GENMHASH:C984C00914A30AB1D7BDFBE8E0C04B89:C76CC821CF4FDA7CA0ECC9AD658ED254
        public  OverridingArgument(string value, bool isSecret)
        {
            this.value = value;
            this.isSecret = isSecret;
        }

        /// <return>Whether the overriding argument is secret or not.</return>
        ///GENMHASH:D02D212E7FFCD59583A54220FA0FAB9D:0F0C931A887FA13CEDA077B5BDDDC43E
        public bool IsSecret
        {
            get
            {
                return this.isSecret;
            }
        }

        /// <return>The value of the overriding argument.</return>
        ///GENMHASH:C1D104519E98AFA1614D0BFD517E6100:DEAACA759AB1EA7CE53B841CB03D5199
        public string Value
        {
            get
            {
                return this.value;
            }
        }
    }
}