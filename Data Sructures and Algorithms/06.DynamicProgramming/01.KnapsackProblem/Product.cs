namespace _01.KnapsackProblem
{
    using System;
    using System.Linq;

    public class Product
    {
        private string name;

        private int cost;

        private int weight;

        public Product(string name, int weight, int cost)
        {
            this.Name = name;
            this.Cost = cost;
            this.Weight = weight;
        }

        public int Weight
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


        public int Cost
        {
            get 
            { 
                return this.cost; 
            }
            
            private set 
            { 
                this.cost = value; 
            }
        }


        public string Name
        {
            get 
            { 
                return this.name;
            }
            
            private set 
            { 
                this.name = value; 
            }
        }
        
    }
}
