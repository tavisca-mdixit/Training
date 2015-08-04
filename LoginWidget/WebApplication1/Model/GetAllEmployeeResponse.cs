using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Model
{
    [DataContract]
    public class GetAllEmployeeResponse : Result
    {
        [DataMember]
        public List<Employee> EmpList { get; set; }
    }
}