using System;
using System.Collections.Generic;
using System.Threading;

namespace ByteBee.TicTacToe
{
    class Program
    {
        private static List<int> _unUsedFields;

        static void Main(string[] args)
        {
            int[,] field = new int[3, 3];

            _unUsedFields = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            ConsoleKey key;

            do
            {
                DrawField(field);

                key = Console.ReadKey(true).Key;

                PlayerMove(field, key);
                CpuMove(field);

                bool gameOver = CheckForWinner(field);

                if (gameOver)
                {
                    Console.ReadKey(true);

                    field = new int[3, 3];
                    _unUsedFields = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
                }

            } while (key != ConsoleKey.Escape);
        }

        static int KeyToNumber(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.NumPad1: return 1;
                case ConsoleKey.NumPad2: return 2;
                case ConsoleKey.NumPad3: return 3;
                case ConsoleKey.NumPad4: return 4;
                case ConsoleKey.NumPad5: return 5;
                case ConsoleKey.NumPad6: return 6;
                case ConsoleKey.NumPad7: return 7;
                case ConsoleKey.NumPad8: return 8;
                case ConsoleKey.NumPad9: return 9;
                default: return 0;
            }
        }

        static void DrawField(int[,] field)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("   +-------+-------+-------+");

            for (int i = 2; i >= 0; i--)
            {
                Console.WriteLine("   |       |       |       |");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("   |   ");

                    int v = field[i, j];

                    if (v == -1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("x");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    else if (v == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("o");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine("   |");
                Console.WriteLine("   |       |       |       |");
                Console.WriteLine("   +-------+-------+-------+");
            }
        }

        static void PlayerMove(int[,] field, ConsoleKey key)
        {
            int playerChoise = KeyToNumber(key) - 1;

            if (playerChoise > 0)
            {
                int x = playerChoise / 3;
                int y = playerChoise % 3;

                field[x, y] = -1;

                _unUsedFields.Remove(playerChoise);
            }
        }

        static void CpuMove(int[,] field)
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);

            int cpuIndex = rnd.Next(_unUsedFields.Count);
            int cpuChoise = _unUsedFields[cpuIndex];

            _unUsedFields.Remove(cpuChoise);
            int x = cpuChoise / 3;
            int y = cpuChoise % 3;

            field[x, y] = 1;
        }

        static bool CheckForWinner(int[,] field)
        {
            int[] score = new int[8];

            score[0] = field[0, 0] + field[0, 1] + field[0, 2];
            score[1] = field[1, 0] + field[1, 1] + field[1, 2];
            score[2] = field[2, 0] + field[2, 1] + field[2, 2];

            score[3] = field[0, 0] + field[1, 0] + field[2, 0];
            score[4] = field[0, 1] + field[1, 1] + field[2, 1];
            score[5] = field[0, 2] + field[1, 2] + field[2, 2];

            score[6] = field[0, 0] + field[1, 1] + field[2, 2];
            score[7] = field[0, 2] + field[1, 1] + field[2, 0];

            for (int i = 0; i < 8; i++)
            {
                if (score[i] == 3)
                {
                    Console.Write("   |  ");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Computer wins");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("        |");
                    Console.WriteLine();

                    Console.WriteLine("   +-----------------------+");
                    return true;
                }

                if (score[i] == -3)
                {
                    Console.Write("   |  ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Player wins");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("          |");
                    Console.WriteLine();

                    Console.WriteLine("   +-----------------------+");
                    return true;
                }
            }

            return false;
        }
    }
}