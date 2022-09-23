using System;

class Print
{
    public static void GameOver(in int score)
    {
        bool flagOut = false;
        int current = 0;
        Console.ForegroundColor = ConsoleColor.White;
        for (int i = 39; i < 79; i++)
        {
            for (int j = 9; j <= 19; j++)
            {
                Console.SetCursorPosition(i, j);
                Console.Write('*');
            }
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        string temp = score.ToString();
        if (temp.Length % 2 == 0)
            temp = "Youre score:" + temp;
        else
            temp = "Youre score: " + temp;
        Console.SetCursorPosition(39 + (40 - temp.Length) / 2, 11);
        Console.Write(temp);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(53, 14);
        Console.Write("Restart game");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(57, 17);
        Console.Write("Exit");

        while (true)
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.W)
                {
                    if (current == 0)
                        current = 1;
                    else
                        current--;
                    Console.ForegroundColor = current == 0 ? ConsoleColor.Yellow : ConsoleColor.Blue;
                    Console.SetCursorPosition(53, 14);
                    Console.Write("Restart game");
                    Console.ForegroundColor = current == 1 ? ConsoleColor.Yellow : ConsoleColor.Blue;
                    Console.SetCursorPosition(57, 17);
                    Console.Write("Exit");
                }
                else if (pressedKey.Key == ConsoleKey.S)
                {
                    if (current == 1)
                        current = 0;
                    else
                        current++;
                    Console.ForegroundColor = current == 0 ? ConsoleColor.Yellow : ConsoleColor.Blue;
                    Console.SetCursorPosition(53, 14);
                    Console.Write("Restart game");
                    Console.ForegroundColor = current == 1 ? ConsoleColor.Yellow : ConsoleColor.Blue;
                    Console.SetCursorPosition(57, 17);
                    Console.Write("Exit");

                }
                else if (pressedKey.Key == ConsoleKey.Enter)
                {
                    if (current == 0)
                        flagOut = true;
                    else
                        Environment.Exit(0);
                };
            }
            if (flagOut)
                break;
        }
    }
    public static void Pause(ref bool restart)
    {
        bool flagOut = false;
        int current = 0;
        Console.ForegroundColor = ConsoleColor.White;
        for (int i = 39; i < 79; i++)
        {
            for (int j = 8; j <= 21; j++)
            {
                Console.SetCursorPosition(i, j);
                Console.Write('*');
            }
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition(54, 10);
        Console.Write("Pause game");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.SetCursorPosition(56, 13);
        Console.Write("Resume");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(53, 16);
        Console.Write("Restart game");
        Console.SetCursorPosition(57, 19);
        Console.Write("Exit");
        while (true)
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                if (pressedKey.Key == ConsoleKey.D1)
                {
                    flagOut = true;
                }
                else if (pressedKey.Key == ConsoleKey.W)
                {
                    if (current == 0)
                        current = 2;
                    else
                        current--;
                    Console.ForegroundColor = current == 0 ? ConsoleColor.Yellow : ConsoleColor.Blue;
                    Console.SetCursorPosition(56, 13);
                    Console.Write("Resume");
                    Console.ForegroundColor = current == 1 ? ConsoleColor.Yellow : ConsoleColor.Blue;
                    Console.SetCursorPosition(53, 16);
                    Console.Write("Restart game");
                    Console.ForegroundColor = current == 2 ? ConsoleColor.Yellow : ConsoleColor.Blue;
                    Console.SetCursorPosition(57, 19);
                    Console.Write("Exit");
                }
                else if (pressedKey.Key == ConsoleKey.S)
                {
                    if (current == 2)
                        current = 0;
                    else
                        current++;
                    Console.ForegroundColor = current == 0 ? ConsoleColor.Yellow : ConsoleColor.Blue;
                    Console.SetCursorPosition(56, 13);
                    Console.Write("Resume");
                    Console.ForegroundColor = current == 1 ? ConsoleColor.Yellow : ConsoleColor.Blue;
                    Console.SetCursorPosition(53, 16);
                    Console.Write("Restart game");
                    Console.ForegroundColor = current == 2 ? ConsoleColor.Yellow : ConsoleColor.Blue;
                    Console.SetCursorPosition(57, 19);
                    Console.Write("Exit");
                }
                else if (pressedKey.Key == ConsoleKey.Enter)
                {
                    if (current == 0)
                        flagOut = true;
                    else if (current == 1)
                    {
                        restart = true;
                        flagOut = true;
                    }
                    else
                        Environment.Exit(0);
                };
            }
            if (flagOut)
                break;
        }
    }
    public static void Bonus(Vector2 position, int type)
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        if (position.x > 0 && position.x < 120)
        {
            Console.SetCursorPosition(position.x, position.y);
            if (type == 1)
                Console.Write('+');
            else
                Console.Write('*');
        }
    }
    public static void Enemy(Vector2 position, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        if (position.x > 0 && position.x < 120)
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.Write('*');
        }
        if (position.x - 1 > 0 && position.x - 1 < 120)
        {
            Console.SetCursorPosition(position.x - 1, position.y);
            Console.Write('<');
        }
        if (position.x + 1 > 0 && position.x + 1 < 120)
        {
            Console.SetCursorPosition(position.x + 1, position.y);
            Console.Write('*');
            Console.SetCursorPosition(position.x + 1, position.y + 1);
            Console.Write('{');
            Console.SetCursorPosition(position.x + 1, position.y - 1);
            Console.Write('{');
        }
    }
    public static void Info(string strl, string strr)
    {
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(strl);
        Console.SetCursorPosition(119 - strr.Length, 0);
        Console.Write(strr);
    }
    public static void Player(Vector2 position)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(position.x, position.y);
        Console.Write('*');
        Console.SetCursorPosition(position.x - 1, position.y);
        Console.Write('*');
        Console.SetCursorPosition(position.x + 1, position.y);
        Console.Write('>');
        Console.SetCursorPosition(position.x - 1, position.y + 1);
        Console.Write('}');
        Console.SetCursorPosition(position.x - 1, position.y - 1);
        Console.Write('}');
    }
    public static void Projectile(Vector2 position, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        if (position.x > 0 && position.x < 120)
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.Write('¤');
        }
    }
    public static void SuperProjectile(Vector2 position)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        if (position.x > 0 && position.x < 120)
        {
            Console.SetCursorPosition(position.x, position.y);
            Console.Write('~');
        }
    }
}