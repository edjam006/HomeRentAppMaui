using HomeRentAppMaui.Services;
using HomeRentAppShared.Models;
using System.Text;
using System.IO;
using HomeRentAppMaui.Helpers;


namespace HomeRentAppMaui.Views;

public partial class AgregarDepartamentoPage : ContentPage
{
    private readonly DepartamentoService _service = new();
    private string _imagenBase64 = string.Empty;

    public AgregarDepartamentoPage()
    {
        InitializeComponent();
    }

    private async void OnSeleccionarImagenClicked(object sender, EventArgs e)
    {
        try
        {
            var resultado = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Selecciona una imagen",
                FileTypes = FilePickerFileType.Images
            });

            if (resultado != null)
            {
                using var stream = await resultado.OpenReadAsync();
                using var memory = new MemoryStream();
                await stream.CopyToAsync(memory);
                _imagenBase64 = Convert.ToBase64String(memory.ToArray());

                PreviewImage.Source = ImageSource.FromStream(() => new MemoryStream(memory.ToArray()));
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo cargar la imagen: {ex.Message}", "OK");
        }
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        var nuevo = new Departamento
        {
            Nombre = NombreEntry.Text,
            Direccion = DireccionEntry.Text,
            Precio = decimal.TryParse(PrecioEntry.Text, out var p) ? p : 0,
            CuartosDisponibles = int.TryParse(CuartosEntry.Text, out var c) ? c : 0,
            Imagen = _imagenBase64,
            UsuarioId = Sesion.UsuarioId // Esto para que se asigne el departamento directo al usuario logueado
        };

        bool ok = await _service.CrearDepartamentoAsync(nuevo);

        if (ok)
        {
            await DisplayAlert("Éxito", "Departamento registrado", "OK");
            await Navigation.PopAsync(); // Regresa a la lista
        }
        else
        {
            await DisplayAlert("Error", "No se pudo registrar", "OK");
        }
    }
}
