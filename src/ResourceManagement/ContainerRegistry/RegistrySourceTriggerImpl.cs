// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ContainerRegistry.Fluent
{
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.Models;
    using Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbnRhaW5lcnJlZ2lzdHJ5LmltcGxlbWVudGF0aW9uLlJlZ2lzdHJ5U291cmNlVHJpZ2dlckltcGw=
    internal partial class RegistrySourceTriggerImpl  :
        IRegistrySourceTrigger,
        Microsoft.Azure.Management.ContainerRegistry.Fluent.RegistrySourceTrigger.Definition.IDefinition,
        RegistrySourceTrigger.Update.IUpdate,
        IUpdateDefinition,
        IHasInner<Models.SourceTrigger>
    {
        private SourceTrigger inner;
        private RegistryTaskImpl registryTaskImpl;
        private SourceTriggerUpdateParameters sourceTriggerUpdateParameters;

        SourceTrigger IHasInner<SourceTrigger>.Inner => this.inner;

        ///GENMHASH:1A8659F8D549D364C509FEE6D051EC24:7BFFB4FD72D26704E97C0D470D44EE51
        internal  RegistrySourceTriggerImpl(string sourceTriggerName, RegistryTaskImpl registryTaskImpl, bool creation)
        {
            if (creation)
            {
                this.registryTaskImpl = registryTaskImpl;
                if (registryTaskImpl.Inner().Id == null)
                {
                    this.inner = new SourceTrigger
                    {
                        SourceRepository = new SourceProperties(),
                        Name = sourceTriggerName
                    };
                }
                else
                {
                    this.sourceTriggerUpdateParameters = new SourceTriggerUpdateParameters
                    {
                        SourceRepository = new SourceUpdateParameters(),
                        Name = sourceTriggerName
                    };
                }
            }
            else
            {
                this.registryTaskImpl = registryTaskImpl;
                this.inner = new SourceTrigger
                {
                    SourceRepository = new SourceProperties()
                };

                bool foundSourceTrigger = false;
                foreach(var stup in registryTaskImpl.taskUpdateParameters.Trigger.SourceTriggers)
                {
                    if (stup.Name.Equals(sourceTriggerName, StringComparison.OrdinalIgnoreCase))
                    {
                        this.sourceTriggerUpdateParameters = stup;
                        foundSourceTrigger = true;
                    }
                }
            
                if (!foundSourceTrigger)
                {
                    throw new ArgumentException("The trigger you are trying to update does not exist. If you are trying to define a new trigger while updating a task, please use the defineSourceTrigger function instead.");       
                }
            }
        }

        ///GENMHASH:76EDE6DBF107009D2B06F19698F6D5DB:5FE22F6A53A68A9EE3FB4DA27A1922CB
        private bool IsInCreateMode()
        {
            if (this.registryTaskImpl.Inner().Id == null)
            {
                return true;
            }
            return false;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:149B69EEF03D91ABFA63968A92324925
        public RegistryTaskImpl Attach()
        {
            if (IsInCreateMode())
            {
                this.registryTaskImpl.WithSourceTriggerCreateParameters(this.inner);
            }
            else
            {
                this.registryTaskImpl.WithSourceTriggerUpdateParameters(this.sourceTriggerUpdateParameters);
            }
            return this.registryTaskImpl;
        }

        ///GENMHASH:C852FF1A7022E39B3C33C4B996B5E6D6:7F78D90F6498B472DCB9BE14FD336BC9
        public SourceTrigger Inner()
        {
            return this.inner;
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:F93A27CDFA36098CFB86991C1BB6E07E
        public RegistryTask.Update.IUpdate Parent()
        {
            return this.registryTaskImpl;
        }

        ///GENMHASH:85DB4C5A8CFE78482BA42A29C86FC7DE:192027ED1843457DBBF0B227E39C70C8
        public string SourceControlBranch()
        {
            return this.inner.SourceRepository?.Branch;
        }

        ///GENMHASH:1C25E40B8E76C8B5F7486447AB1764BC:735B6973CEF37D2A5C7BD3DF1D8CE861
        public string SourceControlRepositoryUrl()
        {
            return this.inner.SourceRepository?.RepositoryUrl;
        }

        ///GENMHASH:5CDF327BBA2C53E9DDAEC69E0596259E:87D9D062BD662564653C6B77FD74C192
        public SourceControlType SourceControlType()
        {
            if (this.inner.SourceRepository == null || this.inner.SourceRepository.SourceControlType == null) 
            {
                return null;
            }
            return Models.SourceControlType.Parse(this.inner.SourceRepository.SourceControlType);
        }

        ///GENMHASH:E45051152580C40469B714ECE589CD85:072DD148AE4E81A35642FD25A986A985
        public IReadOnlyList<Models.SourceTriggerEvent> SourceTriggerEvents()
        {
            if (this.inner.SourceTriggerEvents == null)
            {
                return new List<Models.SourceTriggerEvent>();
            }
            return new List<Models.SourceTriggerEvent>(this.inner.SourceTriggerEvents.Select(e => SourceTriggerEvent.Parse(e)));
        }

        ///GENMHASH:06F61EC9451A16F634AEB221D51F2F8C:83A5F71A1B328D8D590BAEBFA00AFA7A
        public TriggerStatus Status()
        {
            if (this.inner.Status == null)
            {
                return null;
            }
            return TriggerStatus.Parse(this.inner.Status);
        }

        ///GENMHASH:E0BE8548ED954B0E97BEA72DD10D64E6:7D8C00382EACF2288A9E95E6FEAE6253
        public RegistrySourceTriggerImpl WithAzureDevOpsAsSourceControl()
        {
            if (IsInCreateMode())
            {
                this.inner.SourceRepository.SourceControlType = Models.SourceControlType.VisualStudioTeamService.ToString();
            }
            else
            {
                this.sourceTriggerUpdateParameters.SourceRepository.SourceControlType = Models.SourceControlType.VisualStudioTeamService.ToString();
            }
            return this;
        }

        ///GENMHASH:3501A74A9158E5A0ACDC87A9E64F49DA:DD80750AAF2F02997079709DA94254F9
        public RegistrySourceTriggerImpl WithCommitTriggerEvent()
        {
            return this.WithTriggerEvent(SourceTriggerEvent.Commit);
        }

        ///GENMHASH:0CE26096AC5B1BB416B45BD74314C313:C8283BED976AA96BA1BF11E38B12A77C
        public RegistrySourceTriggerImpl WithGithubAsSourceControl()
        {
            if (IsInCreateMode())
            {
                this.inner.SourceRepository.SourceControlType = Models.SourceControlType.Github.ToString();
            }
            else
            {
                this.sourceTriggerUpdateParameters.SourceRepository.SourceControlType = Models.SourceControlType.Github.ToString();
            }
            return this;
        }

        ///GENMHASH:3E69A43E7A662444657707F40E0AFAE6:A0485820A5148EF22821E98CDE5712CC
        public RegistrySourceTriggerImpl WithPullTriggerEvent()
        {
            return this.WithTriggerEvent(SourceTriggerEvent.Pullrequest);
        }

        ///GENMHASH:993553CEE69195BA14AFB76D2E2EC427:C9C73743BA068D281F188DCE3E989A79
        public RegistrySourceTriggerImpl WithRepositoryAuthentication(TokenType tokenType, string token)
        {
            if (IsInCreateMode())
            {
                AuthInfo authInfo = new AuthInfo()
                {
                    TokenType = tokenType.ToString(),
                    Token = token
                };
                this.inner.SourceRepository.SourceControlAuthProperties = authInfo;
            }
            else
            {
                AuthInfoUpdateParameters authInfoUpdateParameters = new AuthInfoUpdateParameters()
                {
                    TokenType = tokenType.ToString(),
                    Token = token
                };
                this.sourceTriggerUpdateParameters.SourceRepository.SourceControlAuthProperties = authInfoUpdateParameters;
            }
            return this;
        }

        ///GENMHASH:B81E7E3437CA81557802957EBD25D0A7:62E8169CE63BE77C359C009BC2F948AD
        public RegistrySourceTriggerImpl WithRepositoryAuthentication(TokenType tokenType, string token, string refreshToken, string scope, int expiresIn)
        {
            if (IsInCreateMode()) {
                AuthInfo authInfo = new AuthInfo()
                {
                    TokenType = tokenType.ToString(),
                    Token = token,
                    RefreshToken = refreshToken,
                    Scope = scope,
                    ExpiresIn = expiresIn
                };
                this.inner.SourceRepository.SourceControlAuthProperties = authInfo;
            }
            else
            {
                AuthInfoUpdateParameters authInfoUpdateParameters = new AuthInfoUpdateParameters()
                {
                    TokenType = tokenType.ToString(),
                    Token = token,
                    RefreshToken = refreshToken,
                    Scope = scope,
                    ExpiresIn = expiresIn
                };
                this.sourceTriggerUpdateParameters.SourceRepository.SourceControlAuthProperties = authInfoUpdateParameters;
            }
            return this;
        }

        ///GENMHASH:6008842EB1CF992E1095E5DADC70AD69:9159AEBFCA6C130E64FCC9D8D45ACEA1
        public RegistrySourceTriggerImpl WithRepositoryBranch(string branch)
        {
            if (IsInCreateMode())
            {
                this.inner.SourceRepository.Branch = branch;
            }
            else
            {
                this.sourceTriggerUpdateParameters.SourceRepository.Branch = branch;
            }
            return this;
        }

        ///GENMHASH:68455C77C6788F7CF6BDE2F512F45F78:DCDC1D80993B039A04D03793EEA3BBF5
        public RegistrySourceTriggerImpl WithSourceControl(SourceControlType sourceControl)
        {
            if (IsInCreateMode())
            {
                this.inner.SourceRepository.SourceControlType = sourceControl.ToString();
            }
            else
            {
                this.sourceTriggerUpdateParameters.SourceRepository.SourceControlType = sourceControl.ToString();
            }
            return this;
        }

        ///GENMHASH:425529E805D7A1214F43D660C0088C3B:02DA19F8F3FA9291B32F8EC535D6DA31
        public RegistrySourceTriggerImpl WithSourceControlRepositoryUrl(string sourceControlRepositoryUrl)
        {
            if (IsInCreateMode())
            {
                this.inner.SourceRepository.RepositoryUrl = sourceControlRepositoryUrl;
            }
            else
            {
                this.sourceTriggerUpdateParameters.SourceRepository.RepositoryUrl = sourceControlRepositoryUrl;
            }
            return this;
        }

        ///GENMHASH:90B327C61CE1E2A0EE0C7CF9151FA1BB:7E287596B09275B27B4F0B8B6F2617DD
        public RegistrySourceTriggerImpl WithTriggerEvent(SourceTriggerEvent sourceTriggerEvent)
        {
            if (this.inner != null)
            {
                if (this.inner.SourceTriggerEvents == null)
                {
                    this.inner.SourceTriggerEvents = new List<string>();
                }
                IList<string> sourceTriggerEvents = this.inner.SourceTriggerEvents;
                if (sourceTriggerEvents.Contains(sourceTriggerEvent.ToString()))
                {
                    return this;
                }
                sourceTriggerEvents.Add(sourceTriggerEvent.ToString());
                if (IsInCreateMode())
                {
                    this.inner.SourceTriggerEvents = sourceTriggerEvents;
                }
                else
                {
                    this.sourceTriggerUpdateParameters.SourceTriggerEvents = sourceTriggerEvents;
                }
            }
            else
            {
                if (this.sourceTriggerUpdateParameters.SourceTriggerEvents == null) {
                    this.sourceTriggerUpdateParameters.SourceTriggerEvents = new List<string>();
                }
                IList<string> sourceTriggerEvents = this.sourceTriggerUpdateParameters.SourceTriggerEvents;
                if (sourceTriggerEvents.Contains(sourceTriggerEvent.ToString()))
                {
                    return this;
                }
                sourceTriggerEvents.Add(sourceTriggerEvent.ToString());
                this.sourceTriggerUpdateParameters.SourceTriggerEvents = sourceTriggerEvents;
            }
            return this;
        }

        ///GENMHASH:309B73D93D71EC09DB82348850B4DC3B:D542559E6A88EEE7C1240397E3414E87
        public RegistrySourceTriggerImpl WithTriggerStatus(TriggerStatus triggerStatus)
        {
            if (IsInCreateMode())
            {
                this.inner.Status = triggerStatus.ToString();
            }
            else
            {
                this.sourceTriggerUpdateParameters.Status = triggerStatus.ToString();
            }
            return this;
        }

        ///GENMHASH:0BF1C26A5E11053589B261FDED004875:B4DAD078A663AEDFE6DE599CDB99F38F
        public RegistrySourceTriggerImpl WithTriggerStatusDisabled()
        {
            return this.WithTriggerStatus(TriggerStatus.Disabled);
        }

        ///GENMHASH:65AC5197E0E1515A6BA907AE78C79483:162085606F0385A3D1C6D8464E5C3C82
        public RegistrySourceTriggerImpl WithTriggerStatusEnabled()
        {
            return this.WithTriggerStatus(TriggerStatus.Enabled);
        }
    }
}