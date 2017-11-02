// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core
{
    public static class ResourceUtils
    {
        public static string GroupFromResourceId(string id)
        {
            return (!string.IsNullOrWhiteSpace(id)) ? ResourceId.FromString(id).ResourceGroupName : null;
        }

        public static string SubscriptionFromResourceId(string id)
        {
            return (id != null) ? ResourceId.FromString(id).SubscriptionId : null;
        }

        public static string ResourceProviderFromResourceId(string id)
        {
            return (!string.IsNullOrWhiteSpace(id)) ? ResourceId.FromString(id).ProviderNamespace : null;
        }

        public static string ResourceTypeFromResourceId(string id)
        {
            return (!string.IsNullOrWhiteSpace(id)) ? ResourceId.FromString(id).ResourceType : null;
        }

        public static string NameFromResourceId(string id)
        {
            return (!string.IsNullOrWhiteSpace(id)) ? ResourceId.FromString(id).Name : null;
        }

        public static string ParentResourcePathFromResourceId(string id)
        {
            return (!string.IsNullOrWhiteSpace(id)) ? ResourceId.FromString(id)?.Parent?.Id : null;
        }

        public static string ConstructResourceId(
            string subscriptionId,
            string resourceGroupName,
            string resourceProviderNamespace,
            string resourceType,
            string resourceName,
            string parentResourcePath)
        {
            string prefixedParentPath = parentResourcePath;
            if (!string.IsNullOrEmpty(parentResourcePath))
            {
                prefixedParentPath = "/" + parentResourcePath;
            }
            return string.Format(
                    "/subscriptions/{0}/resourcegroups/{1}/providers/{2}{3}/{4}/{5}",
                    subscriptionId,
                    resourceGroupName,
                    resourceProviderNamespace,
                    prefixedParentPath,
                    resourceType,
                    resourceName);
        }

        public static string CreateODataFilterForTags(string tagName, string tagValue)
        {
            if (tagName == null)
            {
                return null;
            }

            else if (tagValue == null)
            {
                return $"tagname eq '{tagName.Trim('\'')}'";
            }
            else
            {
                return $"tagname eq '{tagName.Trim('\'')}' and tagvalue eq '{tagValue.Trim('\'')}'";
            }
        }
    }
}
