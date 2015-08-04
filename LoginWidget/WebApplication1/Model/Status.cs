using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Model
{
    [DataContract]
    public class Status
    {

        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}