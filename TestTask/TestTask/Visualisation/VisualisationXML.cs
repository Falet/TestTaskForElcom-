using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Drawing;
using System.IO;

namespace TestTask
{
    class VisualisationXML: IVisualizable
    {
        private float GlobalPosY = 0;

        private Graphics GraphicForDraw;
        private Bitmap Canvas;
        private SizeF SizeOfNewImage;
        /// <summary>
        /// Визуализация дерева элементов формата XML на WinForms
        /// </summary>
        /// <param name="ElementForVisualisation">Элемент для визуализации</param>
        /// <param name="Canvas">Холст на котором будет рисоваться дерево</param>
        /// <param name="SetHeightOfElement">Базовая высота элемента</param>
        /// <returns></returns>
        public Bitmap Visualisation(ElementXMLInTree ElementForVisualisation, float SetHeightOfElement)
        {
            Canvas = new Bitmap(1, 1);
            using (GraphicForDraw = Graphics.FromImage(Canvas))
            {
                Image ElementWithAttribute = Properties.Resources.ElementWithAttribute;
                float WidthOfElement = ElementForVisualisation.NameOfElement.ToString().Length * SetHeightOfElement * 1 / 3.5f;
                PointF PosForText = new PointF(0 + WidthOfElement / 15, GlobalPosY + SetHeightOfElement / 4);
                if((0 + WidthOfElement + 150) > Canvas.Width || (0 + SetHeightOfElement) > Canvas.Height)
                {
                    SizeOfNewImage = new SizeF(0 + WidthOfElement + 150, 0 + SetHeightOfElement);
                    Canvas = ResizeImage(Canvas, SizeOfNewImage);
                    GraphicForDraw = Graphics.FromImage(Canvas);
                }
                GraphicForDraw.DrawString(ElementForVisualisation.NameOfElement.ToString(), new Font("Times New Roman", SetHeightOfElement * 1 / 3), Brushes.Black, PosForText);
                GraphicForDraw.DrawImage(Properties.Resources.Element, 0, GlobalPosY, WidthOfElement, SetHeightOfElement);
                float SavedYPosForDrawLine = GlobalPosY;
                if (ElementForVisualisation.Childs != null)
                {
                    foreach (ElementXMLInTree element in ElementForVisualisation.Childs)
                    {

                        DrawLineBetweenElement(WidthOfElement, WidthOfElement+ 150, SavedYPosForDrawLine, SetHeightOfElement);
                        DrawElementOfTree(element, WidthOfElement + 150, SetHeightOfElement);
                        if (element != ElementForVisualisation.Childs[ElementForVisualisation.Childs.Count - 1])
                            GlobalPosY += SetHeightOfElement + 10;
                    }
                }
            }
            return Canvas;
        }
        /// <summary>
        /// Рекурсивная функция 
        /// Высчитывает координаты текущего элемента и отрисовывает элементов
        /// </summary>
        /// <param name="ElementTreeForDraw">Элемент для отрисовки</param>
        /// <param name="XPos">X Позиция элементов(или группы элементов,если дочерних элементов несколько)</param>
        /// <param name="HeightOfElement">Базовая высота элемента</param>
        private void DrawElementOfTree(ElementXMLInTree ElementTreeForDraw,float XPos, float HeightOfElement)
        {
            float CurrentHeightOfAttribute;
            float CurrentWidthElementOfAttribute = 0;
            float CurrentWidthOfElement;
            float SavedYPosForDrawLine = GlobalPosY;
            if (ElementTreeForDraw.Attributes != null)
            {
                CurrentHeightOfAttribute = ElementTreeForDraw.Attributes.Count * HeightOfElement * 1.2f;

                foreach (XAttribute element in ElementTreeForDraw.Attributes)
                {
                    float widthAB = element.ToString().Length * HeightOfElement * 1 / 3;
                    if (widthAB > CurrentWidthElementOfAttribute)
                        CurrentWidthElementOfAttribute = widthAB;
                }
                CurrentWidthOfElement = Math.Max(ElementTreeForDraw.NameOfElement.ToString().Length * HeightOfElement * 1 / 3.5f, CurrentWidthElementOfAttribute);
                if ((XPos + CurrentWidthOfElement + 150) > Canvas.Width)
                {
                    SizeOfNewImage = new SizeF(XPos + CurrentWidthOfElement + 150, Canvas.Height);
                    Canvas = ResizeImage(Canvas, SizeOfNewImage);
                    GraphicForDraw = Graphics.FromImage(Canvas);
                }
                if((GlobalPosY + (CurrentHeightOfAttribute + HeightOfElement)) > Canvas.Height)
                {
                    SizeOfNewImage = new SizeF(Canvas.Width, GlobalPosY + (CurrentHeightOfAttribute + HeightOfElement));
                    Canvas = ResizeImage(Canvas, SizeOfNewImage);
                    GraphicForDraw = Graphics.FromImage(Canvas);
                }
                GraphicForDraw.DrawImage(Properties.Resources.ElementWithAttributeUpper, XPos, GlobalPosY, CurrentWidthOfElement, HeightOfElement);
                GraphicForDraw.DrawImage(Properties.Resources.ElementWithAttributeLower, XPos, GlobalPosY + HeightOfElement, CurrentWidthOfElement, CurrentHeightOfAttribute);
                PointF PosForText = new PointF(XPos + CurrentWidthOfElement / 10, GlobalPosY + HeightOfElement / 4);
                GraphicForDraw.DrawString(ElementTreeForDraw.NameOfElement.ToString(), new Font("Times New Roman", HeightOfElement * 1 / 3), Brushes.Black, PosForText);
                foreach (XAttribute element in ElementTreeForDraw.Attributes)
                {
                    PosForText.Y += HeightOfElement;
                    GraphicForDraw.DrawString(element.ToString(), new Font("Times New Roman", HeightOfElement * 1 / 3), Brushes.Black, PosForText);
                }
                SavedYPosForDrawLine = GlobalPosY;
                GlobalPosY += CurrentHeightOfAttribute;
            }
            else
            {
                CurrentWidthOfElement = ElementTreeForDraw.NameOfElement.ToString().Length * HeightOfElement * 1 / 3.5f;
                if ((XPos + CurrentWidthOfElement + 150) > Canvas.Width)
                {
                    SizeOfNewImage = new SizeF(XPos + CurrentWidthOfElement + 150, Canvas.Height);
                    Canvas = ResizeImage(Canvas, SizeOfNewImage);
                    GraphicForDraw = Graphics.FromImage(Canvas);
                }
                if((GlobalPosY + HeightOfElement) > Canvas.Height)
                {
                    SizeOfNewImage = new SizeF(Canvas.Width, GlobalPosY + HeightOfElement);
                    Canvas = ResizeImage(Canvas, SizeOfNewImage);
                    GraphicForDraw = Graphics.FromImage(Canvas);
                }
                GraphicForDraw.DrawImage(Properties.Resources.Element, XPos, GlobalPosY, CurrentWidthOfElement, HeightOfElement);
                PointF pos = new PointF(XPos + CurrentWidthOfElement / 15, GlobalPosY + HeightOfElement / 4);
                GraphicForDraw.DrawString(ElementTreeForDraw.NameOfElement.ToString(), new Font("Times New Roman", HeightOfElement * 1 / 3), Brushes.Black, pos);
            }
            if (ElementTreeForDraw.Childs != null)
            {
                XPos += CurrentWidthOfElement + 150;
                foreach (ElementXMLInTree element in ElementTreeForDraw.Childs)
                {
                    DrawLineBetweenElement(CurrentWidthOfElement,XPos, SavedYPosForDrawLine, HeightOfElement);
                    DrawElementOfTree(element,XPos, HeightOfElement);
                    if(element != ElementTreeForDraw.Childs[ElementTreeForDraw.Childs.Count - 1])
                        GlobalPosY += (int)HeightOfElement +10;
                }
            }
        }
        /// <summary>
        /// Отрисовка линий соединяющих элементы в дерево
        /// </summary>
        /// <param name="CurrentWidth">Ширина блока элемента</param>
        /// <param name="XPos">X Позиция текущего элемента</param>
        /// <param name="YPos">Y Позиция текущего элемента</param>
        /// <param name="HeightOfElement">Базовая высота элемента</param>
        private void DrawLineBetweenElement(float CurrentWidth, float XPos, float YPos, float HeightOfElement)
        {
            PointF PointBeginElement, PointLastElement;

            PointBeginElement = new PointF(XPos - CurrentWidth - 150, YPos);
            PointBeginElement.X += CurrentWidth;
            PointBeginElement.Y += HeightOfElement / 2;
            PointLastElement = new PointF(XPos, GlobalPosY);
            PointLastElement.Y += HeightOfElement / 2;
            if (PointLastElement.X > Canvas.Width)
            {
                SizeOfNewImage = new SizeF(PointLastElement.X + 150, Canvas.Height);
                Canvas = ResizeImage(Canvas, SizeOfNewImage);
                GraphicForDraw = Graphics.FromImage(Canvas);
            }
            if (PointLastElement.Y > Canvas.Height)
            {
                SizeOfNewImage = new SizeF(Canvas.Width, PointLastElement.Y + 150);
                Canvas = ResizeImage(Canvas, SizeOfNewImage);
                GraphicForDraw = Graphics.FromImage(Canvas);
            }
            using (Pen PenForDrawLine = new Pen(Color.Blue, 2))
            {
                GraphicForDraw.DrawLine(PenForDrawLine, PointBeginElement, PointLastElement);
            }
        }
        /// <summary>
        /// Изменение размера холста
        /// </summary>
        /// <param name="ImgToResize">Холст для изменения размера</param>
        /// <param name="Size">Требуемый размер</param>
        /// <returns></returns>
        private static Bitmap ResizeImage(Bitmap ImgToResize, SizeF Size)
        {
            try
            {
                Bitmap b = new Bitmap((int)Size.Width + 100, (int)Size.Height + 100);
                using (Graphics GraphicForResizedCanvas = Graphics.FromImage((Image)b))
                {
                    GraphicForResizedCanvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    GraphicForResizedCanvas.DrawImage(ImgToResize, 0, 0, ImgToResize.Width, ImgToResize.Height);
                }
                return b;
            }
            catch
            {
                return ImgToResize;
            }
        }
    }
}
