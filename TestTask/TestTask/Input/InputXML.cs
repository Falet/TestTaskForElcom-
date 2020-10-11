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
                XmlReader r = XmlReader.Create(URLString);
                while (r.NodeType != XmlNodeType.Element)
                    r.Read();
                XElement e = XElement.Load(r);
                return e;
            }
            catch
            {
                return null;
            }
        }
    }
}
