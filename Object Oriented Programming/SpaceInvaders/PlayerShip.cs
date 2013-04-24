using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    public class PlayerShip : GameObject
    {
        private bool isShooting;

        public bool IsShooting
        {
            get { return isShooting; }
            set { isShooting = value; }
        }

        public PlayerShip(MatrixPosition topLeft)
            : base(topLeft, new char[,] { { '^' } })
        {
            this.isShooting = false;
            //this.image = GetPlayerImage();
        }

        //private char[,] GetPlayerImage()
        //{
        //    return new char[,] { { '^' } };
        //}

        public void MoveLeft()
        {
            this.topLeft.Col--;
        }

        public void MoveRight()
        {
            this.topLeft.Col++;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> projectiles = new List<GameObject>();

            if (this.isShooting)
            {
                var projectile = new Projectile(this.topLeft, new MatrixPosition(-1, 0));
                projectile.Owner = ProjectileOwner.Player;
                projectiles.Add(projectile);
                this.isShooting = false;
            }

            return projectiles;
        }

        public override void Update()
        {

        }
    }
}
