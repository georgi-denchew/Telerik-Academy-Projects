namespace Methods
{
    using System;
    
    public class Methods
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("All of the sides should be positive");
            }

            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
            return area;
        }

        public static string ConvertDigitToWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Invalid digit");
            }
        }

        public static int FindMaximalElement(params int[] elements)
        {
            int maxValue = int.MinValue;

            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException(" Array is missing or is empty");
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxValue)
                {
                    maxValue = elements[i];
                }
            }

            return maxValue;
        }
                
        // Since logical cohesion is not a good practice,
        // the method PrintAsNumber was divided into three other methods
        public static void PrintAsFloatingPoint(object number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintAsPercentage(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintAsRightAlligned(object number)
        {
            Console.WriteLine("{0,8}", number);
        }

        // The method is supposed to do exactly one thing, therefore methods IsHorizontal
        // and IsVertical vere extracted as separate.
        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        public static bool IsHorizontal(double y1, double y2)
        {
            bool isHorizontal = y1 == y2;
            return isHorizontal;
        }

        public static bool IsVertical(double x1, double x2)
        {
            bool isVertical = x1 == x2;
            return isVertical;
        }

        static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));
            
            Console.WriteLine(ConvertDigitToWord(5));
            
            Console.WriteLine(FindMaximalElement(5, -1, 3, 2, 14, 2, 3));

            PrintAsFloatingPoint(1.3);
            PrintAsPercentage(0.75);
            PrintAsRightAlligned(2.30);

            Console.WriteLine(CalculateDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + IsHorizontal(-1, 2.5));
            Console.WriteLine("Vertical? " + IsVertical(3, 3));
            
            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 03, 12), "From Sofia");

            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 03), "From Vidin, gamer, high results");

            Console.WriteLine("Is {0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}