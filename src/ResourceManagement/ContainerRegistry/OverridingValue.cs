// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    /// <summary>
    /// Defines an overriding value that overrides values passed in for RegistryFileTaskStep, RegistryFileTaskRunRequest, RegistryEncodedTaskStep, and RegistryEncodedTaskRunRequest.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5Lk92ZXJyaWRpbmdWYWx1ZQ==
    public partial class OverridingValue 
    {
        private bool isSecret;
        private string value;

        /// <summary>
        /// Constructor that defines an OverridingValue.
        /// </summary>
        /// <param name="value">The value of the overriding value.</param>
        /// <param name="isSecret">Whether the overriding value will be secret.</param>
        ///GENMHASH:563338C2AFB33F578597260C0192A4A6:C76CC821CF4FDA7CA0ECC9AD658ED254
        public  OverridingValue(string value, bool isSecret)
        {
            this.value = value;
            this.isSecret = isSecret;
        }

        /// <return>Whether the overriding value is secret or not.</return>
        ///GENMHASH:D02D212E7FFCD59583A54220FA0FAB9D:0F0C931A887FA13CEDA077B5BDDDC43E
        public bool IsSecret
        {
            get
            {
                return this.isSecret;
            }
        }

        /// <return>The value of the overriding value.</return>
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