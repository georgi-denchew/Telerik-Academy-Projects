using System;

namespace MatrixRefactoring
{
    public class DirectionChanger
    {
        private Direction direction;
        public DirectionChanger(Direction direction)
        {
            this.Direction = direction;
        }

        public int Row { get; private set; }
        public int Col { get; private set; }

        public Direction Direction
        {
            get
            {
                return this.direction;
            }
            protected set
            {
                this.direction = value;

                switch (value)
                {
                    case Direction.BottomRight:
                        {
                            this.Row = 1;
                            this.Col = 1;
                            break;
                        }
                    case Direction.Bottom:
                        {
                            this.Row = 1;
                            this.Col = 0;
                            break;
                        }
                    case Direction.BottomLeft:
                        {
                            this.Row = 1;
                            this.Col = -1;
                            break;
                        }
                    case Direction.Left:
                        {
                            this.Row = 0;
                            this.Col = -1;
                            break;
                        }
                    case Direction.TopLeft:
                        {
                            this.Row = -1;
                            this.Col = -1;
                            break;
                        }
                    case Direction.Top:
                        {
                            this.Row = -1;
                            this.Col = 0;
                            break;
                        }
                    case Direction.TopRight:
                        {
                            this.Row = -1;
                            this.Col = 1;
                            break;
                        }
                    case Direction.Right:
                        {
                            this.Row = 0;
                            this.Col = 1;
                            break;
                        }
                }
            }
        }

        public void ChangeDirection()
        {
            if ((int)this.Direction == Enum.GetValues(typeof(Direction)).Length)
            {
                this.Direction = MatrixRefactoring.Direction.BottomRight;
            }
            else
            {
                this.Direction++;
            }
        }
    }
}
