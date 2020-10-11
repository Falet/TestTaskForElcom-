using System.Drawing;

namespace TestTask
{
    //Интерфейс на случай другого метода визуализации
    interface IVisualizable
    {
        Bitmap Visualisation(ElementXMLInTree ElementForVisualisation, float SetHeightOfElement);
    }
}
