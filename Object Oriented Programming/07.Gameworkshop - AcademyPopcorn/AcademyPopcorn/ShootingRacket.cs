using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ShootingRacket : Racket
    {
        private bool toShoot = false;
        

        public ShootingRacket(MatrixCoords topleft, int width)
            : base(topleft, width)
        {
        }

        public void Shoot()
        {
            this.toShoot = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> producedObjects = new List<GameObject>();
            
            if (toShoot)
            {
                producedObjects.Add(new Bullet(new MatrixCoords(this.GetTopLeft().Row, this.GetTopLeft().Col + (this.Width / 2))));
                this.toShoot = false;
            }

            return producedObjects;
        }
    }
}
