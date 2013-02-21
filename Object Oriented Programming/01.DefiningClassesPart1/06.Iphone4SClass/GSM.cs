using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace _06.Iphone4SClass
{
    public class GSM
    {
        public Battery battery = new Battery(BatteryType.LiIon, 710, 18);
        public Display display = new Display(4.3M, 16000000);
        private string model;
        private string manifacturer;
        private decimal? price;
        private string owner;
        private static string iPhone4S = "IPhone4S (made by Apple) is a revolutionary new product, with elegant design and is able to " +
            "perform many different operations";


        public GSM(string manifacturer, string model, decimal? price, string owner, Battery battery, Display display)
        {
            this.manifacturer = manifacturer;
            this.model = model;
            this.Price = price;
            this.owner = owner;
            this.battery.BattModel = battery.BattModel;
            this.battery.HoursIdle = battery.HoursIdle;
            this.battery.HoursTalk = battery.HoursTalk;
            this.display.Size = display.Size;
            this.display.Colors = display.Colors;
        }

        public static string IPhone4S
        {
            get { return iPhone4S; }
            set { iPhone4S = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public string Manifacturer
        {
            get { return this.manifacturer; }
            set { this.manifacturer = value; }
        }

        public decimal? Price
        {
            get { return this.price; }
            set
            {
                if (value >= 0 || value == null)
                {
                    this.price = value;
                }
                else
                {
                    try
                    {
                        throw new ArgumentException();
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Invalid price");
                        Environment.Exit(0);
                    }
                }
            }
        }

        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public override string ToString()
        {
            StringBuilder infoBuild = new StringBuilder();
            infoBuild.AppendLine(Manifacturer);
            infoBuild.AppendLine(Model);
            infoBuild.AppendLine(Price.ToString());
            infoBuild.AppendLine(Owner);
            infoBuild.AppendLine(battery.BattModel.ToString());
            infoBuild.AppendLine(battery.HoursIdle.ToString());
            infoBuild.AppendLine(display.Colors.ToString());
            infoBuild.AppendLine(display.Size.ToString());
            string info = infoBuild.ToString();
            return info.Trim();
        }
        
    }
}
