using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace TestTask
{
    public struct ElementXMLInTree
    //Односвязный список элементов дерева,листьями которого являются элементы XML
    {
        public ElementXMLInTree(XName CurrentName)
        {
            NameOfElement = CurrentName;
            Attributes = null;
            Childs = null;
        }
        public XName NameOfElement;
        public IEnumerable<XAttribute> Attributes;
        public List<ElementXMLInTree> Childs;
    }
    class ParserXML: IParserable
    {
        
        public void Parse(XElement ParsedXml)
        //Основаная функция для парсинга XML
        {
            ElementXMLInTree Root = new ElementXMLInTree(ParsedXml.Name);
            if (ParsedXml.HasAttributes == true)
                Root.Attributes = ParsedXml.Attributes();
            if (ParsedXml.HasElements == true)
            {
                Root.Childs = new List<ElementXMLInTree>();
                NextSearchChildsForParent(Root, ParsedXml);
            }
                
        }
        private void NextSearchChildsForParent(ElementXMLInTree Parent, XElement Childs)
        //Рекурсивная функция для создания ссылок на дочерние элементы в односвязном списке
        {
            IEnumerable<XElement> ElementsXML = Childs.Elements();
            foreach (XElement currentElement in ElementsXML)
            {
                ElementXMLInTree currentElementForTree = new ElementXMLInTree(currentElement.Name);
                Parent.Childs.Add(currentElementForTree);
                if(currentElement.HasAttributes == true)
                    Parent.Attributes = currentElement.Attributes();
                if (currentElement.HasElements == true)
                {
                    currentElementForTree.Childs = new List<ElementXMLInTree>();
                    NextSearchChildsForParent(currentElementForTree, currentElement);
                }
            }
        }
    }
}
