using HomeRentAppShared.Models;

namespace HomeRentAppMaui.Views
{
    public partial class RegistroPage : ContentPage
    {
        public RegistroPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            var usuario = new Usuario
            {
                UsuarioId = UsuarioEntry.Text,
                Nombre = NombreEntry.Text,
                Apellido = ApellidoEntry.Text,
                Correo = CorreoEntry.Text,
                Contrasena = PasswordEntry.Text
            };

            if (string.IsNullOrWhiteSpace(usuario.UsuarioId) ||
                string.IsNullOrWhiteSpace(usuario.Contrasena))
            {
                await DisplayAlert("Error", "Usuario ID y Contraseña son obligatorios", "OK");
                return;
            }

            // Guardado local en SQLite
            var existente = await App.UsuarioDB.GetUsuarioPorIdAsync(usuario.UsuarioId);
            if (existente != null)
            {
                await DisplayAlert("Error", "Este Usuario ID ya existe", "OK");
                return;
            }

            await App.UsuarioDB.SaveUsuarioAsync(usuario);
            await DisplayAlert("Éxito", "Usuario registrado correctamente", "OK");
            await Shell.Current.GoToAsync("//LoginPage");

        }
    }
}
