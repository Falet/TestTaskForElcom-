using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace TestTask
{
    /// <summary>
    /// Односвязный список элементов дерева,листьями которого являются элементы XML
    /// </summary>
    class ElementXMLInTree
    {
        public ElementXMLInTree(XName CurrentName)
        {
            NameOfElement = CurrentName;
            Attributes = null;
            Childs = null;
            HeightAtPixel = 0;
            WidthAtPixel = 20;
        }
        public XName NameOfElement;
        public List<XAttribute> Attributes;
        public List<ElementXMLInTree> Childs;
        public float HeightAtPixel;
        public float WidthAtPixel;
    }
    class ParserXML: IParserable 
    {
        /// <summary>
        /// Основаная функция для парсинга XML
        /// </summary>
        /// <param name="ParsedXml">Общий массив элементов XML</param>
        public ElementXMLInTree Parse(XElement ParsedXml)
        {
            ElementXMLInTree Root = new ElementXMLInTree(ParsedXml.Name);
            if (ParsedXml.HasAttributes == true)
            {
                Root.Attributes = new List<XAttribute>();
                foreach (XAttribute element in ParsedXml.Attributes())
                {
                    Root.Attributes.Add(element);
                }
            }
            if (ParsedXml.HasElements == true)
            {
                Root.Childs = new List<ElementXMLInTree>();
                NextSearchChildsForParent(Root, ParsedXml);
            }
            return Root;
        }
        /// <summary>
        /// Рекурсивная функция для создания ссылок на дочерние элементы в односвязном списке
        /// </summary>
        /// <param name="Parent">Родитель текущей структуры</param>
        /// <param name="Childs">Дочерние элементы текущей структуры</param>
        private void NextSearchChildsForParent(ElementXMLInTree Parent, XElement Childs)
        {
            IEnumerable<XElement> ElementsXML = Childs.Elements();
            foreach (XElement currentElement in ElementsXML)
            {
                ElementXMLInTree currentElementForTree = new ElementXMLInTree(currentElement.Name);
                Parent.Childs.Add(currentElementForTree);
                if(currentElement.HasAttributes == true)
                {
                    currentElementForTree.Attributes = new List<XAttribute>();
                    foreach (XAttribute element in currentElement.Attributes())
                    {
                        currentElementForTree.Attributes.Add(element);
                    }
                }
                if (currentElement.HasElements == true)
                {
                    currentElementForTree.Childs = new List<ElementXMLInTree>();
                    NextSearchChildsForParent(currentElementForTree, currentElement);
                }
            }
        }
    }
}
