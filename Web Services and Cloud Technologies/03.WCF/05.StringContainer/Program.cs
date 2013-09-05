using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace _05.StringContainer
{
    class Program
    {
        static void Main(string[] args)
        {

            // FIRST START TASK 03
            var counterClient = new ServiceStringContainerClient();

            var result = counterClient.PrintContainCountAsync("bla", "blablabla").Result;

            Console.WriteLine(result);
        }
    }
}
