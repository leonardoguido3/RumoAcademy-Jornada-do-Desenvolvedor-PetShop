using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Models
{
    public class ClienteModel
    {
        public string CpfCliente { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string? Telefone { get; set; }
    }
}
