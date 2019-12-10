// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.PrivateDns.Fluent
{
    internal class ETagState
    {
        private bool doImplicitETagCheckOnCreate;
        private bool doImplicitETagCheckOnUpdate;
        private string eTagOnDelete;
        private string eTagOnUpdate;

        internal ETagState()
        {
        }

        internal ETagState Clear()
        {
            this.doImplicitETagCheckOnCreate = false;
            this.doImplicitETagCheckOnUpdate = false;
            this.eTagOnUpdate = null;
            this.eTagOnDelete = null;
            return this;
        }

        internal string IfMatchValueOnDelete()
        {
            return this.eTagOnDelete;
        }

        internal string IfMatchValueOnUpdate(string currentETagValue)
        {
            string eTagValue = null;
            if (this.doImplicitETagCheckOnUpdate)
            {
                eTagValue = currentETagValue;
            }
            if (this.eTagOnUpdate != null)
            {
                eTagValue = this.eTagOnUpdate;
            }
            return eTagValue;
        }

        internal string IfNonMatchValueOnCreate()
        {
            if (this.doImplicitETagCheckOnCreate)
            {
                return "*";
            }
            return null;
        }

        internal ETagState WithExplicitETagCheckOnDelete(string eTagValue)
        {
            this.eTagOnDelete = eTagValue;
            return this;
        }

        internal ETagState WithExplicitETagCheckOnUpdate(string eTagValue)
        {
            this.eTagOnUpdate = eTagValue;
            return this;
        }

        internal ETagState WithImplicitETagCheckOnCreate()
        {
            this.doImplicitETagCheckOnCreate = true;
            return this;
        }

        internal ETagState WithImplicitETagCheckOnUpdate()
        {
            this.doImplicitETagCheckOnUpdate = true;
            return this;
        }
    }
}
