using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using EvaluacionP3.Models;

namespace EvaluacionP3.Repository
{
    public class RepositoryPaises
    {
        private readonly HttpClient _client;

        public RepositoryPaises()
        {
            _client = new HttpClient();
        }

        public async Task<List<Pais>> DevuelveInfoPaisesAsync()
        {
            var response = await _client.GetAsync("https://restcountries.com/v3.1/all");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var paises = JsonSerializer.Deserialize<List<Pais>>(json);
                return paises;
            }
            return new List<Pais>();
        }
    }
}
