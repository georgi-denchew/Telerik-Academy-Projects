using System;
namespace _01.MobilePhoneInfo
{
    public class Battery
    {
        private string model;
        private int hoursIdle;
        private int hoursTalk;

        public Battery()
        {
            this.model = "ASD-1C-P800";
            this.hoursIdle = 710;
            this.hoursTalk = 18;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int HoursIdle
        {
            get { return this.hoursIdle; }
            set { this.hoursIdle = value; }
        }

        public int HoursTalk
        {
            get { return this.hoursTalk; }
            set { this.hoursTalk = value; }
        }
    }
}
