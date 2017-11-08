// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for CheckNameAvailabilityResult.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLkNoZWNrTmFtZUF2YWlsYWJpbGl0eVJlc3VsdEltcGw=
    internal partial class CheckNameAvailabilityResultImpl :
        Wrapper<Models.RegistryNameStatusInner>,
        ICheckNameAvailabilityResult
    {
        ///GENMHASH:ECE9AA3B22E6D72ED037B235766E650D:3B10E7F4F225C9FDB67E8B7665F89745
        public bool IsAvailable()
        {
            return Inner.NameAvailable.Value;
        }

        ///GENMHASH:39A7E2BFDDD2D6F13D7EBE13673EA7FA:A397F8558268A1EB70B99CF0DCC0998D
        public string UnavailabilityReason()
        {
            return Inner.Reason;
        }

        ///GENMHASH:3A8C639760DE81ABB3D12F40D11FF27C:999EA9EE5C4B74B7DA151E7C41C67EAE
        public string UnavailabilityMessage()
        {
            return Inner.Message;
        }

        /// <summary>
        /// Creates an instance of the check name availability result object.
        /// </summary>
        /// <param name="inner">The inner object.</param>
        ///GENMHASH:E5AF0EA7E8C7D9DA59B43D01D7005C57:B0DF93AB45A1550B74A2BFD026E1B756
        internal CheckNameAvailabilityResultImpl(RegistryNameStatusInner inner) : base(inner)
        {
        }
    }
}