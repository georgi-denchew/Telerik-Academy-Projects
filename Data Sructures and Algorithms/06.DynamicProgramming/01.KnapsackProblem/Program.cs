namespace _01.KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main(string[] args)
        {
            int n = 6;            
            int weightCapacity = 10;

            Product[] products = new Product[n];

            products[0] = new Product("beer", 3, 2);
            products[1] = new Product("vodka", 8, 12);
            products[2] = new Product("cheese", 4, 5);
            products[3] = new Product("nuts", 1, 4);
            products[4] = new Product("ham", 2, 3);
            products[5] = new Product("whiskey", 8, 13);

            List<Product> result = KnapsackSolver(products, weightCapacity);

            int totalWeight = 0;
            int totalCost = 0;
            StringBuilder resultNames = new StringBuilder();

            foreach (var product in result)
            {
                totalWeight += product.Weight;
                totalCost += product.Cost;
                resultNames.Append(string.Format("{0} + ", product.Name));
            }

            resultNames.Length -= 3;

            StringBuilder output = new StringBuilder();
            output.AppendLine("Optimal solution:");
            output.AppendLine(resultNames.ToString());
            output.AppendLine(string.Format("weight = {0}", totalWeight));
            output.AppendLine(string.Format("cost = {0}", totalCost));

            Console.WriteLine(output.ToString());
        }

        private static List<Product> KnapsackSolver(Product[] products, int weightCapacity)
        {
            if (weightCapacity == 0 || products.Length == 0)
            {
                return new List<Product>();
            }

            int[,] values = new int[products.Length, weightCapacity + 1];

            int[,] stored = new int[products.Length, weightCapacity + 1];


            for (int i = 0; i <= products.Length - 1; i++)
            {
                values[i, 0] = 0;
                stored[i, 0] = 0;
            }

            for (int j = 1; j <= weightCapacity; j++)
            {
                if (products[0].Weight <= j)
                {
                    values[0, j] = products[0].Cost;
                    stored[0, j] = 1;
                }
                else
                {
                    values[0, j] = 0;
                    stored[0, j] = 0;
                }
            }

            for (int i = 0; i <= products.Length - 2; i++)
            {
                for (int j = 1; j <= weightCapacity; j++)
                {
                    Product currentProduct = products[i + 1];

                    if (currentProduct.Weight > j)
                    {
                        values[i + 1, j] = values[i, j];

                        continue;
                    }

                    int removeValue = values[i, j];
                    int addValue = values[i, j - currentProduct.Weight] + currentProduct.Cost;

                    if (addValue > removeValue)
                    {
                        values[i + 1, j] = addValue;
                        stored[i + 1, j] = 1;
                    }
                    else
                    {
                        values[i + 1, j] = removeValue;
                        stored[i + 1, j] = 0;
                    }
                }
            }

            List<Product> optimalResult = new List<Product>();
            {
                int remainingCapacity = weightCapacity;
                int productIndex = products.Length - 1;

                while (productIndex >= 0 && remainingCapacity >= 0)
                {
                    if (stored[productIndex, remainingCapacity] == 1)
                    {
                        optimalResult.Add(products[productIndex]);
                        remainingCapacity -= products[productIndex].Weight;
                    }

                    productIndex--;
                }
            }

            return optimalResult;
        }
    }
}
