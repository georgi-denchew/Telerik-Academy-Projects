using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace _12.GSMCallHistoryTest
{
    class Program
    {
        static long maxLength = long.MinValue;
        static Call longest;
        static void Main(string[] args)
        {

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Battery batteryGalaxy = new Battery(BatteryType.LiIon, 710, 20);
            Display displayGalaxy = new Display(4.3M, 16000000);
            
            DateTime dateOne = new DateTime(2013, 02, 20, 11, 11, 12);
            Call callOne = new Call(dateOne, "0899111111", 71);
            
            GSM galaxy = new GSM("samsung", "galaxySII", 400, "bai shile", batteryGalaxy, displayGalaxy, callOne);
            
            DateTime dateTwo = new DateTime(2013, 02, 21, 12, 12, 12);
            Call callTwo = new Call(dateTwo, "0899222222", 50);
            
            DateTime dateThree = new DateTime(2013, 02, 22, 13, 13, 13);
            Call callThree = new Call(dateThree, "0899333333", 100);

            GSM.AddCall(callTwo);
            GSM.AddCall(callThree);

            foreach (Call call in GSM.CallHistory)
            {
                Console.WriteLine("Call time: {0}", call.Datetime);
                Console.WriteLine("Call number: {0}", call.Number);
                Console.WriteLine("Call duration: {0}", call.Duration);
                Console.WriteLine();
            }

            Console.WriteLine("{0:C}", GSM.CallsPrice(0.37M));
            Console.WriteLine();

            foreach (Call call in GSM.CallHistory)
            {
                if (call.Duration > maxLength)
                {
                    maxLength = call.Duration;
                    longest = call;
                }
            }

            GSM.DeleteCall(longest);
            Console.WriteLine("{0:C}", GSM.CallsPrice(0.37M));
            Console.WriteLine();

            GSM.ClearCallHistory();
            Console.WriteLine("{0:C}", GSM.CallsPrice(0.37M));
        }
    }
}
