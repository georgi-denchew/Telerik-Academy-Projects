using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class UnstoppableBall : Ball
    {
        public UnstoppableBall(MatrixCoords topleft, MatrixCoords speed)
            : base(topleft, speed)
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" || otherCollisionGroupString == "unpassableBlock";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            
            if ((collisionData.hitObjectsCollisionGroupStrings.Exists(x => x == "unpassableBlock")) ||
                (collisionData.hitObjectsCollisionGroupStrings.Exists(x => x == "racket"))
                || (collisionData.hitObjectsCollisionGroupStrings.Exists(x => x == "indestructibleBlock")))
            {
                if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
                {
                    this.Speed.Row *= -1;
                }
                if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
                {
                    this.Speed.Col *= -1;
                }
            }
        }
    }
}
