using System;

namespace ByteBee.TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] field = new int[3, 3];
            
            Console.CursorVisible = false;
            ConsoleKey key = ConsoleKey.NoName;

            do
            {
                DrawField(field);

                key = Console.ReadKey().Key;

                if (key == ConsoleKey.NumPad1)
                    field[2, 0] = -1;
                if (key == ConsoleKey.NumPad2)
                    field[2, 1] = -1;
                if (key == ConsoleKey.NumPad3)
                    field[2, 2] = -1;
                if (key == ConsoleKey.NumPad4)
                    field[1, 0] = -1;
                if (key == ConsoleKey.NumPad5)
                    field[1, 1] = -1;
                if (key == ConsoleKey.NumPad6)
                    field[1, 2] = -1;
                if (key == ConsoleKey.NumPad7)
                    field[0, 0] = -1;
                if (key == ConsoleKey.NumPad8)
                    field[0, 1] = -1;
                if (key == ConsoleKey.NumPad9)
                    field[0, 2] = -1;

            } while (key != ConsoleKey.Escape);
        }

        static void DrawField(int[,] field)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("   +-------+-------+-------+");

            for (int i = 0; i < 3; i++)
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
    }
}