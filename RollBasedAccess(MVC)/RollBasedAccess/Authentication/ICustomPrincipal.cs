using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{
    class ICustomPrincipal :System.Security.Principal.IPrincipal
    {
        
            string FirstName { get; set; }

            string LastName { get; set; }
        
    }
}
