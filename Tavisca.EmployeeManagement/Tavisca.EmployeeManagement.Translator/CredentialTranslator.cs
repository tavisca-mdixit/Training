using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.Translator
{
    public static class CredentialTranslator
    {
        public static Model.Credentials ToDomainModel(this Model.Credentials creds)
        {
            if (creds == null) return null;
            return new Model.Credentials()
            {
                UserName = creds.UserName,
                Password = creds.Password
            };
        }
    }
}
