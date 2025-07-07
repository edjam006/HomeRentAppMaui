using HomeRentAppShared.Models;
using HomeRentAppMaui.Services;
using HomeRentAppMaui.ViewModels;
using SQLite;

namespace HomeRentAppMaui.Views
{
    public partial class DepartamentoPage : ContentPage
    {
        public DepartamentoPage()
        {
            InitializeComponent();
            BindingContext = new DepartamentoLocalViewModel();
        }

        private async void OnAgregarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarDepartamentoPage());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (BindingContext is DepartamentoLocalViewModel vm)
            {
                vm.CargarDepartamentos(); // asegúrate de hacerlo público
            }
        }

    }
}