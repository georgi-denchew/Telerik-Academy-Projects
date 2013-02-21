using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace _08.CallClass
{
    //Create a class Call to hold a call performed through a GSM. 
    //It should contain date, time, dialed phone number and duration (in seconds).

    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            DateTime datetime = new DateTime(2013, 02, 03, 13, 14, 15);
            Call call = new Call(datetime, "0899999999", 1234567800000000);
            Battery battery = new Battery(BatteryType.LiIon, 710, 18);
            Display display = new Display(3.4M, 16000000);
            GSM phone = new GSM("samsung", "galaxySII", 400, "pesho", battery, display, call);

            Console.WriteLine(phone.ToString());
        }
    }
}
