namespace _14.LabyrinthFill
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Labyrinth
    {
        private const char UnreachabelCell = 'x';
        private const char UnreachableSymbol = 'u';
        private const char StartSymbol = '*';

        private int size;
        private int startRow;
        private int startCol;
        private int nextRow;
        private int nextCol;
        private bool[,] reachable;
        private bool[,] visited;
        private int[,] matrix;

        private Queue<int> nextRows;
        private Queue<int> nextCols;
        private Queue<int> nextValues;

        private Random rand = new Random();
        private int currentIndex;

        /// <summary>
        /// Initiates an instance of the <see cref="Labyrinth"/> class.
        /// The labyrinth has a random number of unreachable cells.
        /// </summary>
        /// <param name="size">The number of rows and columns of the labyrinth</param>
        /// <param name="startRow">Zero-based index of the row,
        /// from which the filling starts</param>
        /// <param name="startCol">Zero-based index of the column,
        /// from which the filling starts</param>
        public Labyrinth(int size, int startRow, int startCol)
        {
            if (size <= 1)
            {
                throw new ArgumentOutOfRangeException("Labyrinth size cannot be less 2",
                    new ArgumentOutOfRangeException());
            }

            if (startRow > size - 1)
            {
                throw new ArgumentOutOfRangeException(string.Format(
                    "The starting row - zero-based ({0}) cannot be larger than the labyrinth rows ({1})",
                    startRow,
                    size - 1),
                    new ArgumentOutOfRangeException());
            }

            if (startCol > size - 1)
            {
                throw new ArgumentOutOfRangeException(string.Format(
                    "The starting column - zero-based ({0}) cannot be larger than the labyrinth columns ({1})",
                    startCol,
                    size - 1),
                    new ArgumentOutOfRangeException());
            }

            this.Size = size;
            this.StartRow = startRow;
            this.StartCol = startCol;
            this.nextRow = 0;
            this.nextCol = 0;
            this.matrix = new int[this.Size, this.Size];
            this.reachable = new bool[this.Size, this.Size];
            this.visited = new bool[this.Size, this.Size];
            this.currentIndex = 0;
            this.nextRows = new Queue<int>();
            this.nextCols = new Queue<int>();
            this.nextValues = new Queue<int>();
           
            this.DetermineReachable();
        }

        public int StartCol
        {
            get 
            { 
                return this.startCol; 
            }
           
            private set 
            { 
                this.startCol = value; 
            }
        }

        public int StartRow
        {
            get 
            { 
                return this.startRow; 
            }
            
            private set 
            { 
                this.startRow = value; 
            }
        }

        public int Size
        {
            get 
            { 
                return this.size;
            }
            
            private set 
            { 
                this.size = value; 
            }
        }

        public static Labyrinth Initialize()
        {
            Console.Write("Enter size N of the labyrinth:");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Enter row of the first cell to fill:");
            int startRow = int.Parse(Console.ReadLine());

            Console.Write("Enter column of the first cell to fill:");
            int startCol = int.Parse(Console.ReadLine());

            return new Labyrinth(n, startRow, startCol);
        }

        /// <summary>
        /// Fills all the reachable cells in the labyrinth
        /// with their respective values.
        /// </summary>
        public void FillLabyrinth()
        {
            this.visited[this.StartRow, this.StartCol] = true;
            this.currentIndex++;
            this.nextValues.Enqueue(this.currentIndex);

            this.FillNearByElements(this.StartRow, this.StartCol);
        }

        /// <summary>
        /// Prints the calculated, filled labyrinth;
        /// </summary>
        public void PrintCalculatedLabyrint()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine("The calculated labyrinth is:");

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    if (this.reachable[i, j])
                    {
                        if (this.matrix[i, j] != 0)
                        {
                            output.AppendFormat("{0,3}", this.matrix[i, j]);
                        }
                        else
                        {
                            output.AppendFormat("{0,3}", Labyrinth.UnreachableSymbol);
                        }
                    }
                    else
                    {
                        if (i == this.startRow && j == this.StartCol)
                        {
                            output.AppendFormat("{0,3}", Labyrinth.StartSymbol);
                            continue;
                        }

                        output.AppendFormat("{0,3}", Labyrinth.UnreachabelCell);
                    }
                }

                output.AppendLine();
            }

            Console.WriteLine(output);
        }

        /// <summary>
        /// Prints the initial, empty labyrinth.
        /// </summary>
        public void PrintInitialLabyrinth()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("The initial labyrinth is:");
            
            for (int i = 0; i < this.reachable.GetLength(0); i++)
            {
                for (int j = 0; j < this.reachable.GetLength(1); j++)
                {
                    if (i == this.StartRow && j == this.StartCol)
                    {
                        output.AppendFormat("{0,3}", Labyrinth.StartSymbol);
                    }
                    else if (this.reachable[i, j])
                    {
                        output.AppendFormat("{0,3}", "0");
                    }
                    else
                    {
                        output.AppendFormat("{0,3}", Labyrinth.UnreachabelCell);
                    }
                }

                output.AppendLine();
            }

            Console.WriteLine(output);
        }

        private void FillNearByElements(int currentRow, int currentCol)
        {
            this.visited[currentRow, currentCol] = true;

            this.currentIndex = this.nextValues.Dequeue();

            // The following lines check if there are nearby cells which are
            // reachable and not filled yet and if so, we fill them.
            if (this.GoodForFilling(currentRow, currentCol - 1))
            {
                this.FillAndEnqueue(currentRow, currentCol - 1);
            }

            if (this.GoodForFilling(currentRow - 1, currentCol))
            {
                this.FillAndEnqueue(currentRow - 1, currentCol);
            }

            if (this.GoodForFilling(currentRow, currentCol + 1))
            {
                this.FillAndEnqueue(currentRow, currentCol + 1);
            }

            if (this.GoodForFilling(currentRow + 1, currentCol))
            {
                this.FillAndEnqueue(currentRow + 1, currentCol);
            }
            
            do
            {
                if (this.nextRows.Count == 0 || this.nextCols.Count == 0)
                {
                    return;
                }

                this.nextRow = this.nextRows.Dequeue();
                this.nextCol = this.nextCols.Dequeue();
            } 
            while (this.visited[this.nextRow, this.nextCol]);

            this.FillNearByElements(this.nextRow, this.nextCol);
        }

        private bool InRange(int currentRow, int currentCol)
        {
            bool inRange = currentRow >= 0 && currentRow < this.matrix.GetLength(0) &&
                currentCol >= 0 && currentCol < this.matrix.GetLength(1);

            return inRange;
        }

        private bool IsFilled(int currentRow, int currentCol)
        {
            bool isFilled = this.matrix[currentRow, currentCol] != 0;

            return isFilled;
        }

        private bool GoodForFilling(int currentRow, int currentCol)
        {
            bool goodForFill = this.InRange(currentRow, currentCol) &&
                !this.IsFilled(currentRow, currentCol) &&
                this.reachable[currentRow, currentCol];

            return goodForFill;
        }

        private void FillAndEnqueue(int currentRow, int currentCol)
        {
            this.matrix[currentRow, currentCol] = this.currentIndex;

            this.nextRows.Enqueue(currentRow);
            this.nextCols.Enqueue(currentCol);
            this.nextValues.Enqueue(this.currentIndex + 1);
        }
        
        private void DetermineReachable()
        {
            for (int i = 0; i < this.reachable.GetLength(0); i++)
            {
                for (int j = 0; j < this.reachable.GetLength(1); j++)
                {
                    if (i == this.startRow && j == this.StartCol)
                    {
                        this.reachable[i, j] = false;
                        continue;
                    }

                    int randomNumber = this.rand.Next(0, 5);
                    this.reachable[i, j] = Convert.ToBoolean(randomNumber);
                }
            }
        }
    }
}
