using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaEstoque.Console
{
    internal class Estoque
    {
        private List<Produto> produtos = new List<Produto>();

        public void AdicionarProduto(Produto produto)
        {
            produtos.Add(produto);
        }

        public decimal CalcularValorTotal()
        {
            decimal valorTotal = 0.00m;

            foreach (Produto p in produtos)
            {
                valorTotal += p.Valor * p.Quantidade;
            }

            return valorTotal;
        }

        public Produto? BuscarProduto(string nome)
        {
            foreach (Produto p in produtos)
            {
                if (nome == p.Nome) return p;
            }

            return null;
        }

        public int QuantidadeProdutos => produtos.Count;
    }
}
