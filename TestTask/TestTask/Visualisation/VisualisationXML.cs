using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Drawing;
using System.IO;

namespace TestTask
{
    class VisualisationXML: IVisualizable
    {
        private int MaxSizeOfWidthAtPixels = 0;
        public Bitmap Visualisation(ElementXMLInTree ElementForVisualisation, Bitmap bmp)
        {
            int x = 0;
            int y = 0;
            
            Bitmap b2 = new Bitmap(bmp, new Size(1000, 1000));
            using (Graphics g = Graphics.FromImage(b2))
            {

                g.TranslateTransform(10, 10);
                Image Element = Properties.Resources.Element;
                Image ElementWithAttribute = Properties.Resources.ElementWithAttribute;



                int width = 80;
                int height = 80;
                for(int i=0;i<100;i++)
                {
                    g.DrawImage(Element, x, y, width, height);
                    PointF pos = new PointF(x+10, y);
                    FindDepthTree(ElementForVisualisation, 1);
                    g.DrawString(MaxSizeOfWidthAtPixels.ToString(), new Font("Arial", height*1/4), Brushes.Black, pos);
                    x += 100;
                }
                g.DrawImage(Element, x, y, width, height);
            }
            return b2;
        }
        private void FindDepthTree(ElementXMLInTree ElementTree, int count)
        {
            if (count > MaxSizeOfWidthAtPixels)
                MaxSizeOfWidthAtPixels = count;
            if (ElementTree.Childs != null)
            {
                List<ElementXMLInTree> CurrentChildsOfElement = ElementTree.Childs;
                foreach (ElementXMLInTree CurrentElement in CurrentChildsOfElement)
                {
                    FindDepthTree(CurrentElement, count + 1);
                }
            }
            
        }
        //https://raw.githubusercontent.com/kizeevov/elcomplusfiles/main/config.xml
    }
}
