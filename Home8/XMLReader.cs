using System;
using System.IO;
using System.Xml.Linq;

namespace Home8
{
    public class XMLReader
    {
        private const string fileName = "TelephoneBook.xml";
        private const string root = "MyContacts";
        private const string tag = "Contact";
        private const string attribute = "TelephoneNumber";

        public void ReadXML()
        {
            if (File.Exists(fileName))
            {
                XDocument xDocument = XDocument.Load(fileName);

                Console.WriteLine("Root element: " + xDocument.Element(root).Name);
                Console.WriteLine("In root tag with array: " + xDocument.Element(root).Element(tag).Name);

                foreach (XElement element in xDocument.Element(root).Elements(tag))
                {
                    string name = element.Value;
                    string telephoneNumber = element.Attribute(attribute).Value;
                    Console.WriteLine("Name: " + name + " number: " + telephoneNumber);
                }
            }
        }

        public long GetPhoneByName(string name)
        {
            if (!string.IsNullOrEmpty(name) && File.Exists(fileName))
            {
                XDocument xDocument = XDocument.Load(fileName);

                foreach (XElement element in xDocument.Element(root).Elements(tag))
                {
                    if (element.Value.Equals(name))
                    {
                        try
                        {
                            return long.Parse(element.Attribute(attribute).Value);
                        }
                        catch
                        {
                            return 0;
                        }
                    }
                }
            }

            return 0;
        }
    }
}
