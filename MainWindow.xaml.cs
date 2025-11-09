using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        long initialValue = 0;
        string operation = "";
        bool isNewEntry = true;


        public MainWindow()
        {
            InitializeComponent();
        }
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            string value = (sender as Button).Content.ToString();

            if (isNewEntry)
            {
                isNewEntry = false;
                Display.Text = value;
            }
        }


        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if(Display.Text.Length > 1)
            {
                Display.Text = Display.Text.Remove(Display.Text.Length - 1);
            }
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            string op = (sender as Button).Content.ToString();


            if (op == "*") op = "*";
            if (op == "/") op = "/";


            initialValue = long.Parse(Display.Text);
            operation = op;
            isNewEntry = true;
        }



        private void Equals_Click(object sender, RoutedEventArgs e)
        {

            long secondNumber = long.Parse(Display.Text);
            long result = 0;
            switch (operation)
            {
                case "*": result = initialValue * secondNumber; break;
                case "+": result = initialValue + secondNumber; break;
                case "-": result = initialValue - secondNumber; break;
                case "/": result = secondNumber == 0 ? initialValue/ secondNumber: 0;break;
            }
            Display.Text = result.ToString();
            isNewEntry = true;

        }



        private void Clear_Click(object sender, RoutedEventArgs e)
        {

            Display.Text = "0";
            initialValue = 0;
            operation = "";
            isNewEntry = true;
        }
    }
}