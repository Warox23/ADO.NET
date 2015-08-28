using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Diagnostics;

namespace ConsoleApplication10
{
       
    class Program
    {        
        static void Main(string[] args)
        {

            Items itms = (Items) new XmlManager().Deserializable(typeof(Items), "qwe.xml");


            AdoNetishche w = new AdoNetishche();
            w.addElemet("DbConnect", itms);
          //  w.TestPoolConnectionn("DbConnect");

       //     Stopwatch sWatch = new Stopwatch();

          
                using (var db = new ItemContext())
                {
                    db.Items.First();
                }


            Console.WriteLine("Succes!");
            Console.Read();

        }
    }


   

}