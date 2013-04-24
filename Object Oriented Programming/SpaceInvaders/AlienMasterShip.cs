using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    public class AlienMasterShip: AlienShip
    {
         public bool IsShooting { get; set; }

        public AlienShip(MatrixPosition topLeft, MatrixPosition speed)
            : base(topLeft, new char[,] { { '@' } }, speed)
        {
            this.framesPerMove = 27;
        }
    }
}

       
