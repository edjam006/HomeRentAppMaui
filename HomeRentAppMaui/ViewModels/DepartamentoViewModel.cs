using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using HomeRentAppMaui.Helpers;
using HomeRentAppMaui.Services;
using HomeRentAppMaui.Views;
using HomeRentAppShared.Models;

namespace HomeRentAppMaui.ViewModels
{
    public class DepartamentoLocalViewModel : INotifyPropertyChanged
    {
        private readonly DepartamentoDatabase _db;

        private Departamento _nuevoDepartamento = new();
        public Departamento NuevoDepartamento
        {
            get => _nuevoDepartamento;
            set
            {
                _nuevoDepartamento = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Departamento> Departamentos { get; set; } = new();

        public ICommand GuardarCommand { get; set; }
        public ICommand VerDepartamentoCommand { get; set; }

        public DepartamentoLocalViewModel()
        {
            _db = App.DepartamentoDB;
            GuardarCommand = new Command(async () => await GuardarDepartamento());
            VerDepartamentoCommand = new Command<Departamento>(async (departamento) =>
            {
                await Shell.Current.Navigation.PushAsync(new DetalleDepartamentoPage(departamento));
            });
            _ = CargarDepartamentos();
        }

        private async Task GuardarDepartamento()
        {
            if (string.IsNullOrWhiteSpace(NuevoDepartamento.Nombre) ||
                string.IsNullOrWhiteSpace(NuevoDepartamento.Direccion) ||
                NuevoDepartamento.Precio <= 0 ||
                NuevoDepartamento.CuartosDisponibles < 0)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Todos los campos deben estar completos y válidos.", "OK");
                return;
            }

            NuevoDepartamento.UsuarioId = Sesion.UsuarioId;
            await _db.SaveDepartamentoAsync(NuevoDepartamento);
            await FileLoggerService.AppendLogAsync(NuevoDepartamento.Nombre);

            NuevoDepartamento = new Departamento(); // Limpia los campos
            await CargarDepartamentos(); // Refresca la lista en la vista
        }




        public async Task CargarDepartamentos()
        {
            var lista = await _db.GetDepartamentosAsync();
            Departamentos.Clear();
            foreach (var d in lista)
                Departamentos.Add(d);
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
