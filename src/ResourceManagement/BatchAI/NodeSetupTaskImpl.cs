// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.Azure.Management.BatchAI.Fluent.Models;

namespace Microsoft.Azure.Management.BatchAI.Fluent
{
    using Microsoft.Azure.Management.BatchAI.Fluent.BatchAICluster.Definition;
    using Microsoft.Azure.Management.BatchAI.Fluent.NodeSetupTask.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for NodeSetupTask and its create interface.
    /// </summary>
    public partial class NodeSetupTaskImpl  :
        IndexableWrapper<SetupTask>,
        INodeSetupTask,
        IDefinition<BatchAICluster.Definition.IWithCreate>
    {
        private BatchAIClusterImpl parent;

        public NodeSetupTaskImpl WithStdOutErrPath(string stdOutErrPathPrefix)
        {
            Inner.StdOutErrPathPrefix = stdOutErrPathPrefix;
            return this;
        }

        private IList<EnvironmentSetting> EnsureEnvironmentSettings()
        {
            if (Inner.EnvironmentVariables == null)
            {
                Inner.EnvironmentVariables = new List<EnvironmentSetting>();
            }
            return Inner.EnvironmentVariables;
        }

        public NodeSetupTaskImpl WithCommandLine(string commandLine)
        {
            Inner.CommandLine = commandLine;
            return this;
        }

        public NodeSetupTaskImpl WithEnvironmentVariable(string name, string value)
        {
            EnsureEnvironmentSettings().Add(new EnvironmentSetting(name, value));
            return this;
        }

         public BatchAIClusterImpl Attach()
        {
            return this.parent.WithSetupTask(this);
        }

        internal  NodeSetupTaskImpl(SetupTask inner, BatchAIClusterImpl parent)
            : base(inner)
        {
            this.parent = parent;
        }

        public NodeSetupTaskImpl WithRunElevated()
        {
            Inner.RunElevated = true;
            return this;
        }
    }
}