using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    interface IProcessor
    {
        void DoGet(string uri);
        void DoPost();
    }
}
