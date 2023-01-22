using PetShop.Models;
using PetShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Controller
{
    public class ClienteController
    {
        private readonly ClienteService _service;

        public ClienteController()
        {
            _service = new ClienteService();
        }

        public bool Insert(string nome, string cpf, string data, string? telefone)
        {
            // instanciando classes
            ClienteModel cliente = new ClienteModel();

            var dataValida = Filters.Validation.ConversaoData(data);
            // injetando os valores nos objetos instanciados
            cliente.Nome = nome.ToUpper().Trim();
            cliente.CpfCliente = cpf;
            cliente.Nascimento = Convert.ToDateTime(dataValida);
            cliente.Telefone = telefone;

            // inserindo no CSV de produtos
            _service.Insert(cliente);

            return true;
        }

        public List<ClienteModel> GetAll(string? name)
        {
            List<ClienteModel> Clientes = _service.GetAll(name);

            return Clientes;

        }
    }
}
