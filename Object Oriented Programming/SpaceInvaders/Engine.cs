using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    public class Engine
    {
        IRenderer renderer;
        IUserInterface userInterface;
        List<GameObject> allObjects;
        List<MovingObject> movingObjects;
        List<MovingObject> alienShips;
        List<GameObject> staticObjects;
        PlayerShip playerShip;
        int sleepTime;

        public Engine(IRenderer renderer, IUserInterface userInterface)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.alienShips = new List<MovingObject>();
            this.staticObjects = new List<GameObject>();
            this.sleepTime = 100;
        }

        public Engine(IRenderer renderer, IUserInterface userInterface, int sleepTime)
            : this(renderer, userInterface)
        {
            this.sleepTime = sleepTime;
        }

        public virtual void AddObject(GameObject newObj)
        {
            if (newObj is MovingObject)
            {
                this.AddMovingObject(newObj as MovingObject);
            }
            else
            {
                this.AddPlayer(newObj);
            }
        }

        private void AddPlayer(GameObject newObj)
        {
            this.allObjects.Remove(this.playerShip);
            this.staticObjects.Remove(this.playerShip);
            this.playerShip = newObj as PlayerShip;
            this.AddStaticObject(newObj);
        }

        private void AddStaticObject(GameObject newObj)
        {
            this.staticObjects.Add(newObj);
            this.allObjects.Add(newObj);
        }

        private void AddMovingObject(MovingObject newObj)
        {
            this.movingObjects.Add(newObj);
            if (newObj is AlienShip)
            {
                this.alienShips.Add(newObj);
            }
            this.allObjects.Add(newObj);
        }

        public virtual void MovePlayerShipLeft()
        {
            if (this.playerShip.TopLeft.Col > 1)
            {
                playerShip.MoveLeft();
            }
        }

        public virtual void MovePlayerShipRight()
        {
            if (this.playerShip.TopLeft.Col < this.renderer.GetWidth() - 2)
            {
                playerShip.MoveRight();
            }
        }

        public virtual void Shoot()
        {
            this.playerShip.IsShooting = true;
        }

        public virtual void Run()
        {
            while (true)
            {
                this.renderer.RenderAll();

                System.Threading.Thread.Sleep(this.sleepTime);
                int count = 0;
                count++;
                this.userInterface.ProcessInput();

                this.renderer.ClearQueue();

                foreach (var obj in this.allObjects)
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);
                }

                CollisionDispatcher.HandleCollisions(movingObjects, staticObjects, alienShips);

                List<GameObject> producedObjects = new List<GameObject>();

                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed);
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed);
                this.alienShips.RemoveAll(obj => obj.IsDestroyed);

                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }
            }
        }
    }
}