using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DayOfWeekServiceConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceDayGetterConsoleApp.ServiceDayGetterClient client = 
                new ServiceDayGetterConsoleApp.ServiceDayGetterClient();
            
            // example value
            string result = client.GetDay(DateTime.Now);
            
            Console.WriteLine(result);
        }
    }
}
