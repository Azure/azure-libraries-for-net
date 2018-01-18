// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    /// <summary>
    /// A utility class to operate on role assignments for a resource with service principal (object id).
    /// the method signature and behaviour can change in future releases.
    /// </summary>
    public class RoleAssignmentHelper : IBeta
    {
        private static string CURRENT_RESOURCE_GROUP_SCOPE = "CURRENT_RESOURCE_GROUP";
        private readonly IGraphRbacManager rbacManager;
        private readonly IIdProvider idProvider;

        private IDictionary<string, System.Tuple<string, BuiltInRole>> rolesToAssign;
        private IDictionary<string, System.Tuple<string, string>> roleDefinitionsToAssign;
        //
        private IList<string> roleAssignmentIdsToRemove;
        private IDictionary<string, System.Tuple<string, BuiltInRole>> roleAssignmentsToRemove;

        /// <summary>
        /// Creates RoleAssignmentHelper.
        /// </summary>
        /// <param name="rbacManager">the graph rbac manager</param>
        /// <param name="idProvider">the provider that provides service principal id and resource id</param>
        public RoleAssignmentHelper(IGraphRbacManager rbacManager, IIdProvider idProvider)
        {
            this.rbacManager = rbacManager;
            this.idProvider = idProvider;

            this.rolesToAssign = new Dictionary<string, System.Tuple<string, BuiltInRole>>();
            this.roleDefinitionsToAssign = new Dictionary<string, System.Tuple<string, string>>();
            this.roleAssignmentIdsToRemove = new List<string>();
            this.roleAssignmentsToRemove = new Dictionary<string, System.Tuple<string, BuiltInRole>>();
        }

        /// <summary>
        /// Specifies that applications running on an Azure service with this identity requires
        /// the given access role with scope of access limited to the current resource group that
        /// the identity resides.
        /// </summary>
        /// <param name="role">Access role to assigned to the identity.</param>
        /// <return>RoleAssignmentHelper.</return>
        public RoleAssignmentHelper WithAccessToCurrentResourceGroup(BuiltInRole role)
        {
            return this.WithAccessTo(CURRENT_RESOURCE_GROUP_SCOPE, role);
        }

        /// <summary>
        /// Specifies that applications running on an Azure service with this identity requires
        /// the access role with scope of access limited to an ARM resource.
        /// </summary>
        /// <param name="resourceId">scope of the access represented in ARM resource ID format.</param>
        /// <param name="role">Access role to assigned to the virtual machine.</param>
        /// <return>RoleAssignmentHelper.</return>
        public RoleAssignmentHelper WithAccessTo(string resourceId, BuiltInRole role)
        {
            string key = resourceId.ToLower() + "_" + role.ToString().ToLower();
            if (!this.rolesToAssign.ContainsKey(key))
            {
                this.rolesToAssign.Add(key, new System.Tuple<string, BuiltInRole>(resourceId, role));
            }
            return this;
        }

        /// <summary>
        /// Specifies that applications running on an Azure service with this identity requires
        /// the given access role with scope of access limited to the current resource group that
        /// the identity resides.
        /// </summary>
        /// <param name="roleDefinitionId">access role definition to assigned to the identity.</param>
        /// <return>RoleAssignmentHelper.</return>
        public RoleAssignmentHelper WithAccessToCurrentResourceGroup(string roleDefinitionId)
        {
            return this.WithAccessTo(CURRENT_RESOURCE_GROUP_SCOPE, roleDefinitionId);
        }

        /// <summary>
        /// Specifies that applications running on an Azure service with this identity requires
        /// the access described in the given role definition with scope of access limited
        /// to an ARM resource.
        /// </summary>
        /// <param name="resourceId">scope of the access represented in ARM resource ID format</param>
        /// <param name="roleDefinitionId">access role definition to assigned to the identity</param>
        /// <returns>RoleAssignmentHelper</returns>
        public RoleAssignmentHelper WithAccessTo(string resourceId, string roleDefinitionId)
        {
            string key = resourceId.ToLower() + "_" + roleDefinitionId.ToLower();
            if (!this.roleDefinitionsToAssign.ContainsKey(key))
            {
                this.roleDefinitionsToAssign.Add(key, new System.Tuple<string, string>(resourceId, roleDefinitionId));
            }
            return this;
        }

        /// <summary>
        /// Specifies that an access role assigned to the identity should be removed.
        /// </summary>
        /// <param name="roleAssignment">a role assigned to the identity</param>
        /// <returns>RoleAssignmentHelper</returns>
        public RoleAssignmentHelper WithoutAccessTo(IRoleAssignment roleAssignment)
        {
            String principalId = roleAssignment.PrincipalId;
            if (principalId == null || !principalId.Equals(idProvider.PrincipalId, StringComparison.OrdinalIgnoreCase))
            {
                return this;
            }
            else
            {
                this.roleAssignmentIdsToRemove.Add(roleAssignment.Id);
            }
            return this;
        }

        /// <summary>
        /// Specifies that an access role assigned to the identity should be removed.
        /// </summary>
        /// <param name="resourceId">the scope of role assignment</param>
        /// <param name="role">the role of role assignment</param>
        /// <returns>RoleAssignmentHelper</returns>
        public RoleAssignmentHelper WithoutAccessTo(string resourceId, BuiltInRole role)
        {
            string key = resourceId.ToLower() + "_" + role.ToString().ToLower();
            if (!this.roleAssignmentsToRemove.ContainsKey(key))
            {
                this.roleAssignmentsToRemove.Add(key, new System.Tuple<string, BuiltInRole>(resourceId, role));
            }
            return this;
        }

        /// <summary>
        /// True if there is role assigments pending to be commited.
        /// </summary>
        public bool HasPendingRoleAssignments
        {
            get
            {
                return this.rolesToAssign.Any() || this.roleDefinitionsToAssign.Any();
            }
        }

        /// <summary>
        /// Commit pending RBAC role assignment creation and removal.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task CommitsRoleAssignmentsPendingActionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await CreateRbacRoleAssignmentsAsync(cancellationToken);
            await RemoveRbacRoleAssignmentsAsync(cancellationToken);
        }

        /// <summary>
        /// Creates RBAC role assignments for the service principal exposed by IdProvider.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>The task with value as list of created role assignments</returns>
        private async Task<List<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment>> CreateRbacRoleAssignmentsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            List<IRoleAssignment> roleAssignments = new List<IRoleAssignment>();
            if (!this.rolesToAssign.Any()
                && !this.roleDefinitionsToAssign.Any())
            {
                return roleAssignments;
            }
            else if (this.idProvider.PrincipalId == null)
            {
                return roleAssignments;
            }
            else
            {
                try
                {
                    ResolveCurrentResourceGroupScope();

                    var roleAssignments1 = await Task.WhenAll(rolesToAssign.Values.Select(async (scopeAndRole) =>
                    {
                        BuiltInRole role = scopeAndRole.Item2;
                        string scope = scopeAndRole.Item1;
                        return await CreateRbacRoleAssignmentIfNotExistsAsync(role.ToString(), scope, true, cancellationToken);
                    }));
                    roleAssignments.AddRange(roleAssignments1);

                    var roleAssignments2 = await Task.WhenAll(roleDefinitionsToAssign.Values.Select(async (scopeAndRole) =>
                    {
                        string roleDefinition = scopeAndRole.Item2;
                        string scope = scopeAndRole.Item1;
                        return await CreateRbacRoleAssignmentIfNotExistsAsync(roleDefinition, scope, false, cancellationToken);
                    }));
                    roleAssignments.AddRange(roleAssignments2);
                    return roleAssignments.FindAll(roleAssignment => roleAssignment != null);
                }
                finally
                {
                    this.rolesToAssign.Clear();
                    this.roleDefinitionsToAssign.Clear();
                }
            }
        }

        /// <summary>
        /// Removes RBAC role assignments for the service principal exposed by IdProvider.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task RemoveRbacRoleAssignmentsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!this.roleAssignmentIdsToRemove.Any() && !this.roleAssignmentsToRemove.Any())
            {
                return;
            }
            else
            {
                try
                {
                    // Delete using role assignment Ids
                    //
                    await Task.WhenAll(roleAssignmentIdsToRemove.Select(async (id) =>
                    {
                        await this.rbacManager
                            .RoleAssignments
                            .DeleteByIdAsync(id, cancellationToken);
                    }));

                    // Delete using role assignment scope and role
                    //
                    await Task.WhenAll(roleAssignmentsToRemove.Select(r => r.Value).Select(async (scopeAndRole) =>
                    {
                        var scope = scopeAndRole.Item1;
                        var role = scopeAndRole.Item2;

                        IRoleDefinition roleDefinition = await this.rbacManager.RoleDefinitions.GetByScopeAndRoleNameAsync(scope, role.ToString(), cancellationToken);
                        if (roleDefinition != null)
                        {
                            var roleAssignments = await this.rbacManager
                                .RoleAssignments
                                .ListByScopeAsync(scope, cancellationToken);

                            var roleAssignment = roleAssignments
                            .FirstOrDefault(r => r.RoleDefinitionId.Equals(roleDefinition.Id, StringComparison.OrdinalIgnoreCase)
                                                    && r.PrincipalId.Equals(this.idProvider.PrincipalId, StringComparison.OrdinalIgnoreCase));
                            if (roleAssignment != null)
                            {
                                await this.rbacManager
                                    .RoleAssignments
                                    .DeleteByIdAsync(roleAssignment.Id, cancellationToken);
                            }
                        }
                    }));

                }
                finally
                {
                    roleAssignmentIdsToRemove.Clear();
                    roleAssignmentsToRemove.Clear();
                }
            }
        }

        /// <summary>
        /// Creates a RBAC role assignment (using role or role definition) for the service principal exposed by IdProvider.
        /// </summary>
        /// <param name="roleOrRoleDefinition">The role or role definition.</param>
        /// <param name="scope">The scope for the role assignment.</param>
        /// <return>the role assignment if it is created, null if assignment already exists.</return>
        private async Task<Microsoft.Azure.Management.Graph.RBAC.Fluent.IRoleAssignment> CreateRbacRoleAssignmentIfNotExistsAsync(string roleOrRoleDefinition, string scope, bool isRole, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(this.idProvider.PrincipalId))
            {
                throw new ArgumentNullException("idProvider.PrincipalId");
            }

            string roleAssignmentName = SdkContext.RandomGuid();
            try
            {
                if (isRole)
                {
                    return await rbacManager
                        .RoleAssignments
                        .Define(roleAssignmentName)
                        .ForObjectId(this.idProvider.PrincipalId)
                        .WithBuiltInRole(BuiltInRole.Parse(roleOrRoleDefinition))
                        .WithScope(scope)
                        .CreateAsync(cancellationToken);
                }
                else
                {
                    return await rbacManager
                        .RoleAssignments
                        .Define(roleAssignmentName)
                        .ForObjectId(this.idProvider.PrincipalId)
                        .WithRoleDefinition(roleOrRoleDefinition)
                        .WithScope(scope)
                        .CreateAsync(cancellationToken);
                }
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Body != null && cloudException.Body.Code != null && cloudException.Body.Code.Equals("RoleAssignmentExists", StringComparison.OrdinalIgnoreCase))
                {
                    // NOTE: We are unable to lookup the role assignment from principal.RoleAssignments() list
                    // because role assignment object does not contain 'role' name (the roleDefinitionId refer
                    // 'role' using id with GUID).
                    return null;
                }
                throw cloudException;
            }
        }

        /// <summary>
        /// If any of the scope in this.rolesToAssign and  this.roleDefinitionsToAssign is marked
        /// with CURRENT_RESOURCE_GROUP_SCOPE placeholder then resolve it and replace the placeholder with actual
        /// resource group scope (id).
        /// </summary>
        /// <return>true if there was a scope that is resolved, false otherwise</return>
        private bool ResolveCurrentResourceGroupScope()
        {
            IEnumerable<string> keysWithCurrentResourceGroupScopeForRoles = this.rolesToAssign
                .Where(role => role.Value.Item1.Equals(CURRENT_RESOURCE_GROUP_SCOPE, System.StringComparison.OrdinalIgnoreCase))
                .Select(role => role.Key)
                .ToList(); // ToList() is required as we are going to modify the same source collection below

            IEnumerable<string> keysWithCurrentResourceGroupScopeForRoleDefinitions = this.roleDefinitionsToAssign
                .Where(role => role.Value.Item1.Equals(CURRENT_RESOURCE_GROUP_SCOPE, System.StringComparison.OrdinalIgnoreCase))
                .Select(role => role.Key)
                .ToList();

            if (!keysWithCurrentResourceGroupScopeForRoles.Any()
                && !keysWithCurrentResourceGroupScopeForRoleDefinitions.Any())
            {
                return false;
            }

            var resourceGroupId = ResourceGroupId(this.idProvider.ResourceId);

            foreach (string key in keysWithCurrentResourceGroupScopeForRoles)
            {
                rolesToAssign[key] = new System.Tuple<string, BuiltInRole>(resourceGroupId, rolesToAssign[key].Item2);
            }

            foreach (string key in keysWithCurrentResourceGroupScopeForRoleDefinitions)
            {
                roleDefinitionsToAssign[key] = new System.Tuple<string, string>(resourceGroupId, roleDefinitionsToAssign[key].Item2);
            }
            return true;
        }

        /// <summary>
        /// This method returns ARM id of the resource group from the given ARM id of a resource in the resource group.
        /// </summary>
        /// <param name="id">ARM id</param>
        /// <returns>ARM id of the resource group</returns>
        private static string ResourceGroupId(String id)
        {
            ResourceId resourceId = ResourceId.FromString(id);
            var builder = new StringBuilder();
            builder.Append("/subscriptions/")
                    .Append(resourceId.SubscriptionId)
                    .Append("/resourceGroups/")
                    .Append(resourceId.ResourceGroupName);
            return builder.ToString();
        }
    }

    /// <summary>
    /// A type that provide the service principal id (object id) and ARM resource
    /// id of the resource for which role assignments needs to be done.
    /// </summary>
    public interface IIdProvider : IBeta
    {
        /// <summary>
        /// Get the service principal id (object id)
        /// </summary>
        string PrincipalId { get; }
        /// <summary>
        /// Get ARM resource id of the resource
        /// </summary>
        string ResourceId { get; }
    }
}
