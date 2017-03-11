namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] field = CreateGameField();
            char[,] mines = GenerateMines();
            int movesCounter = 0;
            bool isExplode = false;
            List<Score> champions = new List<Score>(6);
            int row = 0;
            int col = 0;
            bool isNewGame = true;
            const int MaximumEmptyCells = 35;
            bool isWin = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Lets play 'Minesweeper'. Can you find the cells without mines?" +
                    "\n-------------\n" +
                    "Commands:" +
                    "\n-------------\n" +
                    "'top' - shows the scoreboard" +
                    "\n'restart' - restarts the game" +
                    "\n'exit' - exits the game!");
                    DrawField(field);
                    isNewGame = false;
                }

                Console.Write("Input row and column separated by space: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        GetScoreBoard(champions);
                        break;
                    case "restart":
                        field = CreateGameField();
                        mines = GenerateMines();
                        DrawField(field);
                        isExplode = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Good Bye!");
                        break;
                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                MakeNextMove(field, mines, row, col);
                                movesCounter++;
                            }

                            if (MaximumEmptyCells == movesCounter)
                            {
                                isWin = true;
                            }
                            else
                            {
                                DrawField(field);
                            }
                        }
                        else
                        {
                            isExplode = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid Command\n");
                        break;
                }

                if (isExplode)
                {
                    DrawField(mines);
                    Console.Write("\nSorry! You lost! Zero points! " + "Input your nickname: ", movesCounter);
                    string nickname = Console.ReadLine();
                    Score score = new Score(nickname, movesCounter);
                    if (champions.Count < 5)
                    {
                        champions.Add(score);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].UserPoints < score.UserPoints)
                            {
                                champions.Insert(i, score);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Score score1, Score score2) => score2.UserName.CompareTo(score1.UserName));
                    champions.Sort((Score score1, Score score2) => score2.UserPoints.CompareTo(score1.UserPoints));
                    GetScoreBoard(champions);

                    field = CreateGameField();
                    mines = GenerateMines();
                    movesCounter = 0;
                    isExplode = false;
                    isNewGame = true;
                }

                if (isWin)
                {
                    Console.WriteLine("\nYOU WIN! You opened all the empty cells!");
                    DrawField(mines);
                    Console.WriteLine("Input ypur name: ");
                    string name = Console.ReadLine();
                    Score score = new Score(name, movesCounter);
                    champions.Add(score);
                    GetScoreBoard(champions);
                    field = CreateGameField();
                    mines = GenerateMines();
                    movesCounter = 0;
                    isWin = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria!");
            Console.Read();
        }

        private static void GetScoreBoard(List<Score> scores)
        {
            Console.WriteLine("\nPOINTS:");
            if (scores.Count > 0)
            {
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} cells", i + 1, scores[i].UserName, scores[i].UserPoints);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty Scoreboard!\n");
            }
        }

        private static void MakeNextMove(char[,] field,char[,] minesField, int currentRow, int currentCol)
        {
            char minesCount = CalculateNeighbourMines(minesField, currentRow, currentCol);
            minesField[currentRow, currentCol] = minesCount;
            field[currentRow, currentCol] = minesCount;
        }

        private static void DrawField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int row = 0; row < rows; row++)
            {
                Console.Write("{0} | ", row);
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(string.Format("{0} ", board[row, col]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int fieldRows = 5;
            int fieldColumns = 10;
            char[,] field = new char[fieldRows, fieldColumns];
            for (int row = 0; row < fieldRows; row++)
            {
                for (int col = 0; col < fieldColumns; col++)
                {
                    field[row, col] = '?';
                }
            }

            return field;
        }

        private static char[,] GenerateMines()
        {
            const int Rows = 5;
            const int Cols = 10;
            char[,] gameField = new char[Rows, Cols];

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    gameField[row, col] = '-';
                }
            }

            List<int> randomList = new List<int>();
            while (randomList.Count < 15)
            {
                Random random = new Random();
                int randomPlace = random.Next(50);
                if (!randomList.Contains(randomPlace))
                {
                    randomList.Add(randomPlace);
                }
            }

            foreach (int number in randomList)
            {
                int row = number / Cols;
                int col = number % Cols;

                if (col == 0 && number != 0)
                {
                    row--;
                    col = Cols;
                }
                else
                {
                    col++;
                }

                gameField[row, col - 1] = '*';
            }

            return gameField;
        }

        private static char CalculateNeighbourMines(char[,] field, int currentRow, int currentCol)
        {
            int minesCount = 0;
            int maxRows = field.GetLength(0);
            int maxCols = field.GetLength(1);
            const int MinRows = 0;
            const int MinCols = 0;

            if (currentRow - 1 >= MinRows)
            {
                if (field[currentRow - 1, currentCol] == '*')
                {
                    minesCount++;
                }
            }

            if (currentRow + 1 < maxRows)
            {
                if (field[currentRow + 1, currentCol] == '*')
                {
                    minesCount++;
                }
            }

            if (currentCol - 1 >= MinCols)
            {
                if (field[currentRow, currentCol - 1] == '*')
                {
                    minesCount++;
                }
            }

            if (currentCol + 1 < maxCols)
            {
                if (field[currentRow, currentCol + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((currentRow - 1 >= MinRows) && (currentCol - 1 >= MinCols))
            {
                if (field[currentRow - 1, currentCol - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((currentRow - 1 >= MinRows) && (currentCol + 1 < maxCols))
            {
                if (field[currentRow - 1, currentCol + 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((currentRow + 1 < maxRows) && (currentCol - 1 >= MinCols))
            {
                if (field[currentRow + 1, currentCol - 1] == '*')
                {
                    minesCount++;
                }
            }

            if ((currentRow + 1 < maxRows) && (currentCol + 1 < maxCols))
            {
                if (field[currentRow + 1, currentCol + 1] == '*')
                {
                    minesCount++;
                }
            }

            return char.Parse(minesCount.ToString());
        }
    }
}
