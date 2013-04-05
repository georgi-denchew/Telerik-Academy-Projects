using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ExplodingBlock : Block
    {
        public ExplodingBlock(MatrixCoords topleft)
            : base(topleft)
        {
            base.body[0, 0] = 'X';
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> producedObjects = new List<GameObject>();
            if (this.IsDestroyed)
            {
                producedObjects.Add(new Explosion(this.TopLeft, new MatrixCoords(-1, 0)));
                producedObjects.Add(new Explosion(this.TopLeft, new MatrixCoords(1, 0)));
                producedObjects.Add(new Explosion(this.TopLeft, new MatrixCoords(0, 1)));
                producedObjects.Add(new Explosion(this.TopLeft, new MatrixCoords(0, -1)));
            }
            return producedObjects;
        }
    }
}
