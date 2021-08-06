using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2BN2_EstruturaDeDados.Classes
{
    class Venda
    {
        public int Codigo { get; set; }

        public Cliente Cliente { get; set; }

        public Produto Produto { get; set; }

        public DateTime DataDaVenda { get; set; }

        public double ValorTotal { get; set; }
    }
}
