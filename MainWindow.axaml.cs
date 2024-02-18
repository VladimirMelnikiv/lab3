using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;
using System.Globalization;

namespace lab3
{
    public partial class MainWindow : Window
    {
        private TextBox? _display;
        private string _leftOperand = "";
        private string _rightOperand = "";
        private string? _operator;
        private double _lastResult = 0;

        public MainWindow()
        {
            InitializeComponent();
            _display = this.FindControl<TextBox>("Display");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void NumberClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var value = button.Content.ToString();
            if (value == ".")
            {
                string lastNumber = _operator == null ? _leftOperand : _rightOperand;
                if (lastNumber.Contains("."))
                {
                    // Если последнее число уже содержит точку, не добавляйте еще одну
                    return;
                }
            }
            if (_operator == null)
            {
                _leftOperand += value;
                if (_display != null)
                {
                    _display.Text = _leftOperand;
                }
            }
            else
            {
                _rightOperand += value;
                if (_display != null)
                {
                    _display.Text = _rightOperand;
                }
            }
        }

        public void OperatorClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            _operator = button.Content.ToString();
            if (_rightOperand != "")
            {
                Calculate();
                if (_display != null)
                {
                    _leftOperand = _display.Text;
                }
                _rightOperand = "";
            }
        }

        public void EqualsClick(object sender, RoutedEventArgs e)
        {
            Calculate();
            if (_display != null)
            {
                _leftOperand = _display.Text;
            }
            _rightOperand = "";
            _operator = null;
        }
        public void EqualsClicka(object sender, RoutedEventArgs e)
        {
            if (_rightOperand == "")
            {
                _rightOperand = _leftOperand;
            }
            Calculate();
            _leftOperand = _display.Text;
            _rightOperand = "";
            _operator = null;
        }

        public void Calculate()
        {
            double left = double.Parse(_leftOperand, CultureInfo.InvariantCulture);
            double right = _rightOperand == "" ? _lastResult : double.Parse(_rightOperand, CultureInfo.InvariantCulture);
            switch (_operator)
            {
                case "+":
                    if (_display != null)
                    {
                        _display.Text = (left + right).ToString();
                    }
                    break;
                case "-":
                    if (_display != null)
                    {
                        _display.Text = (left - right).ToString();
                    }
                    break;
                case "*":
                    if (_display != null)
                    {
                        _display.Text = (left * right).ToString();
                    }
                    break;
                case "/":
                    if (_display != null)
                    {
                        _display.Text = (left / right).ToString();
                    }
                    break;
                case "mod":
                    if (_display != null)
                    {
                        _display.Text = (left % right).ToString();
                    }
                    break;
                case "n!":
                    if (_display != null)
                    {
                        _display.Text = Factorial((int)left).ToString();
                    }
                    break;
                case "x^y":
                    if (_display != null)
                    {
                        _display.Text = Math.Pow(left, right).ToString();
                    }
                    break;
                case "lg":
                    if (_display != null)
                    {
                        _display.Text = Math.Log10(left).ToString();
                    }
                    break;
                case "floor":
                    if (_display != null)
                    {
                        _display.Text = Math.Floor(left).ToString();
                    }
                    break;
                case "sin":
                    if (_display != null)
                    {
                        _display.Text = Math.Sin(left).ToString();
                    }
                    break;
                case "cos":
                    if (_display != null)
                    {
                        _display.Text = Math.Cos(left).ToString();
                    }
                    break;
                case "tan":
                    if (_display != null)
                    {
                        _display.Text = Math.Tan(left).ToString();
                    }
                    break;
                case "ln":
                    if (_display != null)
                    {
                        _display.Text = Math.Log(left).ToString();
                    }
                    break;
                case "ceil":
                    if (_display != null)
                    {
                        _display.Text = Math.Ceiling(left).ToString();
                    }
                    break;
            }
            if (_display != null)
            {
                _lastResult = Convert.ToDouble(_display.Text);
            }
        }
        public void ClearClick(object sender, RoutedEventArgs e)
        {
            _leftOperand = "";
            _rightOperand = "";
            _operator = null;
            if (_display != null)
            {
                _display.Text = "0";
            }
            _lastResult = 0;
        }
        public void BackspaceClick(object sender, RoutedEventArgs e)
        {
            if (_operator == null && _leftOperand.Length > 0)
            {
                _leftOperand = _leftOperand.Substring(0, _leftOperand.Length - 1);
                if (_display != null)
                {
                    _display.Text = _leftOperand;
                }
            }
            else if (_rightOperand.Length > 0)
            {
                _rightOperand = _rightOperand.Substring(0, _rightOperand.Length - 1);
                if (_display != null)
                {
                    _display.Text = _rightOperand;
                }
            }
        }

        private static int Factorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }
            else
            {
                return number * Factorial(number - 1);
            }
        }
    }
}