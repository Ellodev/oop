using System.Runtime.CompilerServices;
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

namespace Tannenbaum;

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
        Tanne t = new Tanne();
        if (!Int32.TryParse(Stammbreite.Text, out int stammbreite)) 
        {
            MessageBox.Show("Please enter a valid number.", "Error");
        } else if (!Int32.TryParse(Stammhoehe.Text, out int stammhoehe))
        {
            MessageBox.Show("Please enter a valid number.", "Error");
        } else if (!Int32.TryParse(Kronenhoehe.Text, out int kronenhoehe))
        {
            MessageBox.Show("Please enter a valid number.", "Error");
        }
        else
        {
            t.Stammbreite = stammbreite;
            t.Stammhoehe = stammhoehe;
            t.Kronehoehe = kronenhoehe;

            t.Zeichne();
            
            TextBlock.Text = t.Zeichnung;
        }
        
    }
}