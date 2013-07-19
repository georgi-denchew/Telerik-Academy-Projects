using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace asd
{
    class UsedProduct
    {
        public decimal Quantity { get; set; }
        public string Measurement { get; set; }
        public string Name { get; set; }
    }

    class RecipeProduct
    {
        public decimal Quantity { get; set; }
        public string Measurement { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            List<UsedProduct> usedList = new List<UsedProduct>();
            List<RecipeProduct> recipeList = new List<RecipeProduct>();
            List<string> check = new List<string>();
            decimal recipeConverted = 0;
            decimal usedConverted = 0;
            bool MatchFound = false;
            decimal remainder = 0;
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(':');
                RecipeProduct newRecipe = new RecipeProduct();
                newRecipe.Quantity = decimal.Parse(input[0]);
                newRecipe.Measurement = input[1];
                newRecipe.Name = input[2];
                recipeList.Add(newRecipe);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().ToLower().Split(':');
                UsedProduct newUsed = new UsedProduct();
                newUsed.Quantity = decimal.Parse(input[0]);
                newUsed.Measurement = input[1];
                newUsed.Name = input[2];
                usedList.Add(newUsed);

            }
            for (int j = 0; j < recipeList.Count; j++) //foreach (RecipeProduct recipeProduct in recipeList)
            {
                RecipeProduct recipeProduct = recipeList[j];
                remainder = ConvertToMils(recipeProduct.Measurement, recipeProduct.Quantity);
                if (!check.Contains(recipeProduct.Name.ToString().ToLower()))
                {
                    for (int k = j + 1; k < recipeList.Count; k++)
                    {
                        if (string.Compare(recipeProduct.Name, recipeList[k].Name, true) == 0)
                        {
                            remainder += ConvertToMils(recipeList[k].Measurement, recipeList[k].Quantity);
                        }
                    }
                    check.Add(recipeProduct.Name.ToString().ToLower());
                }
                else
                {
                    continue;
                }


                for (int i = 0; i < usedList.Count; i++)
                {
                    if (usedList[i].Name.ToLower() == recipeProduct.Name.ToLower())
                    {
                        MatchFound = true;

                        usedConverted = ConvertToMils(usedList[i].Measurement, usedList[i].Quantity);
                        remainder = remainder - usedConverted;

                    }
                }
                if (MatchFound && remainder > 0)
                {
                    remainder = ConvertToUnit(recipeProduct.Measurement, remainder);
                    remainder = Math.Round(remainder, 2);
                    Console.WriteLine("{0:F2}:{1}:{2}", remainder, recipeProduct.Measurement, recipeProduct.Name);

                }
                if (!MatchFound)
                {
                    remainder = ConvertToUnit(recipeProduct.Measurement, remainder);
                    remainder = Math.Round(remainder, 2);
                    Console.WriteLine("{0:F2}:{1}:{2}", remainder, recipeProduct.Measurement, recipeProduct.Name);
                }
                MatchFound = false;
                remainder = 0;
            }
        }
        private static decimal ConvertToMils(string measure, decimal quantity)
        {
            switch (measure)
            {
                case "mls": return quantity;
                case "milliliters": return quantity;
                case "ls": return quantity * 1000;
                case "liters": return quantity * 1000;
                case "tbsps": return quantity * 15;
                case "tablespoons": return quantity * 15;
                case "fl ozs": return quantity * 30;
                case "fluid unces": return quantity * 30;
                case "tsps": return quantity * 5;
                case "teaspoons": return quantity * 5;
                case "gals": return quantity * 3840;
                case "gallons": return quantity * 3840;
                case "pts": return quantity * 480;
                case "pints": return quantity * 480;
                case "qts": return quantity * 960;
                case "quarts": return quantity * 960;
                case "cups": return quantity * 240;
                default: throw new ArgumentException("Invalid unit");

            }
        }
        private static decimal ConvertToUnit(string measure, decimal quantity)
        {
            switch (measure)
            {
                case "mls": return quantity;
                case "milliliters": return quantity;
                case "ls": return quantity / 1000;
                case "liters": return quantity / 1000;
                case "tbsps": return quantity / 15;
                case "tablespoons": return quantity / 15;
                case "fl ozs": return quantity / 30;
                case "fluid unces": return quantity / 30;
                case "tsps": return quantity / 5;
                case "teaspoons": return quantity / 5;
                case "gals": return quantity / 3840;
                case "gallons": return quantity / 3840;
                case "pts": return quantity / 480;
                case "pints": return quantity / 480;
                case "qts": return quantity / 960;
                case "quarts": return quantity / 960;
                case "cups": return quantity / 240;
                default: throw new ArgumentException("Invalid unit");

            }
        }
    }
}
