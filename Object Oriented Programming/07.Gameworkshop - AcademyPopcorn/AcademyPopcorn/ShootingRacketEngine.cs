using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ShootingRacketEngine : Engine //TASK 04
    {
        public ShootingRacketEngine(IRenderer renderer, IUserInterface userInterface, int sleep)
            : base(renderer, userInterface, sleep)
        {
        }


        public void ShootPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).Shoot();
            }
        }

    }
}
