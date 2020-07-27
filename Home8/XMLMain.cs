using System;

namespace Home8
{
    public class XMLMain
    {
        public static void Main(string[] args)
        {
            XMLCreator creator = new XMLCreator();
            XMLReader reader = new XMLReader();

            creator.CreateTelephoneBook("GGfff", 380557778841);
            creator.AddContact("kek", 1);
            creator.AddContact("kek", 1);
            reader.ReadXML();
            Console.WriteLine(reader.GetPhoneByName("GGfff"));
            Console.ReadKey();
        }
    }
}
