// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.KeyVault.Fluent
{

    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Definition;
    using Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update;
    using Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResourceActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.KeyVault.Fluent.Models;
    using Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition;
    using Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Implementation for AccessPolicy and its parent interfaces.
    /// </summary>
    internal partial class AccessPolicyImpl :
        ChildResource<Microsoft.Azure.Management.KeyVault.Fluent.Models.AccessPolicyEntry, Microsoft.Azure.Management.KeyVault.Fluent.VaultImpl, Microsoft.Azure.Management.KeyVault.Fluent.IVault>,
        IAccessPolicy,
        IDefinition<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Definition.IWithCreate>,
        IUpdateDefinition<Microsoft.Azure.Management.KeyVault.Fluent.Vault.Update.IUpdate>,
        Microsoft.Azure.Management.KeyVault.Fluent.AccessPolicy.Update.IUpdate
    {
        private string userPrincipalName;
        private string servicePrincipalName;
        ///GENMHASH:DB1CD9648996DA10B58423DFABD976E4:BC7BE29DA61C7F6594944FD23512AD2F
        internal AccessPolicyImpl(AccessPolicyEntry innerObject, Microsoft.Azure.Management.KeyVault.Fluent.VaultImpl parent) : base(innerObject, parent)
        {
            Inner.TenantId = Guid.Parse(parent.TenantId);
        }

        ///GENMHASH:EFC2DDE75F20FD4EAFECA334A50B3D22:B383D7B422F0E34653A55B7CA778970F
        internal string UserPrincipalName
        {
            get
            {
                return this.userPrincipalName;
            }
        }

        ///GENMHASH:F7CF19ADF2E05F1D39D6A50FA0A5AB79:EB069810FBC10E1827D16F395FF3A078
        internal string ServicePrincipalName
        {
            get
            {
                return this.servicePrincipalName;
            }
        }

        ///GENMHASH:DA183CCEBC00D21096D59D1B439F4E2F:8CE5F00FA8F3A032BD5A0628F8ACA3DB
        public string TenantId
        {
            get
            {
                if (Inner.TenantId == null)
                {
                    return null;
                }
                return Inner.TenantId.ToString();
            }
        }

        ///GENMHASH:17540EB75C744FB87D329C55BE359E09:9C269984048544F2AD468D4C15E27F5E
        public string ObjectId
        {
            get
            {
                if (Inner.ObjectId == null)
                {
                    return null;
                }
                return Inner.ObjectId;
            }
        }

        ///GENMHASH:359D1EADA427782D05CA5CF20BD6D91A:FDF832AECB3EF51F25367680A7510FAB
        public string ApplicationId
        {
            get
            {
                if (Inner.ApplicationId == null)
                {
                    return null;
                }
                return Inner.ApplicationId.ToString();
            }
        }

        ///GENMHASH:5FECF7CEB96EFF8A50AB4CA3950B5843:833D7CA0001EC62E67CD177E707E39B5
        public Permissions Permissions
        {
            get
            {
                return Inner.Permissions;
            }
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:CC8D1D4F5D89E231669C5963BF9F8E9C
        public override string Name()
        {
            return ObjectId;
        }

        ///GENMHASH:2548489FEC6DEDA375BB14337408C32F:F98681659352BAAE0C36842A9939C2C0
        private void InitializeKeyPermissions()
        {
            if (Inner.Permissions == null)
            {
                Inner.Permissions = new Permissions();
            }
            if (Inner.Permissions.Keys == null)
            {
                Inner.Permissions.Keys = new List<KeyPermissions>();
            }
        }

        ///GENMHASH:E016D80945C42D59D0AEF2D38ECB30DB:5F47B75D080175C69CF7CF370856DC63
        private void InitializeSecretPermissions()
        {
            if (Inner.Permissions == null)
            {
                Inner.Permissions = new Permissions();
            }
            if (Inner.Permissions.Secrets == null)
            {
                Inner.Permissions.Secrets = new List<SecretPermissions>();
            }
        }

        ///GENMHASH:CAED6C15F9B42B76A5AC64F370A3FD5B:D711BB2E9099F8836329B1458BCB95BB
        public AccessPolicyImpl AllowKeyPermissions(params KeyPermissions[] permissions)
        {
            return AllowKeyPermissions(new List<KeyPermissions>(permissions));
        }

        ///GENMHASH:4285C26105D2CACA3EB31944C49CADB1:D711BB2E9099F8836329B1458BCB95BB
        public AccessPolicyImpl AllowKeyPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.KeyPermissions> permissions)
        {
            InitializeKeyPermissions();
            foreach (var permission in permissions)
            {
                if (!Inner.Permissions.Keys.Contains(permission))
                {
                    Inner.Permissions.Keys.Add(permission);
                }
            }
            return this;
        }

        ///GENMHASH:3B24D44CFE59D6F67A1E749291E41B8F:1E59286A8F22B9A1DA22ED9E99425039
        public AccessPolicyImpl AllowSecretPermissions(params SecretPermissions[] permissions)
        {
            return AllowSecretPermissions(new List<SecretPermissions>(permissions));
        }

        ///GENMHASH:78BA35A3DD13CB1E4732F1F2B4B3F36A:1E59286A8F22B9A1DA22ED9E99425039
        public AccessPolicyImpl AllowSecretPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.SecretPermissions> permissions)
        {
            InitializeSecretPermissions();
            foreach (var permission in permissions)
            {
                if (!Inner.Permissions.Secrets.Contains(permission))
                {
                    Inner.Permissions.Secrets.Add(permission);
                }
            }
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:B7963E82870A365FD51B673F0B0274AC
        public Microsoft.Azure.Management.KeyVault.Fluent.VaultImpl Attach()
        {
            Parent.WithAccessPolicy(this);
            return Parent;
        }

        ///GENMHASH:2D15AA31EDC834E6F6B074930607F790:225E1D92A92E81E1982C4A483BC88058
        public AccessPolicyImpl ForObjectId(string objectId)
        {
            Inner.ObjectId = objectId;
            return this;
        }

        ///GENMHASH:9E92F3BA1758AAE198E09D586436080A:0A1851786DBC209232600425DAE0D55D
        public AccessPolicyImpl ForUser(IActiveDirectoryUser user)
        {
            Inner.ObjectId = user.Id;
            return this;
        }

        ///GENMHASH:8E6D48BCE723A76A602CE321050BFECB:57A825FB9FC082E89AA8F17B8DEB7486
        public AccessPolicyImpl ForUser(string userPrincipalName)
        {
            this.userPrincipalName = userPrincipalName;
            return this;
        }

        ///GENMHASH:498DF2FE8CE61E58CF671C4DCDF1A6D1:F6952E2299613B074C6F3E2594360B44
        public AccessPolicyImpl ForGroup(IActiveDirectoryGroup group)
        {
            Inner.ObjectId = group.Id;

            return this;
        }

        ///GENMHASH:7B10596856964977EC5E018A031EE6E9:E17FF884EE021904E2BD4F8BD9BDB6FC
        public AccessPolicyImpl ForServicePrincipal(IServicePrincipal servicePrincipal)
        {
            Inner.ObjectId = servicePrincipal.Id;
            return this;
        }

        ///GENMHASH:A5A82E0B3718195704CB5A3CC0F635D9:7F5AA729AD0F3F93063692EA32AF9FD8
        public AccessPolicyImpl ForServicePrincipal(string servicePrincipalName)
        {
            this.servicePrincipalName = servicePrincipalName;
            return this;
        }

        ///GENMHASH:01ABB2A8A169AF9132F24847F24D56E9:438CAA23A6AC21CE3918CCD89F051C7B
        public AccessPolicyImpl AllowKeyAllPermissions()
        {
            return AllowKeyPermissions(KeyPermissions.Encrypt.GetType()
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(KeyPermissions))
                .Select(f => (KeyPermissions)f.GetValue(null))
                .ToArray());
        }

        ///GENMHASH:A03FAAD8A56A117F1C5B4D0165E18038:2886FCB58861FDE2A5A0722CF95F02F8
        public AccessPolicyImpl DisallowKeyAllPermissions()
        {
            InitializeKeyPermissions();
            Inner.Permissions.Keys.Clear();
            return this;
        }

        ///GENMHASH:0379078579ABB5B0C7747DE0FCD150CE:32E7054731C3AF1FE28D7D4F657764E5
        public AccessPolicyImpl DisallowKeyPermissions(params KeyPermissions[] permissions)
        {
            return DisallowKeyPermissions(new List<KeyPermissions>(permissions));
        }

        ///GENMHASH:BFC40A8274C194ADA54B97FFF26C792F:B6357A7A6591914A7D868EDF465B9C79
        public AccessPolicyImpl DisallowKeyPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.KeyPermissions> permissions)
        {
            InitializeSecretPermissions();
            foreach (var permission in permissions)
            {
                Inner.Permissions.Keys.Remove(permission);
            }
            return this;
        }

        ///GENMHASH:23EFE82E8A7FB33D4BEAF74B70CE1367:F9763811A5E6A497FF943250AB590C11
        public AccessPolicyImpl AllowSecretAllPermissions()
        {
            return AllowSecretPermissions(SecretPermissions.Get.GetType()
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(SecretPermissions))
                .Select(f => (SecretPermissions)f.GetValue(null))
                .ToArray());
        }

        ///GENMHASH:034BD24F1EDCEF94C2B612E26745EC84:3DEB6E41E02F3F5DD756AAD51E9D5A41
        public AccessPolicyImpl DisallowSecretAllPermissions()
        {
            InitializeSecretPermissions();
            Inner.Permissions.Secrets.Clear();
            return this;
        }

        ///GENMHASH:0BE789A9F7F46772A48AE4DEF539ED9B:C45089A07841C467C39B8B11526C860C
        public AccessPolicyImpl DisallowSecretPermissions(params SecretPermissions[] permissions)
        {
            return DisallowSecretPermissions(new List<SecretPermissions>(permissions));
        }

        ///GENMHASH:044EB3BD07FE92ADABF599BDE9722E03:08024B552C1C45974AC88973802166CA
        public AccessPolicyImpl DisallowSecretPermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.SecretPermissions> permissions)
        {
            InitializeSecretPermissions();
            foreach (var permission in permissions)
            {
                Inner.Permissions.Secrets.Remove(permission);
            }
            return this;
        }

        ///GENMHASH:15559971150DD16EE8C6A99E65B918C4:1B7756ABF8CA620B4AEA60A8AF376026
        private void InitializeCertificatePermissions()
        {
            if (Inner.Permissions == null)
            {
                Inner.Permissions = new Permissions();
            }
            if (Inner.Permissions.Certificates == null)
            {
                Inner.Permissions.Certificates = new List<CertificatePermissions>();
            }
        }

        ///GENMHASH:4F1155F2A91F6B705DDEA67B0C5064CF:6C9DEF89D75DCF75C0DB0D1756D2662C
        public AccessPolicyImpl AllowCertificatePermissions(params CertificatePermissions[] permissions)
        {
            return AllowCertificatePermissions(new List<CertificatePermissions>(permissions));
        }

        ///GENMHASH:87481A220E01189B297B093F69F7D607:6C9DEF89D75DCF75C0DB0D1756D2662C
        public AccessPolicyImpl AllowCertificatePermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.CertificatePermissions> permissions)
        {
            InitializeCertificatePermissions();
            foreach (var permission in permissions)
            {
                if (!Inner.Permissions.Certificates.Contains(permission))
                {
                    Inner.Permissions.Certificates.Add(permission);
                }
            }
            return this;
        }

        ///GENMHASH:3CA9C293D3584AB382168617DC8AC2DC:1ED91EC5382646AF3251110612D16696
        public AccessPolicyImpl AllowCertificateAllPermissions()
        {
            return AllowCertificatePermissions(CertificatePermissions.Get.GetType()
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(f => f.FieldType == typeof(CertificatePermissions))
                .Select(f => (CertificatePermissions)f.GetValue(null))
                .ToArray());
        }

        ///GENMHASH:4D963017A45C9FB4AAD21FAA40B89E00:FB198DF0AC0B66066441E26A91E3DFA6
        public AccessPolicyImpl DisallowCertificateAllPermissions()
        {
            InitializeCertificatePermissions();
            Inner.Permissions.Certificates.Clear();
            return this;
        }

        ///GENMHASH:AE11CDB2ADB4CA43E822A6B9D47FDC9E:A24189CA74B21DF2134B4EE9EA72529A
        public AccessPolicyImpl DisallowCertificatePermissions(params CertificatePermissions[] permissions)
        {
            return DisallowCertificatePermissions(new List<CertificatePermissions>(permissions));
        }

        ///GENMHASH:6562F07801E147CF447CBEC581289858:369E0217A4239EAE03E2E9B77137E684
        public AccessPolicyImpl DisallowCertificatePermissions(IList<Microsoft.Azure.Management.KeyVault.Fluent.Models.CertificatePermissions> permissions)
        {
            InitializeCertificatePermissions();
            foreach (var permission in permissions)
            {
                Inner.Permissions.Certificates.Remove(permission);
            }
            return this;
        }

        Vault.Update.IUpdate ISettable<Vault.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}