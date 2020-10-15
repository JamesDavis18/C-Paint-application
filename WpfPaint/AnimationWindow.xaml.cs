using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfControlLibrary1;

namespace WpfPaint
{
    /// <summary>
    /// Interaction logic for AnimationWindow.xaml
    /// The main class for the animation window, initialises the window and displays the Inkcanvas window. 
    /// </summary>
    public partial class AnimationWindow : Window
    {
        //Had to create Enummeration do define what editing mode was selected on the inkcanvas
        public enum ToolMode
        {
            ThinBrush,
            MidBrush,
            ThickBrush,
            TextBox,
            Erase,
            Select,
            Ellipse,
            PolyLine,
            Polygon,
        }


        public System.Windows.Ink.DrawingAttributes
        DefaultDrawingattributes { get; set; }

        DrawingAttributes inkDA;
        DrawingAttributes highlighterDA;
        bool useHighlighter = false;

        private void WindowLoaded(object sender, EventArgs e)
        {
            //Sets drawing attributes for the Inkcanvas whenever the window is loaded
            // Drawing attruibbutes for the normal pen
            inkDA = new DrawingAttributes();
            inkDA.Color = Colors.Black;
            inkDA.Height = 5;
            inkDA.Width = 5;
            inkDA.FitToCurve = false;

            // Drawing attributes for the highliter pen
            highlighterDA = new DrawingAttributes();
            highlighterDA.Color = Colors.LimeGreen;
            highlighterDA.IsHighlighter = true;
            highlighterDA.StylusTip = StylusTip.Rectangle;
            highlighterDA.Height = 30;
            highlighterDA.Width = 10;

            animationInkCanvas.DefaultDrawingAttributes = inkDA;
        }


        // Defualts the tool mode to Thinbrush when drawing on the Inkcanvas
        ToolMode currentToolSelected = ToolMode.ThinBrush;

        // NameScope.SetNameScope (this, new NameScope());

        // A storyboard must be Initialised for animations to work
        private Storyboard myStoryboard;

        void App_Startup(object sender, StartupEventArgs e)
        {
            AnimationWindow window = new AnimationWindow();
            window.Show();
        }

        private Point mouseDownPos;

        public class Collectionstrokes
        {
            public string strokes;
        }

        // This finds the postion of the mouse in the animation window, used for drawing textboxes in the Inkcanvas.
        public Point MousePos { get; set; }

        public AnimationWindow()
        {
            InitializeComponent();
        }

        // Event handler for setting the stroke coloutr of each button within the control
        private void ColorChangedHandler(object sender, RoutedEventArgs e)
        {
            SetStrokeColor(((UserControl1)sender).ColorState);
        }

        //Sets the currentColor field for the coulr controls when they are used in the Inkcanvas
        private Color currentColor;

        private object mouseEnterColorAnimation;

        // Sets the color method and stroke for the Colour Controls library. 
        public void SetStrokeColor(Color c)
        {
            currentColor = c;
            animationInkCanvas.DefaultDrawingAttributes.Color = c;
        }

        private void ColourPicker_Loaded(object sender, RoutedEventArgs e)
        {

        }

        // Event handlers for the bubbled routed events set in the wpf control libary
        // This particular one is for the Erase handler
        private void EraseHandler(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void SelectHandler(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.EditingMode = InkCanvasEditingMode.Select;
        }

        private void ClearHandler(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.Strokes.Clear();
        }

        private void UndoHandler(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.Strokes.RemoveAt(animationInkCanvas.Strokes.Count - 1);
        }

        //Inkcanvas editing buttons carried over from Wpf Conrtrol library
        private void EditingControls_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Copy_btn_Click(object sender, ExecutedRoutedEventArgs e)
        {
            //string xaml = XamlWriter.Save(myRect);
            //Clipboard.SetText(xaml, TextDataFormat.Xaml);
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            //This button saves the inkcanvas as a rendered bitmap . The file is encoded and saved to a folder within the project. 
            //Converts margin values of the Inkcanvas to a string
            int marg = int.Parse(this.animationInkCanvas.Margin.Left.ToString());
            RenderTargetBitmap rtb =
                new RenderTargetBitmap((int)this.animationInkCanvas.ActualWidth - marg,
                (int)this.animationInkCanvas.ActualHeight - marg, 0, 0,
            PixelFormats.Default);
            rtb.Render(this.animationInkCanvas);
            BmpBitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(rtb));
            //Location where the .bmp file is created. 
            FileStream fs = File.Open(@"K:\University of suffolk\Level 5\Advanced software development\WPF\WpfAnimationsApp\Saves.bmp", FileMode.Create);
            encoder.Save(fs);
            fs.Close();
        }

        private void Btnthick_Brush(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            animationInkCanvas.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
            animationInkCanvas.DefaultDrawingAttributes.Width = 5.0d;
        }

        private void Btnmid_brush_Click(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            animationInkCanvas.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
            animationInkCanvas.DefaultDrawingAttributes.Width = 3.5d;
        }

        private void Btnthin_brush_Click(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            animationInkCanvas.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
            animationInkCanvas.DefaultDrawingAttributes.Width = 2.0d;
        }

        private void BrushComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Item_Pencil_Selected(object sender, RoutedEventArgs e)
        {
            if (animationInkCanvas != null)
            {
                DrawingAttributes da;

                da = new DrawingAttributes();
                da.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
                da.Width = 0.5d;
                da.Color = Color.FromRgb(112, 112, 112);

                animationInkCanvas.DefaultDrawingAttributes = da;

                useHighlighter = true;
            }
        }

        private void Item_Thinbrush_Selected(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            currentToolSelected = ToolMode.ThinBrush;
            animationInkCanvas.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
            animationInkCanvas.DefaultDrawingAttributes.Width = 2.0d;
        }

        private void Item_Midbrush_Selected(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            currentToolSelected = ToolMode.MidBrush;
            animationInkCanvas.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
            animationInkCanvas.DefaultDrawingAttributes.Width = 3.5d;
        }

        private void Item_Thickbrush_Selected(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            currentToolSelected = ToolMode.ThickBrush;
            animationInkCanvas.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
            animationInkCanvas.DefaultDrawingAttributes.Width = 5.0d;
        }

        // Zoom function that enlarges the active area of the InkCanvas
        private void ButtonZoom1_Click(object sender, RoutedEventArgs e)
        {
            var scaler = animationInkCanvas.LayoutTransform as ScaleTransform;

            // Sets the transform scale of the InkCanvas
            if (scaler == null)
            {
                scaler = new ScaleTransform(1.0, 1.0);
                animationInkCanvas.LayoutTransform = scaler;
            }

            // Sets the duration of the animation
            DoubleAnimation animator = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromMilliseconds(900)),
            };

            if (scaler.ScaleX == 1.0)
            {
                animator.To = 1.5;
            }
            else
            {
                animator.To = 1.0;
            }

            scaler.BeginAnimation(ScaleTransform.ScaleXProperty, animator);
            scaler.BeginAnimation(ScaleTransform.ScaleYProperty, animator);
        }

        private void BtnZoom2_Click(object sender, RoutedEventArgs e)
        {
            var scaler = animationInkCanvas.LayoutTransform as ScaleTransform;

            if (scaler == null)
            {
                // If scalex and scley roperties are set by animation, it will have to be removed 
                // before we can set them to "local" values.
                animationInkCanvas.LayoutTransform = new ScaleTransform(1.5, 1.5);
            }
            else
            {
                // Sets the Scale x and Scale Y properties, 
                double curZoomFactor = scaler.ScaleX;

                if (scaler.HasAnimatedProperties)
                {
                    scaler.BeginAnimation(ScaleTransform.ScaleXProperty, null);
                    scaler.BeginAnimation(ScaleTransform.ScaleYProperty, null);

                }
                if (curZoomFactor == 1.0)
                {
                    scaler.ScaleX = 1.5;
                    scaler.ScaleY = 1.5;
                }
                else
                {
                    scaler.ScaleX = 1.0;
                    scaler.ScaleY = 1.0;
                }
            }
        }

        private void BtnText_block_Click(object sender, RoutedEventArgs e)
        {
            TextBlock textBlock1 = new TextBlock
            {
                Text = "Draw in the area below"
            };
            Canvas.SetTop(textBlock1, 100);
            Canvas.SetLeft(textBlock1, 100);
            animationInkCanvas.Children.Add(textBlock1);
        }

        private void BtnDraw_text_Click(object sender, RoutedEventArgs e)
        {
            currentToolSelected = ToolMode.TextBox;
            animationInkCanvas.EditingMode = InkCanvasEditingMode.None;
        }

        private void animationInkCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (currentToolSelected == ToolMode.TextBox)
            {
                TextBox myTextBox = new TextBox();
                animationInkCanvas.Children.Add(myTextBox);
                myTextBox.Visibility = Visibility.Visible;
                //Point MousePos = e.GetPosition(animationInkCanvas);
                Point mousePos = Mouse.GetPosition(animationInkCanvas);
                //double left = Math.Min(mouseDownPos.X, MousePos.X);
                //double top = Math.Min(mouseDownPos.Y, MousePos.Y);
                //myTextBox.Width = Math.Abs(mouseDownPos.X - MousePos.X);
                //myTextBox.Height = Math.Abs(mouseDownPos.Y - MousePos.Y);
                InkCanvas.SetLeft(myTextBox, mousePos.X);
                InkCanvas.SetTop(myTextBox, mousePos.Y);
            }
        }

        private void animationInkCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (currentToolSelected == ToolMode.TextBox)
            {
                TextBox myTextBox = new TextBox();
                animationInkCanvas.Children.Add(myTextBox);
                myTextBox.Visibility = Visibility.Visible;
                //Point MousePos = e.GetPosition(animationInkCanvas);
                Point mousePos = Mouse.GetPosition(animationInkCanvas);
                InkCanvas.SetTop(myTextBox, mousePos.Y);
            }
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.Children.Clear();
        }

        private void Btn_undo_Click(object sender, RoutedEventArgs e)
        {
            if (animationInkCanvas != null)
            {
                animationInkCanvas.Strokes.RemoveAt(animationInkCanvas.Strokes.Count - 1);
            }
        }

        private void Btn_Select_Click(object sender, RoutedEventArgs e)
        {
            currentToolSelected = ToolMode.Select;
            animationInkCanvas.EditingMode = InkCanvasEditingMode.Select;
        }

        private void Btn_eraser_Click(object sender, RoutedEventArgs e)
        {
            currentToolSelected = ToolMode.Erase;
            animationInkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void Strokes_Delete_Click(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.Strokes.Clear();
        }

        private void Btn_ellipse_Click(object sender, RoutedEventArgs e)
        {
            currentToolSelected = ToolMode.Ellipse;
            Ellipse myEllipse = new Ellipse();
            myEllipse.Stroke = System.Windows.Media.Brushes.Black;
            myEllipse.Fill = System.Windows.Media.Brushes.DarkBlue;
            myEllipse.HorizontalAlignment = HorizontalAlignment.Left;
            myEllipse.VerticalAlignment = VerticalAlignment.Center;
            myEllipse.Width = 50;
            myEllipse.Height = 75;
            animationInkCanvas.Children.Add(myEllipse);
        }

        private void Btn_strokesSquare_Click(object sender, RoutedEventArgs e)
        {
            // Instead of creating a polygon with points the button uses strokes to and stylus points to construct a rectangular shape.
            // This is done so that the strokes can be detected as a stroke collection which Is easier to animate with cetain types of animation.
            StylusPointCollection pts = new StylusPointCollection();
            pts.Add(new StylusPoint(10, 10));
            pts.Add(new StylusPoint(10, 100));
            pts.Add(new StylusPoint(100, 100));
            pts.Add(new StylusPoint(100, 10));
            pts.Add(new StylusPoint(10, 10));
            //Defines the stoke as the number of points
            Stroke s = new Stroke(pts);
            s.DrawingAttributes.Color = Colors.Red;
            animationInkCanvas.Strokes.Add(s);
        }

        private void Btn_polyline_Click(object sender, RoutedEventArgs e)
        {
            // Selects the polyline from the tool enumeration
            currentToolSelected = ToolMode.PolyLine;
            Polyline myPolyline = new Polyline();
            myPolyline.Stroke = System.Windows.Media.Brushes.SlateGray;
            myPolyline.StrokeThickness = 3;
            myPolyline.FillRule = FillRule.EvenOdd;
            //Plots the points of the polyline
            System.Windows.Point Point4 = new System.Windows.Point(1, 40);
            System.Windows.Point Point5 = new System.Windows.Point(10, 85);
            System.Windows.Point Point6 = new System.Windows.Point(20, 40);
            //adds the points to a point collection, polygons and polylines need to be saved as a point 
            //collection so they can be animated.
            PointCollection myPointCollection2 = new PointCollection();
            myPointCollection2.Add(Point4);
            myPointCollection2.Add(Point5);
            myPointCollection2.Add(Point6);
            myPolyline.Points = myPointCollection2;
            animationInkCanvas.Children.Add(myPolyline);
        }

        //Button when on click should change the colour of an existing polygon on the InkCanvas
        private void BtnColour_Animate_Click(object sender, RoutedEventArgs e)
        {
            //Create the Solid Colour Brush
            SolidColorBrush aquaBrush = new SolidColorBrush();
            aquaBrush.Color = Colors.Aqua;

            //Create the recatngle filled with the soid colour
            Rectangle colorRectangle = new Rectangle();
            colorRectangle.Width = 300;
            colorRectangle.Height = 200;
            colorRectangle.Fill = aquaBrush;

            //Register the name of the brush
            this.RegisterName("aquaBrush", aquaBrush);

            //Animate the brush with a green color
            ColorAnimation mouseEnterColorAnimation = new ColorAnimation();
            mouseEnterColorAnimation.To = Colors.Green;
            mouseEnterColorAnimation.Duration = TimeSpan.FromSeconds(1);
            mouseEnterColorAnimation.RepeatBehavior = RepeatBehavior.Forever;
            Storyboard.SetTargetName(mouseEnterColorAnimation, "aquaBrush");
            Storyboard.SetTargetProperty(
                mouseEnterColorAnimation, new PropertyPath(SolidColorBrush.ColorProperty));
            Storyboard mouseEnterStoryboard = new Storyboard();
            mouseEnterStoryboard.Children.Add(mouseEnterColorAnimation);

            mouseEnterStoryboard.Begin(this);

            animationInkCanvas.Children.Add(colorRectangle);
        }

        private void Button_polygonSquare_1(object sender, RoutedEventArgs e)
        {
            var polygon = new Polygon { StrokeThickness = 1, Fill = Brushes.Red };
            polygon.Points.Add(new Point(10, 50));
            polygon.Points.Add(new Point(180, 50));
            polygon.Points.Add(new Point(180, 150));
            polygon.Points.Add(new Point(10, 150));
            animationInkCanvas.Children.Add(polygon);
        }

        // A button whcih generates a fade animation using a creted Rectangle object
        private void BtnFade_animate_Click(object sender, RoutedEventArgs e)
        {
            //Generates and sets the name of the rectangle object
            Rectangle myRectangle = new Rectangle();
            myRectangle.Name = "myRectangle";
            this.RegisterName(myRectangle.Name, myRectangle);
            myRectangle.Width = 100;
            myRectangle.Height = 100;
            myRectangle.Fill = Brushes.Blue;

            //Seta animation type as a DoubleAnimation
            //Sets duration and behaviours of the animation
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            myDoubleAnimation.From = 1.0;
            myDoubleAnimation.To = 0.0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
            myDoubleAnimation.AutoReverse = true;
            myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

            // Defines the storyboard for this animation, sets the target of the animation and the 
            // property of the target that the animation is changing
            myStoryboard = new Storyboard();
            myStoryboard.Children.Add(myDoubleAnimation);
            Storyboard.SetTargetName(myDoubleAnimation, myRectangle.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.OpacityProperty));

            // Activates the storyboard
            myStoryboard.Begin(this);

            // Use loaded event to start the Storyboard
            animationInkCanvas.Children.Add(myRectangle);
        }

        private void myRectangleLoaded(object sender, RoutedEventArgs e)
        {
            myStoryboard.Begin(this);
        }

        // An animation which rotates a aquare 360 degrees
        private void Btn_rotate_animation_Click(object sender, RoutedEventArgs e)
        {
            // Creates new polygon as a target onject before the animation starts
            var squarepolygon = new Polygon { StrokeThickness = 1, Fill = Brushes.Green };
            squarepolygon.Points.Add(new Point(10, 50));
            squarepolygon.Points.Add(new Point(180, 50));
            squarepolygon.Points.Add(new Point(180, 150));
            squarepolygon.Points.Add(new Point(10, 150));
            animationInkCanvas.Children.Add(squarepolygon);

            // Creates the rotate animation as a double animation
            DoubleAnimation da = new DoubleAnimation();
            da.From = 0;
            da.To = 360;
            da.Duration = new Duration(TimeSpan.FromSeconds(3));
            da.RepeatBehavior = RepeatBehavior.Forever;
            da.AutoReverse = true;
            // Sets the behavior of the polygon to RenderTransform, where the object moves to a specific point
            RotateTransform rt = new RotateTransform();
            squarepolygon.RenderTransform = rt;
            rt.BeginAnimation(RotateTransform.AngleProperty, da);
        }

        private void Btn_pathAnimation_Click(object sender, RoutedEventArgs e)
        {
            EllipseGeometry animatedEllipseGeometry =
                new EllipseGeometry(new Point(10, 100), 15, 15);

            //Register The name of the Ellipse with the page so it is targeted by the storyboard
            this.RegisterName("AnimatedEllipseGeometry", animatedEllipseGeometry);

            //Creates a path element to display the ellipse
            System.Windows.Shapes.Path ellipsePath = new System.Windows.Shapes.Path();
            ellipsePath.Data = animatedEllipseGeometry;
            ellipsePath.Fill = Brushes.Crimson;
            ellipsePath.Margin = new Thickness(15);

            //Display the ellipsePath on the existing Inkcanvas
            animationInkCanvas.Children.Add(ellipsePath);
            this.Content = animationInkCanvas;

            //Create the animation path.
            PathGeometry animationPath = new PathGeometry();
            PathFigure pFigure = new PathFigure();
            pFigure.StartPoint = new Point(10, 100);
            PolyBezierSegment pBezierSegment = new PolyBezierSegment();
            //Setting the points for the bezier curve
            pBezierSegment.Points.Add(new Point(35, 0));
            pBezierSegment.Points.Add(new Point(135, 0));
            pBezierSegment.Points.Add(new Point(155, 100));
            pBezierSegment.Points.Add(new Point(180, 190));
            pBezierSegment.Points.Add(new Point(270, 200));
            pBezierSegment.Points.Add(new Point(310, 100));
            pFigure.Segments.Add(pBezierSegment);
            animationPath.Figures.Add(pFigure);

            //Freezing the pathgeometry impoves performace
            animationPath.Freeze();

            PointAnimationUsingPath centerPointAnimation =
                new PointAnimationUsingPath();
            centerPointAnimation.PathGeometry = animationPath;
            centerPointAnimation.Duration = TimeSpan.FromSeconds(5);

            // Create a Storyboard for the animation to run
            Storyboard.SetTargetName(centerPointAnimation, "AnimatedEllipseCurve");
            Storyboard.SetTargetProperty(centerPointAnimation,
                new PropertyPath(EllipseGeometry.CenterProperty));

            // Apply the Path Animation to the storyboard
            Storyboard pathAnimationStoryboard = new Storyboard();
            pathAnimationStoryboard.AutoReverse = true;
            pathAnimationStoryboard.Children.Add(centerPointAnimation);

        }

        private void endAnimation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dash_line_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        /// <summary>
        /// Combobox items which allow the user to select varios colours of lines to add to the Inkcanvas
        /// </summary>
        private void Item_BlackLine_Selected(object sender, RoutedEventArgs e)
        {
            if (animationInkCanvas != null)
            {
                // Defines the line object
                Line objLine = new Line();

                // Sets the colour of the line stroke (in this case balck)
                objLine.Stroke = System.Windows.Media.Brushes.Black;
                objLine.Fill = System.Windows.Media.Brushes.Black;

                // Sets the margin positioning of the line element within the application Inkcanvas
                objLine.X1 = Item_BlackLine.ActualWidth + Item_BlackLine.Margin.Left;
                objLine.Y1 = Item_BlackLine.ActualHeight + Item_BlackLine.Margin.Top;

                objLine.X2 = Application.Current.MainWindow.ActualWidth;
                objLine.Y2 = Application.Current.MainWindow.ActualHeight;

                animationInkCanvas.Children.Add(objLine);
            }
        }

        private void Item_RedLine_Selected(object sender, RoutedEventArgs e)
        {
            if (animationInkCanvas != null)
            {
                Line objLine = new Line();

                objLine.Stroke = System.Windows.Media.Brushes.Red;
                objLine.Fill = System.Windows.Media.Brushes.Red;

                objLine.X1 = Item_RedLine.ActualWidth + Item_RedLine.Margin.Left;
                objLine.Y1 = Item_RedLine.ActualHeight + Item_RedLine.Margin.Top;

                objLine.X2 = Application.Current.MainWindow.ActualWidth;
                objLine.Y2 = Application.Current.MainWindow.ActualHeight;

                animationInkCanvas.Children.Add(objLine);
            }
        }

        private void Item_BlueLine_Selected(object sender, RoutedEventArgs e)
        {
            if (animationInkCanvas != null)
            {
                Line objLine = new Line();

                objLine.Stroke = System.Windows.Media.Brushes.Blue;
                objLine.Fill = System.Windows.Media.Brushes.Blue;

                objLine.X1 = Item_BlueLine.ActualWidth + Item_BlueLine.Margin.Left;
                objLine.Y1 = Item_BlueLine.ActualHeight + Item_BlueLine.Margin.Top;

                objLine.X2 = Application.Current.MainWindow.ActualWidth;
                objLine.Y2 = Application.Current.MainWindow.ActualHeight;

                animationInkCanvas.Children.Add(objLine);
            }

        }

        private void Ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // Check box to switch the pen stroke mode to highlighter
        private void SwitchHighliter_Checked(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.DefaultDrawingAttributes.IsHighlighter = true;
        }

        // This switches the pen stroke mode back to default once the checkbox is unchecked 
        private void SwitchHighliter_Unchecked(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.DefaultDrawingAttributes.IsHighlighter = false;
        }

        private void BtnDraw_triangle_Click(object sender, RoutedEventArgs e)
        {
            // Creates a new Pointcollection class
            // Points are then added to the collection and their position is defined
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(new Point(0, 0));
            myPointCollection.Add(new Point(0, 30));
            myPointCollection.Add(new Point(1, 50));

            // Triangle is created as a Polygon class
            Polygon myTriangle = new Polygon();
            myTriangle.Points = myPointCollection;
            myTriangle.Width = 100;
            myTriangle.Height = 100;
            myTriangle.Stretch = Stretch.Fill;
            myTriangle.Stroke = Brushes.Magenta;
            myTriangle.StrokeThickness = 2;

            animationInkCanvas.Children.Add(myTriangle);
        }

        private void Animation_Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Item_Square_fade_Selected(object sender, RoutedEventArgs e)
        {
            if (animationInkCanvas != null)
            {
                //Generates and sets the name of the rectanglle object
                currentToolSelected = ToolMode.Polygon;
                Rectangle myRectangle = new Rectangle();
                myRectangle.Name = "myRectangle";
                this.RegisterName(myRectangle.Name, myRectangle);
                myRectangle.Width = 100;
                myRectangle.Height = 100;
                myRectangle.Fill = Brushes.Blue;

                //Seta animation type as a DoubleAnimation
                //Sets duration and behaviours of the animation
                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = 1.0;
                myDoubleAnimation.To = 0.0;
                myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
                myDoubleAnimation.AutoReverse = true;
                myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

                Storyboard fadeStoryboard = new Storyboard();
                Storyboard.SetTargetName(myDoubleAnimation, myRectangle.Name);
                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Rectangle.OpacityProperty));
                fadeStoryboard.Children.Add(myDoubleAnimation);

                fadeStoryboard.Begin(this);
                //Use loaded event to start the Storyboard
                animationInkCanvas.Children.Add(myRectangle);
            }

        }

        private void Item_Ellipse_fade_Selected(object sender, RoutedEventArgs e)
        {
            if (animationInkCanvas != null)
            {
                currentToolSelected = ToolMode.Ellipse;
                Ellipse myEllipse = new Ellipse();
                myEllipse.Stroke = System.Windows.Media.Brushes.Black;
                myEllipse.Fill = System.Windows.Media.Brushes.DarkBlue;
                myEllipse.HorizontalAlignment = HorizontalAlignment.Left;
                myEllipse.VerticalAlignment = VerticalAlignment.Center;
                myEllipse.Width = 50;
                myEllipse.Height = 75;
                animationInkCanvas.Children.Add(myEllipse);

                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = 1.0;
                myDoubleAnimation.To = 0.0;
                myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
                myDoubleAnimation.AutoReverse = true;
                myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

                Storyboard fadeStoryboard = new Storyboard();
                Storyboard.SetTargetName(myDoubleAnimation, myEllipse.Name);
                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Ellipse.OpacityProperty));
                fadeStoryboard.Children.Add(myDoubleAnimation);

                fadeStoryboard.Begin(this);

                animationInkCanvas.Children.Add(myEllipse);
            }
        }

        private void Item_Triangle_fade_Selected(object sender, RoutedEventArgs e)
        {
            if (animationInkCanvas != null)
            {
                currentToolSelected = ToolMode.Polygon;
                PointCollection myPointCollection = new PointCollection();
                myPointCollection.Add(new Point(0, 0));
                myPointCollection.Add(new Point(0, 30));
                myPointCollection.Add(new Point(1, 50));

                Polygon myTriangle = new Polygon();
                myTriangle.Points = myPointCollection;
                myTriangle.Width = 100;
                myTriangle.Height = 100;
                myTriangle.Stretch = Stretch.Fill;
                myTriangle.Fill = Brushes.Magenta;
                myTriangle.StrokeThickness = 2;

                DoubleAnimation myDoubleAnimation = new DoubleAnimation();
                myDoubleAnimation.From = 1.0;
                myDoubleAnimation.To = 0.0;
                myDoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(5));
                myDoubleAnimation.AutoReverse = true;
                myDoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;

                Storyboard fadeStoryboard = new Storyboard();
                Storyboard.SetTargetName(myDoubleAnimation, myTriangle.Name);
                Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath(Polygon.OpacityProperty));
                fadeStoryboard.Children.Add(myDoubleAnimation);

                fadeStoryboard.Begin(this);

                animationInkCanvas.Children.Add(myTriangle);
            }
        }

        private void Btn_Background_colour_Checked(object sender, RoutedEventArgs e)
        {
            ColorAnimation animation;
            animation = new ColorAnimation();
            animation.From = Color.FromRgb(206, 217, 208);
            animation.To = Color.FromRgb(53, 59, 60);
            animation.Duration = new Duration(TimeSpan.FromSeconds(1));
            this.animationInkCanvas.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        }

        private void Btn_Background_colour_Unchecked(object sender, RoutedEventArgs e)
        {
            ColorAnimation animation;
            animation = new ColorAnimation();
            animation.From = Color.FromRgb(53, 59, 60);
            animation.To = Color.FromRgb(206, 217, 208);
            animation.Duration = new Duration(TimeSpan.FromSeconds(1));
            this.animationInkCanvas.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            currentToolSelected = ToolMode.ThinBrush;
            animationInkCanvas.DefaultDrawingAttributes.Color = Colors.WhiteSmoke;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            animationInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            currentToolSelected = ToolMode.ThinBrush;
            animationInkCanvas.DefaultDrawingAttributes.Color = Colors.Black;
        }

        private void Btn_BezierCurve_Click(object sender, RoutedEventArgs e)
        {
            PathFigure pthFigure = new PathFigure();
            pthFigure.StartPoint = new Point(10, 100);

            PolyBezierSegment pbzSeg = new PolyBezierSegment();
            pbzSeg.Points.Add(new Point(0, 0));
            pbzSeg.Points.Add(new Point(50, 0));
            pbzSeg.Points.Add(new Point(100, 150));
            pbzSeg.Points.Add(new Point(100, 0));
            pbzSeg.Points.Add(new Point(150, 25));
            pbzSeg.Points.Add(new Point(200, 100));

            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
            myPathSegmentCollection.Add(pbzSeg);

            pthFigure.Segments = myPathSegmentCollection;

            PathFigureCollection pthFigureCollection = new PathFigureCollection();
            pthFigureCollection.Add(pthFigure);

            PathGeometry pthGeometry = new PathGeometry();
            pthGeometry.Figures = pthFigureCollection;

            System.Windows.Shapes.Path arcPath = new System.Windows.Shapes.Path();
            arcPath.Stroke = new SolidColorBrush(Colors.Black);
            arcPath.StrokeThickness = 1;
            arcPath.Data = pthGeometry;
            arcPath.Fill = new SolidColorBrush(Colors.LawnGreen);

            animationInkCanvas.Children.Add(arcPath);
        }

        private void Item_Square_color_Selected(object sender, RoutedEventArgs e)
        {
            if (animationInkCanvas != null)
            {
                //Create the Solid Colour Brush
                SolidColorBrush aquaBrush = new SolidColorBrush();
                aquaBrush.Color = Colors.Aqua;

                //Create the recatngle filled with the soid colour
                Rectangle colorRectangle = new Rectangle();
                colorRectangle.Width = 300;
                colorRectangle.Height = 200;
                colorRectangle.Fill = aquaBrush;

                //Register the name of the brush
                this.RegisterName("aquaBrush", aquaBrush);

                //Animate the brush with a green color
                ColorAnimation mouseEnterColorAnimation = new ColorAnimation();
                mouseEnterColorAnimation.To = Colors.Green;
                mouseEnterColorAnimation.Duration = TimeSpan.FromSeconds(1);
                mouseEnterColorAnimation.RepeatBehavior = RepeatBehavior.Forever;
                Storyboard.SetTargetName(mouseEnterColorAnimation, "aquaBrush");
                Storyboard.SetTargetProperty(
                    mouseEnterColorAnimation, new PropertyPath(SolidColorBrush.ColorProperty));
                Storyboard mouseEnterStoryboard = new Storyboard();
                mouseEnterStoryboard.Children.Add(mouseEnterColorAnimation);

                mouseEnterStoryboard.Begin(this);

                animationInkCanvas.Children.Add(colorRectangle);
            }
        }

        private void Item_Ellipse_color_Selected(object sender, RoutedEventArgs e)
        {
            if (animationInkCanvas != null)
            {
                // Create the Solid Colour Brush
                SolidColorBrush chocBrush = new SolidColorBrush();
                chocBrush.Color = Colors.Chocolate;

                // This button uses similar code to the one above but creates an ellipse instead of a rectangle to fill with colour
                currentToolSelected = ToolMode.Ellipse;
                Ellipse colorEllipse = new Ellipse();
                colorEllipse.Fill = chocBrush;
                colorEllipse.HorizontalAlignment = HorizontalAlignment.Left;
                colorEllipse.VerticalAlignment = VerticalAlignment.Center;
                colorEllipse.Width = 300;
                colorEllipse.Height = 120;

                //Register the name of the brush
                this.RegisterName("chocBrush", chocBrush);

                //Animate the brush with a gold color
                ColorAnimation mouseEnterColorAnimation = new ColorAnimation();
                mouseEnterColorAnimation.To = Colors.DarkSlateBlue;
                mouseEnterColorAnimation.Duration = TimeSpan.FromSeconds(5);
                mouseEnterColorAnimation.RepeatBehavior = RepeatBehavior.Forever;
                Storyboard.SetTargetName(mouseEnterColorAnimation, "chocBrush");
                Storyboard.SetTargetProperty(
                    mouseEnterColorAnimation, new PropertyPath(SolidColorBrush.ColorProperty));
                Storyboard mouseEnterStoryboard = new Storyboard();
                mouseEnterStoryboard.Children.Add(mouseEnterColorAnimation);

                mouseEnterStoryboard.Begin(this);

                animationInkCanvas.Children.Add(colorEllipse);
            }
        }

        private void Item_Triangle_color_Selected(object sender, RoutedEventArgs e)
        {
            if (animationInkCanvas != null)
            {
                SolidColorBrush tanBrush = new SolidColorBrush();
                tanBrush.Color = Colors.Tan;

                //Create the Triangle polygon
                PointCollection myPointCollection = new PointCollection();
                myPointCollection.Add(new Point(0, 0));
                myPointCollection.Add(new Point(0, 30));
                myPointCollection.Add(new Point(1, 50));

                Polygon colorTriangle = new Polygon();
                colorTriangle.Points = myPointCollection;
                colorTriangle.Width = 100;
                colorTriangle.Height = 100;
                colorTriangle.Stretch = Stretch.Fill;
                colorTriangle.Fill = tanBrush;

                //Register the name of the brush
                this.RegisterName("tanBrush", tanBrush);

                //Animate the brush with a gold color
                ColorAnimation mouseEnterColorAnimation = new ColorAnimation();
                mouseEnterColorAnimation.To = Colors.Magenta;
                mouseEnterColorAnimation.Duration = TimeSpan.FromSeconds(3);
                mouseEnterColorAnimation.RepeatBehavior = RepeatBehavior.Forever;
                Storyboard.SetTargetName(mouseEnterColorAnimation, "tanBrush");
                Storyboard.SetTargetProperty(
                    mouseEnterColorAnimation, new PropertyPath(SolidColorBrush.ColorProperty));
                Storyboard mouseEnterStoryboard = new Storyboard();
                mouseEnterStoryboard.Children.Add(mouseEnterColorAnimation);

                mouseEnterStoryboard.Begin(this);

                animationInkCanvas.Children.Add(colorTriangle);
            }
        }

        private void Btn_animatePolyline_Click(object sender, RoutedEventArgs e)
        {
            Line getMyTargetLine = new Line();

            // Sets stroke stroke colour and thickness of the line object
            getMyTargetLine.Stroke = System.Windows.Media.Brushes.Blue;
            getMyTargetLine.Fill = System.Windows.Media.Brushes.Blue;
            getMyTargetLine.StrokeThickness = 4;

            // Sets the line length to the margins of the window inkcanvas
            getMyTargetLine.X1 = Item_BlueLine.ActualWidth + Item_BlueLine.Margin.Left;
            getMyTargetLine.Y1 = Item_BlueLine.ActualHeight + Item_BlueLine.Margin.Top;

            // Line length changes with the actual height and width of the window
            getMyTargetLine.X2 = Application.Current.MainWindow.ActualWidth;
            getMyTargetLine.Y2 = Application.Current.MainWindow.ActualHeight;

            // Sets the duration and creates a stroryboard for the animation
            var duration = new Duration(TimeSpan.FromSeconds(0.1));
            var colorAnimation = new ColorAnimation();
            colorAnimation.To = Colors.LightGreen;
            colorAnimation.RepeatBehavior = RepeatBehavior.Forever;
            Storyboard.SetTarget(colorAnimation, getMyTargetLine);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("Stroke.Color"));
            Storyboard lineColorStoryboard = new Storyboard();
            lineColorStoryboard.Children.Add(colorAnimation);

            lineColorStoryboard.Begin(this);

            animationInkCanvas.Children.Add(getMyTargetLine);
        }

        private void RibbonButton_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDraw_Arc_Click(object sender, RoutedEventArgs e)
        {
            PathFigure pthFigure = new PathFigure();
            pthFigure.StartPoint = new Point(0, 100);

            ArcSegment arcseg = new ArcSegment();
            arcseg.Point = new Point(200, 100);
            arcseg.Size = new Size(300, 50);
            arcseg.IsLargeArc = true;
            arcseg.IsLargeArc = true;
            arcseg.SweepDirection = SweepDirection.Counterclockwise;
            arcseg.RotationAngle = 30;

            PathSegmentCollection myPathSegmentCollection = new PathSegmentCollection();
            myPathSegmentCollection.Add(arcseg);

            pthFigure.Segments = myPathSegmentCollection;

            PathFigureCollection pthFigureCollection = new PathFigureCollection();
            pthFigureCollection.Add(pthFigure);

            PathGeometry pthGeometry = new PathGeometry();
            pthGeometry.Figures = pthFigureCollection;

            System.Windows.Shapes.Path arcPath = new System.Windows.Shapes.Path();
            arcPath.Stroke = new SolidColorBrush(Colors.Black);
            arcPath.StrokeThickness = 1;
            arcPath.Data = pthGeometry;
            arcPath.Fill = new SolidColorBrush(Colors.Yellow);

            animationInkCanvas.Children.Add(arcPath);
        }

        private void ButtonLoad_Click_2(object sender, RoutedEventArgs e)
        {
            //Opens a file explorer dialog and allows the user to select an image file to import into the application
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All Supported FileTypes(*.*)|*.* JPEG| (*.jpg;*.jpeg)|*.jpg;*.jpeg| Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                // Drive Identifier must match the drive the appluication is on
                image.UriSource = new Uri("G:/University of suffolk/Level 5/Advanced software development/WPF/WpfAnimationsApp/image1.png");
                image.EndInit();
                //image1.Source = image;
                Image newImageElement = new Image();
                newImageElement.Source = image;
                animationInkCanvas.Children.Add(newImageElement);
            }
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document1"; // Setting the default File Name
            dlg.DefaultExt = ".text"; // Setting the default file extension
            dlg.Filter = "Text documents (.txt)|*txt"; //Filters files by extension

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
            }
        }

        private void Btn_copy_Click(object sender, RoutedEventArgs e)
        {
            if (this.animationInkCanvas.GetSelectedStrokes().Count > 0)
                this.animationInkCanvas.CopySelection();
        }

        private void Btn_Paste_Click(object sender, RoutedEventArgs e)
        {
            if (this.animationInkCanvas.CanPaste())
                this.animationInkCanvas.Paste();
        }

        private void Btn_ImgScale_Click(object sender, RoutedEventArgs e)
        {

            ////WriteableBitmap bitmap = new WriteableBitmap();
            ////bitmap.SetSource();
            ////image1.Source = bitmap;

            //// open file stream
            //OpenFileDialog dlg;
            //dlg = new OpenFileDialog();

            //Uri uri;
            //ImageSource imageSource;
            //imageSource = image1.Source;

            //if (dlg.ShowDialog() == true)
            //{
            //    uri = new Uri(dlg.FileName);
            //    BitmapImage bitmapImage = new BitmapImage();
            //    bitmapImage.BeginInit();
            //    bitmapImage.StreamSource = imageSource.;
                //    //bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                //    //bitmapImage.EndInit();

                //    //BitmapImage.Create()
                //    //return bitmapimage;
                //    //}
                //    Image.
                //    image1.Source = bitmapImage;
                //}

                ////using (MemoryStream memory = new MemoryStream())
                ////{
                //    //bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                //    //memory.Position = 0;



                ////Image img = new Image();
                ////img.Source = bitmapImage;
                ////WriteableBitmap i;


                ////do
                ////{
                ////    ScaleTransform st = new ScaleTransform();
                ////    st.ScaleX = 0.3;
                ////    st.ScaleY = 0.3;
                ////    i = new WriteableBitmap(img, st);
                ////    img.Source = i;
                ////} while (i.Pixels.Length / 1024 > 100);
            }
    }
}
