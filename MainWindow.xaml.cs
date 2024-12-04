using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point currentPoint = new Point();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.Clear();
        }

        private void Mouse_Down(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                currentPoint = e.GetPosition(myCanvas);
        }

        private void Mouse_Up(object sender, MouseButtonEventArgs e)
        {
            string mde = Mode.SelectedItem.ToString();
            int mdeIndex = mde.IndexOf(": ");
            string remde = mde.Substring(mdeIndex + 2);
            if (remde == "Straight Line")
            {
                Line line = new Line();
                line.Stroke = SystemColors.WindowFrameBrush;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(myCanvas).X;
                line.Y2 = e.GetPosition(myCanvas).Y;

                string len = Brushsize.SelectedItem.ToString();
                string pattern = @"\d{1,2}$";
                Match match = Regex.Match(len, pattern);
                line.StrokeThickness = int.Parse(match.Value);

                string colr = Brushcolor.SelectedItem.ToString();
                int colonIndex = colr.IndexOf(": ");
                string result = colr.Substring(colonIndex + 2);
                BrushConverter converter = new BrushConverter();
                Brush colorBrush = (Brush)converter.ConvertFromString(result);
                line.Stroke = colorBrush;

                myCanvas.Children.Add(line);
            }
        }

        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                string mde = Mode.SelectedItem.ToString();
                int mdeIndex = mde.IndexOf(": ");
                string remde = mde.Substring(mdeIndex + 2);

                if (remde == "Free Drawing")
                {
                    Line line = new Line();
                    line.Stroke = SystemColors.WindowFrameBrush;
                    line.X1 = currentPoint.X;
                    line.Y1 = currentPoint.Y;
                    line.X2 = e.GetPosition(myCanvas).X;
                    line.Y2 = e.GetPosition(myCanvas).Y;

                    string len = Brushsize.SelectedItem.ToString();
                    string pattern = @"\d{1,2}$";
                    Match match = Regex.Match(len, pattern);
                    line.StrokeThickness = int.Parse(match.Value);

                    string colr = Brushcolor.SelectedItem.ToString();
                    int colonIndex = colr.IndexOf(": ");
                    string result = colr.Substring(colonIndex + 2);
                    BrushConverter converter = new BrushConverter();
                    Brush colorBrush = (Brush)converter.ConvertFromString(result);
                    line.Stroke = colorBrush;

                    currentPoint = e.GetPosition(myCanvas);
                    myCanvas.Children.Add(line);
                }
            }
        }
    }
}