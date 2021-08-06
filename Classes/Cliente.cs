using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2BN2_EstruturaDeDados.Classes
{
    class Cliente : IComparable
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public double ValorTotalPago { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Cliente cliente = ((Cliente)obj);
            if (cliente.CPF != "")
            {
                return this.CPF.CompareTo(cliente.CPF);
            }
            else
            {
                throw new Exception();
            }
        }

        public override string ToString()
        {
            return CPF + "|" + Nome + "|" + ValorTotalPago;
        }
    }
}
