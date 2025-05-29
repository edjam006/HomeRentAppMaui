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

            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(password))
            {
                await DisplayAlert("�xito", "Inicio de sesi�n correcto", "OK");
                await Shell.Current.GoToAsync("//DepartamentoPage");
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contrase�a incorrectos", "OK");
            }
            Sesion.UsuarioId = usuario; // donde `usuario` es el ID que el usuario ingres�
            await Shell.Current.GoToAsync("//DepartamentoPage");

        }


        private async void irAregistro_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//RegistroPage");

        }
    }
}
