using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    public class AlienShip : MovingObject
    {
        // alien shooting added
        public bool IsShooting { get; set; }

        public AlienShip(MatrixPosition topLeft, MatrixPosition speed)
            : base(topLeft, new char[,] { { '@' } }, speed)
        {
            this.framesPerMove = 27;
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

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> projectiles = new List<GameObject>();
            if (this.IsShooting)
            {
                var projectile = new Projectile(this.topLeft, new MatrixPosition(1, 0));
                projectile.Owner = ProjectileOwner.Alien;
                projectiles.Add(projectile);
                this.IsShooting = false;
            }

            return projectiles;
        }
    }
}
