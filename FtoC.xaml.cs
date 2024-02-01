using WPFCustomMessageBox;
using System.Windows;

namespace WpfApp1;

public partial class FtoC : Window
{
    public FtoC()
    {
        InitializeComponent();
    }
    
    private void BtnClose_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
    
    private void BtnConvert_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (TxtCelsius.Text != string.Empty && TxtFahrenheit.Text == string.Empty)
            {
                var celsius = double.TryParse(TxtCelsius.Text, out var celsiusValue)
                    ? celsiusValue
                    : throw new Exception("Invalid Celsius value");
                var fahrenheit = celsiusValue * 9 / 5 + 32;
                TxtFahrenheit.Text = fahrenheit.ToString("F2");
            }
            else if (TxtCelsius.Text == string.Empty && TxtFahrenheit.Text != string.Empty)
            {
                var fahrenheit = double.TryParse(TxtFahrenheit.Text, out var fahrenheitValue)
                    ? fahrenheitValue
                    : throw new Exception("Invalid Fahrenheit value");
                var celsius = (fahrenheitValue - 32) * 5 / 9;
                TxtCelsius.Text = celsius.ToString("F2");
            }
            else if(TxtCelsius.Text != string.Empty && TxtFahrenheit.Text != string.Empty)
            {
                MessageBoxResult res = CustomMessageBox.ShowYesNo("Which one do you want to convert?", "°F or °C", "°F -> °C", "°C -> °F"); 
                if(res == MessageBoxResult.Yes)
                {
                    var fahrenheit = double.TryParse(TxtFahrenheit.Text, out var fahrenheitValue)
                        ? fahrenheitValue
                        : throw new Exception("Invalid Fahrenheit value");
                    var celsius = (fahrenheitValue - 32) * 5 / 9;
                    TxtCelsius.Text = celsius.ToString("F2");
                }
                else if(res == MessageBoxResult.No)
                {
                    var celsius = double.TryParse(TxtCelsius.Text, out var celsiusValue)
                        ? celsiusValue
                        : throw new Exception("Invalid Celsius value");
                    var fahrenheit = celsiusValue * 9 / 5 + 32;
                    TxtFahrenheit.Text = fahrenheit.ToString("F2");
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    
    
}