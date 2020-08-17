using System;
using System.Threading;

namespace Home11
{
    public class Matrix
    {
        private readonly char[] chars;
        private readonly Random random;
        private readonly int width;
        private readonly int height;
        private readonly object locker;
        private static volatile Barrier barrier;
        private static volatile char[,] matrix;
        private const ConsoleColor firstColor = ConsoleColor.White;
        private const ConsoleColor secondColor = ConsoleColor.Green;
        private const ConsoleColor otherColor = ConsoleColor.DarkGreen;
        private const ConsoleColor emptyColor = ConsoleColor.Black;
        private const char emptyChar = ' ';
        private const int sleepTime = 200;
        private const int minLenghtStripe = 7;

        private void StripeChange(object index)
        {
            int column = (int)index;
            int stripeLenght = random.Next(minLenghtStripe, height - minLenghtStripe);

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
                                Console.ForegroundColor = firstColor;
                                Console.SetCursorPosition(column, row + 1);
                                char c = GetRandomChar();
                                matrix[row + 1, column] = c;
                                Console.Write(c);
                            }

                            if (row < height)
                            {
                                Console.ForegroundColor = secondColor;
                                Console.SetCursorPosition(column, row);
                                Console.Write(matrix[row, column]);
                            }

                            if (row - 1 < height && row - 1 >= 0)
                            {
                                Console.ForegroundColor = otherColor;
                                Console.SetCursorPosition(column, row - 1);
                                Console.Write(matrix[row - 1, column]);
                            }

                            if (stripeLenght > 0)
                            {
                                if (row - stripeLenght - 1 >= 0)
                                {
                                    matrix[row - stripeLenght - 1, column] = emptyChar;
                                    DeleteChar(column, row - stripeLenght - 1);
                                }
                            }
                            else
                            {
                                matrix[height - 1, column] = emptyChar;
                                DeleteChar(column, height - 1);
                            }

                            if (!matrix[height - 1, column].Equals(emptyChar))
                            {
                                matrix[row - stripeLenght, column] = emptyChar;
                                DeleteChar(column, row - stripeLenght);
                                stripeLenght--;
                            }

                            break;
                        }
                    }

                    if (StripeIsEmpty(column))
                        stripeLenght = -1;
                }

                barrier.SignalAndWait();
            }
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
            Console.SetCursorPosition(left, top);
            Console.ForegroundColor = emptyColor;
            Console.Write(emptyChar);
        }

        public Matrix()
        {
            chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
            random = new Random();
            locker = new object();
            width = Console.WindowWidth;
            height = Console.WindowHeight;
            barrier = new Barrier(width);
            matrix = new char[height, width];
            Console.WindowLeft = Console.WindowTop = 0;
            Console.SetWindowPosition(0, 0);
            Console.CursorVisible = false;

            for (int row = 0; row < height; row++)
                for (int column = 0; column < width; column++)
                    matrix[row, column] = emptyChar;

            for (int column = 0; column < width; column++)
                new Thread(StripeChange).Start(column);
        }
    }
}