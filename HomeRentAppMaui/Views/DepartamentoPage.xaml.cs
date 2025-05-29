using HomeRentAppShared.Models;
using HomeRentAppMaui.Services;

namespace HomeRentAppMaui.Views;

public partial class DepartamentoPage : ContentPage
{
    private readonly DepartamentoService _service = new();

    public DepartamentoPage()
    {
        InitializeComponent();
        _ = LoadDepartamentos();
    }

    private async Task LoadDepartamentos()
    {
        var lista = await _service.ObtenerDepartamentosAsync();
        DepartamentosCollection.ItemsSource = lista;
    }

    private async void OnAgregarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AgregarDepartamentoPage());
    }
}
