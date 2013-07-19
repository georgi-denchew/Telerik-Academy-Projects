using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace _17.DateAfterSixHoursAndThirtyMins
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
            string input = "03.02.2013 19:37:20";
            DateTime date = DateTime.ParseExact(input, "dd.MM.yyyy HH:mm:ss", CultureInfo.CurrentCulture);
            DateTime newDate = date.AddHours(6.5);
            Console.WriteLine("{0:dddd dd.MM.yyyy HH:mm:ss}", newDate);
        }
    }
}
