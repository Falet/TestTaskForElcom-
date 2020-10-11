using System;
using System.Xml;
using System.Xml.Linq;

namespace TestTask
{
    class InputXML: Iinput
    {
        public XElement InputDataUsingURL(String URLString)
        {
            try
            {
                XmlReader XMLOnURL = XmlReader.Create(URLString);
                while (XMLOnURL.NodeType != XmlNodeType.Element)
                    XMLOnURL.Read();
                XElement ResultXML = XElement.Load(XMLOnURL);
                return ResultXML;
            }
            catch
            {
                return null;
            }
        }
    }
}
