using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.Model
{

    public class Credentials
    {
      
        public string UserName { get; set; }
        public string Password { get; set; }

        //create a validator;
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.UserName))
                throw new Exception("FirstName cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(this.Password))
                throw new Exception("Email cannot be null or empty.");

        }
    }
}
