using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
namespace operatorOverloading
{
    public class Converter
    {
       public double fetch(){
          
string contents = File.ReadAllText("C:/Users/mdixit/Desktop/json.txt");
 //Dictionary<string,string> dictionary =
 // new Dictionary<string, string>();
         
        string[] arr = contents.Split(',');
           bool found;
           string check = "USDINR";
           
           string[] arr1;
           foreach (string i in arr)
           {
               if (i.Contains(check))
               {
                   found = true;
                   if (found)
                   {
                       arr1 = i.Split(':');
                       Console.WriteLine("{0} {1}", arr1[0], arr1[1]);
                       ///     dictionary.Add(arr1[0], arr1[1]);

                       double val = Convert.ToDouble(arr1[1]);
                       //   Console.WriteLine("{0}",val);
                       return val;
                   }
               }
              
           }
           Console.ReadLine();
                   return -1;
               
          
       
}
    }
}
/*Converter obj = new Converter();
                var rate = obj.fetch();
                Console.WriteLine("The COnverted Amount is :{0}", rate * moneyThree.Amount);*/