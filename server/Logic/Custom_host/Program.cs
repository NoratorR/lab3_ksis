using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Custom_Logic;

namespace Custom_host
{
    class Program
    {
     
        static void Main(string[] args)
        {
            SetHandler handler = new SetHandler();
            handler.Signature();
            TCPServer host = new TCPServer(handler);
            host.Initializer();
            Console.WriteLine("Serer Works");
            host.Open();
            Console.ReadKey();
            host.Close();
            
        }
    }

   
}
