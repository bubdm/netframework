using System;
using System.Windows;
using System.Windows.Media;

namespace WpfApp1
{
    public class CustVisualFrameworkElement : FrameworkElement
    {
        private VisualCollection collection; //коллекция всех элементов
        public CustVisualFrameworkElement()
        {
            collection = new VisualCollection(this) //заполнить коллекцию квадартом и кругом
            {
                AddRect(),
                AddCircle(),
            };
        }
        private Visual AddCircle()
        {
            DrawingVisual drawingVisual = new DrawingVisual(); 
            using (DrawingContext drawingContext = drawingVisual.RenderOpen()) //объект для создания нового содержимого
            {
                drawingContext.DrawEllipse(Brushes.DarkBlue, null, new Point(80,80), 40,50); //создать круг и нарисовать его
            }
            return drawingVisual;
        }
        private Visual AddRect()
        {
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen()) //объект для создания нового содержимого
            {
                drawingContext.DrawRectangle(Brushes.Tomato, null, new Rect(new Point(150,100), new Size(300,100))); //создать квадрат и нарисовать его
            }
            return drawingVisual;
        }
        protected override int VisualChildrenCount => collection.Count;
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= collection.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return collection[index]; //коллекция из графических элементов
        }
    }
}