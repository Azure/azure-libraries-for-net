// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.2.2.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Compute;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Azure.OData;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for VirtualMachineExtensionImagesOperations.
    /// </summary>
    public static partial class VirtualMachineExtensionImagesOperationsExtensions
    {
            /// <summary>
            /// Gets a virtual machine extension image.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='location'>
            /// The name of a supported Azure region.
            /// </param>
            /// <param name='publisherName'>
            /// </param>
            /// <param name='type'>
            /// </param>
            /// <param name='version'>
            /// </param>
            public static VirtualMachineExtensionImageInner Get(this IVirtualMachineExtensionImagesOperations operations, string location, string publisherName, string type, string version)
            {
                return operations.GetAsync(location, publisherName, type, version).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a virtual machine extension image.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='location'>
            /// The name of a supported Azure region.
            /// </param>
            /// <param name='publisherName'>
            /// </param>
            /// <param name='type'>
            /// </param>
            /// <param name='version'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<VirtualMachineExtensionImageInner> GetAsync(this IVirtualMachineExtensionImagesOperations operations, string location, string publisherName, string type, string version, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(location, publisherName, type, version, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a list of virtual machine extension image types.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='location'>
            /// The name of a supported Azure region.
            /// </param>
            /// <param name='publisherName'>
            /// </param>
            public static IList<VirtualMachineExtensionImageInner> ListTypes(this IVirtualMachineExtensionImagesOperations operations, string location, string publisherName)
            {
                return operations.ListTypesAsync(location, publisherName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of virtual machine extension image types.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='location'>
            /// The name of a supported Azure region.
            /// </param>
            /// <param name='publisherName'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<VirtualMachineExtensionImageInner>> ListTypesAsync(this IVirtualMachineExtensionImagesOperations operations, string location, string publisherName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListTypesWithHttpMessagesAsync(location, publisherName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets a list of virtual machine extension image versions.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='location'>
            /// The name of a supported Azure region.
            /// </param>
            /// <param name='publisherName'>
            /// </param>
            /// <param name='type'>
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            public static IList<VirtualMachineExtensionImageInner> ListVersions(this IVirtualMachineExtensionImagesOperations operations, string location, string publisherName, string type, ODataQuery<VirtualMachineExtensionImageInner> odataQuery = default(ODataQuery<VirtualMachineExtensionImageInner>))
            {
                return operations.ListVersionsAsync(location, publisherName, type, odataQuery).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets a list of virtual machine extension image versions.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='location'>
            /// The name of a supported Azure region.
            /// </param>
            /// <param name='publisherName'>
            /// </param>
            /// <param name='type'>
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<VirtualMachineExtensionImageInner>> ListVersionsAsync(this IVirtualMachineExtensionImagesOperations operations, string location, string publisherName, string type, ODataQuery<VirtualMachineExtensionImageInner> odataQuery = default(ODataQuery<VirtualMachineExtensionImageInner>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListVersionsWithHttpMessagesAsync(location, publisherName, type, odataQuery, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
