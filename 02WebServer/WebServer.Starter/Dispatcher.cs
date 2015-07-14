using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebServer;
using System.Configuration;
namespace WebServer
{
    public class RequestDispatcher
    {

        private Socket _clientSocket = null;
        private static Factory_Handler factoryHandler = new Factory_Handler();
        public RequestDispatcher(Socket clientSocket)
        {
            _clientSocket = clientSocket;
        }
        public void HandleClient()
        {
            var parseRequest = new ParseRequest();
            string requestString = DecodeRequest(_clientSocket);
            if (string.IsNullOrWhiteSpace(requestString) == false)
            {
                parseRequest.Parser(requestString);
                Console.WriteLine(parseRequest.HttpUrl);
                int dotIndex = parseRequest.HttpUrl.LastIndexOf('.') + 1;
                if (dotIndex > 0)
                {

                    var requestHandler = factoryHandler.CreateHandler(parseRequest.HttpUrl, _clientSocket, ConfigurationManager.AppSettings["Path"]);

                    if (parseRequest.HttpMethod.Equals("get", StringComparison.InvariantCultureIgnoreCase))
                    {

                        requestHandler.DoGet(parseRequest.HttpUrl);
                    }
                    else
                    {
                        Console.WriteLine("unimplemented methode");
                        Console.ReadLine();
                    }
                }
                else
                {
                    TextRequestHandler htmlRequestHandler = new TextRequestHandler(_clientSocket, ConfigurationManager.AppSettings["Path"]);
                    htmlRequestHandler.DoGet(parseRequest.HttpUrl);
                }
            }
            StopClientSocket(_clientSocket);  //closes the connection
        }

        public void StopClientSocket(Socket clientSocket)
        {
            if (clientSocket != null)
                clientSocket.Close();
        }

        private string DecodeRequest(Socket clientSocket)
        {
            Encoding _charEncoder = Encoding.UTF8;
            var receivedBufferlen = 0;
            var buffer = new byte[10240];
            try
            {
                receivedBufferlen = clientSocket.Receive(buffer);
            }
            catch (Exception)
            {
                Console.ReadLine();
            }
            return _charEncoder.GetString(buffer, 0, receivedBufferlen);
        }
    }
}
