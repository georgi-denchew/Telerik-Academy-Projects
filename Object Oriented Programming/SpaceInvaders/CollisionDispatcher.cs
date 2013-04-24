using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    public static class CollisionDispatcher
    {
        public static void HandleCollisions(List<MovingObject> movingObjects, List<GameObject> staticObjects, List<MovingObject> alienShips)
        {
            foreach (var obj in movingObjects)
            {
                //handle destruction collisions (projectiles killing aliens)
                //TODO: projectiles killing player
                // projectile owner check added
                if (obj is Projectile && (obj as Projectile).Owner == ProjectileOwner.Player)
                {
                    foreach (var alien in alienShips)
                    {
                        if (obj.TopLeft.Row == alien.TopLeft.Row && obj.TopLeft.Col == alien.TopLeft.Col)
                        {
                            alien.RespondToCollision(CollisionType.Destruction);
                        }
                    }
                }
            }

            foreach (var obj in movingObjects)
            {
                //ensure aliens are bouncing off the walls
                if (obj is AlienShip)
                {
                    if (CollidesWithWall(obj, staticObjects))
                    {
                        //if one alien hits a wall, change direction for all aliens
                        ChangeAliensDirection(movingObjects);
                        break;
                    }
                }
            }
        }

        private static void ChangeAliensDirection(List<MovingObject> movingObjects)
        {
            foreach (var alien in movingObjects)
            {
                if (alien is AlienShip)
                {
                    alien.RespondToCollision(CollisionType.Bounce);
                }
            }
        }

        private static bool CollidesWithWall(MovingObject obj, List<GameObject> staticObjects)
        {
            foreach (var staticObj in staticObjects)
            {
                if (staticObj is Wall && obj.TopLeft.Row == staticObj.TopLeft.Row)
                {
                    if (obj.TopLeft.Col - 1 == staticObj.TopLeft.Col)
                    {
                        return true;
                    }
                    else
                    {
                        if (obj.TopLeft.Col + 1 == staticObj.TopLeft.Col)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
