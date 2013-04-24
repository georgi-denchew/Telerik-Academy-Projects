using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class StartResume : MenuItem
    {
        public StartResume(MatrixPosition topLeft)
            : base(topLeft, new char[,] { { 'S', 'T', 'A', 'R', 'T', '/', 'R', 'E', 'S', 'U', 'M', 'E', } })
        {
        }
        
        public override void TakeAction()
        {
        }

        public override void Update()
        {
            
        }
    }
}