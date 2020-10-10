using System;
using System.Xml.Linq;

namespace TestTask
{
    //Интерфейс на случай ввода разных форматов(Json...) или разного способа ввода,например с файла
    interface Iinput
    {
        XElement InputDataUsingURL(String URL);
    }
}
