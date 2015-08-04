using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Model
{
    [DataContract]
    public class EmpChangePassword
    {

        [DataMember]
        public string EmployeeId { get; set; }


        [DataMember]
        public string OldPassword { get; set; }

        [DataMember]
        public string NewPassword { get; set; }
    }
}