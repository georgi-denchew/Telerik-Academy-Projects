using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.PhoneInfoConstructors
{
    public class GSM
    {
        public Battery battery = new Battery();
        public Display display = new Display();
        private string model;
        private string manifacturer;
        private decimal? price;
        private string owner;

        public GSM(string manifacturer, string model) : this(manifacturer, model, null, null, null, null, null, null, null)
        {
        }

        public GSM(string manifacturer, string model, decimal? price, string owner)
            : this(manifacturer, model, price, owner, null, null, null, null, null)
        {
        }

        public GSM(string manifacturer, string model, decimal? price, string owner, string batteryModel, decimal? displaySize) :
            this(manifacturer, model, price, owner, batteryModel, null, null, displaySize, null)
        {
        }

        public GSM(string manifacturer, string model, decimal? price, string owner, string batteryModel,
            int? hoursIdle, int? hoursTalk, decimal? displaySize, int? displayColors )
        {
            this.model = model;
            this.manifacturer = manifacturer;
            this.price = price;
            this.owner = owner;
            this.battery.Model = batteryModel;
            this.battery.HoursIdle = hoursIdle;
            this.battery.HoursTalk = hoursTalk;
            this.display.Size = displaySize;
            this.display.Colors = displayColors;
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
    }
}
