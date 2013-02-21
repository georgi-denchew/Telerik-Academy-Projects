using System;
using System.Threading;
using System.Globalization;

namespace _03.BatteryTypeEnumeration
{
    //Add an enumeration BatteryType (Li-Ion, NiMH, NiCd, …) and use it as a new field for the batteries.

    class Specifications
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");   
            Battery battery = new Battery(BatteryType.LiIon, 600, 10);
            Display display = new Display(2, 172385);            
            string manifacturer = "Samsung";
            string model = "Galaxy SII";
            decimal? price = 400;
            string owner = "Krali Marko";
            GSM phone = new GSM(manifacturer, model, price, owner, battery, display);
            Console.WriteLine("Phone specifications:");
            Console.WriteLine("Phone manifacturer: {0}", phone.Manifacturer);
            Console.WriteLine("Phone model: {0}", phone.Model);
            Console.WriteLine("Phone price: {0:C}", phone.Price);
            Console.WriteLine("Phone owner: {0}", phone.Owner);
            Console.WriteLine();
            Console.WriteLine("Battery specifications:");
            Console.WriteLine("Battery model: {0}", phone.battery.BattModel);
            Console.WriteLine("Hours idle: {0}", phone.battery.HoursIdle);
            Console.WriteLine("Hours talk: {0}", phone.battery.HoursTalk);
            Console.WriteLine();
            Console.WriteLine("Display specifications:");
            Console.WriteLine("Display colors: {0}",phone.display.Colors);
            Console.WriteLine("Display size: {0}", phone.display.Size);
        }
    }
}
