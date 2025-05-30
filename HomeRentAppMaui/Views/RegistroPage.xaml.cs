using HomeRentAppShared.Models;
using HomeRentAppMaui.Services;

namespace HomeRentAppMaui.Views
{
    public partial class RegistroPage : ContentPage
    {
        private readonly UsuarioService _usuarioService = new();

        public RegistroPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            var nuevoUsuario = new Usuario
            {
                UsuarioId = UsuarioEntry.Text,
                Nombre = NombreEntry.Text,
                Apellido = ApellidoEntry.Text,
                Correo = CorreoEntry.Text,
                Contraseña = PasswordEntry.Text
            };

            bool exito = await _usuarioService.RegistrarUsuarioAsync(nuevoUsuario);

            if (exito)
            {
                await DisplayAlert("Éxito", "Usuario registrado correctamente", "OK");
                await Shell.Current.GoToAsync("//LoginPage");

            }
            else
            {
                await DisplayAlert("Error", "No se pudo registrar el usuario", "OK");
            }
        }
    }
}