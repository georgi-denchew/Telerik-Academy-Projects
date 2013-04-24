using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    public class ConsoleRenderer : IRenderer
    {
        int renderContextMatrixRows;
        int renderContextMatrixCols;
        char[,] renderContextMatrix;

        public ConsoleRenderer(int visibleConsoleRows, int visibleConsoleCols)
        {
            renderContextMatrix = new char[visibleConsoleRows, visibleConsoleCols + 10];

            this.renderContextMatrixRows = renderContextMatrix.GetLength(0);
            this.renderContextMatrixCols = renderContextMatrix.GetLength(1) - 10;

            this.ClearQueue();
        }

        public void EnqueueForRendering(IRenderable obj)
        {
            char[,] objImage = obj.GetImage();

            int imageRows = objImage.GetLength(0);
            int imageCols = objImage.GetLength(1);

            MatrixPosition objTopLeft = obj.GetPosition();

            int lastRow = Math.Min(objTopLeft.Row + imageRows, this.renderContextMatrixRows);
            int lastCol = Math.Min(objTopLeft.Col + imageCols, this.renderContextMatrixCols);

            for (int row = obj.GetPosition().Row; row < lastRow; row++)
            {
                for (int col = obj.GetPosition().Col; col < lastCol; col++)
                {
                    if (row >= 0 && row < renderContextMatrixRows &&
                        col >= 0 && col < renderContextMatrixCols)
                    {
                        renderContextMatrix[row, col] = objImage[row - obj.GetPosition().Row, col - obj.GetPosition().Col];
                    }
                }
            }
        }

        public void RenderAll()
        {
            Console.SetCursorPosition(0, 0);

            StringBuilder scene = new StringBuilder();

            for (int row = 0; row < this.renderContextMatrixRows; row++)
            {
                for (int col = 0; col < this.renderContextMatrixCols; col++)
                {
                    scene.Append(this.renderContextMatrix[row, col]);
                }

                scene.Append(Environment.NewLine);
            }

            Console.WriteLine(scene.ToString());
        }

        public void ClearQueue()
        {
            for (int row = 0; row < this.renderContextMatrixRows; row++)
            {
                for (int col = 0; col < this.renderContextMatrixCols; col++)
                {
                    this.renderContextMatrix[row, col] = ' ';
                }
            }
        }

        public int GetWidth()
        {
            return this.renderContextMatrixCols;
        }
    }
}
