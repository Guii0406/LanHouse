using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lanhouse
{
    class Caixa
    {
        public string sevico;
        public double total;

        public Caixa(string servico, double total)
        {
            this.sevico = servico;
            this.total = total;
        }
    }
}
