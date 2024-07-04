using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using EvaluacionP3.Models;
using EvaluacionP3.Repository;
using Microsoft.Maui.Controls;

namespace EvaluacionP3.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly RepositoryPaises _repository;

        public ObservableCollection<Pais> Paises { get; set; }
        public ICommand ObtenerPaisesCommand { get; }

        public MainViewModel()
        {
            _repository = new RepositoryPaises();
            Paises = new ObservableCollection<Pais>();
            ObtenerPaisesCommand = new Command(async () => await ObtenerPaises());
        }

        private async Task ObtenerPaises()
        {
            var paises = await _repository.DevuelveInfoPaisesAsync();
            foreach (var pais in paises)
            {
                Paises.Add(pais);
            }
        }
    }
}
