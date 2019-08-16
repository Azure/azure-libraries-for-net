// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Sql.Fluent.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// An execution of a job
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class JobExecutionInner : ProxyResourceInner
    {
        /// <summary>
        /// Initializes a new instance of the JobExecutionInner class.
        /// </summary>
        public JobExecutionInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the JobExecutionInner class.
        /// </summary>
        /// <param name="jobVersion">The job version number.</param>
        /// <param name="stepName">The job step name.</param>
        /// <param name="stepId">The job step id.</param>
        /// <param name="jobExecutionId">The unique identifier of the job
        /// execution.</param>
        /// <param name="lifecycle">The detailed state of the job execution.
        /// Possible values include: 'Created', 'InProgress',
        /// 'WaitingForChildJobExecutions', 'WaitingForRetry', 'Succeeded',
        /// 'SucceededWithSkipped', 'Failed', 'TimedOut', 'Canceled',
        /// 'Skipped'</param>
        /// <param name="provisioningState">The ARM provisioning state of the
        /// job execution. Possible values include: 'Created', 'InProgress',
        /// 'Succeeded', 'Failed', 'Canceled'</param>
        /// <param name="createTime">The time that the job execution was
        /// created.</param>
        /// <param name="startTime">The time that the job execution
        /// started.</param>
        /// <param name="endTime">The time that the job execution
        /// completed.</param>
        /// <param name="currentAttempts">Number of times the job execution has
        /// been attempted.</param>
        /// <param name="currentAttemptStartTime">Start time of the current
        /// attempt.</param>
        /// <param name="lastMessage">The last status or error message.</param>
        /// <param name="target">The target that this execution is executed
        /// on.</param>
        public JobExecutionInner(string id = default(string), string name = default(string), string type = default(string), int? jobVersion = default(int?), string stepName = default(string), int? stepId = default(int?), System.Guid? jobExecutionId = default(System.Guid?), JobExecutionLifecycle lifecycle = default(JobExecutionLifecycle), ProvisioningState provisioningState = default(ProvisioningState), System.DateTime? createTime = default(System.DateTime?), System.DateTime? startTime = default(System.DateTime?), System.DateTime? endTime = default(System.DateTime?), int? currentAttempts = default(int?), System.DateTime? currentAttemptStartTime = default(System.DateTime?), string lastMessage = default(string), JobExecutionTarget target = default(JobExecutionTarget))
            : base(id, name, type)
        {
            JobVersion = jobVersion;
            StepName = stepName;
            StepId = stepId;
            JobExecutionId = jobExecutionId;
            Lifecycle = lifecycle;
            ProvisioningState = provisioningState;
            CreateTime = createTime;
            StartTime = startTime;
            EndTime = endTime;
            CurrentAttempts = currentAttempts;
            CurrentAttemptStartTime = currentAttemptStartTime;
            LastMessage = lastMessage;
            Target = target;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets the job version number.
        /// </summary>
        [JsonProperty(PropertyName = "properties.jobVersion")]
        public int? JobVersion { get; private set; }

        /// <summary>
        /// Gets the job step name.
        /// </summary>
        [JsonProperty(PropertyName = "properties.stepName")]
        public string StepName { get; private set; }

        /// <summary>
        /// Gets the job step id.
        /// </summary>
        [JsonProperty(PropertyName = "properties.stepId")]
        public int? StepId { get; private set; }

        /// <summary>
        /// Gets the unique identifier of the job execution.
        /// </summary>
        [JsonProperty(PropertyName = "properties.jobExecutionId")]
        public System.Guid? JobExecutionId { get; private set; }

        /// <summary>
        /// Gets the detailed state of the job execution. Possible values
        /// include: 'Created', 'InProgress', 'WaitingForChildJobExecutions',
        /// 'WaitingForRetry', 'Succeeded', 'SucceededWithSkipped', 'Failed',
        /// 'TimedOut', 'Canceled', 'Skipped'
        /// </summary>
        [JsonProperty(PropertyName = "properties.lifecycle")]
        public JobExecutionLifecycle Lifecycle { get; private set; }

        /// <summary>
        /// Gets the ARM provisioning state of the job execution. Possible
        /// values include: 'Created', 'InProgress', 'Succeeded', 'Failed',
        /// 'Canceled'
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public ProvisioningState ProvisioningState { get; private set; }

        /// <summary>
        /// Gets the time that the job execution was created.
        /// </summary>
        [JsonProperty(PropertyName = "properties.createTime")]
        public System.DateTime? CreateTime { get; private set; }

        /// <summary>
        /// Gets the time that the job execution started.
        /// </summary>
        [JsonProperty(PropertyName = "properties.startTime")]
        public System.DateTime? StartTime { get; private set; }

        /// <summary>
        /// Gets the time that the job execution completed.
        /// </summary>
        [JsonProperty(PropertyName = "properties.endTime")]
        public System.DateTime? EndTime { get; private set; }

        /// <summary>
        /// Gets or sets number of times the job execution has been attempted.
        /// </summary>
        [JsonProperty(PropertyName = "properties.currentAttempts")]
        public int? CurrentAttempts { get; set; }

        /// <summary>
        /// Gets start time of the current attempt.
        /// </summary>
        [JsonProperty(PropertyName = "properties.currentAttemptStartTime")]
        public System.DateTime? CurrentAttemptStartTime { get; private set; }

        /// <summary>
        /// Gets the last status or error message.
        /// </summary>
        [JsonProperty(PropertyName = "properties.lastMessage")]
        public string LastMessage { get; private set; }

        /// <summary>
        /// Gets the target that this execution is executed on.
        /// </summary>
        [JsonProperty(PropertyName = "properties.target")]
        public JobExecutionTarget Target { get; private set; }

    }
}
