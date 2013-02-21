using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PriceCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime galaxyDate = new DateTime(2013, 02, 20, 11, 11, 12);
            Call callGalaxy = new Call(galaxyDate, "0899111111", 71);
            Battery batteryGalaxy = new Battery(BatteryType.LiIon, 710, 20);
            Display displayGalaxy = new Display(4.3M, 16000000);
            GSM galaxy = new GSM("samsung", "galaxySII", 400, "bai shile", batteryGalaxy, displayGalaxy, callGalaxy);

            DateTime nokiaDate = new DateTime(2013, 02, 19, 12, 12, 12);
            Call callNokia = new Call(nokiaDate, "0899222222", 269);
            Battery batteryNokia = new Battery(BatteryType.NiCd, 10000, 1000);
            Display displayNokia = new Display(0.5M, 2);
            GSM nokia = new GSM("nokia", "3310", 10, "bai shile iok para", batteryNokia, displayNokia, callNokia);

            DateTime htcDate = new DateTime(2013, 02, 22, 13, 13, 13);
            Call htcCall = new Call(htcDate, "0899333333", 1 );
            Battery htcOneBattery = new Battery(BatteryType.NiCd, 1000, 30);
            Display htcOneDisplay = new Display(4.8M, 18000000);
            GSM htcOne = new GSM("htc", "One", 600, "bash bai shile", htcOneBattery, htcOneDisplay, htcCall);


            Console.WriteLine("{0:C}",GSM.CallsPrice(0.27M));
        }
    }
}
