using System;

namespace MatrixRefactoring
{
    public class Position
    {
        private int row;

        private int col;

        public int Row
        {
            get 
            { 
                return this.row; 
            }

            set 
            { 
                this.row = value; 
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                this.col = value;
            }
        }

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public void UpdatePosition(DirectionChanger changer)
        {
            this.Row += changer.Row;
            this.col += changer.Col;
        }

    }
}
