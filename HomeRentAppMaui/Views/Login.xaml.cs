using HomeRentAppMaui.Helpers;
using HomeRentAppMaui.Services;
namespace HomeRentAppMaui.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private readonly UsuarioService _usuarioService = new();

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string usuario = UsuarioEntry.Text;
            string password = PasswordEntry.Text;

            var resultado = await _usuarioService.IniciarSesionAsync(usuario, password);

            if (resultado != null)
            {
                Sesion.UsuarioId = resultado.UsuarioId;
                await DisplayAlert("�xito", "Inicio de sesi�n correcto", "OK");
                await Shell.Current.GoToAsync("//DepartamentoPage");
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contrase�a incorrectos", "OK");
            }
        }



        private async void irAregistro_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//RegistroPage");

        }
    }
}
