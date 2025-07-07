using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HomeRentAppMaui.Services;
using HomeRentAppMaui.ViewModels;
using HomeRentAppShared.Models;
using System.Windows.Input;

namespace HomeRentAppMaui.ViewModels
{
    public class DepartamentoViewModel : INotifyPropertyChanged
    {
        private readonly DepartamentoService _service = new();
        public ObservableCollection<Departamento> Departamentos { get; set; } = new();

        public ICommand CargarDepartamentosCommand { get; }

        public DepartamentoViewModel()
        {
            CargarDepartamentosCommand = new Command(async () => await CargarDepartamentos());
            _ = CargarDepartamentos(); // se puede ejecutar directamente o desde la página con el comando
        }

        private async Task CargarDepartamentos()
        {
            var lista = await _service.ObtenerDepartamentosAsync();
            Departamentos.Clear();
            foreach (var item in lista)
            {
                Departamentos.Add(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}