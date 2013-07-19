using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;



class Program
{
    static List<string> recipeProducts = new List<string>();
    static List<decimal>recipeAmount = new List<decimal>();
    static List<string> recipeOriginalUnit = new List<string>();
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int recipeProdCount = int.Parse(Console.ReadLine());
        for (int p = 0; p < recipeProdCount; p++)
        {
            string recipeLine = Console.ReadLine();
            string[] tokens = recipeLine.Split(':');
            decimal amount = decimal.Parse(tokens[0]);
            string unit = tokens[1];
            string product = tokens[2];
            AddProduct(product, amount, unit);
        }
        int addedProdCount = int.Parse(Console.ReadLine());
        for (int p = 0; p < addedProdCount; p++)
        {
            string addedLine = Console.ReadLine();
            string[] tokens = addedLine.Split(':');
            decimal amount = decimal.Parse(tokens[0]);
            string unit = tokens[1];
            string product = tokens[2];
            RemoveProduct(product, amount, unit);
        }

        for (int i = 0; i < recipeProducts.Count; i++)
        {
            if (recipeAmount[i] > 0)
            {
                Console.WriteLine("{0:F2}:{1}:{2}",ConvertToUnit(recipeOriginalUnit[i],recipeAmount[i]), recipeOriginalUnit[i], recipeProducts[i]);
            }
        }
    }
    private static void RemoveProduct(string product, decimal amount, string unit)
    {
        decimal amountMilliters = ConvertToMils(unit, amount);
        for (int p = 0; p < recipeProducts.Count; p++)
        {
            if (string.Compare(recipeProducts[p], product, true) == 0)
            {
                //product found
                recipeAmount[p] -= amountMilliters;
                return;
            }
        }
    }
    private static void AddProduct(string product, decimal amount, string unit)
    {
        decimal amountMilliters = ConvertToMils(unit, amount);
        for (int p = 0; p < recipeProducts.Count; p++)
        {
            if (string.Compare(recipeProducts[p], product, true) == 0)
            {
                recipeAmount[p] += amountMilliters;
                return;
            }
        }
        recipeProducts.Add(product);
        recipeAmount.Add(amountMilliters);
        recipeOriginalUnit.Add(unit);
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

