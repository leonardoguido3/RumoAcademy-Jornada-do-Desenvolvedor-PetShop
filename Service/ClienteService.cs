using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service
{
    internal class ClienteService
    {
        private readonly List<Models.ClienteModel> _clientes = new List<Models.ClienteModel>();
        private readonly Data.ApiPetShopGW _gw;

        public ClienteService()
        {
            _gw= new Data.ApiPetShopGW();
        }

        public void Insert(Models.ClienteModel cliente)
        {
            try
            {
                _gw.Insert(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception($" HOUVE UM ERRO PARA CADASTRAR O {cliente.Nome}! ERRO: {ex.Message}");
            }
        }

        public List<ClienteModel> GetAll(string? name)
        {
            return _gw.GetAll(name);
        }
    }
}
