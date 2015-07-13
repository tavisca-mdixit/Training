using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace OperatorOverloading.GetJson
{
    public class GetFile
    {   ///Function to get json fromat text into a string
        public static string Get()
        {   //Fetching the file into a string through api.config
            string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
            if (File.Exists(baseUrl))
            {
                string jsonFile = File.ReadAllText(baseUrl);
                return jsonFile;
            }
            throw new FileNotFoundException(Messages.FileNotFound);
        }
    }
}