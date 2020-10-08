using System;
using System.Xml;
using System.Xml.Linq;

namespace TestTask
{
    class InputXML: Iinput
    {
        public void InputDataUsingURL(String URLString)
        {
            XmlReader r = XmlReader.Create(URLString);
            while (r.NodeType != XmlNodeType.Element)
                r.Read();
            XElement e = XElement.Load(r);
            Console.WriteLine(e);
            IParserable ParseXML = new ParserXML();
            ParseXML.Parse(e);
        }
    }
}
