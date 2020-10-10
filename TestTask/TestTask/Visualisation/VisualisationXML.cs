using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Drawing;
using System.IO;

namespace TestTask
{
    class VisualisationXML: IVisualizable
    {
        private float Gheight = 40;
        private int y = 0;
        private Graphics g;
        public Bitmap Visualisation(ElementXMLInTree ElementForVisualisation, Bitmap bmp)
        {
            Bitmap b2 = new Bitmap(bmp, new Size(5500, 5000));
            using (g = Graphics.FromImage(b2))
            {

                g.TranslateTransform(10, 10);
                
                Image ElementWithAttribute = Properties.Resources.ElementWithAttribute;
                float width = 0;
                int height = 40;
                width = ElementForVisualisation.NameOfElement.ToString().Length * height * 1 / 3.5f;
                PointF pos = new PointF(0 + width / 15, y + height / 4);
                g.DrawString(ElementForVisualisation.NameOfElement.ToString(), new Font("Times New Roman", height * 1 / 3), Brushes.Black, pos);
                g.DrawImage(Properties.Resources.Element, 0, y, width, height);
                int y1 = y;
                if (ElementForVisualisation.Childs != null)
                {
                    foreach (ElementXMLInTree element in ElementForVisualisation.Childs)
                    {
                        Point pt1, pt2;

                        pt1 = new Point(0, y1); pt1.Offset((int)width, height / 2);
                        pt2 = new Point((int)(0 + width + 150), y); pt2.Offset(0, height / 2);
                        using (Pen pen = new Pen(Color.Blue, 2))
                        {
                            g.DrawLine(pen, pt1, pt2);
                        }
                        DrawElementOfTree(element, width + 150);
                        if (element != ElementForVisualisation.Childs[ElementForVisualisation.Childs.Count - 1])
                            y += height + 10;
                    }
                }
            }
            return b2;
        }
        private void DrawElementOfTree(ElementXMLInTree ElementTreeChild,float x)
        {
            float heightA;
            float widthA= 0;
            Image ElementImage;
            if (ElementTreeChild.Attributes != null)
            {
                heightA = ElementTreeChild.Attributes.Count * Gheight * 1 / 3.5f;
                foreach (string element in ElementTreeChild.Attributes)
                {
                    float widthAB = element.Length * Gheight * 1 / 3.5f;
                    if (widthAB > widthA)
                        widthA = widthAB;
                }
                ElementImage = Properties.Resources.ElementWithAttribute;
            }
            else
                ElementImage = Properties.Resources.Element;
            float width = Math.Max(ElementTreeChild.NameOfElement.ToString().Length * Gheight * 1 / 3.5f, widthA);
            PointF pos = new PointF(x + width / 15, y + Gheight / 4);
            g.DrawString(ElementTreeChild.NameOfElement.ToString(), new Font("Times New Roman", Gheight * 1 / 3), Brushes.Black, pos);
            g.DrawImage(ElementImage, x, y, width, Gheight);
            
            if (ElementTreeChild.Childs != null)
            {
                x += width + 150;
                int y1 = y;
                foreach (ElementXMLInTree element in ElementTreeChild.Childs)
                {
                    Point pt1, pt2;
                    
                    pt1 = new Point((int)(x- width - 150), y1); pt1.Offset((int)width, (int)Gheight / 2);
                    pt2 = new Point((int)x, y); pt2.Offset(0, (int)Gheight / 2);
                    using (Pen pen = new Pen(Color.Blue, 2))
                    {
                        g.DrawLine(pen, pt1, pt2);
                    }
                    DrawElementOfTree(element,x);
                    if(element != ElementTreeChild.Childs[ElementTreeChild.Childs.Count - 1])
                        y += (int)Gheight +10;
                }
            }
        }

        //https://raw.githubusercontent.com/kizeevov/elcomplusfiles/main/config.xml
        //https://raw.githubusercontent.com/kizeevov/elcomplusfiles/main/tree.xml
    }
}
