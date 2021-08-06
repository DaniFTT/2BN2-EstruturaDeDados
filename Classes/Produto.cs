using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2BN2_EstruturaDeDados.Classes
{
    class Produto : IComparable
    {
        public int Codigo { get; set; }

        public double Preco { get; set; }

        public string Descricao { get; set; }

        public Categoria Categoria { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public int QuantidadeDeVendas { get; set; }

        public double ValorTotalVendido { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Produto produto = ((Produto)obj);
            if (produto.Descricao != "")
            {
                return this.Descricao.CompareTo(produto.Descricao);
            }
            else
            {
                throw new Exception();
            }
        }

        public override string ToString()
        {
            return "H - " + Descricao + "|" + Codigo + "|" + QuantidadeDeVendas + "|" + Math.Round(ValorTotalVendido, 2);
        }

    }
}
