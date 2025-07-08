using HomeRentAppMaui.Helpers;

namespace HomeRentAppMaui.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string usuario = UsuarioEntry.Text;
            string password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Usuario y contraseña son requeridos", "OK");
                return;
            }

            var resultado = await App.UsuarioDB.ValidarLoginAsync(usuario, password);

            if (resultado != null)
            {
                Sesion.UsuarioId = resultado.UsuarioId;
                await Shell.Current.GoToAsync("//DepartamentoPage");
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
            }
        }



        private async void irAregistro_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//RegistroPage");

        }
    }
}