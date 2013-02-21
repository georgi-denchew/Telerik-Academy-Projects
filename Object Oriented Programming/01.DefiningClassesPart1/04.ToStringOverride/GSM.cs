using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ToStringOverride
{
    public class GSM
    {
        public Battery battery = new Battery(BatteryType.LiIon, 710, 18);
        public Display display = new Display(4.3M, 16000000);
        private string model;
        private string manifacturer;
        private decimal? price;
        private string owner;


        public GSM(string manifacturer, string model, decimal? price, string owner, Battery battery, Display display)
        {
            this.manifacturer = manifacturer;
            this.model = model;
            this.price = price;
            this.owner = owner;
            this.battery.BattModel = battery.BattModel;
            this.battery.HoursIdle = battery.HoursIdle;
            this.battery.HoursTalk = battery.HoursTalk;
            this.display.Size = display.Size;
            this.display.Colors = display.Colors;
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
            set { this.price = value; }
        }

        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public override string ToString()
        {
            StringBuilder infoBuild = new StringBuilder();
            infoBuild.AppendLine(manifacturer);
            infoBuild.AppendLine(model);
            infoBuild.AppendLine(price.ToString());
            infoBuild.AppendLine(owner);
            infoBuild.AppendLine(battery.BattModel.ToString());
            infoBuild.AppendLine(battery.HoursIdle.ToString());
            infoBuild.AppendLine(display.Colors.ToString());
            infoBuild.AppendLine(display.Size.ToString());
            string info = infoBuild.ToString();
            return info.Trim();
        }
        
    }
}
