using System.Collections.Generic;

namespace _01.ChefClass
{
    public class Bowl
    {
        private decimal volume;
        private List<Vegetable> containedVegetables = new List<Vegetable>();

        public Bowl(decimal volume)
        {
            this.Volume = volume;
        }

        public decimal Volume
        {
            get
            {
                return this.volume;
            }

            private set
            {
                this.volume = value;
            }
        }

        public void Add(Vegetable vegetable)
        {
            containedVegetables.Add(vegetable);
        }
    }
}
