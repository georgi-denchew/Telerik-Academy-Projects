using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public abstract class MenuItem : GameObject, IRenderable
    {
        protected char[,] message;     

        public bool isChosen { get; protected set; }

        protected MenuItem(MatrixPosition topLeft, char[,] message)
            : base(topLeft, message)
        {

            this.isChosen = false;

        }

        public abstract void TakeAction();
        

    }
}
