using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    public class Wall : GameObject
    {
        public Wall(MatrixPosition topLeft)
            : base(topLeft, new char[,] { { '#' } })
        {

        }

        public override void Update()
        {
            //Do nothing
        }
    }
}
