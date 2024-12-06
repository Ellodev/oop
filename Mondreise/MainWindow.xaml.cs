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

namespace Mondreise;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void SubmitButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (Double.TryParse(GeschwindigkeitInput.Text, out double geschwindigkeit))
        {
            Console.Write(geschwindigkeit);
            mondreise mondreise = new mondreise(geschwindigkeit);
            double result;
            if (RadioButtonTage.IsChecked == true)
            {
                result = mondreise.GetTravelDurationHours();
            } else if (RadioButtonStunden.IsChecked == true)
            {
                result = mondreise.GetTravelDurationDays();
            }
            else
            {
                result = 0;
            }
            Output.Text = Convert.ToString(result);
        }
        else
        {
            MessageBox.Show("Please enter a valid number.", "Error");
        }
    }
}