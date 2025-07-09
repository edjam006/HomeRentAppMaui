using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using HomeRentAppShared.Models;
using HomeRentAppMaui.Services;
using HomeRentAppMaui.Helpers;

namespace HomeRentAppMaui.ViewModels
{
    public class PerfilViewModel : INotifyPropertyChanged
    {
        private readonly DepartamentoDatabase _db;

        private Usuario _usuarioActual = new();
        public Usuario UsuarioActual
        {
            get => _usuarioActual;
            set
            {
                _usuarioActual = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Departamento> DepartamentosUsuario { get; set; } = new();

        public PerfilViewModel()
        {
            _db = App.DepartamentoDB;
            CargarDatos();
        }

        private async void CargarDatos()
        {
            if (!string.IsNullOrWhiteSpace(Sesion.UsuarioId))
            {
                var usuario = await App.UsuarioDB.GetUsuarioPorIdAsync(Sesion.UsuarioId);

                if (usuario != null)
                    UsuarioActual = usuario;

                var departamentos = await _db.GetDepartamentosAsync();
                var filtrados = departamentos.Where(d => d.UsuarioId == Sesion.UsuarioId);

                DepartamentosUsuario.Clear();
                foreach (var depa in filtrados)
                    DepartamentosUsuario.Add(depa);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
