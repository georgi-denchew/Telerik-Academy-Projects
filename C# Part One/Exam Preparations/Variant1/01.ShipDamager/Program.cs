using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ShipDamager
{
    class Program
    {
        static void Main(string[] args)
        {
            int sx1 = int.Parse(Console.ReadLine());
            int sy1 = int.Parse(Console.ReadLine());
            int sx2 = int.Parse(Console.ReadLine());
            int sy2 = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            int cx1 = int.Parse(Console.ReadLine());
            int cy1 = int.Parse(Console.ReadLine());
            int cx2 = int.Parse(Console.ReadLine());
            int cy2 = int.Parse(Console.ReadLine());
            int cx3 = int.Parse(Console.ReadLine());
            int cy3 = int.Parse(Console.ReadLine());
            int cy1shot = (h - cy1) + h;
            int cy2shot = (h - cy2) + h;
            int cy3shot = (h - cy3) + h;
            int damage = 0;

            if (cx1 > Math.Min(sx1, sx2) && cx1 < Math.Max(sx1, sx2) && cy1shot > Math.Min(sy1, sy2) && cy1shot < Math.Max(sy1, sy2))
            {
                damage += 100;
            }

            if (cx2 > Math.Min(sx1, sx2) && cx2 < Math.Max(sx1, sx2) && cy2shot > Math.Min(sy1, sy2) && cy2shot < Math.Max(sy1, sy2))
            {
                damage += 100;
            }

            if (cx3 > Math.Min(sx1, sx2) && cx3 < Math.Max(sx1, sx2) && cy3shot > Math.Min(sy1, sy2) && cy3shot < Math.Max(sy1, sy2))
            {
                damage += 100;
            }

            if ((cx1 == sx1 || cx1 == sx2) && cy1shot > Math.Min(sy1, sy2) && cy1shot < Math.Max(sy1, sy2) || (cx1 > Math.Min(sx2, sx1) && cx1 < Math.Max(sx1, sx2) && (cy1shot == sy1 || cy1shot == sy2)))
            {
                damage += 50;
            }

            if ((cx2 == sx1 || cx2 == sx2) && cy2shot > Math.Min(sy1, sy2) && cy2shot < Math.Max(sy1, sy2) || (cx2 > Math.Min(sx2, sx1) && cx2 < Math.Max(sx1, sx2) && (cy2shot == sy1 || cy2shot == sy2)))
            {
                damage += 50;
            }

            if ((cx3 == sx1 || cx3 == sx2) && cy3shot > Math.Min(sy1, sy2) && cy3shot < Math.Max(sy1, sy2) || (cx3 > Math.Min(sx2, sx1) && cx3 < Math.Max(sx1, sx2) && (cy3shot == sy1 || cy3shot == sy2)))
            {
                damage += 50;
            }

            if ((cx1 == sx1 || cx1 == sx2) && (cy1shot == sy1 || cy1shot == sy2))
            {
                damage += 25;
            }

            if ((cx2 == sx1 || cx2 == sx2) && (cy2shot == sy1 || cy2shot == sy2))
            {
                damage += 25;
            }

            if ((cx3 == sx1 || cx3 == sx2) && (cy3shot == sy1 || cy3shot == sy2))
            {
                damage += 25;
            }

            Console.WriteLine(damage + "%");
        }
    }
}
