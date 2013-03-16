using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    public class AlienShip : MovingObject
    {
        public AlienShip(MatrixPosition topLeft, MatrixPosition speed)
            : base(topLeft, new char[,] { { '@' } }, speed)
        {
            this.framesPerMove = 51;
        }

        public override void RespondToCollision(CollisionType collisionType)
        {
            if (collisionType == CollisionType.Bounce)
            {
                this.Speed.Col *= -1;
            }

            if (collisionType == CollisionType.Destruction)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
