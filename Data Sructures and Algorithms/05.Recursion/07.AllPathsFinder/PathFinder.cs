namespace _07.AllPathsFinder
{
    using System;
    using System.Linq;
    using System.Text;

    public class PathFinder
    {
        private bool[,] passable;
        private bool[,] visited;
        private int[] rowPaths;
        private int[] colPaths;
        private bool atLeastOnePath;

        public PathFinder(int size)
        {
            this.passable = new bool[size, size];
            this.visited = new bool[size, size];
            this.rowPaths = new int[size * size];
            this.colPaths = new int[size * size];
            this.atLeastOnePath = false;

            this.DeterminePossible();
        }

        public void PathExists()
        {
            if (!this.atLeastOnePath)
            {
                Console.WriteLine("No paths are found. Restart the application so that new" +
                    "random passable cells are generated");
            }
        }

        public void FindAllPaths(int currentRow, int currentCol, int endRow, int endCol, int rowIndex = 0, int colIndex = 0)
        {
            bool inRange = ((currentCol >= 0) && currentCol < this.passable.GetLength(1)) &&
                ((currentRow >= 0) && currentRow < this.passable.GetLength(0));

            if (!inRange || 
                !this.passable[currentRow, currentCol] ||
                this.visited[currentRow, currentCol])
            {
                return;
            }

            // storing the path so far
            this.rowPaths[rowIndex] = currentRow;
            this.colPaths[colIndex] = currentCol;

            if (currentRow == endRow && currentCol == endCol)
            {
                this.atLeastOnePath = true;
                this.PrintPaths(endRow, endCol);
                return;
            }

            this.visited[currentRow, currentCol] = true;

            // check the cell to the right
            this.FindAllPaths(currentRow, currentCol + 1, endRow, endCol, rowIndex + 1, colIndex + 1);
            // check the cell underneath
            this.FindAllPaths(currentRow + 1, currentCol, endRow, endCol, rowIndex + 1, colIndex + 1);
            // check the cell to the left
            this.FindAllPaths(currentRow, currentCol - 1, endRow, endCol, rowIndex + 1, colIndex + 1);
            // check the cell to the top
            this.FindAllPaths(currentRow - 1, currentCol, endRow, endCol, rowIndex + 1, colIndex + 1);

            this.visited[currentRow, currentCol] = false;
        }

        private void PrintPaths(int endRow, int endCol)
        {
            int index = 0;
            Console.WriteLine("Beginning of new path:");
            while (true)
            {
                Console.Write("{0} {1}; ", this.rowPaths[index], this.colPaths[index]);
                
                // since one path may be longer than others
                // and because the path storage isn't cleaned up
                // an explicit check is performed if the 
                // destination cell is reached
                if (this.rowPaths[index] == endRow && this.colPaths[index] == endCol)
                {
                    break;
                }
                index++;
            }
            Console.WriteLine();
            Console.WriteLine("End of path");
            Console.WriteLine();
        }

        public void PrintMatrix()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("The matrix is (1 - passable, X - unpassable):");

            for (int i = 0; i < this.passable.GetLength(0); i++)
            {
                for (int j = 0; j < this.passable.GetLength(1); j++)
                {
                    if (this.passable[i, j])
                    {
                        output.AppendFormat("{0,3}", "1");
                    }
                    else
                    {
                        output.AppendFormat("{0,3}", "X");
                    }
                }

                output.AppendLine();
            }

            Console.WriteLine(output);
        }

        private void DeterminePossible()
        {
            Random rand = new Random();

            for (int i = 0; i < this.passable.GetLength(0); i++)
            {
                for (int j = 0; j < this.passable.GetLength(1); j++)
                {
                    int randomNumber = rand.Next(0, 5);
                    this.passable[i, j] = Convert.ToBoolean(randomNumber);
                }
            }
        }
    }
}
