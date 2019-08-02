using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Animation;

namespace ByteBee.BattleShip.Engine
{
    public abstract class Board : IEnumerable<Field>
    {
        private readonly Field[,] _memory = new Field[10, 10];
        public Field this[int x, int y]
        {
            get => _memory[x, y];
            protected set => _memory[x, y] = value;
        }

        public IList<Ship> Fleet { get; set; } = new List<Ship>();
        public IEnumerator<Field> GetEnumerator()
        {
            return _memory.Cast<Field>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class PlayerBoard : Board
    {

    }

    public class ComputerBoard : Board
    {
        public ComputerBoard()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    this[x, y] = new Field(x, y);
                }
            }
        }

        public void Generate()
        {
            var carrier = new Carrier(this);

            for (int i = 0; i < carrier.SizeOfTheShip; i++)
            {
                this[3, i+3].IsShip = true;
            }

            Fleet.Add(carrier);
        }
    }

    public class Field
    {
        public bool IsShip { get; set; }
        public Point Coordinate { get; private set; }

        public Field(int x, int y)
        {
            Coordinate = new Point(x, y);
            
        }
    }

    public abstract class Ship
    {
        public abstract int SizeOfTheShip { get; }
        public Board Board { get; }

        protected Ship(Board board)
        {
            Board = board;
        }
    }

    public class Carrier : Ship
    {
        public override int SizeOfTheShip { get; } = 5;

        public Carrier(Board board) : base(board)
        {
            
        }
    }

    public class Battleship : Ship
    {
        public override int SizeOfTheShip { get; } = 4;
        public Battleship(Board board) : base(board)
        {
        }
    }

    public class Cruiser : Ship
    {
        public override int SizeOfTheShip { get; } = 3;
        public Cruiser(Board board) : base(board)
        {
        }
    }

    public class Destroyer : Ship
    {
        public override int SizeOfTheShip { get; } = 2;
        public Destroyer(Board board) : base(board)
        {
        }
    }
}