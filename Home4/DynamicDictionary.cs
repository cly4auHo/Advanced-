using System;
using System.Collections.Generic;
using System.Linq;

namespace Home4
{
    public class DynamicDictionary
    {
        public static void Main(string[] args)
        {
            List<dynamic> words = new List<dynamic>()
            {
                new Vocabluary("house","дом"),
                new Vocabluary("bread","хлеб"),
                new Vocabluary("cat","кот"),
                new Vocabluary("car","авто"),
                new Vocabluary("dog","пёс"),
                new Vocabluary("year","год")
            };

            var vocabulary = from word in words
                             group word by new { Key = word.EnWord };

            foreach (var key in vocabulary)
            {
                Console.WriteLine(key.Key);

                foreach (var item in key)
                {
                    Console.WriteLine(item.RuWord);
                }
            }

            Console.ReadKey();
        }
    }

    class Vocabluary
    {
        private string enWord;
        private string ruWord;

        public string EnWord { get => enWord; set => enWord = value; }
        public string RuWord { get => ruWord; set => ruWord = value; }

        public Vocabluary(string enWord, string ruWord)
        {
            this.enWord = enWord;
            this.ruWord = ruWord;
        }
    }
}
