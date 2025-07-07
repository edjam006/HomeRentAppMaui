using HomeRentAppShared.Models;
using HomeRentAppMaui.Services;
using HomeRentAppMaui.ViewModels;


namespace HomeRentAppMaui.Views
{
    public partial class DepartamentoPage : ContentPage
    {
        public DepartamentoPage()
        {
            InitializeComponent();
            BindingContext = new DepartamentoViewModel();
        }

        private async void OnAgregarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarDepartamentoPage());
        }
    }
}