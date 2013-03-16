using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    class Program
    {
        const int WorldRows = 23;
        const int WorldCols = 50;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                AlienShip alien = new AlienShip(new MatrixPosition(startRow, i), new MatrixPosition(0, 1));
                AlienShip alien1 = new AlienShip(new MatrixPosition(startRow+1, i), new MatrixPosition(0, 1));

                engine.AddObject(alien);
                engine.AddObject(alien1);
            }

            PlayerShip player = new PlayerShip(new MatrixPosition(WorldRows - 2, WorldCols / 2));

            engine.AddObject(player);
        }

        private static void BuildWalls(Engine engine)
        {
            for (int col = 0; col < WorldCols; col++)
            {
                Wall wallBlockTop = new Wall(new MatrixPosition(0, col));
                Wall wallBlockBottom = new Wall(new MatrixPosition(WorldRows - 1, col));

                engine.AddObject(wallBlockTop);
                engine.AddObject(wallBlockBottom);
            }

            for (int row = 1; row < WorldRows - 1; row++)
            {
                Wall wallBlockLeft = new Wall(new MatrixPosition(row, 0));
                Wall wallBlockRight = new Wall(new MatrixPosition(row, WorldCols - 1));

                engine.AddObject(wallBlockLeft);
                engine.AddObject(wallBlockRight);
            }
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardController();
            Engine gameEngine = new Engine(renderer, keyboard);
            
            BuildWalls(gameEngine);
            Initialize(gameEngine);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerShipLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerShipRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.Shoot();
            };

            gameEngine.Run();
        }
    }
}
