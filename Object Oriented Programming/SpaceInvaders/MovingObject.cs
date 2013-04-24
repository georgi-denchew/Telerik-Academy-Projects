using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    public class MovingObject : GameObject
    {
        protected int framesPerMove;
        private int currentFrame;

        public MatrixPosition Speed { get; protected set; }

        public MovingObject(MatrixPosition topLeft, char[,] image, MatrixPosition speed)
            : base(topLeft, image)
        {
            this.currentFrame = 0;
            this.framesPerMove = 1;
            this.Speed = speed;
        }

        protected virtual void UpdatePosition()
        {
            this.currentFrame++;
            if (this.currentFrame == this.framesPerMove)
            {
                this.TopLeft += this.Speed;
                this.currentFrame = 0;
            }
            //this.TopLeft += this.Speed;
        }

        public override void Update()
        {
            this.UpdatePosition();
        }
    }
}
