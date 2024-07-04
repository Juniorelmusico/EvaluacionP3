using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using EvaluacionP3.Models;

namespace EvaluacionP3.Data
{
    public class PaisDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public PaisDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Pais>().Wait();
        }

        public Task<List<Pais>> GetPaisesAsync()
        {
            return _database.Table<Pais>().ToListAsync();
        }

        public Task<int> SavePaisAsync(Pais pais)
        {
            return _database.InsertAsync(pais);
        }

        public Task<int> UpdatePaisAsync(Pais pais)
        {
            return _database.UpdateAsync(pais);
        }

        public Task<int> DeletePaisAsync(Pais pais)
        {
            return _database.DeleteAsync(pais);
        }
    }
}
