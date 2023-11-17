using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static int screenWidth = 40;
    static int screenHeight = 20;

    static int paddleLength = 5;
    static int paddleX;
    static int paddleY;

    static int ballX;
    static int ballY;
    static int ballDirectionX = 1;
    static int ballDirectionY = 1;

    static List<Block> blocks;

    static bool isGameOver = false;

    class Block
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsActive { get; set; }

        public Block(int x, int y)
        {
            X = x;
            Y = y;
            IsActive = true;
        }
    }

    static void Main()
    {
        Console.WindowHeight = screenHeight;
        Console.WindowWidth = screenWidth;
        Console.BufferHeight = screenHeight;
        Console.BufferWidth = screenWidth;

        InitializeGame();

        while (!isGameOver)
        {
            Draw();
            HandleInput();
            MoveBall();
            CheckCollision();
            UpdateBlocks();
            Thread.Sleep(50);
        }

        Console.Clear();
        Console.WriteLine("Game Over!");
        Console.ReadLine();
    }

    static void InitializeGame()
    {
        paddleX = screenWidth / 2 - paddleLength / 2;
        paddleY = screenHeight - 1;

        ballX = screenWidth / 2;
        ballY = screenHeight - 2;

        blocks = new List<Block>();

        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < screenWidth; x += 4)
            {
                blocks.Add(new Block(x, y));
            }
        }
    }

    static void Draw()
    {
        Console.Clear();

        // Draw paddle
        for (int i = 0; i < paddleLength; i++)
        {
            Console.SetCursorPosition(paddleX + i, paddleY);
            Console.Write("=");
        }

        // Draw ball
        Console.SetCursorPosition(ballX, ballY);
        Console.Write("O");

        // Draw blocks
        foreach (var block in blocks.Where(b => b.IsActive))
        {
            Console.SetCursorPosition(block.X, block.Y);
            Console.Write("■");
        }
    }

    static void HandleInput()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (paddleX > 0)
                        paddleX--;
                    break;
                case ConsoleKey.RightArrow:
                    if (paddleX < screenWidth - paddleLength)
                        paddleX++;
                    break;
            }
        }
    }

    static void MoveBall()
    {
        ballX += ballDirectionX;
        ballY += ballDirectionY;

        // Bounce off walls
        if (ballX == 0 || ballX == screenWidth - 1)
            ballDirectionX = -ballDirectionX;

        if (ballY == 0)
            ballDirectionY = -ballDirectionY;

        // Check if the ball hits the paddle
        if (ballY == paddleY - 1 && ballX >= paddleX && ballX < paddleX + paddleLength)
            ballDirectionY = -ballDirectionY;

        // Check if the ball hits blocks
        foreach (var block in blocks.Where(b => b.IsActive))
        {
            if (ballX == block.X && ballY == block.Y)
            {
                block.IsActive = false;
                ballDirectionY = -ballDirectionY;
            }
        }

        // Check if the ball hits the bottom of the screen
        if (ballY == screenHeight - 1)
            isGameOver = true;
    }

    static void CheckCollision()
    {
        // Check if all blocks are cleared
        if (blocks.All(b => !b.IsActive))
            isGameOver = true;
    }

    static void UpdateBlocks()
    {
        // Add new row of blocks if needed
        if (blocks.All(b => !b.IsActive))
        {
            for (int x = 0; x < screenWidth; x += 4)
            {
                blocks.Add(new Block(x, 0));
            }
        }
    }
}
