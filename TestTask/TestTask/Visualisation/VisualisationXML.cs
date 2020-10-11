using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Drawing;
using System.IO;

namespace TestTask
{
    class VisualisationXML: IVisualizable
    {
        private float GLobalHeightElement = 38;
        private float GlobalPosY = 0;
        private Graphics g;
        public Bitmap Visualisation(ElementXMLInTree ElementForVisualisation, Bitmap bmp)
        {
            Bitmap ResizedBitMap = new Bitmap(bmp, new Size(1500, 1000));
            using (g = Graphics.FromImage(ResizedBitMap))
            {
                g.TranslateTransform(10, 10);
                
                Image ElementWithAttribute = Properties.Resources.ElementWithAttribute;
                float Width = ElementForVisualisation.NameOfElement.ToString().Length * GLobalHeightElement * 1 / 3.5f;
                PointF PosForText = new PointF(0 + Width / 15, GlobalPosY + GLobalHeightElement / 4);
                g.DrawString(ElementForVisualisation.NameOfElement.ToString(), new Font("Times New Roman", GLobalHeightElement * 1 / 3), Brushes.Black, PosForText);
                g.DrawImage(Properties.Resources.Element, 0, GlobalPosY, Width, GLobalHeightElement);
                float SavedYPosForDrawLine = GlobalPosY;
                if (ElementForVisualisation.Childs != null)
                {
                    foreach (ElementXMLInTree element in ElementForVisualisation.Childs)
                    {
                        DrawLineBetweenElement(Width, Width+ 150, SavedYPosForDrawLine);
                        DrawElementOfTree(element, Width + 150);
                        if (element != ElementForVisualisation.Childs[ElementForVisualisation.Childs.Count - 1])
                            GlobalPosY += GLobalHeightElement + 10;
                    }
                }
            }
            return ResizedBitMap;
        }
        private void DrawElementOfTree(ElementXMLInTree ElementTreeForDraw,float x)
        {
            float heightA;
            float WidthElementOfAttribute = 0;
            float width;
            float SavedYPosForDrawLine = GlobalPosY;
            if (ElementTreeForDraw.Attributes != null)
            {
                heightA = ElementTreeForDraw.Attributes.Count * GLobalHeightElement * 1.2f;

                foreach (XAttribute element in ElementTreeForDraw.Attributes)
                {
                    float widthAB = element.ToString().Length * GLobalHeightElement * 1 / 3;
                    if (widthAB > WidthElementOfAttribute)
                        WidthElementOfAttribute = widthAB;
                }
                width = Math.Max(ElementTreeForDraw.NameOfElement.ToString().Length * GLobalHeightElement * 1 / 3.5f, WidthElementOfAttribute);
                g.DrawImage(Properties.Resources.ElementWithAttributeUpper, x, GlobalPosY, width, GLobalHeightElement);
                g.DrawImage(Properties.Resources.ElementWithAttributeLower, x, GlobalPosY + GLobalHeightElement, width, heightA);
                
                PointF PosForText = new PointF(x + width / 10, GlobalPosY + GLobalHeightElement / 4);
                g.DrawString(ElementTreeForDraw.NameOfElement.ToString(), new Font("Times New Roman", GLobalHeightElement * 1 / 3), Brushes.Black, PosForText);
                foreach (XAttribute element in ElementTreeForDraw.Attributes)
                {
                    PosForText.Y += GLobalHeightElement;
                    g.DrawString(element.ToString(), new Font("Times New Roman", GLobalHeightElement * 1 / 3), Brushes.Black, PosForText);
                }
                SavedYPosForDrawLine = GlobalPosY;
                GlobalPosY += heightA;
            }
            else
            {
                width = ElementTreeForDraw.NameOfElement.ToString().Length * GLobalHeightElement * 1 / 3.5f;
                g.DrawImage(Properties.Resources.Element, x, GlobalPosY, width, GLobalHeightElement);
                PointF pos = new PointF(x + width / 15, GlobalPosY + GLobalHeightElement / 4);
                g.DrawString(ElementTreeForDraw.NameOfElement.ToString(), new Font("Times New Roman", GLobalHeightElement * 1 / 3), Brushes.Black, pos);
            }
            if (ElementTreeForDraw.Childs != null)
            {
                x += width + 150;
                
                foreach (ElementXMLInTree element in ElementTreeForDraw.Childs)
                {
                    DrawLineBetweenElement(width,x, SavedYPosForDrawLine);
                    DrawElementOfTree(element,x);
                    if(element != ElementTreeForDraw.Childs[ElementTreeForDraw.Childs.Count - 1])
                        GlobalPosY += (int)GLobalHeightElement +10;
                }
            }
        }
        private void DrawLineBetweenElement(float CurrentWidth, float XPos, float YPos)
        {
            PointF pt1, pt2;

            pt1 = new PointF(XPos - CurrentWidth - 150, YPos);
            pt1.X += CurrentWidth;
            pt1.Y += GLobalHeightElement / 2;
            pt2 = new PointF(XPos, GlobalPosY);
            pt2.Y += GLobalHeightElement / 2;
            using (Pen pen = new Pen(Color.Blue, 2))
            {
                g.DrawLine(pen, pt1, pt2);
            }
        }
        //https://raw.githubusercontent.com/kizeevov/elcomplusfiles/main/config.xml
        //https://raw.githubusercontent.com/kizeevov/elcomplusfiles/main/tree.xml
    }
}
