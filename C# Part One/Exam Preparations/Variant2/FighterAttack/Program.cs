using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FighterAttack
{
    class Program
    {
        static void Main(string[] args)
        {
            int px1 = int.Parse(Console.ReadLine());
            int py1 = int.Parse(Console.ReadLine());
            int px2 = int.Parse(Console.ReadLine());
            int py2 = int.Parse(Console.ReadLine());
            int fx = int.Parse(Console.ReadLine());
            int fy = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int hitX = fx + d;
            int hitY = fy;
            int damage = 0;

            if (((hitX >= px1 && hitX <= px2) || (hitX <= px1 && hitX >= px2)) &&
                ( (hitY >= py1 && hitY <= py2) || (hitY >= py2 && hitY <= py1)))
            {
                damage += 100;
            }
            if (((hitX + 1 >= px1 && hitX + 1 <= px2) || (hitX + 1 <= px1 && hitX + 1 >= px2)) &&
                ((hitY >= py1 && hitY <= py2) || (hitY >= py2 && hitY <= py1)))
            {
                damage += 75;
            }

            if (((hitX >= px1 && hitX <= px2) || (hitX <= px1 && hitX >= px2)) &&
                ((hitY + 1 >= py1 && hitY + 1 <= py2) || (hitY + 1 >= py2 && hitY + 1 <= py1)))
            {
                damage += 50;
            }

            if (((hitX >= px1 && hitX <= px2) || (hitX <= px1 && hitX >= px2)) &&
                ((hitY - 1 >= py1 && hitY - 1 <= py2) || (hitY - 1 >= py2 && hitY - 1 <= py1)))
            {
                damage += 50;
            }

            Console.WriteLine(damage);
        }
    }
}
