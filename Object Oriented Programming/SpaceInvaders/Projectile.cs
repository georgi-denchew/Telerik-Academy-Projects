using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    public class Projectile : MovingObject
    {
        public Projectile(MatrixPosition topLeft, MatrixPosition speed)
            : base(topLeft, new char[,] { { '|' } }, speed)
        {

        }
    }
}
