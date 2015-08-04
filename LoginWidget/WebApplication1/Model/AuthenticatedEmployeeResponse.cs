using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WebApplication1.Model;

namespace Model
{   
    [DataContract]
    public class AuthenticatedEmployeeResponse : Result 
    {
        [DataMember]
        public Employee AuthenticatedEmployee { get; set; }
    }
}