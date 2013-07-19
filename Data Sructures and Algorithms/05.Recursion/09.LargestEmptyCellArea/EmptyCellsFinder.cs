namespace _09.LargestEmptyCellArea
{
    using System;
    using System.Linq;
    using System.Text;

    public class EmptyCellsFinder
    {
        private readonly string[,] matrix;
        private readonly bool[,] visited;
        private int maxCellsCount;
        private readonly int width;
        private readonly int height;
        private static string[] largestEmptyCellsRowIndices;
        private static string[] largestEmptyCellsColIndices;

        public EmptyCellsFinder(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.matrix = new string[width, height];
            this.visited = new bool[width, height];
            largestEmptyCellsRowIndices = new string[width * height];
            largestEmptyCellsColIndices = new string[width * height];
            this.maxCellsCount = 0;

            this.FillMatrix();
        }

        public void FindLargestEmptyCellArea()
        {
            this.PrintInitialMatrix();

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    if (!this.visited[i, j] && this.matrix[i, j] == null)
                    {
                        int emptyCellCount = 0;
                        string[] emptyCellRowIndices = new string[this.width * this.height];
                        string[] emptyCellColIndices = new string[this.width * this.height];

                        this.FindLargestEmptyCellArea(i, j, 0, ref emptyCellRowIndices,
                            ref emptyCellColIndices, ref emptyCellCount);
                    }
                }
            }

            this.PrintLargestEmptyCellArea();
        }

        private void FindLargestEmptyCellArea(int currentRow, int currentCol, int storeIndex, ref string[] emptyCellRowIndices,
            ref string[] emptyCellColIndices, ref int emptyCellsCount)
        {
            bool inRange = this.InRange(currentRow, currentCol);

            if (!inRange || visited[currentRow, currentCol] || this.matrix[currentRow, currentCol] != null)
            {
                if (emptyCellsCount > this.maxCellsCount)
                {
                    largestEmptyCellsRowIndices = emptyCellRowIndices;
                    largestEmptyCellsColIndices = emptyCellColIndices;
                    this.maxCellsCount = emptyCellsCount;
                }

                return;
            }

            emptyCellsCount++;


            this.UpdateResult(emptyCellRowIndices, emptyCellColIndices, currentRow, currentCol);

            visited[currentRow, currentCol] = true;

            // check all nearby cells
            FindLargestEmptyCellArea(currentRow, currentCol + 1, storeIndex + 1, ref emptyCellRowIndices,
                ref emptyCellColIndices, ref emptyCellsCount);
            
            FindLargestEmptyCellArea(currentRow + 1, currentCol, storeIndex + 1, ref emptyCellRowIndices,
                ref emptyCellColIndices, ref emptyCellsCount);
            
            FindLargestEmptyCellArea(currentRow, currentCol - 1, storeIndex + 1, ref emptyCellRowIndices,
                ref emptyCellColIndices, ref emptyCellsCount);
            
            FindLargestEmptyCellArea(currentRow - 1, currentCol, storeIndex + 1, ref emptyCellRowIndices,
                ref emptyCellColIndices, ref emptyCellsCount);
        }

        private void UpdateResult(string[] emptyCellRowIndices, string[] emptyCellColIndices, int currentRow, int currentCol)
        {
            for (int i = 0; i < emptyCellRowIndices.Length; i++)
            {
                if (emptyCellRowIndices[i] == null)
                {
                    emptyCellRowIndices[i] = currentRow.ToString();
                    break;
                }
            }

            for (int i = 0; i < emptyCellColIndices.Length; i++)
            {
                if (emptyCellColIndices[i] == null)
                {
                    emptyCellColIndices[i] = currentCol.ToString();
                    break;
                }
            }
        }

        private bool InRange(int currentRow, int currentCol)
        {
            bool inRange = currentRow >= 0 && currentRow < this.matrix.GetLength(0) &&
                currentCol >= 0 && currentCol < this.matrix.GetLength(1);
            return inRange;
        }

        private void FillMatrix()
        {
            Random rand = new Random();

            for (int i = 0; i < this.width * this.height / 2; i++)
            {
                int rowIndex = rand.Next(0, width);
                int colIndex = rand.Next(0, height);

                this.matrix[rowIndex, colIndex] = "full";
            }
        }

        private void PrintInitialMatrix()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("The matrix is (0 - empty cell, 1 - full cell):");

            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                {
                    if (this.matrix[i, j] == null)
                    {
                        output.AppendFormat("{0,3}", "0");
                    }
                    else
                    {
                        output.AppendFormat("{0,3}", "1");
                    }
                }

                output.AppendLine();
            }

            Console.WriteLine(output);
        }

        private void PrintLargestEmptyCellArea()
        {
            Console.WriteLine("Cells count in the largest empty cell area: {0}", this.maxCellsCount);
            Console.WriteLine("Largest empty cell area contains the cells (non-consecutive):");
            for (int i = 0; i < largestEmptyCellsColIndices.Length; i++)
            {
                if (largestEmptyCellsColIndices[i] != null &&
                    largestEmptyCellsRowIndices[i] != null)

                    Console.Write("{0} {1}; ",
                        largestEmptyCellsRowIndices[i],
                        largestEmptyCellsColIndices[i]);
            }

            Console.WriteLine();
        }

    }
}
