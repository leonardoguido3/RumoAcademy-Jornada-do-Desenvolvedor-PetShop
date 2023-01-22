using Newtonsoft.Json;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Encodings;

namespace PetShop.Data
{
    internal class ApiPetShopGW
    {
        public void Insert(ClienteModel model)
        {
            var httpClient = new HttpClient();

            var conteudoSerializado = JsonConvert.SerializeObject(model);
            var content = new StringContent(conteudoSerializado, Encoding.UTF8, "application/json");

            var url = "https://localhost:44378/Cliente";
            var resultado = httpClient.PostAsync(url, content).Result;

            string conteudoApi = resultado.Content.ReadAsStringAsync().Result;
            if (!resultado.IsSuccessStatusCode)
                throw new Exception("Ocorreu um erro ao chamar a API: " + conteudoApi);
        }

        public List<ClienteModel> GetAll(string? name)
        {
            var httpClient = new HttpClient();
            var url = "";

            if (name is null)
                url = "https://localhost:44378/Cliente";
            if (name is not null)
                url = "https://localhost:44378/Cliente?nome=" + name;

            var resultado = httpClient.GetAsync(url).Result;

            string conteudoApi = resultado.Content.ReadAsStringAsync().Result;

            List<ClienteModel> clientes = JsonConvert.DeserializeObject<List<ClienteModel>>(conteudoApi);

            return clientes;

        }
    }
}
