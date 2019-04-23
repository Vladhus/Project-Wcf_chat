using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ChatHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(wcf_chat2.ServiceChat)))
            {
                host.Open();
                Console.WriteLine("host is working now!");
                Console.ReadLine();
            }
        }
    }
}
