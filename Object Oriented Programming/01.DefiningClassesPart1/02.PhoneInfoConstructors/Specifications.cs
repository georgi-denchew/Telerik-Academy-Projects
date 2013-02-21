using System;
using System.Threading;
using System.Globalization;

namespace _02.PhoneInfoConstructors
{
    //Define several constructors for the defined classes that take different sets of arguments 
    //(the full information for the class or part of it). Assume that model and manufacturer are mandatory 
    //(the others are optional). All unknown data fill with null.

    class Specifications
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string manifacturer = "Samsung";
            string model = "Galaxy SII";
            string owner = "Bai Shile";
            decimal price = 400;
            string batteryModel = "ASD-1M";
            int hoursIdle = 710;
            int hoursTalk = 18;
            decimal displaySize = 4.3M;
            int displayColors = 16000000;
            GSM phone = new GSM(manifacturer, model);
            //GSM phone = new GSM(manifacturer, model, price, owner);
            //GSM phone = new GSM(manifacturer, model, price, owner, batteryType, displaySize);
           // GSM phone = new GSM(manifacturer, model, price, owner, batteryModel, hoursIdle, hoursTalk, displaySize, displayColors);
            Console.WriteLine("Phone specifications:");
            Console.WriteLine("Phone model: {0}", phone.Model);
            Console.WriteLine("Phone manifacturer: {0}", phone.Manifacturer);
            Console.WriteLine("Phone price: {0:C}", phone.Price);
            Console.WriteLine("Phone owner: {0}", phone.Owner);
            Console.WriteLine();
            Console.WriteLine("Battery specifications:");
            Console.WriteLine("Battery model: {0}", phone.battery.Model);
            Console.WriteLine("Hours idle: {0}", phone.battery.HoursIdle);
            Console.WriteLine("Hours talk: {0}", phone.battery.HoursTalk);
            Console.WriteLine();
            Console.WriteLine("Display specifications:");
            Console.WriteLine("Display size: {0}", phone.display.Size);
            Console.WriteLine("Number of colors: {0}", phone.display.Colors);
        }
    }
}
