using HomeRentAppShared.Models;
using HomeRentAppMaui.Helpers;

namespace HomeRentAppMaui.Views;

public partial class DetalleDepartamentoPage : ContentPage
{
    public DetalleDepartamentoPage(Departamento departamento)
    {
        InitializeComponent();

        NombreLabel.Text = departamento.Nombre;
        DireccionLabel.Text = departamento.Direccion;
        PrecioLabel.Text = $"Precio: {departamento.Precio:C}";
        CuartosLabel.Text = $"Cuartos disponibles: {departamento.CuartosDisponibles}";
        MainImage.Source = ImageSource.FromStream(() =>
            new MemoryStream(Convert.FromBase64String(departamento.Imagen)));

        var usuario = App.UsuarioDB.GetUsuarioPorIdAsync(departamento.UsuarioId).Result;
        if (usuario != null)
        {
            NombreUsuarioLabel.Text = $"{usuario.Nombre} {usuario.Apellido}";
            CorreoUsuarioLabel.Text = usuario.Correo;
        }
    }
}
