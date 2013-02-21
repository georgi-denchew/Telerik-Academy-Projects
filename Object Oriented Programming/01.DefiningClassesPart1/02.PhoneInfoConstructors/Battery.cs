using System;
namespace _02.PhoneInfoConstructors
{
    public class Battery
    {
        private string model;
        private int? hoursIdle;
        private int? hoursTalk;

        public Battery()
        {
            this.model = null;
            this.hoursIdle = null;
            this.hoursTalk = null;
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public int? HoursIdle
        {
            get { return this.hoursIdle; }
            set { this.hoursIdle = value; }
        }

        public int? HoursTalk
        {
            get { return this.hoursTalk; }
            set { this.hoursTalk = value; }
        }

    }
}
