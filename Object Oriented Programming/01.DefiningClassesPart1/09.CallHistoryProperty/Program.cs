using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace _09.CallHistoryProperty
{
    //Add a property CallHistory in the GSM class to hold a list of the performed calls. 
    //Try to use the system class List<Call>.

    class Program
    {
        static void Main(string[] args)
        {
            DateTime galaxyDate = new DateTime(2013, 02, 20, 11, 11, 12);
            Call callGalaxy = new Call(galaxyDate, "0899111111", 12454234);
            Battery batteryGalaxy = new Battery(BatteryType.LiIon, 710, 20);
            Display displayGalaxy = new Display(4.3M, 16000000);
            GSM galaxy = new GSM("samsung", "galaxySII", 400, "bai shile", batteryGalaxy, displayGalaxy, callGalaxy);

            DateTime nokiaDate = new DateTime(2013, 02, 19, 12, 12, 12);
            Call callNokia = new Call(nokiaDate, "0899222222", 123453212345);
            Battery batteryNokia = new Battery(BatteryType.NiCd, 10000, 1000);
            Display displayNokia = new Display(0.5M, 2);
            GSM nokia = new GSM("nokia", "3310", 10, "bai shile iok para", batteryNokia, displayNokia, callNokia);

            DateTime htcDate = new DateTime(2013, 02, 22, 13, 13, 13);
            Call htcCall = new Call(htcDate, "0899333333", 12431234321234);
            Battery htcOneBattery = new Battery(BatteryType.NiCd, 1000, 30);
            Display htcOneDisplay = new Display(4.8M, 18000000);
            GSM htcOne = new GSM("htc", "One", 600, "bash bai shile", htcOneBattery, htcOneDisplay, htcCall);

            foreach (Call call in GSM.calls)
            {
                Console.WriteLine(call.Datetime);
                Console.WriteLine(call.Number);
                Console.WriteLine(call.Duration);
                Console.WriteLine();
            }
        }
    }
}
