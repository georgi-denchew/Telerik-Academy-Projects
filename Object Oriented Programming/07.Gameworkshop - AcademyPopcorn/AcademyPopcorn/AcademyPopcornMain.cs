using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++) 
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            //ExplodingBlock explBlock = new ExplodingBlock(new MatrixCoords(startRow + 1, WorldCols - 22));//TASK 10 - uncomment to test
                                                                                                          
            //engine.AddObject(explBlock);                                                                  //TASK 10 - uncomment to test
                                                                                                          
            //Block currBlock1 = new Block(new MatrixCoords(startRow + 1, WorldCols - 21));                 //TASK 10 - uncomment to test
                                                                                                          
            //engine.AddObject(currBlock1);                                                                 //TASK 10 - uncomment to test
                                                                                                          
            //Block currBlock2 = new Block(new MatrixCoords(startRow + 1, WorldCols - 23));                 //TASK 10 - uncomment to test

            //engine.AddObject(currBlock2);                                                                 //TASK 10 - uncomment to test

            GiftBlock giftBlock = new GiftBlock(new MatrixCoords(startRow + 1, WorldCols - 22));          //TASK 11 & TASK 12 - uncomment to test

            engine.AddObject(giftBlock);                                                                  //TASK 11 & TASK 12 - uncomment to test


            for (int i = 0; i < WorldCols; i++) //TASK 01
            {
                IndestructibleBlock ceilingBlock = new IndestructibleBlock(new MatrixCoords(0, i));

                engine.AddObject(ceilingBlock);
            }

            for (int i = 1; i < WorldRows; i++) //TASK 01
            {
                IndestructibleBlock leftWallBlock = new IndestructibleBlock(new MatrixCoords(i, 0));
                IndestructibleBlock rightWallBlock = new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1));
               
                engine.AddObject(leftWallBlock);
                engine.AddObject(rightWallBlock);
            }

            for (int i = 10; i < WorldCols - 10; i++)
            {
                UnpassableBlock unpassableBlock = new UnpassableBlock(new MatrixCoords(WorldRows / 2, i)); //TASK 09 - uncomment to test

                engine.AddObject(unpassableBlock);
            }

            //TrailObject trail = new TrailObject(new MatrixCoords(WorldRows - 10, 3), 5); //TASK 05 - uncomment to test
            
            //engine.AddObject(trail); //TASK 05 - uncomment to test

            //UnstoppableBall unstoppableBall = new UnstoppableBall(new MatrixCoords(WorldRows - 1, 0), new MatrixCoords(-1, 1)); //TASK 09 - uncomment to test

            //engine.AddObject(unstoppableBall);  //TASK 09 - uncomment to test

            //MeteoriteBall meteoriteBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1)); //TASK 07 - uncomment to test

            //engine.AddObject(meteoriteBall); //TASK 07 - uncomment to test

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            ShootingRacketEngine gameEngine = new ShootingRacketEngine(renderer, keyboard, 100); //TASK 12

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) => //TASk 12
                {
                    gameEngine.ShootPlayerRacket();            //TASK 12
                };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
