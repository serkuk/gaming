using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
            ConsoleKey key = ConsoleKey.NoName;

            do
            {
                try
                {
                    DrawField(field);

                    key = Console.ReadKey(true).Key;

                    PlayerMove(field, key);
                    CpuMove(field);

                    Task.Delay(1000);

                    bool gameOver = CheckForWinner(field);

                    if (gameOver)
                    {
                        Console.ReadKey(true);

                        field = new int[3, 3];
                        _unUsedFields = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
                    }
                }
                catch (Exception e)
                {
                }
            }
            while (key != ConsoleKey.Escape);
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
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("   +-----------------------+");
            Console.WriteLine("   |      Tic-Tac-Toe      |");
            Console.WriteLine("   +-------+-------+-------+");

            for (int i = 2; i >= 0; i--)
            {
                Console.WriteLine("   |       |       |       |");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("   |   ");

                    int v = field[i, j];

                    // player selection
                    if (v == -1)
                    {
                        Console.Write("x");
                    }
                    // computer selection
                    else if (v == 1)
                    {
                        Console.Write("o");
                    }
                    // free field
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

            // the user should not be able to make the same move twice
            if (!_unUsedFields.Contains(playerChoise))
                throw new Exception();

            // determine the field coordinate
            int x = playerChoise / 3;
            int y = playerChoise % 3;
            
            // make the move
            field[x, y] = -1;

            // removes current field possible values
            _unUsedFields.Remove(playerChoise);
        }

        static void CpuMove(int[,] field)
        {
            // generates a random possible move for the computer
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int cpuIndex = rnd.Next(_unUsedFields.Count);
            int cpuChoise = _unUsedFields[cpuIndex];

            // determine the field coordinate
            int x = cpuChoise / 3;
            int y = cpuChoise % 3;

            // make the move
            field[x, y] = 1;

            // removes current field possible values
            _unUsedFields.Remove(cpuChoise);
        }

        static bool CheckForWinner(int[,] field)
        {
            int[] score = new int[8];

            // sum up all possible winning possibilities
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
                // if the computer got 3 in a row, the computer wins the match
                if (score[i] == 3)
                {
                    Console.WriteLine("   |  Computer wins        |");
                    Console.WriteLine("   +-----------------------+");
                    return true;
                }

                // if the player got 3 in a row, the computer wins the match
                if (score[i] == -3)
                {
                    Console.WriteLine("   |  Player wins          |");
                    Console.WriteLine("   +-----------------------+");
                    return true;
                }
            }

            return false;
        }
    }
}