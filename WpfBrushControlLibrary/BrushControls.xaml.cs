using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBrushControlLibrary
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        bool isHighlighter;

        public UserControl1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
            animationInkCanvas.DefaultDrawingAttributes.Width = 5.0d;
        }

        private void Btnthin_brush_Click(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
            animationInkCanvas.DefaultDrawingAttributes.Width = 2.0d;
        }

        private void Btnmid_brush_Click(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
            animationInkCanvas.DefaultDrawingAttributes.Width = 3.5d;
        }

        private void Btnpencil_Click(object sender, RoutedEventArgs e)
        {
            DrawingAttributes da;

            da = new DrawingAttributes();
            da.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
            da.Width = 0.5d;
            da.Color = Color.FromRgb(112, 112, 112);

            animationInkCanvas.DefaultDrawingAttributes = da;

            isHighlighter = true;
        }
    }
}
