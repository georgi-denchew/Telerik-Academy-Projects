using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    public interface IRenderable
    {
        MatrixPosition GetPosition();
        //returns the top left position
        char[,] GetImage();
    }
}
