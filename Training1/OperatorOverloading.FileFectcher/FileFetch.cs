using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace OperatorOverloading.FileFectcher
{
    public class FileFetch
    {
        public string FileFectcher()
        {   //Fetching the file into a string
            if (File.Exists("C:/Users/mdixit/Desktop/json.txt"))
            {
                string jsonFile = File.ReadAllText("C:/Users/mdixit/Desktop/json.txt");
                return jsonFile;
            }
            throw new FileNotFoundException(Messages.FileNotFound);
        }
    }
}