using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
namespace _07.GSMTest
{
    //Write a class GSMTest to test the GSM class:
    //Create an array of few instances of the GSM class.
    //Display the information about the GSMs in the array.
    //Display the information about the static property IPhone4S.

    class Specifications
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            
            Battery galaxyBattery = new Battery(BatteryType.LiIon, 710, 18);
            Display galaxyDisplay = new Display(4.3M, 16000000);
            GSM galaxySII = new GSM("Samsung", "GalaxySI", 400, "bai shile", galaxyBattery, galaxyDisplay);
            
            Battery htcOneBattery = new Battery(BatteryType.NiCd, 1000, 30);
            Display htcOneDisplay = new Display(4.8M, 18000000);
            GSM htcOne = new GSM("htc", "One", 600, "bash bai shile", htcOneBattery, htcOneDisplay);
            
            Battery nokia3310Battery = new Battery(BatteryType.NiMH, 1000000, 1000);
            Display nokia3310Display = new Display(0.5M, 2);
            GSM nokia3310 = new GSM("nokia", "3310", 10, "bai shile iok para", nokia3310Battery, nokia3310Display);

            GSM[] phones = { galaxySII, htcOne, nokia3310 };

            foreach (GSM phone in phones)
            {
                Console.WriteLine(phone.ToString());
                Console.WriteLine();
            }
            Console.WriteLine(GSM.IPhone4S);
        }
    }
}
