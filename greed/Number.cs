using System;
using System.Collections.Generic;
using System.Text;

namespace greed
{
    class Number
    {
        private int Num;
        private int X;
        private int Y;
        private string Direction;
        private bool IsHighlight;
        private bool IsDestroyed;

        public Number(int x, int y)
        {
            var rand = new Random();
            Num = rand.Next(1, 10);
            X = x;
            Y = y;
            IsDestroyed = false;

            Draw();
        }

        public int x
        {
            get { return X; }
        }

        public int y
        {
            get { return Y; }
        }

        public int num
        {
            get { return Num; }
        }

        public string direction
        {
            get { return Direction; }
            set { Direction = value; }
        }

        public bool isHighlight
        {
            get { return IsHighlight; }
            set
            {
                IsHighlight = value;
                Highlight();
            }
        }


        public bool isDestroyed
        {
            get { return IsDestroyed; }
            set { IsDestroyed = value; }
        }

        private void Draw()
        {
            Console.SetCursorPosition(X, Y);
            ChooseColor();
            Console.Write(Num);
        }

        public void Destroy()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(num);
        }

        private void Highlight()
        {
            if (isHighlight)
            {
                Console.SetCursorPosition(X, Y);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(Num);
                Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.SetCursorPosition(X, Y);
                Console.BackgroundColor = ConsoleColor.Black;
                ChooseColor();
                Console.Write(Num);
            }
        }

        private void ChooseColor()
        {
            switch (Num)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 6:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case 8:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 9:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
        }
    }
}
