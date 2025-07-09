using HomeRentAppMaui.ViewModels;

namespace HomeRentAppMaui.Views;

public partial class PerfilPage : ContentPage
{
    public PerfilPage()
    {
        InitializeComponent();
        BindingContext = new PerfilViewModel();
    }
}
