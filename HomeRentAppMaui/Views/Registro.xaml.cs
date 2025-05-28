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
            // Aqui envio los datos a la API usando HttpClient
            await DisplayAlert("Registro", "Registro exitoso (simulado)", "OK");
            await Shell.Current.GoToAsync("LoginPage");
        }
    }
}
