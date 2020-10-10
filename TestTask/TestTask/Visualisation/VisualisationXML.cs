using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Drawing;
using System.IO;

namespace TestTask
{
    class VisualisationXML: IVisualizable
    {
        private int width = 324;//12 размер 1 буквы
        private int height = 40;
        //private int x = 0;
        private int y = 0;
        private Graphics g;
        public Bitmap Visualisation(ElementXMLInTree ElementForVisualisation, Bitmap bmp)
        {
            Bitmap b2 = new Bitmap(bmp, new Size(5500, 5000));
            using (g = Graphics.FromImage(b2))
            {

                g.TranslateTransform(10, 10);
                
                Image ElementWithAttribute = Properties.Resources.ElementWithAttribute;
                width = ElementForVisualisation.NameOfElement.ToString().Length * 12;
                foreach (ElementXMLInTree element in ElementForVisualisation.Childs)
                    DrawElementOfTree(ElementForVisualisation, element, width + 50);





                //g.DrawString("Sвапываыварываываымсвывавап", new Font("Times New Roman", height*1/3), Brushes.Black, pos);

            }
            return b2;
        }
        private void DrawElementOfTree(ElementXMLInTree ElementTreeParent,ElementXMLInTree ElementTreeChild,int x)
        {
            width = ElementTreeChild.NameOfElement.ToString().Length * 12;
            PointF pos = new PointF(x + width / 8.5f, y + height / 4);
            g.DrawString(ElementTreeChild.NameOfElement.ToString(), new Font("Times New Roman", height * 1 / 3), Brushes.Black, pos);
            g.DrawImage(Properties.Resources.Element, x, y, width, height);
            if (ElementTreeChild.Childs != null)
            {
                x += width + 50;
                foreach (ElementXMLInTree element in ElementTreeChild.Childs)
                {
                    DrawElementOfTree(ElementTreeChild, element,x);
                    //if(ElementTreeChild.Childs.Count != 1)
                        y += height+10;
                }
            }
        }

        //https://raw.githubusercontent.com/kizeevov/elcomplusfiles/main/config.xml
        //https://raw.githubusercontent.com/kizeevov/elcomplusfiles/main/tree.xml
    }
}
