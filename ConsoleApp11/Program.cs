using System;

namespace ExampleFour
{
    class Program
    {
        private static bool gameStatus = true;
        private static readonly string x = " X ";
        private static readonly string o = " O ";
        private static string ptr = x;
        private static readonly string emp = "   ";
        private static string[,] gameArr = new string[,] { };
        private static readonly int[,] cords = new int[,]
        {
            { 0, 0}, { 0, 2}, { 0, 4},
            { 2, 0}, { 2, 2}, { 2, 4},
            { 4, 0}, { 4, 2}, { 4, 4}
        };

        private static readonly int[,] winArr = new int[,]
        {
            {0, 1, 2}, { 3, 4, 5}, {6, 7, 8},
            {0, 3, 6}, { 1, 4, 7}, {2, 5, 8},
            {0, 4, 8}, { 2, 4, 6}
        };
        static void Main(string[] args)
        {
            Menu();
        }

        static void Show()
        {
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(gameArr[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Start()
        {
            var playerIndex = 0;
            Show();
            do
            {
                Console.Write(ptr + "’s move > ");
                playerIndex = Convert.ToInt32(Console.ReadLine());
                Play(playerIndex);
            } while (gameStatus);
        }
        static void Play(int index)
        {
            if (index > 0 && index < 10 && gameArr[cords[index - 1, 0], cords[index - 1, 1]] == emp)
            {
                gameArr[cords[index - 1, 0], cords[index - 1, 1]] = ptr;

                Show();
                CheckWon();
                GameOver();
                ptr = ptr == x ? o : x;
            }
            else
            {
                Console.WriteLine("Illegal move! Try again.");
            }
        }

        static void GameOver()
        {
            if (!gameStatus) return;

            var count = 9;
            for (var i = 0; i < 9; i++)
            {
                if (gameArr[cords[i, 0], cords[i, 1]] != emp)
                {
                    count--;
                }
            }

            if (count <= 0)
            {
                Console.WriteLine("Game over!");
                initGame();
            }
        }

        static void Menu()
        {
            Console.Clear();
            ResetGame();
            Console.Write("1. New game\n2. About the author \n3. Exit\n> ");
            var gameMode = Convert.ToInt32(Console.ReadLine());
            switch (gameMode)
            {
                case 1:
                    Start();
                    break;
                case 2:
                    ShowAuthorInfo();
                    break;
                case 3:
                    ExitGame();
                    break;
                default:
                    break;
            }
        }

        static void ShowAuthorInfo()
        {
            Console.Clear();
            var info = "My name is nilda nur, I am 21 years old.\n" +
                        "I was born in Mersin, Turkey.\n" +
                        "I like to listening to music.\n" +
                        "My favorite food is hamburger.\n";
            Console.WriteLine(info);
            initGame();
        }

        static void ExitGame()
        {
            Console.Write("Are you sure you want to quit? [y/n]\n> ");
            var sure = Console.ReadLine();
            if (sure == "n")
                Menu();
            else
            {
                gameStatus = false;
            }
        }
        static void CheckWon()
        {
            for (int i = 0; i < 8; i++)
            {
                var a = gameArr[cords[winArr[i, 0], 0], cords[winArr[i, 0], 1]];
                var b = gameArr[cords[winArr[i, 1], 0], cords[winArr[i, 1], 1]];
                var c = gameArr[cords[winArr[i, 2], 0], cords[winArr[i, 2], 1]];

                if (a != emp && b != emp && c != emp)
                {
                    if (a == b && b == c)
                    {
                        Console.WriteLine($"{ptr} won!");
                        gameStatus = false;
                        initGame();
                    }
                }
            }
        }

        static void initGame()
        {
            Console.WriteLine("[Press Enter to return to main menu...]");
            Console.ReadKey();
            Menu();
        }

        static void ResetGame()
        {
            gameStatus = true;
            gameArr = new string[,] {
                { emp, "|", emp, "|",emp },
                { "---", "+", "---", "+", "---" },
                { emp, "|", emp, "|", emp },
                { "---", "+", "---", "+", "---" },
                { emp, "|", emp, "|", emp }
            };
        }

    }
}