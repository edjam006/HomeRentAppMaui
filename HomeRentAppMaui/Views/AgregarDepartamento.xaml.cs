using HomeRentAppMaui.Services;
using HomeRentAppShared.Models;
using System.Text;
using System.IO;
using HomeRentAppMaui.Helpers;
using HomeRentAppMaui.ViewModels;
using SQLite;


namespace HomeRentAppMaui.Views;
public partial class AgregarDepartamentoPage : ContentPage
{
    public DepartamentoLocalViewModel ViewModel { get; set; }

    private string _imagenBase64 = string.Empty;

    public AgregarDepartamentoPage()
    {
        InitializeComponent();
        ViewModel = new DepartamentoLocalViewModel();
        BindingContext = ViewModel;
    }

    private async void OnSeleccionarImagenClicked(object sender, EventArgs e)
    {
        try
        {
            var resultado = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Selecciona una imagen",
                FileTypes = FilePickerFileType.Images
            });

            if (resultado != null)
            {
                using var stream = await resultado.OpenReadAsync();
                using var memory = new MemoryStream();
                await stream.CopyToAsync(memory);
                _imagenBase64 = Convert.ToBase64String(memory.ToArray());

                PreviewImage.Source = ImageSource.FromStream(() => new MemoryStream(memory.ToArray()));
                ViewModel.NuevoDepartamento.Imagen = _imagenBase64;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo cargar la imagen: {ex.Message}", "OK");
        }
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
{
    if (ViewModel.GuardarCommand.CanExecute(null))
    {
        ViewModel.GuardarCommand.Execute(null);
        await DisplayAlert("Éxito", "Departamento registrado", "OK");
        await Navigation.PopAsync();
    }
}

}
