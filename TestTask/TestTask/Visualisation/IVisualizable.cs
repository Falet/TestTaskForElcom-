using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Drawing;

namespace TestTask
{
    //Интерфейс на случай другого метода визуализации
    interface IVisualizable
    {
        Bitmap Visualisation(ElementXMLInTree ElementForVisualisation, Bitmap bmp);
    }
}
