// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Sql.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.Sql.Fluent.Models;

    /// <summary>
    /// Implementation for CheckNameAvailabilityResult.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnNxbC5pbXBsZW1lbnRhdGlvbi5DaGVja05hbWVBdmFpbGFiaWxpdHlSZXN1bHRJbXBs
    internal partial class CheckNameAvailabilityResultImpl  :
        Wrapper<Models.CheckNameAvailabilityResponseInner>,
        ICheckNameAvailabilityResult
    {

        /// <summary>
        /// Creates an instance of the check name availability result object.
        /// </summary>
        /// <param name="inner">The inner object.</param>
        ///GENMHASH:6E11439BC0EE92936D1373B518E18596:0FD5BCAE10307382B777A749B232A151
        internal CheckNameAvailabilityResultImpl(CheckNameAvailabilityResponseInner inner) : base(inner)
        {
        }

        ///GENMHASH:ECE9AA3B22E6D72ED037B235766E650D:853A4A58250437949396E2FC3A58AA01
        public bool IsAvailable()
        {
            return this.Inner.Available.GetValueOrDefault(false);
        }

        ///GENMHASH:39A7E2BFDDD2D6F13D7EBE13673EA7FA:B41A1B8D811D360E51A50909E883B551
        public string UnavailabilityReason()
        {
            return this.Inner.Reason?.ToString();
        }

        ///GENMHASH:3A8C639760DE81ABB3D12F40D11FF27C:956F849F281D3F4FB2CCF800ECE810C3
        public string UnavailabilityMessage()
        {
            return this.Inner.Message;
        }
    }
}