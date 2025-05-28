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

            // Aquí puedes implementar la lógica de validación real
            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Éxito", "Inicio de sesión correcto", "OK");
                await Shell.Current.GoToAsync("DepartamentoPage");
            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña incorrectos", "OK");
            }
        }
    }
}
