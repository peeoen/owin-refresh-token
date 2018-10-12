using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefreshToken
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9011/";

            // Start OWIN host 
            //WebApp.Start<Startup>(url: baseAddress);
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.ReadLine();
            }
   
            
        }
    }
}
