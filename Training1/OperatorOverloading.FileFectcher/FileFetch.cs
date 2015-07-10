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
        {
            string jsonFile = File.ReadAllText("C:/Users/mdixit/Desktop/json.txt");
            return jsonFile;
        }
    }
}