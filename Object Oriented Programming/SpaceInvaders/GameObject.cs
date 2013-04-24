using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    public abstract class GameObject : IRenderable
    {
        protected char[,] image;
        protected MatrixPosition topLeft;

        public MatrixPosition TopLeft
        {
            get
            {
                return new MatrixPosition(topLeft.Row, topLeft.Col);
            }

            protected set
            {
                this.topLeft = new MatrixPosition(value.Row, value.Col);
            }
        }

        public bool IsDestroyed { get; protected set; }

        protected GameObject(MatrixPosition topLeft, char[,] image)
        {
            this.TopLeft = topLeft;

            int imageRows = image.GetLength(0);
            int imageCols = image.GetLength(1);

            this.image = this.CopyImageMatrix(image);

            this.IsDestroyed = false;
        }

        private char[,] CopyImageMatrix(char[,] matrixToCopy)
        {
            int rows = matrixToCopy.GetLength(0);
            int cols = matrixToCopy.GetLength(1);

            char[,] result = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = matrixToCopy[row, col];
                }
            }

            return result;
        }

        public virtual MatrixPosition GetPosition()
        {
            return this.TopLeft;
        }

        public virtual char[,] GetImage()
        {
            return this.CopyImageMatrix(this.image);
        }

        public virtual IEnumerable<GameObject> ProduceObjects()
        {
            return new List<GameObject>();
        }

        public abstract void Update();

        public virtual void RespondToCollision(CollisionType collisionType)
        {
        }
    }
}
