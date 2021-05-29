using System;
using System.Threading;

namespace Home11
{
    public class Matrix
    {
        private readonly char[] chars = "$%#!*abcdefghijklmnopqrstuvwxyz1234567890?:^&▲▼".ToCharArray();
        private readonly Random random;
        private readonly int width;
        private readonly int height;
        private volatile char[,] matrix;
        private const ConsoleColor firstColor = ConsoleColor.White;
        private const ConsoleColor secondColor = ConsoleColor.Green;
        private const ConsoleColor otherColor = ConsoleColor.DarkGreen;
        private const char emptyChar = ' ';
        private const int sleepTime = 50;
        private const int minLenghtStripe = 7;

        private char GetRandomChar => chars[random.Next(chars.Length)];

        private void StripeChange(object index)
        {
            int column = (int)index;
            int stripeLenght = -1;

            while (true)
            {
                Thread.Sleep(sleepTime);

                if (stripeLenght < 0)
                    stripeLenght = random.Next(minLenghtStripe, height - minLenghtStripe);

                lock (matrix)
                {
                    if (StripeIsEmpty(column))
                    {
                        char c = GetRandomChar;
                        matrix[0, column] = c;
                        WriteChar(c, column, 0, firstColor);
                    }
                    else
                    {
                        for (int row = height - 1; row >= 0; row--)
                        {
                            if (!matrix[row, column].Equals(emptyChar))
                            {
                                if (row - stripeLenght >= 0)
                                    DeleteChar(column, row - stripeLenght);

                                if (row != height - 1)
                                {
                                    char c = GetRandomChar;
                                    matrix[row + 1, column] = c;
                                    WriteChar(c, column, row + 1, firstColor);
                                    WriteChar(matrix[row, column], column, row, secondColor);

                                    if (row - 1 >= 0)
                                        WriteChar(matrix[row - 1, column], column, row - 1, otherColor);
                                }
                                else
                                {
                                    stripeLenght--;
                                }

                                break;
                            }
                        }
                    }
                }
            }
        }

        private void WriteChar(char c, int left, int top, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(left, top);
            Console.Write(c);
        }

        private void DeleteChar(int left, int top)
        {
            matrix[top, left] = emptyChar;
            Console.SetCursorPosition(left, top);
            Console.Write(emptyChar);
        }

        private bool StripeIsEmpty(int index)
        {
            for (int row = 0; row < height; row++)
                if (!matrix[row, index].Equals(emptyChar))
                    return false;

            return true;
        }

        public Matrix()
        {
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.CursorVisible = false;
            random = new Random();
            width = Console.WindowWidth;
            height = Console.WindowHeight;
            matrix = new char[height, width];

            for (int row = 0; row < height; row++)
                for (int column = 0; column < width; column++)
                    matrix[row, column] = emptyChar;

            for (int column = 0; column < width; column++)
                new Thread(StripeChange).Start(column);
        }
    }
}
