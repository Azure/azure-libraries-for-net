// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.DefinitionManagedOrUnmanaged
{
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition;
    using Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.DefinitionShared;

    /// <summary>
    /// The entirety of the virtual machine definition.
    /// </summary>
    public interface IDefinitionManagedOrUnmanaged :
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.DefinitionShared.IDefinitionShared,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootUsernameManagedOrUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxRootPasswordOrPublicKeyManagedOrUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminUsernameManagedOrUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsAdminPasswordManagedOrUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithFromImageCreateOptionsManagedOrUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithLinuxCreateManagedOrUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithWindowsCreateManagedOrUnmanaged,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithManagedCreate,
        Microsoft.Azure.Management.Compute.Fluent.VirtualMachine.Definition.IWithUnmanagedCreate
    {

    }
}