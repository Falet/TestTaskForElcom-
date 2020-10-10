using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace TestTask
{
    //Интерфейс на случай парсинга разных форматов(Json...)
    interface IParserable
    {
        ElementXMLInTree Parse(XElement ParsedData);
    }
}
