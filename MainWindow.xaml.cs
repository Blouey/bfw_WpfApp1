using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ButtonMessage_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Hello World");
        BtnMessage.Content = "Clicked";
        BtnMessage.Effect = new BlurEffect();
        
        
    }
    
    private void ButtonClose_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
    
    private void ButtonMessage_OnMouseEnter(object sender, MouseEventArgs e)
    {
        if (BtnMessage.Effect == null)
        {
            BtnMessage.Content = "Mouse Enter";
            BtnMessage.RenderSize = new Size(
                305, 105);
        }
    }

    private void BtnMessage_OnMouseLeave(object sender, MouseEventArgs e)
    {
        if (BtnMessage.Effect == null)
        {
            BtnMessage.Content = "Mouse left";
            BtnMessage.RenderSize = new Size(
                300, 100);
            Thread.Sleep(1000);
            BtnMessage.Content = "Message";
        }
    }
}