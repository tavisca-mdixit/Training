using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;

namespace WebServer.Model
{
    class Dispatcher
    {
        private Socket _clientSocket = null;
        private bool _isRunning = true;
        internal void Start()
        {
            while (this._isRunning)
            {
                Socket socket;
                if (Application.RequestQueue.TryDequeue(out socket) == false)
                    continue;
                Task.Run(() =>
                {
                    this.Dispatch(socket);
                });
            }
        }
        public void Dispatch(Socket clientSocket)
        {
            this._clientSocket = clientSocket;
            var requestParser = new Request();
            var requestString = DecodeRequest(_clientSocket);
            requestParser.Parser(requestString);

            Console.WriteLine(requestParser.HttpUrl);

            if (requestParser.HttpMethod != null && requestParser.HttpMethod.Equals("GET"))
            {

                var response = new Response(_clientSocket, ConfigurationManager.AppSettings["Path"]);
                response.RequestUrl(requestParser.HttpUrl);
            }
            else
            {
                new InProcQueue().Enqueue(_clientSocket);

            }
        }

        internal void Stop()
        {
            this._isRunning = false;
        }

        private string DecodeRequest(Socket clientSocket)
        {
            Encoding _charEncoder = Encoding.UTF8;
            var receivedBufferlen = 0;
            var buffer = new byte[1024];
            try
            {
                receivedBufferlen = clientSocket.Receive(buffer);
            }
            catch (Exception)
            {

                Thread.Yield();

            }
            return _charEncoder.GetString(buffer, 0, receivedBufferlen);
        }
    }
}
