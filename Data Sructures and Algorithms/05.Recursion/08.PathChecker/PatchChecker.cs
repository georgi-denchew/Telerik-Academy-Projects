namespace _08.PathChecker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class PatchChecker
    {
        private readonly bool[,] passable;
        private bool[,] visited;
        private bool atLeastOnePath;

        public PatchChecker(int size)
        {
            this.passable = new bool[size, size];
            this.visited = new bool[size, size];
            this.atLeastOnePath = false;

            this.DeterminePossible();
        }

        public void PathExists()
        {
            if (!this.atLeastOnePath)
            {
                Console.WriteLine("No paths are found. Restart the application so that new " +
                    "random passable cells are generated");
            }
            else
            {
                Console.WriteLine("At least one path exists between the two cells.");
            }
        }

        public void FindAllPaths(int currentRow, int currentCol, int endRow, int endCol, int rowIndex = 0, int colIndex = 0)
        {
            Stack<int> nextRows = new Stack<int>();
            nextRows.Push(currentRow);
            Stack<int> nextCols = new Stack<int>();
            nextCols.Push(currentCol);

            while (!this.atLeastOnePath && (nextRows.Count > 0 && nextCols.Count > 0))
            {
                currentRow = nextRows.Pop();
                currentCol = nextCols.Pop();

                bool inRange = ((currentCol >= 0) && currentCol < this.passable.GetLength(1)) &&
                    ((currentRow >= 0) && currentRow < this.passable.GetLength(0));

                if (!inRange ||
                    !this.passable[currentRow, currentCol] ||
                    this.visited[currentRow, currentCol] ||
                    this.atLeastOnePath)
                {
                    continue;
                }

                if (currentRow == endRow && currentCol == endCol)
                {
                    this.atLeastOnePath = true;
                    return;
                }
                rowIndex++;
                colIndex++;

                this.visited[currentRow, currentCol] = true;

                // checking the cell to the right
                nextRows.Push(currentRow);
                nextCols.Push(currentCol + 1);

                // checking the cell underneath
                nextRows.Push(currentRow + 1);
                nextCols.Push(currentCol);

                // checking the cell to the left
                nextRows.Push(currentRow);
                nextCols.Push(currentCol - 1);

                // checking the cell ontop
                nextRows.Push(currentRow - 1);
                nextCols.Push(currentCol);
            }
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
