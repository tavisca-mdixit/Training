using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    class Factory_Handler
    {
        private List<string> _knownExtensions = new List<string> { ".html", ".htm", ".css", ".js", ".txt", ".ico" };


        public IProcessor CreateHandler(string url, Socket clientSocket, string contentPath)
        {
            IProcessor requestProcessor = null;
            string pageExtension = GetExtensionFromUrl(url);

            
            if (_knownExtensions.Contains(pageExtension))
            {
                switch (pageExtension)
                {

                    case ".html":
                        requestProcessor = new TextRequestHandler(clientSocket, contentPath);
                        break;
                    case ".htm":
                        requestProcessor = new TextRequestHandler(clientSocket, contentPath);
                        break;
                    case ".css":
                        requestProcessor = new TextRequestHandler(clientSocket, contentPath);
                        break;
                    case ".js":
                        requestProcessor = new TextRequestHandler(clientSocket, contentPath);
                        break;
                    case ".txt":
                        requestProcessor = new TextRequestHandler(clientSocket, contentPath);
                        break;
                    default:
                        requestProcessor = new NotFoundHandler(clientSocket);
                        break;
                }
            }
            else
            {
                requestProcessor = new InternalErrorHandler(clientSocket);
            }
            return requestProcessor;
        }

        private string GetExtensionFromUrl(string url)
        {
            return url.Substring(url.LastIndexOf('.'));
        }

    }
}
