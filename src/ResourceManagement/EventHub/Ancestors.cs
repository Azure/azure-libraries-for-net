// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;

namespace Microsoft.Azure.Management.EventHub.Fluent
{
    class OneAncestor
    {
        private readonly String resourceGroupName;
        private readonly String ancestor1Name;

        public OneAncestor(String resourceGroupName, String ancestor1Name)
        {
            this.resourceGroupName = resourceGroupName ?? throw new ArgumentNullException("resourceGroupName");
            this.ancestor1Name = ancestor1Name ?? throw new ArgumentNullException("ancestor1Name");
        }

        public OneAncestor(ResourceId resourceId)
        {
            if (resourceId == null)
            {
                throw new ArgumentNullException("resourceId");
            }
            if (resourceId.Id == null)
            {
                throw new ArgumentNullException("resourceId.iId");
            }
            if (resourceId.Parent == null)
            {
                throw new ArgumentNullException("resourceId.Parent");
            }
            this.resourceGroupName = resourceId.ResourceGroupName ?? throw new ArgumentNullException("resourceId.ResourceGroupName");
            this.ancestor1Name = resourceId.Parent.Name ?? throw new ArgumentNullException("resourceId.Parent.Name");
        }

        public OneAncestor(String resourceId) : this(ResourceId.FromString(resourceId))
        {
        }

        public String ResourceGroupName
        {
            get
            {
                return this.resourceGroupName;
            }
        }

        public String Ancestor1Name
        {
            get
            {
                return this.ancestor1Name;
            }
        }
    }

    class TwoAncestor : OneAncestor
    {
        private String ancestor2Name;

        public TwoAncestor(String resourceGroupName, String ancestor1Name, String ancestor2Name) 
            : base(resourceGroupName, ancestor1Name)
        {
            this.ancestor2Name = ancestor2Name ?? throw new ArgumentNullException("ancestor2Name");
        }

        public TwoAncestor(ResourceId resourceId) : base(resourceId)
        {
            if (resourceId.Parent.Parent == null)
            {
                throw new ArgumentNullException("resourceId.Parent.Parent");
            }
            this.ancestor2Name = resourceId.Parent.Parent.Name ?? throw new ArgumentNullException("resourceId.Parent.Parent.Name");
        }

        public TwoAncestor(String resourceId) : this(ResourceId.FromString(resourceId))
        {
        }

        public String Ancestor2Name
        {
            get
            {
                return this.ancestor2Name;
            }
        }
    }

    class ThreeAncestor : TwoAncestor
    {
        private readonly String ancestor3Name;

        public ThreeAncestor(String resourceGroupName, String ancestor1Name, String ancestor2Name, String ancestor3Name) 
            : base(resourceGroupName, ancestor1Name, ancestor2Name)
        {
            this.ancestor3Name = ancestor3Name ?? throw new ArgumentNullException("ancestor3Name");
        }

        public ThreeAncestor(ResourceId resourceId) : base(resourceId)
        {
            if (resourceId.Parent.Parent.Parent == null)
            {
                throw new ArgumentNullException("resourceId.Parent.Parent.Parent");
            }
            this.ancestor3Name = resourceId.Parent.Parent.Parent.Name ?? throw new ArgumentNullException("resourceId.Parent.Parent.Parent.Name");
        }

        public ThreeAncestor(String resourceId) : this(ResourceId.FromString(resourceId))
        {
        }

        public String Ancestor3Name
        {
            get
            {
                return this.ancestor3Name;
            }
        }
    }
}
