using Newtonsoft.Json;
using practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace practica.EF.Data
{
    public class ExternalApiContext
    {
        public async Task<List<ExternalAPI>> GetAPIAsync()
        {
            var httpClient = new HttpClient();
            var respuesta = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/comments");
            var respuestaString = await respuesta.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<ExternalAPI>>(respuestaString);

            return list;
        }
    }
}
