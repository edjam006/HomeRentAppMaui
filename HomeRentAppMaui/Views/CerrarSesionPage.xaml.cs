using HomeRentAppMaui.Helpers;

namespace HomeRentAppMaui.Views;

public partial class CerrarSesionPage : ContentPage
{
	public CerrarSesionPage()
	{
		InitializeComponent();
        CerrarSesion();
    }
    private async void CerrarSesion()
    {
        // Borrar sesión
        Sesion.UsuarioId = string.Empty;

        // Redirigir al login y quitar navegación hacia atrás
        Application.Current.MainPage = new NavigationPage(new LoginPage());
    }
}