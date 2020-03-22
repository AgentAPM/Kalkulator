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

namespace Kalkulator
{
    public partial class MainWindow : Window
    {
        long display = 0;
        decimal accumulator = 0;
        byte digits = 0, maxdigits = 10;
        decimal point = 100;
        char operation = ' ';
        bool touched = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private decimal Point
        {
            get
            {
                if (point > 1)
                {
                    point = 100;
                    return (1);
                }
                else if (point < -1)
                {
                    point = -100;
                    return (-1);
                }
                else
                    return (point);
            }
            set
            {
                point = value;
            }
        }
        private void UpdateDisplay()
        {
            Result.Text = (display * Point).ToString();
            Result.Text = Result.Text.Substring(0,Math.Min(maxdigits + 1, Result.Text.Length));
        }
        private void DisplayAccumulator()
        {
            Result.Text = accumulator.ToString();
            Result.Text = Result.Text.Substring(0,Math.Min(maxdigits + 1, Result.Text.Length));
        }
        private void ResetDisplay()
        {
            display = 0;
            digits = 0;
            point = 100;
            touched = false;
        }
        private void AddDigit(short d)
        {
            if (digits < maxdigits)
            {
                display = display * 10 + d;
                digits++;
                if (point != 0)
                    point /= 10;
            }
            UpdateDisplay();
            touched = true;
        }
        private void Execute(char next = ' ')
        {
            if (touched)
            {
                switch (operation)
                {
                    case '+':
                        accumulator += display * Point;
                        break;
                    case '-':
                        accumulator -= display * Point;
                        break;
                    case '*':
                        accumulator *= display * Point;
                        break;
                    case '/':
                        if ((display * Point).Equals(0))
                        {
                            Result.Text = "Nie dziel przez 0";
                            ResetDisplay();
                            operation = next;
                            return;
                        }
                        else
                            accumulator /= display * Point;
                        break;
                    default:
                        accumulator = display * Point;
                        break;
                }
                accumulator = (decimal)(decimal.ToDouble(accumulator));
                ResetDisplay();
                DisplayAccumulator();
            }
            operation = next;
        }

        private void Click0(object sender, RoutedEventArgs e)
        {
            AddDigit(0);
            if ((digits*Point).Equals(0))
                digits--;
        }
        private void Click1(object sender, RoutedEventArgs e)
        {
            AddDigit(1);
        }
        private void Click2(object sender, RoutedEventArgs e)
        {
            AddDigit(2);
        }
        private void Click3(object sender, RoutedEventArgs e)
        {
            AddDigit(3);
        }
        private void Click4(object sender, RoutedEventArgs e)
        {
            AddDigit(4);
        }
        private void Click5(object sender, RoutedEventArgs e)
        {
            AddDigit(5);
        }
        private void Click6(object sender, RoutedEventArgs e)
        {
            AddDigit(6);
        }
        private void Click7(object sender, RoutedEventArgs e)
        {
            AddDigit(7);
        }
        private void Click8(object sender, RoutedEventArgs e)
        {
            AddDigit(8);
        }
        private void Click9(object sender, RoutedEventArgs e)
        {
            AddDigit(9);
        }
        private void ClickNegate(object sender, RoutedEventArgs e)
        {
            if (touched)
            {
                point *= -1;
                UpdateDisplay();
            }
            else
            {
                accumulator *= -1;
                DisplayAccumulator();
            }
        }

        private void ClickPlus(object sender, RoutedEventArgs e)
        {
            Execute('+');
        }
        private void ClickMinus(object sender, RoutedEventArgs e)
        {
            Execute('-');
        }
        private void ClickTimes(object sender, RoutedEventArgs e)
        {
            Execute('*');
        }
        private void ClickDivide(object sender, RoutedEventArgs e)
        {
            Execute('/');
        }
        private void ClickEquals(object sender, RoutedEventArgs e)
        {
            Execute();
        }


        private void ClickPoint(object sender, RoutedEventArgs e)
        {
            if (digits==0)
                AddDigit(0);
            if (point > 1)
                point = 1;
            else if (point < -1)
                point = -1;
        }
        private void ClickClear(object sender, RoutedEventArgs e)
        {
            ResetDisplay();
            UpdateDisplay();
        }
        private void ClickReset(object sender, RoutedEventArgs e)
        {
            accumulator = 0;
            operation = ' ';
            ResetDisplay();
            UpdateDisplay();
        }
        private void ClickBack(object sender, RoutedEventArgs e)
        {
            if (digits > 0)
            {
                display /= 10;
                digits--;
                point *= 10;
                point = (decimal)(decimal.ToDouble(point));
                UpdateDisplay();
            }
        }
    }
}
