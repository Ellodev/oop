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
    private bool isGasActive = false;
    private bool isBrakeActive = false;

    public MainWindow()
    {
        InitializeComponent();
        
        var cars = new List<Car>()
        {
            new Car("Porsche", 250),
            new Car("Ferrari", 370),
            new Car("Opel", 90),
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

    private async void Gas_OnClick(object sender, RoutedEventArgs e)
    {
        if (selectedCar != null && !isBrakeActive)
        {
            isGasActive = true;
            while (isGasActive)
            {
                selectedCar.GibGas();
                Geschwindigkeit.Text = selectedCar.GetAktuelleGeschwindigkeit().ToString();
                FuelLevel.Value = selectedCar.GetTankFuellstand();
                await Task.Delay(100);
            }
        }
    }

    private async void Brake_OnClick(object sender, RoutedEventArgs e)
    {
        if (selectedCar != null && !isGasActive)
        {
            isBrakeActive = true;
            while (isBrakeActive)
            {
                selectedCar.Bremse();
                Geschwindigkeit.Text = selectedCar.GetAktuelleGeschwindigkeit().ToString();
                FuelLevel.Value = selectedCar.GetTankFuellstand();
                await Task.Delay(100);
            }
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

    private void UIElement_OnMouseLeave(object sender, MouseEventArgs e)
    {
        isGasActive = false;
        isBrakeActive = false;
    }
}