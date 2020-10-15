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
using System.Windows.Ink;

namespace WpfEditingControlLibrary
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// An editing control library used for basic functions ush as moving stokes, deleting undoing and erasing.
    /// These basic operations are designed to work on an Inkcanvas application.
    /// </summary>
    public partial class EditingControls : UserControl
    {
        // Create a custom routed event by first registering a RoutedEventID
        // This event uses the bubbling routing strategy
        public static readonly RoutedEvent EraseEvent = EventManager.RegisterRoutedEvent(
            "Erase", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(EditingControls));

        // Provide CLR accessors for the event
        public event RoutedEventHandler Erase
        {
            add { AddHandler(EraseEvent, value); }
            remove { RemoveHandler(EraseEvent, value); }
        }

        // This method raises the Tap event for the button
        void RaiseEraseEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Button.ClickEvent);
            RaiseEvent(newEventArgs);
        }

        private void ButtonEraser_Click_1(object sender, RoutedEventArgs e)
        {
            RaiseEraseEvent();
        }


        public EditingControls()
        {
            InitializeComponent();
        }

        public class Collectionstrokes
        {
            //public String strokes { get => currentStroke; set => currentStroke = value; }
        }

       private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            //Grid.Collectionstrokes = InkCanvasEditingMode.Select;
        }

        private void ButtonEraser_Click(object sender, RoutedEventArgs e)
        {
            //This actually raises the custom event
            RaiseEraseEvent();
            //Grid.Collectionstrokes = InkCanvasEditingMode.EraseByPoint;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            //Grid.Strokes.Clear();
        }
    }
}
