using System.Text.Json;

namespace SistemaEstoque.Console
{
    internal class EstoqueArquivo
    {
        public void Salvar(Estoque estoque)
        {
            string json = JsonSerializer.Serialize(estoque.Produtos);
            File.WriteAllText("estoque.json", json);
        }

        public Estoque Carregar()
        {
            Estoque estoque = new Estoque();

            if (!File.Exists("estoque.json")) return estoque;

            string json = File.ReadAllText("estoque.json");

            List<Produto>? produtosCarregados = JsonSerializer.Deserialize<List<Produto>>(json);

            if (produtosCarregados != null)
            {
                foreach (Produto pro in produtosCarregados)
                {
                    estoque.AdicionarProduto(pro);
                }
            }

            return estoque;
        }
    }
}
