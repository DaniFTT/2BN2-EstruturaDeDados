using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2BN2_EstruturaDeDados.Classes
{
    class Categoria : IComparable
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double ValorTotalDeVendas { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Categoria categoria = ((Categoria)obj);
            if (categoria.Codigo > 0)
            {
                return this.Codigo.CompareTo(categoria.Codigo);
            }
            else
            {
                throw new Exception();
            }
        }

        public override string ToString()
        {
            return Descricao + "|" + Codigo + "|" + Math.Round(ValorTotalDeVendas, 2);
        }
    }
}
