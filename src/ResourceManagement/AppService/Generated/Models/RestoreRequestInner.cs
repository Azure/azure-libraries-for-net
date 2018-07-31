// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.AppService.Fluent.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Description of a restore request.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class RestoreRequestInner : ProxyOnlyResourceInner
    {
        /// <summary>
        /// Initializes a new instance of the RestoreRequestInner class.
        /// </summary>
        public RestoreRequestInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RestoreRequestInner class.
        /// </summary>
        /// <param name="storageAccountUrl">SAS URL to the container.</param>
        /// <param name="overwrite">&lt;code&gt;true&lt;/code&gt; if the
        /// restore operation can overwrite target app; otherwise,
        /// &lt;code&gt;false&lt;/code&gt;. &lt;code&gt;true&lt;/code&gt; is
        /// needed if trying to restore over an existing app.</param>
        /// <param name="kind">Kind of resource.</param>
        /// <param name="blobName">Name of a blob which contains the
        /// backup.</param>
        /// <param name="siteName">Name of an app.</param>
        /// <param name="databases">Collection of databases which should be
        /// restored. This list has to match the list of databases included in
        /// the backup.</param>
        /// <param name="ignoreConflictingHostNames">Changes a logic when
        /// restoring an app with custom domains. &lt;code&gt;true&lt;/code&gt;
        /// to remove custom domains automatically. If
        /// &lt;code&gt;false&lt;/code&gt;, custom domains are added to
        /// the app's object when it is being restored, but that might fail due
        /// to conflicts during the operation.</param>
        /// <param name="ignoreDatabases">Ignore the databases and only restore
        /// the site content</param>
        /// <param name="appServicePlan">Specify app service plan that will own
        /// restored site.</param>
        /// <param name="operationType">Operation type. Possible values
        /// include: 'Default', 'Clone', 'Relocation', 'Snapshot',
        /// 'CloudFS'</param>
        /// <param name="adjustConnectionStrings">&lt;code&gt;true&lt;/code&gt;
        /// if SiteConfig.ConnectionStrings should be set in new app;
        /// otherwise, &lt;code&gt;false&lt;/code&gt;.</param>
        /// <param name="hostingEnvironment">App Service Environment name, if
        /// needed (only when restoring an app to an App Service
        /// Environment).</param>
        public RestoreRequestInner(string storageAccountUrl, bool overwrite, string id = default(string), string name = default(string), string type = default(string), string kind = default(string), string blobName = default(string), string siteName = default(string), IList<DatabaseBackupSetting> databases = default(IList<DatabaseBackupSetting>), bool? ignoreConflictingHostNames = default(bool?), bool? ignoreDatabases = default(bool?), string appServicePlan = default(string), BackupRestoreOperationType? operationType = default(BackupRestoreOperationType?), bool? adjustConnectionStrings = default(bool?), string hostingEnvironment = default(string))
            : base(id, name, type, kind)
        {
            StorageAccountUrl = storageAccountUrl;
            BlobName = blobName;
            Overwrite = overwrite;
            SiteName = siteName;
            Databases = databases;
            IgnoreConflictingHostNames = ignoreConflictingHostNames;
            IgnoreDatabases = ignoreDatabases;
            AppServicePlan = appServicePlan;
            OperationType = operationType;
            AdjustConnectionStrings = adjustConnectionStrings;
            HostingEnvironment = hostingEnvironment;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets SAS URL to the container.
        /// </summary>
        [JsonProperty(PropertyName = "properties.storageAccountUrl")]
        public string StorageAccountUrl { get; set; }

        /// <summary>
        /// Gets or sets name of a blob which contains the backup.
        /// </summary>
        [JsonProperty(PropertyName = "properties.blobName")]
        public string BlobName { get; set; }

        /// <summary>
        /// Gets or sets &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt; if the
        /// restore operation can overwrite target app; otherwise,
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt;.
        /// &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt; is needed if trying
        /// to restore over an existing app.
        /// </summary>
        [JsonProperty(PropertyName = "properties.overwrite")]
        public bool Overwrite { get; set; }

        /// <summary>
        /// Gets or sets name of an app.
        /// </summary>
        [JsonProperty(PropertyName = "properties.siteName")]
        public string SiteName { get; set; }

        /// <summary>
        /// Gets or sets collection of databases which should be restored. This
        /// list has to match the list of databases included in the backup.
        /// </summary>
        [JsonProperty(PropertyName = "properties.databases")]
        public IList<DatabaseBackupSetting> Databases { get; set; }

        /// <summary>
        /// Gets or sets changes a logic when restoring an app with custom
        /// domains. &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt; to remove
        /// custom domains automatically. If
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt;, custom domains are
        /// added to
        /// the app's object when it is being restored, but that might fail due
        /// to conflicts during the operation.
        /// </summary>
        [JsonProperty(PropertyName = "properties.ignoreConflictingHostNames")]
        public bool? IgnoreConflictingHostNames { get; set; }

        /// <summary>
        /// Gets or sets ignore the databases and only restore the site content
        /// </summary>
        [JsonProperty(PropertyName = "properties.ignoreDatabases")]
        public bool? IgnoreDatabases { get; set; }

        /// <summary>
        /// Gets or sets specify app service plan that will own restored site.
        /// </summary>
        [JsonProperty(PropertyName = "properties.appServicePlan")]
        public string AppServicePlan { get; set; }

        /// <summary>
        /// Gets or sets operation type. Possible values include: 'Default',
        /// 'Clone', 'Relocation', 'Snapshot', 'CloudFS'
        /// </summary>
        [JsonProperty(PropertyName = "properties.operationType")]
        public BackupRestoreOperationType? OperationType { get; set; }

        /// <summary>
        /// Gets or sets &amp;lt;code&amp;gt;true&amp;lt;/code&amp;gt; if
        /// SiteConfig.ConnectionStrings should be set in new app; otherwise,
        /// &amp;lt;code&amp;gt;false&amp;lt;/code&amp;gt;.
        /// </summary>
        [JsonProperty(PropertyName = "properties.adjustConnectionStrings")]
        public bool? AdjustConnectionStrings { get; set; }

        /// <summary>
        /// Gets or sets app Service Environment name, if needed (only when
        /// restoring an app to an App Service Environment).
        /// </summary>
        [JsonProperty(PropertyName = "properties.hostingEnvironment")]
        public string HostingEnvironment { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (StorageAccountUrl == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "StorageAccountUrl");
            }
            if (Databases != null)
            {
                foreach (var element in Databases)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
