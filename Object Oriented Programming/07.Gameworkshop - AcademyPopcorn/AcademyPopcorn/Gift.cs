using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class Gift : MovingObject
    {
        private int counter = 0;
        public Gift(MatrixCoords topleft)
            : base(topleft, new char[,] { { '$' } }, new MatrixCoords(1, 0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        protected override void UpdatePosition()
        {
            if (counter % 5 == 0)
            {
                base.UpdatePosition();
            }
            counter++;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> producedObjects = new List<GameObject>();

            if (IsDestroyed)
            {
                producedObjects.Add(new ShootingRacket(new MatrixCoords(this.GetTopLeft().Row + 1, this.GetTopLeft().Col), 6));
            }

            return producedObjects;
        }
    }
}
