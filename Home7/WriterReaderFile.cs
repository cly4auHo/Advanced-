using System;
using System.IO;
using System.Linq;

namespace Home7
{
    public class WriterReaderFile
    {
        private static char[] wrongCharactersForNameFile = { '/', '\\', ':', '*', '?', '«', '<', '>', '|' };
        private const string testFolderPath = @"D:\Test\";

        public static void Main(string[] args)
        {
            Console.WriteLine("Write name of file");
            string path;

            while (true)
            {
                string name = Console.ReadLine();
                name = name.Trim();

                if (CheckPathHaveWrongChar(name))
                {
                    Console.WriteLine("Wrong characters");
                    continue;
                }
                else if (string.IsNullOrEmpty(name))
                {
                    name = "DEFAULT_NAME";
                }

                path = testFolderPath + name + ".txt";
                break;
            }

            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    Console.WriteLine("Press CTRL + Enter to end");

                    while (true)
                    {
                        sw.WriteLine(Console.ReadLine());

                        if (Console.ReadKey(true).Modifiers.HasFlag(ConsoleModifiers.Control))
                            break;
                    }
                }
            }

            Console.WriteLine("Press any button to open file");
            Console.ReadKey();

            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string text;

                    while ((text = sr.ReadLine()) != null)
                        Console.WriteLine(text);
                }
            }

            Console.ReadKey();
        }

        private static bool CheckPathHaveWrongChar(string path)
        {
            foreach (char item in wrongCharactersForNameFile)
                if (path.Contains(item))
                    return true;

            return false;
        }
    }
}
