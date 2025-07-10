using HomeRentAppShared.Models;
using HomeRentAppMaui.Helpers;

namespace HomeRentAppMaui.Views;

public partial class DetalleDepartamentoPage : ContentPage
{
    public DetalleDepartamentoPage(Departamento departamento)
    {
        InitializeComponent();
        CargarDatos(departamento);
    }

    private async void CargarDatos(Departamento departamento)
    {
        NombreLabel.Text = departamento.Nombre;
        DireccionLabel.Text = departamento.Direccion;
        PrecioLabel.Text = $"Precio: {departamento.Precio:C}";
        CuartosLabel.Text = $"Cuartos disponibles: {departamento.CuartosDisponibles}";

        if (!string.IsNullOrEmpty(departamento.Imagen))
        {
            MainImage.Source = ImageSource.FromStream(() =>
                new MemoryStream(Convert.FromBase64String(departamento.Imagen)));
        }

        // Obtener los datos del usuario de manera segura
        var usuario = await App.UsuarioDB.GetUsuarioPorIdAsync(departamento.UsuarioId);
        if (usuario != null)
        {
            NombreUsuarioLabel.Text = $"{usuario.Nombre} {usuario.Apellido}";
            CorreoUsuarioLabel.Text = usuario.Correo;
        }
        else
        {
            NombreUsuarioLabel.Text = "Usuario no encontrado";
            CorreoUsuarioLabel.Text = "";
        }
    }
}
