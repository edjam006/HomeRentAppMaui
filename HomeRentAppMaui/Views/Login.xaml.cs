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
                await DisplayAlert("Error", "Usuario y contrase�a son requeridos", "OK");
                return;
            }

            var resultado = await App.UsuarioDB.ValidarLoginAsync(usuario, password);

            if (resultado != null)
            {
                Sesion.UsuarioId = resultado.UsuarioId;

                // Primero establece AppShell como p�gina principal
                Application.Current.MainPage = new AppShell();

                // Luego navega al tab principal
                await Shell.Current.GoToAsync("//DepartamentoPage");
            }


            else
            {
                await DisplayAlert("Error", "Usuario o contrase�a incorrectos", "OK");
            }
        }


        private async void irAregistro_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new AppShell();
            await Shell.Current.GoToAsync("//RegistroPage");
        }

    }
}