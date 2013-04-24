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
        const int MenuRows = 5;
        const int MenuCols = 10;

        static void Initialize(Engine engine)
        {
            int startRow = 2;
            int startCol = 2;
            int endCol = WorldCols - 2;
            int alienStartRow = startRow;

            for (int i = startCol + 4; i < endCol - 10; i++)
            {
                if (i == startCol + 15)
                {
                    alienStartRow++;
                }

                if (i == startCol + 20)
                {
                    alienStartRow--;
                }

                AlienShip alien = new AlienShip(new MatrixPosition(alienStartRow, i), new MatrixPosition(1, 1));
                engine.AddObject(alien);
            }

            PlayerShip player = new PlayerShip(new MatrixPosition(WorldRows - 2, WorldCols / 2));

            engine.AddObject(player);

        }

        private static void BuildMenu(Engine engine)
        {
            StartResume startResume = new StartResume(new MatrixPosition(3 , WorldCols + 3));
            engine.AddObject(startResume);
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
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols + 20);
            IUserInterface keyboard = new KeyboardController();
            Engine gameEngine = new Engine(renderer, keyboard);

            BuildWalls(gameEngine);
            BuildMenu(gameEngine);
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

            keyboard.OnEscapePressed += (sender, eventInfo) =>
                {
                    gameEngine.Pause();
                };

            gameEngine.Run();
        }
    }
}
