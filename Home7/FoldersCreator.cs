using System;
using System.IO;
using System.Collections.Generic;

namespace Home7
{
    public class FoldersCreator
    {
        private static List<string> paths = new List<string>();
        private const string testFolderPath = @"D:\Test\Folder";

        public static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
                string path = testFolderPath + i;

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    paths.Add(path);

                    Console.WriteLine("Список каталогов: ");

                    foreach (string item in Directory.GetDirectories(path))
                        Console.WriteLine(item);

                    Console.WriteLine("Cписок файлов: ");

                    foreach (string item in Directory.GetFiles(path))
                        Console.WriteLine(item);

                    Console.WriteLine("Родительский каталог: " + Directory.GetParent(path));
                }
            }

            Console.WriteLine("Press any button to delete Directories");
            Console.ReadKey();

            foreach (string path in paths)
                if (Directory.Exists(path))
                    Directory.Delete(path);
        }
    }
}
