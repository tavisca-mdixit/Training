﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Model
{
    [DataContract]
    public class GetRemarkResponse: Result
    {
        [DataMember]
        public List<Remark> RequestedRemark { get; set; }
    }
}