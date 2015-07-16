using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    class NotFoundHandler : IProcessor
    {

        RegistryKey registryKey = Registry.ClassesRoot;
        private Socket _clientSocket = null;
        private Encoding _charEncoder = Encoding.UTF8;


        public NotFoundHandler(Socket clientSocket)
        {
            _clientSocket = clientSocket;
        }

        private void SendResponse(Socket clientSocket, byte[] byteContent, string responseCode, string contentType)
        {
            try
            {
                byte[] byteHeader = CreateHeader(responseCode, byteContent.Length, contentType);
                clientSocket.Send(byteHeader);
                clientSocket.Send(byteContent);
                clientSocket.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private byte[] CreateHeader(string responseCode, int contentLength, string contentType)
        {
            return _charEncoder.GetBytes("HTTP/1.1 " + responseCode + "\r\n"
                                  + "Server: Simple Web Server\r\n"
                                  + "Content-Length: " + contentLength + "\r\n"
                                  + "Connection: close\r\n"
                                  + "Content-Type: " + contentType + "\r\n\r\n");
        }

        public void DoGet(string uri)
        {
            byte[] emptyByteArray = new byte[0];
            SendResponse(_clientSocket, emptyByteArray, "404 Internal server error", "text/html");
        }
        /// <summary>
        /// Incomplete ,, Will implement this method late On
        /// </summary>
        public void DoPost()
        {
            throw new NotImplementedException();
        }

    }
}
