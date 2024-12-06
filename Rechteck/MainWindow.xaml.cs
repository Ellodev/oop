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

namespace Rechteck;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if (!double.TryParse(HoeheInput.Text, out double height))
        {
            MessageBox.Show("Please enter a valid number.", "Error");
        } else if (!double.TryParse(BreiteInput.Text, out double width))
        {
            MessageBox.Show("Please enter a valid number.", "Error");
        }
        else
        {
            rechteck rechteck1 = new rechteck(height, width);
            double area = rechteck1.GetArea();
            FlaecheAusgabe.Text = Convert.ToString(area);
        }
    }
}