using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{
    public class CustomPrincipalSerializedModel
    {

        public string Id { get; set; }

        public string Title { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
