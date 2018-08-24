// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.AzureReachabilityReport.Definition
{
    using System;

    /// <summary>
    /// The stage of the definition which contains all the minimum required inputs for execution, but also allows
    /// for any other optional settings to be specified.
    /// </summary>
    public interface IWithExecute  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.Network.Fluent.IAzureReachabilityReport>,
        Microsoft.Azure.Management.Network.Fluent.AzureReachabilityReport.Definition.IWithAzureLocations,
        Microsoft.Azure.Management.Network.Fluent.AzureReachabilityReport.Definition.IWithProviders
    {

    }

    /// <summary>
    /// Sets Azure regions to scope the query to.
    /// Note: if none or multiple Azure regions specified, only one provider should be set.
    /// If none or multiple providers specified, only one Azure region should be set.
    /// </summary>
    public interface IWithAzureLocations 
    {

        Microsoft.Azure.Management.Network.Fluent.AzureReachabilityReport.Definition.IWithExecute WithAzureLocations(params string[] azureLocations);
    }

    /// <summary>
    /// Sets the end time for the Azure reachability report.
    /// </summary>
    public interface IWithEndTime 
    {

        /// <param name="endTime">The start time for the Azure reachability report.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.AzureReachabilityReport.Definition.IWithExecute WithEndTime(DateTime endTime);
    }

    /// <summary>
    /// Sets the list of Internet service providers.
    /// Note: if none or multiple Azure regions specified, only one provider should be set.
    /// If none or multiple providers specified, only one Azure region should be set.
    /// </summary>
    public interface IWithProviders 
    {

        /// <param name="providers">The list of Internet service providers.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.AzureReachabilityReport.Definition.IWithExecute WithProviders(params string[] providers);
    }

    /// <summary>
    /// The entirety of Azure reachability report parameters definition.
    /// </summary>
    public interface IDefinition  :
        Microsoft.Azure.Management.Network.Fluent.AzureReachabilityReport.Definition.IWithProviderLocation,
        Microsoft.Azure.Management.Network.Fluent.AzureReachabilityReport.Definition.IWithStartTime,
        Microsoft.Azure.Management.Network.Fluent.AzureReachabilityReport.Definition.IWithEndTime,
        Microsoft.Azure.Management.Network.Fluent.AzureReachabilityReport.Definition.IWithExecute
    {

    }

    /// <summary>
    /// The first stage of Azure reachability report parameters definition.
    /// </summary>
    public interface IWithProviderLocation 
    {

        /// <param name="country">The name of the country.</param>
        /// <return>The AzureReachabilityReport object itself.</return>
        Microsoft.Azure.Management.Network.Fluent.AzureReachabilityReport.Definition.IWithStartTime WithProviderLocation(string country);

        /// <param name="country">The name of the country.</param>
        /// <param name="state">The name of the state.</param>
        /// <return>The AzureReachabilityReport object itself.</return>
        Microsoft.Azure.Management.Network.Fluent.AzureReachabilityReport.Definition.IWithStartTime WithProviderLocation(string country, string state);

        /// <param name="country">The name of the country.</param>
        /// <param name="state">The name of the state.</param>
        /// <param name="city">The name of the city.</param>
        /// <return>The AzureReachabilityReport object itself.</return>
        Microsoft.Azure.Management.Network.Fluent.AzureReachabilityReport.Definition.IWithStartTime WithProviderLocation(string country, string state, string city);
    }

    /// <summary>
    /// Sets the start time for the Azure reachability report.
    /// </summary>
    public interface IWithStartTime 
    {

        /// <param name="startTime">The start time for the Azure reachability report.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.Network.Fluent.AzureReachabilityReport.Definition.IWithEndTime WithStartTime(DateTime startTime);
    }
}