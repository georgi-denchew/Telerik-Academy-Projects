using System;
using System.Collections.Generic;

namespace RefactoringSourceProject
{
    public class Minesweeper
    {
        private static char[,] displayField = CreateDisplayField();
        private static char[,] bombField = CreateBombField();
        private static int pointsCount = 0;

        /// <summary>
        /// Variable, which indicates if the player "opened" a bomb-square.
        /// </summary>
        private static bool exploded = false;
        private static bool gameToStart = true;
        private static bool gameWon = false;
        private static List<Score> scoreSheet = new List<Score>(6);

        /// <summary>
        /// The method, used to run the game.
        /// </summary>
        static void Main()
        {
            const int MaxMoves = 35;
            string command = string.Empty;
            int currentRow = 0;
            int currentColumn = 0;

            StartNewGame();

            do
            {
                if (gameToStart)
                {
                    Console.WriteLine("Let's play Minesweeper. Try your luck to find the fields without mines. The command \"top\"" +
                        "shows the High-scores chart, \"restart\" starts a new game and \"exit\" exits the game");
                    Console.WriteLine("{0} Press any key to start", Environment.NewLine);
                    Console.ReadKey();
                    Draw(displayField);
                    gameToStart = false;
                }

                Console.Write("Enter row and column separated by a single whitespace : ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out currentRow) &&
                        int.TryParse(command[2].ToString(), out currentColumn) &&
                        currentRow <= displayField.GetLength(0) && currentColumn <= displayField.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowScoreSheet(scoreSheet);
                        break;
                    case "restart":
                        StartNewGame();
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye!");
                        break;
                    case "turn":
                        if (bombField[currentRow, currentColumn] != '*')
                        {
                            if (bombField[currentRow, currentColumn] == '-')
                            {
                                MakeTurn(displayField, bombField, currentRow, currentColumn);
                                pointsCount++;
                            }

                            if (MAX_MOVES == pointsCount)
                            {
                                gameWon = true;
                            }
                            else
                            {
                                Draw(displayField);
                            }
                        }
                        else
                        {
                            exploded = true;
                        }

                        break;
                    default:
                        Console.WriteLine("{0} Error! Invalid Command {0}", Environment.NewLine);
                        break;
                }

                if (exploded)
                {
                    Draw(bombField);

                    Console.Write("{0} Hrrrrrr! You died heroicly with {1} points.Enter nickname: ", 
                        Environment.NewLine, pointsCount);

                    string nickname = Console.ReadLine();
                    Score score = new Score(nickname, pointsCount);

                    if (scoreSheet.Count < 5)
                    {
                        scoreSheet.Add(score);
                    }
                    else
                    {
                        for (int i = 0; i < scoreSheet.Count; i++)
                        {
                            if (scoreSheet[i].Points < score.Points)
                            {
                                scoreSheet.Insert(i, score);
                                scoreSheet.RemoveAt(scoreSheet.Count - 1);
                                break;
                            }
                        }
                    }

                    ShowScoreSheet(scoreSheet);

                    StartNewGame();
                }

                if (gameWon)
                {
                    Console.WriteLine("{0}Congratulations! You won with a perfect score!");
                    Draw(bombField);
                    Console.WriteLine("Enter nickname: ");
                    string nickname = Console.ReadLine();
                    Score score = new Score(nickname, pointsCount);
                    scoreSheet.Add(score);
                    ShowScoreSheet(scoreSheet);

                    StartNewGame();
                }
            }

            while (command != "exit");
        }

        private static void StartNewGame()
        {
            displayField = CreateDisplayField();
            bombField = CreateBombField();
            pointsCount = 0;
            exploded = false;
            gameToStart = true;
            gameWon = false;
        }

        private static void ShowScoreSheet(List<Score> scoreSheet)
        {
            Console.WriteLine("{0} Scoresheet:", Environment.NewLine);

            if (scoreSheet.Count > 0)
            {
                scoreSheet.Sort((Score r1, Score r2) => r2.Nickname.CompareTo(r1.Nickname));
                scoreSheet.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                for (int i = 0; i < scoreSheet.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} moves",
                        i + 1, scoreSheet[i].Nickname, scoreSheet[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty scoresheet!{0}", Environment.NewLine);
            }
        }

        /// <summary>
        /// "Turns" the square so we can see if there is a bomb in it
        /// </summary>
        private static void MakeTurn(char[,] displayField, char[,] bombField, int currentRow, int currentColumn)
        {
            char nearbyBombs = CountNearbyBombs(bombField, currentRow, currentColumn);
            bombField[currentRow, currentColumn] = nearbyBombs;
            displayField[currentRow, currentColumn] = nearbyBombs;
        }

        private static void Draw(char[,] field)
        {
            Console.Clear();
            int boardRows = field.GetLength(0);
            int boardColumns = field.GetLength(1);
            Console.WriteLine("{0}    0 1 2 3 4 5 6 7 8 9", Environment.NewLine);
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < boardRows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < boardColumns; j++)
                {
                    Console.Write(string.Format("{0} ", field[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------{0}", Environment.NewLine);
        }

        private static char[,] CreateDisplayField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] CreateBombField()
        {
            int rows = 5;
            int columns = 10;
            char[,] bombField = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    bombField[i, j] = '-';
                }
            }

            List<int> randomNumbers = new List<int>();
            while (randomNumbers.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!randomNumbers.Contains(randomNumber))
                {
                    randomNumbers.Add(randomNumber);
                }
            }

            foreach (int number in randomNumbers)
            {
                int randomColumn = number / columns;
                int randomRow = number % columns;
                if (randomRow == 0 && number != 0)
                {
                    randomColumn--;
                    randomRow = columns;
                }
                else
                {
                    randomRow++;
                }

                bombField[randomColumn, randomRow - 1] = '*';
            }

            return bombField;
        }

        private static char CountNearbyBombs(char[,] bombField, int currentRow, int currentColumn)
        {
            int nearbyBombsCount = 0;
            int bombFieldRows = bombField.GetLength(0);
            int bombFieldColumns = bombField.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (bombField[currentRow - 1, currentColumn] == '*')
                {
                    nearbyBombsCount++;
                }
            }

            if (currentRow + 1 < bombFieldRows)
            {
                if (bombField[currentRow + 1, currentColumn] == '*')
                {
                    nearbyBombsCount++;
                }
            }

            if (currentColumn - 1 >= 0)
            {
                if (bombField[currentRow, currentColumn - 1] == '*')
                {
                    nearbyBombsCount++;
                }
            }

            if (currentColumn + 1 < bombFieldColumns)
            {
                if (bombField[currentRow, currentColumn + 1] == '*')
                {
                    nearbyBombsCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentColumn - 1 >= 0))
            {
                if (bombField[currentRow - 1, currentColumn - 1] == '*')
                {
                    nearbyBombsCount++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentColumn + 1 < bombFieldColumns))
            {
                if (bombField[currentRow - 1, currentColumn + 1] == '*')
                {
                    nearbyBombsCount++;
                }
            }

            if ((currentRow + 1 < bombFieldRows) && (currentColumn - 1 >= 0))
            {
                if (bombField[currentRow + 1, currentColumn - 1] == '*')
                {
                    nearbyBombsCount++;
                }
            }

            if ((currentRow + 1 < bombFieldRows) && (currentColumn + 1 < bombFieldColumns))
            {
                if (bombField[currentRow + 1, currentColumn + 1] == '*')
                {
                    nearbyBombsCount++;
                }
            }

            return char.Parse(nearbyBombsCount.ToString());
        }
    }
}
