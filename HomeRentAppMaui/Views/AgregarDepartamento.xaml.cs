using HomeRentAppShared.Models;
using HomeRentAppMaui.Services;

namespace HomeRentAppMaui.Views;

public partial class AgregarDepartamentoPage : ContentPage
{
    private readonly DepartamentoService _service = new();

    public AgregarDepartamentoPage()
    {
        InitializeComponent();
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        var nuevo = new Departamento
        {
            Nombre = NombreEntry.Text,
            Direccion = DireccionEntry.Text,
            Precio = decimal.TryParse(PrecioEntry.Text, out var p) ? p : 0,
            CuartosDisponibles = int.TryParse(CuartosEntry.Text, out var c) ? c : 0,
            UsuarioId = "admin" // reemplaza con lógica real si usas login
        };

        bool ok = await _service.CrearDepartamentoAsync(nuevo);

        if (ok)
        {
            await DisplayAlert("Éxito", "Departamento registrado", "OK");
            await Navigation.PopAsync(); // Regresa a la vista anterior
        }
        else
        {
            await DisplayAlert("Error", "No se pudo registrar", "OK");
        }
    }
}
