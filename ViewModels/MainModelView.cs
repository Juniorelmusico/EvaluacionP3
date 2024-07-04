using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using EvaluacionP3.Models;
using EvaluacionP3.Repository;
using EvaluacionP3.Data;
using Microsoft.Maui.Controls;

namespace EvaluacionP3.ViewModels
{
    public class MainModelView : BaseViewModel
    {
        private readonly RepositoryPaises _repository;
        private readonly PaisDatabase _database;

        public ObservableCollection<Pais> Paises { get; set; }
        public ICommand ObtenerPaisesCommand { get; }

        public MainModelView(string dbPath)
        {
            _repository = new RepositoryPaises();
            _database = new PaisDatabase(dbPath);
            Paises = new ObservableCollection<Pais>();
            ObtenerPaisesCommand = new Command(async () => await ObtenerPaises());
        }

        private async Task ObtenerPaises()
        {
            var paises = await _repository.DevuelveInfoPaisesAsync();
            foreach (var pais in paises)
            {
                pais.Status = $"{GetInitials("Junior Espin ")}{new Random().Next(1000, 2000)}";
                await _database.SavePaisAsync(pais);
                Paises.Add(pais);
            }
        }

        private string GetInitials(string name)
        {
            return string.Concat(name.Split(' ').Select(x => x[0]));
        }
    }
}
