using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tavisca.EmployeeManagement.DataContract
{
    [DataContract]
    public class Status
    {
        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Message { get; set; }

        public static Status Success { get { return new Status(){Code="200" ,Message="Success"}; } }
    }
}
