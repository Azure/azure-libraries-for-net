// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.BatchAI.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.BatchAI;
    using Microsoft.Azure.Management.BatchAI.Fluent;
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Specifies a setup task which can be used to customize the compute nodes
    /// of the cluster.
    /// </summary>
    public partial class SetupTask
    {
        /// <summary>
        /// Initializes a new instance of the SetupTask class.
        /// </summary>
        public SetupTask()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SetupTask class.
        /// </summary>
        /// <param name="commandLine">Command Line to start Setup
        /// process.</param>
        /// <param name="stdOutErrPathPrefix">The path where the Batch AI
        /// service will upload the stdout and stderror of setup task.</param>
        /// <param name="environmentVariables">Collection of environment
        /// settings.</param>
        /// <param name="runElevated">Specifies whether to run the setup task
        /// in elevated mode. The default value is false.</param>
        public SetupTask(string commandLine, string stdOutErrPathPrefix, IList<EnvironmentSetting> environmentVariables = default(IList<EnvironmentSetting>), bool? runElevated = default(bool?))
        {
            CommandLine = commandLine;
            EnvironmentVariables = environmentVariables;
            RunElevated = runElevated;
            StdOutErrPathPrefix = stdOutErrPathPrefix;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets command Line to start Setup process.
        /// </summary>
        [JsonProperty(PropertyName = "commandLine")]
        public string CommandLine { get; set; }

        /// <summary>
        /// Gets or sets collection of environment settings.
        /// </summary>
        [JsonProperty(PropertyName = "environmentVariables")]
        public IList<EnvironmentSetting> EnvironmentVariables { get; set; }

        /// <summary>
        /// Gets or sets specifies whether to run the setup task in elevated
        /// mode. The default value is false.
        /// </summary>
        [JsonProperty(PropertyName = "runElevated")]
        public bool? RunElevated { get; set; }

        /// <summary>
        /// Gets or sets the path where the Batch AI service will upload the
        /// stdout and stderror of setup task.
        /// </summary>
        [JsonProperty(PropertyName = "stdOutErrPathPrefix")]
        public string StdOutErrPathPrefix { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (CommandLine == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "CommandLine");
            }
            if (StdOutErrPathPrefix == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "StdOutErrPathPrefix");
            }
            if (EnvironmentVariables != null)
            {
                foreach (var element in EnvironmentVariables)
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
