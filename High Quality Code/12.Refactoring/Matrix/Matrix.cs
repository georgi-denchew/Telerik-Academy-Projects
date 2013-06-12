using System;
using System.Text;

namespace MatrixRefactoring
{

    // I don't think there's any need for comments - I hope the variables "speak for themselves"

    public class Matrix
    {
        private Position currentPosition = new Position(0, 0);
        private DirectionChanger currentDirection = new DirectionChanger(Direction.BottomRight);
        private DirectionChanger[] allDirections = new DirectionChanger[Enum.GetValues(typeof(Direction)).Length];
        private int[,] matrix;
        private int currentCellValue = 1;

        public Matrix(int matrixSize)
        {
            if (matrixSize < 1 || matrixSize > 100)
            {
                throw new ArgumentOutOfRangeException("Matrix size should be between 1 and 100");
            }

            this.matrix = new int[matrixSize, matrixSize];

            CreateMatrix();

            CreateDirections();
        }

        private void CreateDirections()
        {
            for (int i = 0; i < Enum.GetValues(typeof(Direction)).Length; i++)
            {
                this.allDirections[i] = new DirectionChanger((Direction)i);
            }
        }

        private void CreateMatrix()
        {
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    this.matrix[i, j] = 0;
                }
            }
        }

        public void FillMatrix()
        {
            while (true)
            {
                this.matrix[this.currentPosition.Row, this.currentPosition.Col] = this.currentCellValue;

                if (!this.IsNextMovementValid())
                {
                    bool emptyCellFound = this.FindEmptyCellPosition(out this.currentPosition);

                    if (emptyCellFound)
                    {
                        currentCellValue++;
                        this.matrix[this.currentPosition.Row, this.currentPosition.Col] = currentCellValue;
                        this.currentDirection = new DirectionChanger(Direction.BottomRight);
                    }
                    else
                    {
                        break;
                    }
                }

                while (!this.IsAvailablePosition(this.currentPosition.Row + this.currentDirection.Row,
                    this.currentPosition.Col + this.currentDirection.Col))
                {
                    this.currentDirection.ChangeDirection();
                }

                this.currentPosition.UpdatePosition(this.currentDirection);
                this.currentCellValue++;
            }
        }


        private bool IsAvailablePosition(int row, int col)
        {
            bool isValidRow = 0 <= row && row < this.matrix.GetLength(0);
            bool isValidCol = 0 <= col && col < this.matrix.GetLength(1);

            return isValidRow && isValidCol && this.matrix[row, col] == 0;
        }

        private bool IsNextMovementValid()
        {
            for (int i = 0; i < allDirections.Length; i++)
            {
                if (this.IsAvailablePosition(this.currentPosition.Row + allDirections[i].Row,
                    this.currentPosition.Col + allDirections[i].Col))
                {
                    return true;
                }
            }

            return false;
        }

        private bool FindEmptyCellPosition(out Position position)
        {
            position = new Position(0, 0);

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    if (this.matrix[i, j] == 0)
                    {
                        position.Row = i;
                        position.Col = j;
                        return true;
                    }
                }
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    result.AppendFormat("{0, 3}", this.matrix[i, j]);
                }

                result.Append("\r\n");
            }

            result.Remove(result.Length - 2, 2);

            return result.ToString();
        }
    }
}