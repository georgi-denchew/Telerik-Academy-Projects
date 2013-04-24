using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    public class MatrixPosition
    {
        public int Row { get; set; }
        public int Col { get; set; }

        public MatrixPosition(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public static MatrixPosition operator +(MatrixPosition a, MatrixPosition b)
        {
            return new MatrixPosition(a.Row + b.Row, a.Col + b.Col);
        }

        public static MatrixPosition operator -(MatrixPosition a, MatrixPosition b)
        {
            return new MatrixPosition(a.Row - b.Row, a.Col - b.Col);
        }

        public override bool Equals(object obj)
        {
            MatrixPosition objAsMatrixCoords = obj as MatrixPosition;

            return objAsMatrixCoords.Row == this.Row && objAsMatrixCoords.Col == this.Col;
        }
    }
}
