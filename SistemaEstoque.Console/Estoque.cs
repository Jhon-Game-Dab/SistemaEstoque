using System.Globalization;

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
            string nomeBuscado = nome.Trim();

            foreach (Produto p in produtos)
            {
                string itemBuscado = p.Nome.Trim();
                int resultado = CultureInfo.GetCultureInfo("pt-BR").CompareInfo.Compare(nomeBuscado, itemBuscado, CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace);
                if (resultado == 0) return p;
            }

            return null;
        }

        public int QuantidadeProdutos => produtos.Count;

        public IReadOnlyList<Produto> Produtos => produtos.AsReadOnly();
    }
}
