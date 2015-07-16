﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model
{
    interface IQueue
    {
        bool TryDequeue(out Socket socket);
        void Enqueue(Socket socket);
    }
}
