using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject //TASK 05
    {
        public const char TrailSymbol = '\'';
        private int lifetime;

        public TrailObject(MatrixCoords coords, int lifetime)
            : base(coords , new char[,] { {TrailSymbol} })
        {
            this.lifetime = lifetime;
        }
        public override void Update()
        {
            if (this.lifetime == 0)
            {
                this.IsDestroyed = true;
            }
            this.lifetime--;
        }
    }
}
