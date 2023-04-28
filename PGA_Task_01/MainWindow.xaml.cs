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

namespace PGA_Task_01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button lastButton;
        String[] signs = { "+", "-", "/", "*" };
        int result = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            if (lastButton != null && lastButton.Content.ToString() == "=")
            {
                Output.Text = result.ToString();
            }
            var button = (Button)(sender);
            Output.Text += button.Content;
            lastButton = button;
        }

        private void OnSignClick(object sender, RoutedEventArgs e)
        {
            if (lastButton != null && lastButton.Content.ToString() == "=")
            {
                Output.Text = result.ToString();
            }
            var button = (Button)(sender);
            var vars = Output.Text.Split(' ');
            if (Output.Text.Length > 0)
            {
                if (lastButton != null && signs.Contains(lastButton.Content))
                {

                    Output.Text = Output.Text.Remove(Output.Text.Length - 3);

                }
                Output.Text += $" {button.Content} ";
            }


            lastButton = button;
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            if (lastButton != null && lastButton.Content.ToString() == "=")
            {
                Output.Text = result.ToString();
            }
            // TODO
            var button = (Button)(sender);
            var vars = Output.Text.Split(' ');

            int.TryParse(vars[0], out var A);
            int.TryParse(vars[2], out var B);

            Output.Text += " = ";
            switch (vars[1])
            {
                case "+":
                    Output.Text += (A + B).ToString();
                    result += A + B;
                    break;
                case "-":
                    Output.Text += (A - B).ToString();
                    result += A - B;
                    break;
                case "*":
                    Output.Text += (A * B).ToString();
                    result += A * B;
                    break;
                case "/":
                    if (B != 0)
                    {
                        Output.Text += (A / B).ToString();
                        result += A / B;
                    }
                    else
                    {
                        Output.Text = "На ноль делить нельзя!";
                    }
                    break;
            }
            lastButton = button;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Output.Text = "";
            lastButton = (Button)(sender);
        }
    }
}
