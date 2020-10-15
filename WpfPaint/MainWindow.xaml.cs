using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibrary1;
using WpfControlLibrary1;
using WpfEditingControlLibrary;

namespace WpfPaint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Original application window used for testing out basic inkcanvas functions such as setting 
    /// editing modes and stroke colourrs and thicknesses. 
    /// 
    /// Note: If icons are not displying change the drive name as releative references didnt work
    /// 
    /// The fade animation combo box and the Pathb animation do not work
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isHighlighter;
        private Point mouseDownPos;

        public class Collectionstrokes
        {
            public String strokes;
        }

        public void MyInkCanvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mouseDownPos = e.GetPosition(inkCanvas);
        }

        public MainWindow()
        {
            ToolsClass x = new ToolsClass();
            float result;
            result = x.MyMethod(15, 10, 31.0f);

            InitializeComponent();

            
        }

        private void Ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonInk_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.EditingMode = InkCanvasEditingMode.Select;
        }

        private void ButtonBlue_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(0, 102, 255);
        }

        private void ButtonEraser_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void ButtonWidthThin_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
            inkCanvas.DefaultDrawingAttributes.Width = 2.0d;
        }

        private void ButtonLightGreen_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(102, 255, 51);
        }

        private void ButtonOrange_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(255, 102, 0);
        }

        private void ButtonRed1_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(255, 0, 0);
        }

        private void ButtonGreen_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(0, 204, 0);
        }

        private void ButtonlightBlue_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(128, 206, 214);
        }

        private void WidthThick_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
            inkCanvas.DefaultDrawingAttributes.Width = 5.0d;
        }

        private void WidthMid_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
            inkCanvas.DefaultDrawingAttributes.Width = 3.5d;
        }

        private void ButtonDarkBlue_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(0, 0, 204);
        }

        private void ButtonDarkYellow_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(255, 153, 0);
        }

        private void ButtonPurple_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(255, 255, 0);
        }

        private void ButtonLightYellow_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(204, 0, 102);
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.Strokes.Clear();
        }

        private void BtnHighlight_Click(object sender, RoutedEventArgs e)
        {
            DrawingAttributes da;

            da = new DrawingAttributes();
            da.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
            da.Width = 10.0d;
            da.Color = Color.FromRgb(255, 255, 153);

            inkCanvas.DefaultDrawingAttributes = da;

            isHighlighter = true;
        }

        private void BtnPencil_Click_1(object sender, RoutedEventArgs e)
        {
            DrawingAttributes da;

            da = new DrawingAttributes();
            da.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
            da.Width = 0.5d;
            da.Color = Color.FromRgb(112, 112, 112);

            inkCanvas.DefaultDrawingAttributes = da;

            isHighlighter = true;
        }

        private void BtnStrokeDel_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.Strokes.RemoveAt(inkCanvas.Strokes.Count - 1);
        }

        private void ButtonPink_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(255, 51, 153);
        }

        private void BtnBrown_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(153, 51, 0);
        }

        private void BtnGold_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(204, 153, 0);
        }

        private void BtnNavy_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(0, 0, 64);
        }

        private void BtnGreenYellow_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(230, 255, 153);
        }

        private void ButtonTurquoise_2(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(113, 213, 200);
        }

        private void BtnDarkPurple_2(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(64, 0, 64);
        }

        private void BtnMaroon_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(128, 0, 0);
        }

        private void BtnDarkBrown_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(124, 64, 3);
        }

        private void ColorPicker1_SelectionChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            // ColorPicker1.IsOpen = true;
            // ColorPicker1.SelectedColor = Colors.Red
            // inkCanvas.Background = new SolidColorBrush(ColorPicker1.SelectedColor);//
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            int marg = int.Parse(this.inkCanvas.Margin.Left.ToString());
            RenderTargetBitmap rtb =
                new RenderTargetBitmap((int)this.inkCanvas.ActualWidth - marg,
                    (int)this.inkCanvas.ActualHeight - marg, 0, 0,
                PixelFormats.Default);
            rtb.Render(this.inkCanvas);
            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));
            FileStream fs = File.Open(@"E:\University of suffolk\Level 5\Advanced software development\WPF\WpfPaintApp\Saves.bmp", FileMode.Create);
            encoder.Save(fs);
            fs.Close();
        }

        private void Text_block_Click(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock1 = new TextBlock();
            textBlock1.Text = "Draw in the area below";
            Canvas.SetTop(textBlock1, 100);
            Canvas.SetLeft(textBlock1, 100);
            inkCanvas.Children.Add(textBlock1);
        }

        private void Draw_textbox_Click(object sender, MouseEventArgs e)
        {
            TextBox myTextBox = new TextBox();
            inkCanvas.Children.Add(myTextBox);
            myTextBox.Visibility = Visibility.Visible;
            Point mousePos = e.GetPosition(inkCanvas);
            double left = Math.Min(mouseDownPos.X, mousePos.X);
            double top = Math.Min(mouseDownPos.Y, mousePos.Y);
            myTextBox.Width = Math.Abs(mouseDownPos.X - mousePos.X);
            myTextBox.Height = Math.Abs(mouseDownPos.Y - mousePos.Y);
            InkCanvas.SetLeft(myTextBox, left);
            InkCanvas.SetTop(myTextBox, top);

        }

        private void Btn_square_Click(object sender, RoutedEventArgs e)
        {
            var polygon = new Polygon { StrokeThickness = 1, Fill = Brushes.Red };
            polygon.Points.Add(new Point(10, 50));
            polygon.Points.Add(new Point(180, 50));
            polygon.Points.Add(new Point(180, 150));
            polygon.Points.Add(new Point(10, 150));
            inkCanvas.Children.Add(polygon);
        }


        private void BtnCircle_Click(object sender, RoutedEventArgs e)
        {
            ////protected override void DrawCore(DrawingContext drawingContext, DrawingAttributes drawingAttributes)
            //DrawingContext drawingContext = new DrawingContext();
            //DrawingAttributes drawingAttributes;

            //DrawingAttributes originalDa = drawingAttributes.Clone();
            //SolidColorBrush brush2 = new SolidColorBrush(drawingAttributes.Color);
            //brush2.Freeze();
            //StylusPoint stp = this.StylusPoints[0];
            //StylusPoint sp = this.StylusPoints[1];
            //double radius = System.Math.Sqrt(System.Math.Pow((double)(sp.X - stp.X), 2) + System.Math.Pow((double)(sp.Y - stp.Y), 2)) / 2.0;

            //drawingContext.DrawEllipse(brush2, null, new Point((sp.X + stp.X) / 2.0, (sp.Y + stp.Y) / 2.0), radius, radius);

            // Add an Ellipse Element
            Ellipse myEllipse = new Ellipse();
            myEllipse.Stroke = System.Windows.Media.Brushes.Black;
            myEllipse.Fill = System.Windows.Media.Brushes.DarkBlue;
            myEllipse.HorizontalAlignment = HorizontalAlignment.Left;
            myEllipse.VerticalAlignment = VerticalAlignment.Center;
            myEllipse.Width = 50;
            myEllipse.Height = 75;
            inkCanvas.Children.Add(myEllipse);
        }

        private void Btn_PolyLine_Click(object sender, RoutedEventArgs e)
        {
            //Add the Polyline Element
            Polyline myPolyline = new Polyline();
            myPolyline.Stroke = System.Windows.Media.Brushes.SlateGray;
            myPolyline.StrokeThickness = 3;
            myPolyline.FillRule = FillRule.EvenOdd;
            System.Windows.Point Point4 = new System.Windows.Point(1, 40);
            System.Windows.Point Point5 = new System.Windows.Point(10, 85);
            System.Windows.Point Point6 = new System.Windows.Point(20, 40);
            PointCollection myPointCollection2 = new PointCollection();
            myPointCollection2.Add(Point4);
            myPointCollection2.Add(Point5);
            myPointCollection2.Add(Point6);
            myPolyline.Points = myPointCollection2;
            inkCanvas.Children.Add(myPolyline);
        }

        private void myEditingControl_Erase(object sender, RoutedEventArgs e)
        {
            inkCanvas.Strokes.Clear();
        }

        private void myEditingControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
