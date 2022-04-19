using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanhouse
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public Cliente(string Nome, string Cpf, string Telefone, string Email)
        {
            this.Nome = Nome;
            this.Cpf = Cpf;
            this.Telefone = Telefone;
            this.Email = Email;
        }

    }
}
