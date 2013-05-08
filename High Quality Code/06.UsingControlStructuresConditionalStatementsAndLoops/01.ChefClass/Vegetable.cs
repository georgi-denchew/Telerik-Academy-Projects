namespace _01.ChefClass
{
    public abstract class Vegetable
    {
        private decimal weight;
        private bool isPeeled;
        private bool isCut;
        private bool isFresh;

        public Vegetable(decimal weight)
        {
            this.Weight = weight;
            this.IsPeeled = false;
            this.IsCut = false;
            this.IsFresh = true;
        }

        public decimal Weight
        {
            get
            {
                return this.weight;
            }

            private set
            {
                this.weight = value;
            }
        }

        public bool IsCut
        {
            get
            {
                return this.isCut;
            }

            private set
            {
                this.isCut = value;
            }
        }

        public bool IsPeeled
        {
            get
            {
                return this.isPeeled;
            }

            private set
            {
                this.isPeeled = value;
            }
        }

        public bool IsFresh
        {
            get
            {
                return this.isFresh;
            }
            private set
            {
                this.isFresh = value;
            }
        }

        public void Cut()
        {
            this.IsCut = true;
        }
        
        public void Peel()
        {
            this.IsPeeled = true;
        }
    }
}
