using System;
using System.Collections.Generic;
using System.Text;

namespace greed
{
    class Controller
    {
        private string icon = "@";
        private int X;
        private int Y;

        public string Lol { get; set; }

        public Controller()
        {
            var rand = new Random();
            X = rand.Next(Console.WindowWidth);
            Y = rand.Next(Console.WindowHeight);
            Draw();
        }

        public int x
        {
            get { return X; }
            set { X = value; }
        }

        public int y
        {
            get { return Y; }
            set { Y = value; }
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(icon);
        }

        public void Erase()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}
