using System;
using System.Collections.Generic;
using System.Text;

namespace greed
{
    class Core
    {
        private Controller message = new Controller();

        public Controller Message
        {
            get { return message; }
            set { message = value; }
        }

        static public void Init()
        {
            int a;
            bool end = false;
            Controller player = new Controller();
            Number[] numbers = new Number[Console.WindowWidth * Console.WindowHeight];

            //Start();

            while (!end)
            {
                a = 0;
                Console.BackgroundColor = ConsoleColor.Black;

                for (int i = 0; i < Console.WindowHeight; i++)
                {
                    for (int j = 0; j < Console.WindowWidth; j++)
                    {

                        numbers[a] = new Number(j, i);
                        a++;

                    }
                }

                player.Draw();

                Game(player, numbers);

                end = End();
            }
        }

        static public void Game(Controller player, Number[] numbers)
        {
            bool exit = false;
            int stop;
            List<Number> toDestroy = new List<Number>();

            while (!exit)
            {
                toDestroy.Clear();

                foreach (Number number in numbers)
                {
                    if (number.x == player.x && number.y + 1 == player.y && !number.isDestroyed)
                    {
                        stop = Array.IndexOf(numbers, number) - number.num * Console.WindowWidth;

                        if (number.y - number.num >= -1)
                        {
                            for (int i = Array.IndexOf(numbers, number); i > stop; i -= Console.WindowWidth)
                            {
                                if (numbers[i].isDestroyed)
                                {
                                    toDestroy.ForEach(item => { if (item.direction == "N") item.isHighlight = false; });
                                    toDestroy.RemoveAll(item => item.direction == "N");
                                    break;
                                }
                                numbers[i].direction = "N";
                                numbers[i].isHighlight = true;
                                toDestroy.Add(numbers[i]);
                            }
                        }

                    }
                    else if (number.x == player.x && number.y - 1 == player.y && !number.isDestroyed)
                    {
                        stop = Array.IndexOf(numbers, number) + number.num * Console.WindowWidth;

                        if (number.y + number.num <= Console.WindowHeight)
                        {
                            for (int i = Array.IndexOf(numbers, number); i < stop; i += Console.WindowWidth)
                            {
                                if (numbers[i].isDestroyed)
                                {
                                    toDestroy.ForEach(item => { if (item.direction == "S") item.isHighlight = false; });
                                    toDestroy.RemoveAll(item => item.direction == "S");
                                    break;
                                }
                                numbers[i].direction = "S";
                                numbers[i].isHighlight = true;
                                toDestroy.Add(numbers[i]);
                            }
                        }
                    }
                    else if (number.x + 1 == player.x && number.y == player.y && !number.isDestroyed)
                    {
                        stop = Array.IndexOf(numbers, number) - number.num;

                        if (number.x - number.num >= 0)
                        {
                            for (int i = Array.IndexOf(numbers, number); i > stop; i--)
                            {
                                if (numbers[i].isDestroyed)
                                {
                                    toDestroy.ForEach(item => { if (item.direction == "W") item.isHighlight = false; });
                                    toDestroy.RemoveAll(item => item.direction == "W");
                                    break;
                                }
                                numbers[i].direction = "W";
                                numbers[i].isHighlight = true;
                                toDestroy.Add(numbers[i]);
                            }
                        }
                    }
                    else if (number.x - 1 == player.x && number.y == player.y && !number.isDestroyed)
                    {
                        stop = Array.IndexOf(numbers, number) + number.num;

                        if (number.x + number.num <= Console.WindowWidth)
                        {
                            for (int i = Array.IndexOf(numbers, number); i < stop; i++)
                            {
                                if (numbers[i].isDestroyed)
                                {
                                    toDestroy.ForEach(item => { if (item.direction == "E") item.isHighlight = false; });
                                    toDestroy.RemoveAll(item => item.direction == "E");
                                    break;
                                }
                                numbers[i].direction = "E";
                                numbers[i].isHighlight = true;
                                toDestroy.Add(numbers[i]);
                            }
                        }
                    }
                    else if (number.x == player.x + 1 && number.y == player.y - 1 && !number.isDestroyed)
                    {
                        stop = Array.IndexOf(numbers, number) - (number.num - 1) * Console.WindowWidth;

                        if (number.x + number.num <= Console.WindowWidth && number.y - number.num >= 0)
                        {
                            for (int i = Array.IndexOf(numbers, number); i > stop; i -= Console.WindowWidth - 1)
                            {
                                if (numbers[i].isDestroyed)
                                {
                                    toDestroy.ForEach(item => { if (item.direction == "NE") item.isHighlight = false; });
                                    toDestroy.RemoveAll(item => item.direction == "NE");
                                    break;
                                }
                                numbers[i].direction = "NE";
                                numbers[i].isHighlight = true;
                                toDestroy.Add(numbers[i]);
                            }
                        }
                    }
                    else if (number.x == player.x + 1 && number.y == player.y + 1 && !number.isDestroyed)
                    {
                        stop = Array.IndexOf(numbers, number) + number.num * Console.WindowWidth;

                        if (number.x + number.num <= Console.WindowWidth && number.y + number.num <= Console.WindowHeight)
                        {
                            for (int i = Array.IndexOf(numbers, number); i < stop; i += Console.WindowWidth + 1)
                            {
                                if (numbers[i].isDestroyed)
                                {
                                    toDestroy.ForEach(item => { if (item.direction == "SE") item.isHighlight = false; });
                                    toDestroy.RemoveAll(item => item.direction == "SE");
                                    break;
                                }
                                numbers[i].direction = "SE";
                                numbers[i].isHighlight = true;
                                toDestroy.Add(numbers[i]);
                            }
                        }
                    }
                    else if (number.x == player.x - 1 && number.y == player.y + 1 && !number.isDestroyed)
                    {
                        stop = Array.IndexOf(numbers, number) + (number.num - 1) * Console.WindowWidth;

                        if (number.x - number.num >= 0 && number.y + number.num <= Console.WindowHeight)
                        {
                            for (int i = Array.IndexOf(numbers, number); i < stop; i += Console.WindowWidth - 1)
                            {
                                if (numbers[i].isDestroyed)
                                {
                                    toDestroy.ForEach(item => { if (item.direction == "SW") item.isHighlight = false; });
                                    toDestroy.RemoveAll(item => item.direction == "SW");
                                    break;
                                }
                                numbers[i].direction = "SW";
                                numbers[i].isHighlight = true;
                                toDestroy.Add(numbers[i]);
                            }
                        }
                    }
                    else if (number.x == player.x - 1 && number.y == player.y - 1 && !number.isDestroyed)
                    {
                        stop = Array.IndexOf(numbers, number) - number.num * Console.WindowWidth;

                        if (number.x - number.num >= 0 && number.y - number.num >= 0)
                        {
                            for (int i = Array.IndexOf(numbers, number); i > stop; i -= Console.WindowWidth + 1)
                            {
                                if (numbers[i].isDestroyed)
                                {
                                    toDestroy.ForEach(item => { if (item.direction == "NW") item.isHighlight = false; });
                                    toDestroy.RemoveAll(item => item.direction == "NW");
                                    break;
                                }
                                numbers[i].direction = "NW";
                                numbers[i].isHighlight = true;
                                toDestroy.Add(numbers[i]);
                            }
                        }
                    }
                }

                if (toDestroy.Count > 0)
                {
                    ConsoleKeyInfo input = Console.ReadKey();
                    switch (input.Key)
                    {
                        case ConsoleKey.Escape:
                            exit = true;
                            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                            break;
                        case ConsoleKey.UpArrow:
                            destroy("N", toDestroy, player);
                            player.Draw();
                            break;
                        case ConsoleKey.DownArrow:
                            destroy("S", toDestroy, player);
                            player.Draw();
                            break;
                        case ConsoleKey.RightArrow:
                            destroy("E", toDestroy, player);
                            player.Draw();
                            break;
                        case ConsoleKey.LeftArrow:
                            destroy("W", toDestroy, player);
                            player.Draw();
                            break;
                        case ConsoleKey.A:
                            destroy("NW", toDestroy, player);
                            player.Draw();
                            break;
                        case ConsoleKey.S:
                            destroy("NE", toDestroy, player);
                            player.Draw();
                            break;
                        case ConsoleKey.X:
                            destroy("SE", toDestroy, player);
                            player.Draw();
                            break;
                        case ConsoleKey.Z:
                            destroy("SW", toDestroy, player);
                            player.Draw();
                            break;
                            break;
                    }
                }
                else
                {
                    Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
                    exit = true;
                }

            }
        }

        static void destroy(string dir, List<Number> arr, Controller c)
        {
            foreach (Number numToDestroy in arr)
            {
                if (numToDestroy.direction == dir)
                {
                    numToDestroy.Destroy();
                    numToDestroy.isDestroyed = true;
                    c.Erase();
                    c.x = numToDestroy.x;
                    c.y = numToDestroy.y;
                }
                else
                {
                    numToDestroy.isHighlight = false;
                }
            }
        }

        static bool End()
        {
            int startX = Console.WindowWidth / 2 - 15;
            int startY = Console.WindowHeight / 2 - 4;
            bool choosed = false;
            bool playAgain = true;

            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.SetCursorPosition(startX + j, startY + i);
                    Console.Write(" ");
                }
            }

            Console.SetCursorPosition(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2 - 2);
            Console.Write("Play again?");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2 + 2);
            Console.Write("Yes");
            Console.SetCursorPosition(Console.WindowWidth / 2 + 6, Console.WindowHeight / 2 + 2);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write("No");

            while (!choosed)
            {
                ConsoleKeyInfo decision = Console.ReadKey();

                switch (decision.Key)
                {
                    case ConsoleKey.LeftArrow:
                        Console.SetCursorPosition(Console.WindowWidth / 2 + 6, Console.WindowHeight / 2 + 2);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("No.");
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2 + 2);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("Yes");
                        Console.BackgroundColor = ConsoleColor.Black;
                        playAgain = false;
                        break;
                    case ConsoleKey.RightArrow:
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2 + 2);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("Yes");
                        Console.SetCursorPosition(Console.WindowWidth / 2 + 6, Console.WindowHeight / 2 + 2);
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write("No.");
                        Console.BackgroundColor = ConsoleColor.Black;
                        playAgain = true;
                        break;
                    case ConsoleKey.Enter:
                        choosed = true;
                        break;
                }
            }

            return playAgain;
        }
    }
}
