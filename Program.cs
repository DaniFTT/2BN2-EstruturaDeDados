using _2BN2_EstruturaDeDados.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2BN2_EstruturaDeDados
{
    class Program
    {
        #region Declaração das OpCodes
        private static int opCodeD;
        private static int opCodeE;
        private static int opCodeF;
        private static List<Cliente> opCodeG;
        private static List<Produto> opCodeH;
        private static List<Categoria> opCodeI;
        private static Dictionary<string, double> opCodeJ = new Dictionary<string, double>();
        private static List<Cliente> opCodeK = new List<Cliente>();
        private static List<Produto> opCodeL = new List<Produto>();
        private static string opCodeM;
        private static List<Venda> opCodeN = new List<Venda>();
        private static int opCodeP;
        private static int opCodeQ;
        private static int opCodeO;
        #endregion

        static void Main(string[] args)
        {

            //Inicia Tempo
            DateTime inicio = DateTime.Now;
            DateTime fim;
            TimeSpan tempoCorrido;



            string resultado = inicio.ToLongTimeString() + Environment.NewLine;
            string filePath = AppDomain.CurrentDomain.BaseDirectory;



            #region Declaração dos Dicionarios
            //Lista categorias validas
            Dictionary<int, Categoria> categoriasValidas = new Dictionary<int, Categoria>();

            //Lista clientes validos
            Dictionary<string, Cliente> clientesValidos = new Dictionary<string, Cliente>();

            //Lista produtos validos
            Dictionary<int, Produto> produtosValidos = new Dictionary<int, Produto>();
             
            //Lista de vendas validas
            Dictionary<int, Venda> vendasValidas = new Dictionary<int, Venda>();
            #endregion



            LeCategorias(filePath, categoriasValidas);

            LeProdutos(filePath, produtosValidos, categoriasValidas);

            LeClientes(filePath, clientesValidos);

            LeVendas(filePath, produtosValidos, vendasValidas, clientesValidos, categoriasValidas);



            resultado += "OPCodes:" + Environment.NewLine;
            resultado += "A - " + categoriasValidas.Count + Environment.NewLine;
            resultado += "B - " + produtosValidos.Count + Environment.NewLine;
            resultado += "C - " + clientesValidos.Count + Environment.NewLine;
            resultado += "D - " + opCodeD + Environment.NewLine;
            resultado += "E - " + opCodeE + Environment.NewLine;
            resultado += "F - " + opCodeF + Environment.NewLine;

            File.WriteAllText(filePath + "resultado.txt", resultado);

            using (StreamWriter sw = new StreamWriter(filePath + "resultado.txt", true))
            {

                resultado = "";

                //oPCodeG
                opCodeG = clientesValidos.Values.ToList();
                opCodeG.Sort();
                foreach (Cliente c in opCodeG)
                {

                    if (c.ValorTotalPago > 0)
                    {
                        resultado = "G - " + c.ToString();
                        sw.WriteLine(resultado);

                        if (opCodeK.Count == 0)
                        {
                            opCodeK.Add(c);
                        }
                        else if (c.ValorTotalPago > opCodeK[0].ValorTotalPago)
                        {
                            opCodeK.Clear();
                            opCodeK.Add(c);
                        }
                        else if (c.ValorTotalPago == opCodeK[0].ValorTotalPago)
                        {
                            opCodeK.Add(c);
                        }
                    }
                    else
                    {
                        opCodeP++;
                    }

                }

                resultado = "";

                //opCodeH
                opCodeH = produtosValidos.Values.ToList();
                opCodeH.Sort();
                foreach (Produto p in opCodeH)
                {
                    resultado = p.ToString();
                    sw.WriteLine(resultado);

                    if (p.QuantidadeDeVendas > 0)
                    {
                        if (opCodeL.Count == 0)
                        {
                            opCodeL.Add(p);
                        }
                        else if (p.QuantidadeDeVendas > opCodeL[0].QuantidadeDeVendas)
                        {
                            opCodeL.Clear();
                            opCodeL.Add(p);
                        }
                        else if (p.QuantidadeDeVendas == opCodeL[0].QuantidadeDeVendas)
                        {
                            opCodeL.Add(p);
                        }
                    }
                    else
                        opCodeO++;


                }

                resultado = "";

                //opCodeI
                opCodeI = categoriasValidas.Values.ToList();
                opCodeI.Sort();
                foreach (Categoria c in opCodeI)
                {
                    resultado = "I - " + c.ToString();
                    sw.WriteLine(resultado);
                    if (c.ValorTotalDeVendas <= 0)
                    {
                        //se não tiver nenuma venda, incrementa o oPCodeQ
                        opCodeQ++;
                    }
                }

                resultado = "";

                //opCodeJ       
                foreach (var d in opCodeJ.Reverse())
                {
                    resultado = "J - " + d.Key.Remove(2) + "/" + d.Key.Substring(2) + "|" + Math.Round(d.Value, 2);
                    sw.WriteLine(resultado);
                }


                resultado = "";

                //opCodeK
                foreach (Cliente c in opCodeK)
                {
                    resultado = "K - " + c.Nome + "|" + c.ValorTotalPago;
                    sw.WriteLine(resultado);
                }


                resultado = "";


                //opCodeL
                foreach (Produto p in opCodeL)
                {
                    resultado = "L - " + p.Descricao + "|" + Math.Round(p.ValorTotalVendido, 2);
                    sw.WriteLine(resultado);
                }

                resultado = "";

                //oPCodeM
                resultado = "M - " + opCodeM;
                sw.WriteLine(resultado);

                resultado = ""; 

                //OPCodeN
                foreach (Venda venda in vendasValidas.Values)
                {
                    if (opCodeN.Count == 0)
                    {
                        opCodeN.Add(venda);
                    }
                    else if (vendasValidas[venda.Codigo].ValorTotal > opCodeN[0].ValorTotal)
                    {
                        opCodeN.Clear();
                        opCodeN.Add(venda);
                    }
                    else if (vendasValidas[venda.Codigo].ValorTotal == opCodeN[0].ValorTotal)
                    {
                        opCodeN.Add(venda);
                    }
                }
                foreach (Venda o in opCodeN)
                {
                    resultado = "N - " + o.Codigo + "|" + o.Cliente.CPF + "|" + o.ValorTotal;
                    sw.WriteLine(resultado);
                }

                resultado = "";

                //OpCodeO
                resultado += "O - " + opCodeO + Environment.NewLine;


                //OpCodeP
                resultado += "P - " + opCodeP + Environment.NewLine;

                //OpCodeQ
                resultado += "Q - " + opCodeQ + Environment.NewLine;



                //Tempo demorado:
                fim = DateTime.Now;
                resultado += fim.ToLongTimeString() + Environment.NewLine;
                tempoCorrido = fim - inicio;
                resultado += tempoCorrido.TotalSeconds + " segundos." + Environment.NewLine;



                sw.WriteLine(resultado);
            }

            Console.WriteLine($"Leitura Finalizada: \nInicio: {inicio}\nFim: {fim}\nTempo em segundos: {tempoCorrido.TotalSeconds} ");
            Console.ReadLine();
        }



        #region Metodos de Leitura dos Arquivos

        /// <summary>
        /// Valida as Categorias do arquivo
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="categorias"></param>
        private static void LeCategorias(string filePath, Dictionary<int, Categoria> categorias)
        {
            using (StreamReader readerCategorias = new StreamReader(filePath + "categorias.txt"))
            {
                string linha;
                string[] dadosCategoria;
                do
                {
                    //Lê a linha e separa os dados no vetor
                    linha = readerCategorias.ReadLine();

                    //verifica se a linha não ta vaiza
                    if (linha == null)
                        break;

                    dadosCategoria = linha.Split('|');

                    int codigo = Convert.ToInt32(dadosCategoria[0]);

                    //Verifica se já foi cadastrado, se já, continua o loop
                    if (categorias.ContainsKey(codigo))
                        continue;


                    //Criando Categoria
                    Categoria categoria = new Categoria
                    {
                        Codigo = codigo,
                        Descricao = dadosCategoria[1]
                    };
                    

                    //Adiciona a categoria no dicionario caso não exista ainda
                    categorias.Add(categoria.Codigo, categoria);

                } while (true);
            }
        }



        /// <summary>
        /// Lê os clientes válidos ao mesmo tempo que incrementa a OpCodeF (Clientes com nomes repetidos)
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="clientes"></param>
        private static void LeClientes(string filePath, Dictionary<string, Cliente> clientes)
        {
            using (StreamReader readerClientes = new StreamReader(filePath + "clientes.txt"))
            {
                string linha;
                string[] dadosCliente;
                List<string> nomes = new List<string>();
                do
                {
                    linha = readerClientes.ReadLine();

                    if (linha == null)
                        break;

                    dadosCliente = linha.Split('|');

                    string cpf = dadosCliente[0];


                    //Se for CPF repetido, ignora
                    if (clientes.ContainsKey(cpf))
                        continue;



                    //Cria cliente da linha atual
                    Cliente cliente = new Cliente
                    {
                        CPF = cpf,
                        Nome = dadosCliente[1]
                    };


                    //Verifica se o nome ta repetido
                    if (nomes.BinarySearch(cliente.Nome) < 0)
                    {
                        opCodeF++;
                        nomes.Add(cliente.Nome);
                        nomes.Sort();
                    }

                    clientes.Add(cliente.CPF, cliente);

                } while (true);
            }
        }



        /// <summary>
        /// /Valida os produtos do arquivo
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="produtos"></param>
        /// <param name="categorias"></param>
        private static void LeProdutos(string filePath,
                                       Dictionary<int, Produto> produtos,
                                       Dictionary<int, Categoria> categorias)
        {
            using (StreamReader readerProduto = new StreamReader(filePath + "produtos.txt"))
            {

                string linha;
                string[] dadosProduto;
                do
                {
                    linha = readerProduto.ReadLine();

                    if (linha == null)
                        break;

                    dadosProduto = linha.Split('|');


                    int codigo = Convert.ToInt32(dadosProduto[0]);


                    //Verifica se é repetido
                    if (produtos.ContainsKey(codigo))
                        continue;


                    //Checando se categoria existe, se não existir continua o loop
                    bool existe = categorias.TryGetValue(Convert.ToInt32(dadosProduto[3]), out Categoria categoria);

                    if (!existe)
                        continue;


                    //Criando produto
                    Produto produto = new Produto
                    {
                        //Preenchendo valores
                        Codigo = codigo,
                        Preco = Convert.ToDouble(dadosProduto[1]),
                        Descricao = dadosProduto[2],
                        DataDeCadastro = DateTime.ParseExact(dadosProduto[4], "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture),
                        Categoria = categoria
                    };

                    
                    produtos.Add(produto.Codigo, produto);

                } while (true);
            }

        }



        /// <summary>
        /// Valida todas as vendas do arquivo, verificando se há um cliente e produt valido para elas
        /// ao mesmo tempo que já descobre ao final da leitura, as OpCodes: 
        /// OpCodeD, OpCodeE, OpCodeG, OpCodeI, OpCodeJ, OpCodeK, OpCodeL,OpCodeM, OpCodeN,
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="produtosValidos"></param>
        /// <param name="vendasValidas"></param>
        /// <param name="clientesValidos"></param>
        /// <param name="categoriasValidas"></param>
        static void LeVendas(string filePath,
                              Dictionary<int, Produto> produtosValidos,
                              Dictionary<int, Venda> vendasValidas,
                              Dictionary<string, Cliente> clientesValidos,
                              Dictionary<int, Categoria> categoriasValidas)
        {

            string linha;
            string[] dadosVenda;

            //OPCodeE
            List<int> listOpCodeE = new List<int>();

            //OPCodeM
            double oPCodeMAuxliar = 0;


            using (StreamReader readerVendas = new StreamReader(filePath + "vendas.txt"))
            {
                do
                {
                    linha = readerVendas.ReadLine();

                    //Verifica se a linha  está vazia
                    if (linha == null)
                        break;


                    dadosVenda = linha.Split('|');


                    //Verifica se o codigo do cliente é valido
                    if (!clientesValidos.TryGetValue(dadosVenda[1], out Cliente comprador))
                        continue;


                    //Verica se é um produto valido
                    if (!produtosValidos.TryGetValue(Convert.ToInt32(dadosVenda[2]), out Produto produtoVendido))
                        continue;


                    Venda venda = new Venda
                    {
                        Codigo = Convert.ToInt32(dadosVenda[0]),
                        Cliente = comprador,
                        Produto = produtoVendido                       
                    };


                    //oPCodeE -  incrementa a quantidade de produtos ventidos sem repetir o codigo
                    if (listOpCodeE.BinarySearch(produtoVendido.Codigo) < 0)
                    {
                        listOpCodeE.Add(produtoVendido.Codigo);
                        listOpCodeE.Sort();
                    }
                   

                    //OpCodeG e OpCodeG K - Cria um cliente auxiliar que sera o cliente com o CPF atual e incrementa nele o valor pago
                    //e o devolve para o dicionario de clientes
                    clientesValidos[comprador.CPF].ValorTotalPago += produtoVendido.Preco;


                    //OPCodeI - converte o codigo de categoria atual para um objeto Categoria e incrementa o valor total das vendas
                    categoriasValidas[produtoVendido.Categoria.Codigo].ValorTotalDeVendas += produtoVendido.Preco;


                    //OPCodeL - vai incrementando o valor vedindo de cada produto para saber qual o mais vendido depois
                    produtosValidos[produtoVendido.Codigo].QuantidadeDeVendas++;
                    produtosValidos[produtoVendido.Codigo].ValorTotalVendido += produtoVendido.Preco;


                    //OPCodeJ e M
                    DateTime data = DateTime.ParseExact(dadosVenda[3], "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                    string periodo = data.ToString("MMyyyy");


                    venda.DataDaVenda = data;


                    if (opCodeJ.ContainsKey(periodo))
                    {
                        opCodeJ[periodo] += produtoVendido.Preco;
                    }
                    else
                    {
                        opCodeJ.Add(periodo, produtoVendido.Preco);
                    }
                    if (oPCodeMAuxliar < opCodeJ[periodo])
                    {
                        oPCodeMAuxliar = opCodeJ[periodo];
                        opCodeM = periodo.Remove(2) + "/" + periodo.Substring(2) + "|" + Math.Round(oPCodeMAuxliar, 2);
                    }
                    else if (oPCodeMAuxliar == opCodeJ[periodo])
                    {
                        opCodeM += Environment.NewLine + periodo.Remove(2) + "/" + periodo.Substring(2) + "|" + Math.Round(oPCodeMAuxliar, 2);
                    }


                    //OPCodeN - incrementa toda venda que tiver o mesmo codigo de venda, para saber qual foi a venda mais cara em reais
                    //ou seja, caso vendasValidas.ContainsKey(venda.Codigo) seja verdadeiro, quer dizer que já a no dicionario de vendas,
                    //aquela venda com aquele código,nela será incrementado o valor da nova venda
                    if (vendasValidas.ContainsKey(venda.Codigo))
                    {
                        vendasValidas[venda.Codigo].ValorTotal += produtoVendido.Preco;                       
                    }
                    //caso ainda não haja aquele código de venda no dicionario, ele será adicionado
                    else
                    {
                        vendasValidas.Add(venda.Codigo, venda);

                        //incrementa as vendas individuais
                        opCodeD++;

                        vendasValidas[venda.Codigo].ValorTotal += produtoVendido.Preco;
                    }

                } while (true);

                opCodeE = listOpCodeE.Count;
            }
        }
        #endregion
    }
}





