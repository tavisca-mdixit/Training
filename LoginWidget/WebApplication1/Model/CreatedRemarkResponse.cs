using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Model
{
    [DataContract]
    public class CreatedRemarkResponse : Result
    {
        [DataMember]
        public Remark Remark { get; set; }
    }
}