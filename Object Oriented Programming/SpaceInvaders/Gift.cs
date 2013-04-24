using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    public class Gift : MovingObject
    {
        public Gift(MatrixPosition topLeft, MatrixPosition speed)
            : base(topLeft, new char[,] image, speed)
        {
            this.framesPerMove = 5;
            
        }

        public override void RespondToCollision(CollisionType collisionType)
        {
           
            if (collisionType == CollisionType.Destruction)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
