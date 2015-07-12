using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
namespace OperatorOverloading.FileFectcher
{
    public class FileFetch
    {   public string baseUrl = System.Configuration.ConfigurationManager.AppSettings["baseUrl"];

        public string FileFectcher()
        {   //Fetching the file into a string
            Console.WriteLine(baseUrl);
            if (File.Exists(baseUrl))
            {
                string jsonFile = File.ReadAllText(baseUrl);
                return jsonFile;
            }
            throw new FileNotFoundException(Messages.FileNotFound);
        }
    }
}