using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace WebServer
{
    class Listener
    {

        private TcpListener _listener;
        private bool _running = false;


        public Listener(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
        }

        public void Run()
        {
            _running = true;
            _listener.Start();
            Console.WriteLine("Waiting for conection...");
            Debug.WriteLine("Waiting for conection...");
            while (_running)
            {
                if (_listener.Pending())
                {

                    Socket clientSocket = _listener.AcceptSocket();
                    RequestDispatcher dispatcher = new RequestDispatcher(clientSocket);
                    Thread dispatcherThread = new Thread(new ThreadStart(dispatcher.HandleClient));
                    dispatcherThread.Start();
                }
            }
            _running = false;
            _listener.Stop();
        }

    }

}

