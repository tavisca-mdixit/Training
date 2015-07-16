using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using WebServer.Model;
namespace WebServe.Host
{
    class Program
    {
        
            static void Main(string[] args)
        {
            try
            {
                string host = ConfigurationManager.AppSettings["webserver-host"];
                if (string.IsNullOrEmpty(host))
                    throw new Exception("Host is invalid");

                int port = 0;
                if (int.TryParse(ConfigurationManager.AppSettings["webserver-port"], out port) == false)
                    throw new Exception("Port is invalid");
                var server = new Server(host, port);
                server.Start();

                Console.WriteLine("Enter any key to exit");
                Console.ReadKey();

                server.Stop();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
