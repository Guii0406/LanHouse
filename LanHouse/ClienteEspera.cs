using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanhouse
{
    class ClienteEspera
    {
        public string nome { get; set; }
        public string celular { get; set; }

        public ClienteEspera(string nome, string celular)
        {
            this.nome = nome;
            this.celular = celular;
        }
    }
}
