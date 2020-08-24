using System;
using System.Threading;

namespace Home11
{
    public class Matrix
    {
        private readonly char[] chars = "$%#!*abcdefghijklmnopqrstuvwxyz1234567890?:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
        private readonly Random random = new Random();
        private readonly object locker = new object();
        private readonly int width;
        private readonly int height;
        private static volatile char[,] matrix;
        private const ConsoleColor firstColor = ConsoleColor.White;
        private const ConsoleColor secondColor = ConsoleColor.Green;
        private const ConsoleColor otherColor = ConsoleColor.DarkGreen;
        private const char emptyChar = ' ';
        private const int sleepTime = 100;
        private const int minLenghtStripe = 7;

        private void StripeChange(object index)
        {
            int column = (int)index;
            int stripeLenght = -1;

            while (true)
            {
                Thread.Sleep(sleepTime);

                if (stripeLenght < 0)
                    stripeLenght = random.Next(minLenghtStripe, height - minLenghtStripe);

                lock (locker)
                {
                    for (int row = height - 1; row >= 0; row--)
                    {
                        if (StripeIsEmpty(column))
                        {
                            Console.SetCursorPosition(column, 0);
                            Console.ForegroundColor = firstColor;
                            char c = GetRandomChar();
                            matrix[0, column] = c;
                            Console.Write(c);
                            break;
                        }
                        else if (matrix[row, column].Equals(emptyChar))
                        {
                            continue;
                        }
                        else
                        {
                            if (row + 1 < height)
                            {
                                char c = GetRandomChar();
                                matrix[row + 1, column] = c;
                                WriteChar(c, column, row + 1, firstColor);
                            }

                            if (row < height)
                            {
                                WriteChar(matrix[row, column], column, row, secondColor);
                            }

                            if (row - 1 < height && row - 1 >= 0)
                            {
                                WriteChar(matrix[row - 1, column], column, row - 1, otherColor);
                            }


                            if (row - stripeLenght - 1 >= 0)
                            {
                                DeleteChar(column, row - stripeLenght - 1);
                            }

                            if (!matrix[height - 1, column].Equals(emptyChar))
                            {
                                DeleteChar(column, row - stripeLenght);
                                stripeLenght--;
                            }

                            break;
                        }
                    }

                    if (StripeIsEmpty(column))
                        stripeLenght = -1;
                }
            }
        }

        private void WriteChar(char c, int left, int top, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(left, top);
            Console.Write(c);
        }

        private char GetRandomChar()
        {
            return chars[random.Next(chars.Length)];
        }

        private bool StripeIsEmpty(int index)
        {
            for (int row = 0; row < height; row++)
                if (!matrix[row, index].Equals(emptyChar))
                    return false;

            return true;
        }

        private void DeleteChar(int left, int top)
        {
            matrix[top, left] = emptyChar;
            Console.SetCursorPosition(left, top);
            Console.Write(emptyChar);
        }

        public Matrix()
        {
            width = Console.WindowWidth;
            height = Console.WindowHeight;
            matrix = new char[height, width];
            Console.CursorVisible = false;

            for (int row = 0; row < height; row++)
                for (int column = 0; column < width; column++)
                    matrix[row, column] = emptyChar;

            for (int column = 0; column < width; column++)
                new Thread(StripeChange).Start(column);
        }
    }
}