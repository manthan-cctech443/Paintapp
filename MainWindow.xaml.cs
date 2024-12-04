﻿using System.Text;
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
            

        }

        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                //if(mode)
                Line line = new Line();
                line.Stroke = SystemColors.WindowFrameBrush;
                line.X1 = currentPoint.X;
                line.Y1 = currentPoint.Y;
                line.X2 = e.GetPosition(myCanvas).X;
                line.Y2 = e.GetPosition(myCanvas).Y;
                currentPoint = e.GetPosition(myCanvas);

                string len = Brushsize.SelectedItem.ToString();
                string pattern = @"\d{1,2}$";
                Match match = Regex.Match(len, pattern);
                line.StrokeThickness = int.Parse(match.Value);
                myCanvas.Children.Add(line);
            }
        }
    }
}