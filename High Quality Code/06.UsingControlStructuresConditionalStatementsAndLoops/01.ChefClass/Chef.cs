namespace _01.ChefClass
{
    public class Chef
    {
        public void Cook()
        {
            Bowl bowl;
            bowl = this.GetBowl();

            Potato potato = this.GetPotato();
            this.Peel(potato);
            this.Cut(potato);
            bowl.Add(potato);

            Carrot carrot = this.GetCarrot();
            this.Peel(carrot);
            this.Cut(carrot);
            bowl.Add(carrot);
        }

        private Bowl GetBowl()
        {
            return new Bowl(3);
        }

        private Carrot GetCarrot()
        {
            return new Carrot(0.2m);
        }

        private Potato GetPotato()
        {
            return new Potato(0.3m);
        }

        private void Cut(Vegetable vegetable)
        {
            vegetable.Cut();
        }

        private void Peel(Vegetable vegetable)
        {
            vegetable.Peel();
        }
    }
}