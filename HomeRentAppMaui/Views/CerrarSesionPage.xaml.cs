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
        // Borrar sesi�n
        Sesion.UsuarioId = string.Empty;

        // Redirigir al login y quitar navegaci�n hacia atr�s
        Application.Current.MainPage = new NavigationPage(new LoginPage());
    }
}