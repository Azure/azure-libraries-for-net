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
    public partial class NodeSetupTaskImpl :
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

        private IList<EnvironmentVariable> EnsureEnvironmentVariables()
        {
            if (Inner.EnvironmentVariables == null)
            {
                Inner.EnvironmentVariables = new List<EnvironmentVariable>();
            }
            return Inner.EnvironmentVariables;
        }

        ///GENMHASH:5E03E122BA1157E26580A70A3DDCFC38:0F2E17AE5B0FFC742A50B16C0B8ECA93
        private IList<Microsoft.Azure.Management.BatchAI.Fluent.Models.EnvironmentVariableWithSecretValue> EnsureEnvironmentVariablesWithSecrets()
        {
            if (Inner.Secrets == null) {
                Inner.Secrets = new List<EnvironmentVariableWithSecretValue>();
            }
            return Inner.Secrets;
        }

        public NodeSetupTaskImpl WithCommandLine(string commandLine)
        {
            Inner.CommandLine = commandLine;
            return this;
        }

        ///GENMHASH:446B156BB626194DD2A3F46642818AF8:551F630EC4E164B1BDC4E1F286DA3951
        public NodeSetupTaskImpl WithEnvironmentVariable(string name, string value)
        {
            EnsureEnvironmentVariables().Add(new EnvironmentVariable(name, value));
            return this;
        }

        ///GENMHASH:997F16B1AEBB01217D1CAE2B03B8B73E:E4346C9A19D9DCFF2986204E3D4749B1
        public NodeSetupTaskImpl WithEnvironmentVariableSecretValue(string name, string value)
        {
            EnsureEnvironmentVariablesWithSecrets().Add(new EnvironmentVariableWithSecretValue(name, value));
            return this;
        }

        ///GENMHASH:AB0BF9D0BEA18CD334AAF69A466D74DB:244EAB58A02E8C0EA8858C0AA028A77B
        public NodeSetupTaskImpl WithEnvironmentVariableSecretValue(string name, string keyVaultId, string secretUrl)
        {
            KeyVaultSecretReference secretReference = new KeyVaultSecretReference(new Models.ResourceId(keyVaultId), secretUrl);
            EnsureEnvironmentVariablesWithSecrets().Add(new EnvironmentVariableWithSecretValue(name, valueSecretReference: secretReference));
            return this;
        }

        public BatchAIClusterImpl Attach()
        {
            return this.parent.WithSetupTask(this);
        }

        internal NodeSetupTaskImpl(SetupTask inner, BatchAIClusterImpl parent)
            : base(inner)
        {
            this.parent = parent;
        }
    }
}