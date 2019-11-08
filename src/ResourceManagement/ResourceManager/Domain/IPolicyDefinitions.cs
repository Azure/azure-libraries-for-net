// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;

    public interface IPolicyDefinitions :
        ISupportsListing<IPolicyDefinition>,
        ISupportsGettingByName<IPolicyDefinition>,
        ISupportsCreating<PolicyDefinition.Definition.IBlank>,
        ISupportsDeletingByName
    {
    }
}
