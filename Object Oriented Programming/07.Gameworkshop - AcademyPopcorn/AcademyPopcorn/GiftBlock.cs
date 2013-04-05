using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class GiftBlock : Block
    {
        public GiftBlock(MatrixCoords topleft)
            : base(topleft)
        {
            base.body[0, 0] = 'G';
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
                producedObjects.Add(new Gift(this.TopLeft));
            }
            return producedObjects;
        }
    }
}
