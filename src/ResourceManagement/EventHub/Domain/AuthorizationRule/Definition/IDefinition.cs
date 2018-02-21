// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Definition
{
    /// <summary>
    /// The stage of the event hub namespace or event hub authorization rule definition allowing to enable send or manage policy.
    /// </summary>
    /// <typeparam name="T">The next stage of the definition.</typeparam>
    public interface IWithSendOrManage<T>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Definition.IWithSend<T>,
        Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Definition.IWithManage<T>
    {
    }

    /// <summary>
    /// The stage of the event hub namespace or event hub authorization rule definition allowing to enable manage policy.
    /// </summary>
    /// <typeparam name="T">The next stage of the definition.</typeparam>
    public interface IWithManage<T>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that the rule should have management access enabled.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        T WithManageAccess();
    }

    /// <summary>
    /// The stage of the event hub namespace or event hub authorization rule definition allowing to enable listen, send or manage policy.
    /// </summary>
    /// <typeparam name="T">The next stage of the definition.</typeparam>
    public interface IWithListenOrSendOrManage<T>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Definition.IWithListen<T>,
        Microsoft.Azure.Management.Eventhub.Fluent.AuthorizationRule.Definition.IWithSendOrManage<T>
    {
    }

    /// <summary>
    /// The stage of the event hub namespace or event hub authorization rule definition allowing to enable send policy.
    /// </summary>
    /// <typeparam name="T">The next stage of the definition.</typeparam>
    public interface IWithSend<T>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that the rule should have sending access enabled.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        T WithSendAccess();
    }

    /// <summary>
    /// The stage of the event hub namespace or event hub authorization rule definition allowing to enable listen policy.
    /// </summary>
    /// <typeparam name="T">The next stage of the definition.</typeparam>
    public interface IWithListen<T>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta
    {
        /// <summary>
        /// Specifies that the rule should have listening access enabled.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        T WithListenAccess();
    }
}