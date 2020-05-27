using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Xps.Packaging;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum SelectShape
        {
            Circle,
            Rectangle,
            Line
        }
        private SelectShape currentShape;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CircleOption_OnClick(object sender, RoutedEventArgs e)
        {
            currentShape = SelectShape.Circle;
        }
        private void RectOption_OnClick(object sender, RoutedEventArgs e)
        {
            currentShape = SelectShape.Rectangle;
        }
        private void LineOption_OnClick(object sender, RoutedEventArgs e)
        {
            currentShape = SelectShape.Line;
        }

        private void CanvasDrawingArea_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
                return;
            Shape shape = null;
            switch (currentShape)
            {
                case SelectShape.Circle:
                    shape = new Ellipse
                    {
                        Fill = Brushes.Green, Height = 40, Width = 40,
                    };
                    break;
                case SelectShape.Rectangle:
                    shape = new Rectangle
                    {
                        Fill = Brushes.Red, Height = 40, Width = 40, RadiusX = 10, RadiusY = 10,
                    };
                    break;
                case SelectShape.Line:
                    shape = new Line
                    {
                        Stroke = Brushes.Blue, StrokeThickness = 10, X1 = 5, Y1 = 5, X2 = 35, Y2 = 35,
                        StrokeStartLineCap = PenLineCap.Round, StrokeEndLineCap = PenLineCap.Round,
                    };
                    break;
                default:
                    return;
            }
            Canvas.SetLeft(shape, e.GetPosition(canvasDrawingArea).X);
            Canvas.SetTop(shape, e.GetPosition(canvasDrawingArea).Y);
            canvasDrawingArea.Children.Add(shape);
        }

        private void CanvasDrawingArea_OnMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point point = e.GetPosition((Canvas)sender);
            HitTestResult result = VisualTreeHelper.HitTest(canvasDrawingArea, point);
            if (result != null)
            {
                canvasDrawingArea.Children.Remove(result.VisualHit as Shape);
            }
        }
    }
}
