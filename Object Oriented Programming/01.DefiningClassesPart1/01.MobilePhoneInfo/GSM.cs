using System;

namespace _01.MobilePhoneInfo
{
    public class GSM
    {
        public Battery battery = new Battery();
        public Display display = new Display();
        private string model;
        private string manifacturer;
        private decimal price;
        private string owner;

        public GSM()
        {
            this.model = "Galaxy SII";
            this.manifacturer = "Samsung";
            this.price = 400;
            this.owner = "Bai Pesho";

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

        public decimal Price
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
