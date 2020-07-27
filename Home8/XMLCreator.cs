using System.IO;
using System.Xml.Linq;

namespace Home8
{
    public class XMLCreator
    {
        private const string fileName = "TelephoneBook.xml";
        private const string root = "MyContacts";
        private const string tag = "Contact";
        private const string attribute = "TelephoneNumber";

        public void CreateTelephoneBook(string name, long telephoneNumber)
        {
            XDocument xDoc = new XDocument();
            XElement rootElement = new XElement(root);
            XElement contact = new XElement(tag, name);

            contact.SetAttributeValue(attribute, telephoneNumber);
            rootElement.Add(contact);
            xDoc.Add(rootElement);
            xDoc.Save(fileName);
        }

        public void AddContact(string name, long telephoneNumber)
        {
            if (File.Exists(fileName) && !string.IsNullOrEmpty(name))
            {
                XDocument xDoc = XDocument.Load(fileName);
                XElement rootElement = xDoc.Element(root);
                XElement contact = new XElement(tag, name);

                contact.SetAttributeValue(attribute, telephoneNumber);
                rootElement.Add(contact);
                xDoc.Save(fileName);
            }
        }
    }
}
