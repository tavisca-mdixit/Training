using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model
{
    public class Server
    {
        private Listener _listner;
        private Dispatcher _dispatcher = new Dispatcher();


        public Server(string host, int port)
        {
            this._listner = new Listener(host, port);

        }



        public void Start()
        {
            Task.Run(() =>
            {
                _listner.Listen();
            });
            Task.Run(() =>
            {
                _dispatcher.Start();
            });

        }

        public void Stop()
        {
            _listner.Stop();
            _dispatcher.Stop();
        }
    }
}
