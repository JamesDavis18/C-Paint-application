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

namespace WpfControlLibrary1
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        //This user control is a colour picker which has been created using visual studio blend so it can work with the new window.
        private Color currentColor;

        private Color CurrentColor { get => currentColor; set => currentColor = value; }

        public UserControl1()
        {
            InitializeComponent();
            ColorState = Colors.Black;
        }

        public Color ColorState
        {
            get { return (Color)this.GetValue(ColorStateProperty); }
            set { this.SetValue(ColorStateProperty, value); }
        }

        // Generates property of the colour/chnaged method that will be used by the event handler
        public static readonly DependencyProperty ColorStateProperty = DependencyProperty.Register(
            "ColorState", typeof(Color), typeof(UserControl1), new PropertyMetadata(default(Color)));

        // Event
        // Create a co=ustom routed event by first registering the RoutedEventID
        // This event uses the bubbling routing strategy
        public static readonly RoutedEvent ColorChangedEvent = EventManager.RegisterRoutedEvent(
            "ColorChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UserControl1));

        // Now need to provie CLR accesors for the event
        public event RoutedEventHandler ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value);  }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        // Method to raise the Color event
        void RaiseColorChangedEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(UserControl1.ColorChangedEvent);
            RaiseEvent(newEventArgs);
        }

        // List of buttons within the colour control 
        private void ButtonInk_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Colors.Black;
            RaiseColorChangedEvent();

        }
        private void ButtonBlue_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(0, 102, 255);
            RaiseColorChangedEvent();
        }

        private void ButtonOrange_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(255, 102, 0);
            RaiseColorChangedEvent();
        }

        private void ButtonRed1_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Colors.Red;
            RaiseColorChangedEvent();
        }

        private void ButtonGreen_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(0, 204, 0);
            RaiseColorChangedEvent();
        }

        private void ButtonlightBlue_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(128, 206, 214);
            RaiseColorChangedEvent();
        }

        private void ButtonLightGreen_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(102, 255, 51);
            RaiseColorChangedEvent();
        }

        private void ButtonDarkBlue_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(0, 0, 204);
            RaiseColorChangedEvent();
        }

        private void ButtonDarkYellow_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(255, 153, 0);
            RaiseColorChangedEvent();
        }

        private void ButtonPurple_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(204, 0, 102);
            RaiseColorChangedEvent();
        }

        private void ButtonLightYellow_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(255, 255, 0);
            RaiseColorChangedEvent();
        }

        private void ButtonPink_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(255, 51, 153);
            RaiseColorChangedEvent();
        }

        private void BtnBrown_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(153, 51, 0);
            RaiseColorChangedEvent();
        }

        private void BtnGold_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(204, 153, 0);
            RaiseColorChangedEvent();
        }

        private void BtnNavy_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(0, 0, 64);
            RaiseColorChangedEvent();
        }

        private void BtnGreenYellow_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(230, 255, 153);
            RaiseColorChangedEvent();
        }

        private void ButtonTurquoise_2(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(174, 234, 223);
            RaiseColorChangedEvent();
        }

        private void BtnDarkPurple_2(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(64, 0, 64);
            RaiseColorChangedEvent();
        }

        private void BtnMaroon_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(128, 0, 0);
            RaiseColorChangedEvent();
        }

        private void BtnDarkBrown_Click(object sender, RoutedEventArgs e)
        {
            ColorState = Color.FromRgb(124, 64, 3);
            RaiseColorChangedEvent();
        }
    }
}
