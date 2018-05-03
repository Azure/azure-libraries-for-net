// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Management.Network.Fluent
{
    using ResourceManager.Fluent.Core;
    using Management.Network.Fluent.Models;
    using ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Update;
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.UpdateDefinition;
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityGroup.Definition;
    using Microsoft.Azure.Management.Network.Fluent.NetworkSecurityRule.Definition;

    /// <summary>
    /// Implementation for NetworkSecurityRule and its create and update interfaces.
    /// </summary>

    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uTmV0d29ya1NlY3VyaXR5UnVsZUltcGw=
    internal partial class NetworkSecurityRuleImpl :
        ChildResource<SecurityRuleInner, NetworkSecurityGroupImpl, INetworkSecurityGroup>,
        INetworkSecurityRule,
        NetworkSecurityRule.Definition.IDefinition<NetworkSecurityGroup.Definition.IWithCreate>,
        NetworkSecurityRule.UpdateDefinition.IUpdateDefinition<NetworkSecurityGroup.Update.IUpdate>,
        NetworkSecurityRule.Update.IUpdate
    {
        private Dictionary<string, ApplicationSecurityGroupInner> sourceAsgs = new Dictionary<string, ApplicationSecurityGroupInner>();
        private Dictionary<string, ApplicationSecurityGroupInner> destinationAsgs = new Dictionary<string, ApplicationSecurityGroupInner>();

        ///GENMHASH:F6CF73FF4B137FB1F39A4CF3F1978CDB:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal NetworkSecurityRuleImpl(SecurityRuleInner inner, NetworkSecurityGroupImpl parent) : base(inner, parent)
        {
        }

        #region Accessors


        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }


        ///GENMHASH:671DFCB9FF648490A9325E2CEF729A98:1264D4A5A514AF0E1D906F6555100DBC
        internal string Direction()
        {
            return Inner.Direction.Value;
        }


        ///GENMHASH:D684E7477889A9013C81FAD82F69C54F:BD249A015EF71106387B78281489583A
        internal string Protocol()
        {
            return Inner.Protocol.Value;
        }


        ///GENMHASH:AD2631B1DB33BADA121356C1B30A8CEF:819A1711E476A574A29B65A8EF3D6B6D
        internal string Access()
        {
            return Inner.Access.Value;
        }


        ///GENMHASH:ED658240BD3BADDE48AC36B850104EF7:61F84F9D03F25051E6B9CD412AC31C5C
        internal string SourceAddressPrefix()
        {
            return Inner.SourceAddressPrefix;
        }


        ///GENMHASH:798F2820BD4219E7B4DD446712FDB17D:622E50000B17B9E3E8B3B81163D29120
        internal string SourcePortRange()
        {
            return Inner.SourcePortRange;
        }


        ///GENMHASH:DA055B08DA468C4A0FDC8D28BC654F0A:701D096BEC8442ACBC8DB508FAEDEC08
        internal string DestinationAddressPrefix()
        {
            return Inner.DestinationAddressPrefix;
        }


        ///GENMHASH:847583119E9E82CC59189CD873027479:7B0007A3A0F94C3FB5812F65DA082878
        internal string DestinationPortRange()
        {
            return Inner.DestinationPortRange;
        }


        ///GENMHASH:F09FEF9E35FF77948775761A5E6A40AB:3361B063A896EE37DD13B78E2584BC5B
        internal int Priority()
        {
            return (Inner.Priority.HasValue) ? Inner.Priority.Value : 0;
        }

        NetworkSecurityGroup.Update.IUpdate ISettable<NetworkSecurityGroup.Update.IUpdate>.Parent()
        {
            return Parent;
        }


        ///GENMHASH:7B3CA3D467253D93C6FF7587C3C0D0B7:F5293CC540B22E551BB92F6FCE17DE2C
        internal string Description()
        {
            return Inner.Description;
        }
        #endregion

        #region Public Withers
        #region Direction and Access


        ///GENMHASH:EBD9F5344656ED7BFFEC14FA40BC4C60:0E729F6D2F3925C7E3F46085CE5D9937
        internal NetworkSecurityRuleImpl AllowInbound()
        {
            return WithDirection(SecurityRuleDirection.Inbound)
                .WithAccess(SecurityRuleAccess.Allow);
        }


        ///GENMHASH:AF657C412FDE8602766B31D8867C8313:B1DB4EFA70463123E9D2520AA5D82584
        internal NetworkSecurityRuleImpl AllowOutbound()
        {
            return WithDirection(SecurityRuleDirection.Outbound)
                .WithAccess(SecurityRuleAccess.Allow);
        }


        ///GENMHASH:1D8264797E709FAECCB80879455AD938:590EABB23A5FEC0599B31AE76B3F8514
        internal NetworkSecurityRuleImpl DenyInbound()
        {
            return WithDirection(SecurityRuleDirection.Inbound)
                .WithAccess(SecurityRuleAccess.Deny);
        }


        ///GENMHASH:9F5E6DE0B4A1972AB162B9849E19B098:95455C1F9A03DC349DB9E7FB791FF5E4
        internal NetworkSecurityRuleImpl DenyOutbound()
        {
            return WithDirection(SecurityRuleDirection.Outbound)
                .WithAccess(SecurityRuleAccess.Deny);
        }
        #endregion

        #region Protocol

        ///GENMHASH:CA0F48388132710245BD9C972F7457A4:3C1AFE09D6F3461448B58077F1A3D334
        public ISet<string> DestinationApplicationSecurityGroupIds()
        {
            return new HashSet<string>(Inner.DestinationApplicationSecurityGroups.Select(asg => asg.Id));
        }

        internal NetworkSecurityRuleImpl WithProtocol(SecurityRuleProtocol protocol)
        {
            Inner.Protocol = protocol;
            return this;
        }

        ///GENMHASH:1928BF3A1A64CC113C96C62B2E19BC60:2F619F28559C25A5F73AEB7C7E089FBE
        internal NetworkSecurityRuleImpl WithAnyProtocol()
        {
            return WithProtocol(SecurityRuleProtocol.Asterisk);
        }
        #endregion

        #region Source Address


        ///GENMHASH:C1E378F412808239D4A5BB26E8D5CA12:74481C12C10AFB05A682DED5138ECA04
        internal NetworkSecurityRuleImpl FromAddress(string cidr)
        {
            Inner.SourceAddressPrefix = cidr;
            return this;
        }


        ///GENMHASH:9A930168883C8C79EC2DDFD0F5F081B9:FB41A055FFDB5493EA532C7E17409EAD
        internal NetworkSecurityRuleImpl FromAnyAddress()
        {
            Inner.SourceAddressPrefix = "*";
            return this;
        }
        #endregion

        #region Source Port


        ///GENMHASH:26CDEE809D8919D602C63114F968DABC:88EAE031F41464BBE725DE1B7EBADFF7
        internal NetworkSecurityRuleImpl FromPort(int port)
        {
            Inner.SourcePortRange = port.ToString();
            return this;
        }


        ///GENMHASH:F32072E391E633A04F75AABC03849892:1862D7F4397444B3CC54EC45F97955FD
        internal NetworkSecurityRuleImpl FromAnyPort()
        {
            Inner.SourcePortRange = "*";
            return this;
        }

        ///GENMHASH:093EC9C7D2F8A52ACF0F5E3F19A16A57:612C8F975A318A0CC7F3BEB8E0DE5308
        public ISet<string> SourceApplicationSecurityGroupIds()
        {
            return new HashSet<string>(Inner.SourceApplicationSecurityGroups.Select(asg => asg.Id));
        }

        ///GENMHASH:CFD60AE93A914AF9C3AFC89544B4E5F9:A6EF93A5D8C69AD2AEA75D286605280F
        internal NetworkSecurityRuleImpl FromPortRange(int from, int to)
        {
            Inner.SourcePortRange = from.ToString() + "-" + to.ToString();
            return this;
        }
        #endregion

        #region Destination Address


        ///GENMHASH:234D30A848ED7DBF5520AFC69AD995C7:733165F73A26B926B324E02146D2875B
        internal NetworkSecurityRuleImpl ToAddress(string cidr)
        {
            Inner.DestinationAddressPrefix = cidr;
            return this;
        }


        ///GENMHASH:F10D880FF926A72A5ABC01A67260E7CB:D1FEA4C1C399C058B3C1D218A2E35EF8
        internal NetworkSecurityRuleImpl ToAnyAddress()
        {
            Inner.DestinationAddressPrefix = "*";
            return this;
        }
        #endregion

        #region Destination Port


        ///GENMHASH:8EE0D22E3AAADFBD66DAE5FE476E2B15:5609309CD3B8E96F439BCD8A267CB260
        internal NetworkSecurityRuleImpl ToPort(int port)
        {
            Inner.DestinationPortRange = port.ToString();
            return this;
        }


        ///GENMHASH:4CCBA9F7181E3D548BCC322F6BAD198C:6A0152B14A756DD0722504A9B60F1732
        internal NetworkSecurityRuleImpl ToAnyPort()
        {
            Inner.DestinationPortRange = "*";
            return this;
        }


        ///GENMHASH:DDC361F80A63428296AD252FDE2F4306:A29156A82641E0C531C3B87E36E13AAA
        internal NetworkSecurityRuleImpl ToPortRange(int from, int to)
        {
            Inner.DestinationPortRange = from.ToString() + "-" + to.ToString();
            return this;
        }
        #endregion

        #region Priority


        ///GENMHASH:6AE4B78366B0EED73067DA623DDF384C:67BE1FE1F2956D83F058540CA2267669
        internal NetworkSecurityRuleImpl WithPriority(int priority)
        {
            Inner.Priority = priority;
            return this;
        }
        #endregion

        #region Description


        ///GENMHASH:016764F09D1966D691B5DE3A7FD47AC9:5D67BF1D9DA1008F878F13C112FF5F35
        internal NetworkSecurityRuleImpl WithDescription(string description)
        {
            Inner.Description = description;
            return this;
        }
        #endregion
        #endregion

        #region Helpers


        ///GENMHASH:14771CE9D31356489E7AB40C9C8F2695:68114EBD3902CF391D25CC7FD0C082C1
        private NetworkSecurityRuleImpl WithDirection(SecurityRuleDirection direction)
        {
            Inner.Direction = direction;
            return this;
        }
        ///GENMHASH:2B7FF25B14EF62E55CC8805B824E0366:11B5B307793C3F9FF1E037CD73A12C40
        public NetworkSecurityRuleImpl WithDestinationApplicationSecurityGroup(string id)
        {
            destinationAsgs[id] = new ApplicationSecurityGroupInner(id: id);
            Inner.DestinationAddressPrefix = null;
            Inner.DestinationAddressPrefixes = null;
            return this;
        }

        ///GENMHASH:704CF58AF600E909FFE3ECF15FF9CD85:8E627CC12F1DC0336E359140C6E63246
        private NetworkSecurityRuleImpl WithAccess(SecurityRuleAccess permission)
        {
            Inner.Access = permission;
            return this;
        }
        #endregion

        #region Actions


        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:5D4BF21E49789459EF95BA820BF19FF2
        internal NetworkSecurityGroupImpl Attach()
        {
            return Parent.WithRule(this);
        }
        #endregion

        ///GENMHASH:A6BD27BDA73F3A8D110E59E9BC1BF594:B3E2FF55E7190758DABFDE8C609EEECA
        public NetworkSecurityRuleImpl WithSourceApplicationSecurityGroup(string id)
        {

            sourceAsgs[id] = new ApplicationSecurityGroupInner(id : id);
            Inner.SourceAddressPrefix = null;
            Inner.SourceAddressPrefixes = null;

            return this;
        }
    }
}
