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

namespace Auto;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Car? selectedCar;
    private bool isUpdating = false;
    public MainWindow()
    {
        InitializeComponent();
        
        var cars = new List<Car>()
        {
            new Car("porsche", 502),
            new Car("Ferrari", 986),
            new Car("VW", 138),
        };
        
        CarComboBox.ItemsSource = cars;
        CarComboBox.SelectedIndex = 0;
    }

    private async void Starten_OnClick(object sender, RoutedEventArgs e)
    {
        if (selectedCar != null)
        {
            selectedCar.StarteMotor();
            Start_Button.Background = new SolidColorBrush(Colors.Green);
        }
        else
        {
            MessageBox.Show("Please select a car");
        }
        if (!isUpdating)
        {
            isUpdating = true;
            await UpdateDisplayAsync();
        }
        
    }
    
    private void CarComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (CarComboBox.SelectedItem is Car car)
        {
            selectedCar = car;
            PSContainer.Text = Convert.ToString(selectedCar.PS);
        }
    }

    private void Tanken_OnClick(object sender, RoutedEventArgs e)
    {
        if (selectedCar != null)
        {
            selectedCar.Auftanken();
            FuelLevel.Value = selectedCar.GetTankFuellstand();
        }
    }

    private void Gas_OnClick(object sender, RoutedEventArgs e)
    {
        if (selectedCar != null)
        {
            selectedCar.GibGas();
            Geschwindigkeit.Text = Convert.ToString(selectedCar.GetAktuelleGeschwindigkeit());
            FuelLevel.Value = selectedCar.GetTankFuellstand();
        }
    }
    private async Task UpdateDisplayAsync()
    {
        while (isUpdating)
        {
            if (selectedCar != null)
            {
                Dispatcher.Invoke(() =>
                {
                    Geschwindigkeit.Text = selectedCar.GetAktuelleGeschwindigkeit().ToString();
                    FuelLevel.Value = selectedCar.GetTankFuellstand();
                    if (selectedCar.GetMotorState())
                    {
                        Start_Button.Background = new SolidColorBrush(Colors.Green);
                    }
                    else
                    {
                        Start_Button.Background = new SolidColorBrush(Colors.Red);
                    }

                    Gang.Text = Convert.ToString(selectedCar.GetAktuellerGang());
                });
            }
            await Task.Delay(100);
        }
    }

    private void Brake_OnClick(object sender, RoutedEventArgs e)
    {
        selectedCar.Bremse();
    }

}