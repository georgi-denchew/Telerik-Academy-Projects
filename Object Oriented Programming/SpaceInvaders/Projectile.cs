using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    public enum ProjectileOwner
    {
        Player = 1, Alien = 2
    }

    public class Projectile : MovingObject
    {
        public ProjectileOwner Owner { get; set; }

        public Projectile(MatrixPosition topLeft, MatrixPosition speed)
            : base(topLeft, new char[,] { { '|' } }, speed)
        {
        }
    }
}
