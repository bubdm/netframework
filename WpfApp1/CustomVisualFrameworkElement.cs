using System;
using System.Runtime.CompilerServices;
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
            //дополнительно реагирование на нажатие мышки
            this.MouseDown += CustVisualFrameworkElement_MouseDown;
        }
        private void CustVisualFrameworkElement_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)//реагирование на нажатия мыши
        {
            Point point = e.GetPosition((UIElement)sender); //найти точку где произведен щелчок
            VisualTreeHelper.HitTest(this, null, new HitTestResultCallback(myCallback), new PointHitTestParameters(point)); //просмотреть дерево на щелчки и вызвать делегат если был щелчок
        }
        public HitTestResultBehavior myCallback(HitTestResult result) //обработка при определении что фигура нажата
        {
            //при щелчке на визуальном элементе переключится между скошенным и нормальным состоянием
            if (result.VisualHit.GetType() == typeof(DrawingVisual))
            {
                if (((DrawingVisual)result.VisualHit).Transform == null)
                {
                    ((DrawingVisual)result.VisualHit).Transform = new SkewTransform(5,5);
                }
            }
            else
            {
                ((DrawingVisual) result.VisualHit).Transform = null;
            }
            //прекращение поиска в визуальном делеве
            return HitTestResultBehavior.Stop;
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