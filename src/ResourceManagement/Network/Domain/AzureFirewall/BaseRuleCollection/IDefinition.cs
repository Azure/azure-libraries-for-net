// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Network.Fluent.AzureFirewall.BaseRuleCollection
{
    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify priority in firewall rule collection.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithPriority<ParentT>
    {
        /// <summary>
        /// Sets the priority of firewall rule collection in Azure firewall.
        /// </summary>
        /// <param name="priority">The value of priority.</param>
        /// <return>The next stage of the definition.</return>
        ParentT WithPriority(int priority);
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify action type in firewall rule collection.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithRuleCollectionActionType<ParentT>
    {
        /// <summary>
        /// Sets the action type of firewall rule collection as 'Allow' in Azure firewall.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ParentT WithAllowActionType();

        /// <summary>
        /// Sets the action type of firewall rule collection as 'Deny' in Azure firewall.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ParentT WithDenyActionType();
    }

    /// <summary>
    /// The stage of the Azure firewall definition allowing to specify nat action type in firewall rule collection.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithNatRuleCollectionActionType<ParentT>
    {
        /// <summary>
        /// Sets the action type of firewall rule collection as 'Snat' in Azure firewall.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ParentT WithSnatActionType();

        /// <summary>
        /// Sets the action type of firewall rule collection as 'Dnat' in Azure firewall.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ParentT WithDnatActionType();
    }
}
