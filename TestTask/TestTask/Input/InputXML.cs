using System;
using System.Xml;
using System.Xml.Linq;

namespace TestTask
{
    class InputXML: Iinput
    {
        /// <summary>
        /// Скачивание и подготовка XML файла
        /// </summary>
        /// <param name="URLString">Срока URL</param>
        /// <returns></returns>
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
