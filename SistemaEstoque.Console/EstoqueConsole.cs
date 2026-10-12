using System.Globalization;

namespace SistemaEstoque.Console
{
    internal class EstoqueConsole
    {
        public bool CadastrarProduto(Estoque estoque)
        {
            System.Console.WriteLine("Digite o nome do produto: ");
            string nome = System.Console.ReadLine() ?? "";

            while (string.IsNullOrWhiteSpace(nome))
            {
                System.Console.WriteLine("Digite um nome de produto válido:");
                nome = System.Console.ReadLine() ?? "";
            }

            System.Console.WriteLine("Digite o valor do produto: ");
            string valorDigitado = System.Console.ReadLine() ?? "0.00";

            decimal valor;

            while (!decimal.TryParse(valorDigitado.Trim().Replace(",", "."), NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture,out valor) || valor < 0.05m)
            {
                System.Console.WriteLine("Digite um valor valido: ");
                valorDigitado = System.Console.ReadLine() ?? "0,00";
            }

            System.Console.WriteLine("Digite quantidade a ser adicionada em estoque:");
            string quantidadeDigitade = System.Console.ReadLine() ?? "0";

            int quantidade;

            while (!int.TryParse(quantidadeDigitade, out quantidade) || quantidade < 0)
            {
                System.Console.WriteLine("Digite uma quantidade inteira maior ou igual a 0:");
                quantidadeDigitade = System.Console.ReadLine() ?? "0";
            }
            
            try
            {
                Produto produto = new Produto(nome, valor, quantidade);

                estoque.AdicionarProduto(produto);

                System.Console.WriteLine($"Produto cadastrado {produto.Nome}, valor do produto: {produto.Valor}, quantidade em estoque: {produto.Quantidade}");

                return true;
            }
            catch (ArgumentOutOfRangeException erro)
            {
                System.Console.WriteLine(erro.Message);

                return false;
            }
            catch (ArgumentException erro)
            {
                System.Console.WriteLine(erro.Message);

                return false;
            }
        }

        public void BuscarProdutoNoConsole(Estoque estoque)
        {
            string nomeBuscado = "";

            System.Console.WriteLine("Qual o produto que deseja buscar?");
            nomeBuscado = System.Console.ReadLine() ?? "";            

            bool encontrado = false;
            bool continuar = true;

            while (!encontrado && continuar)
            {
                Produto? produtoEncontrado = estoque.BuscarProduto(nomeBuscado);
                if (produtoEncontrado != null)
                {
                    string valorProdutoEncontrado = produtoEncontrado.Valor.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));

                    System.Console.WriteLine($"Produto buscado: {produtoEncontrado.Nome}, preço: {valorProdutoEncontrado}, quantidade em estoque: {produtoEncontrado.Quantidade}");

                    encontrado = true;
                }
                else
                {
                    System.Console.WriteLine($"Produto com nome {nomeBuscado} não encontrado");

                    System.Console.WriteLine("Digite o nome de um produto cadastrado ou Não para parar de buscar");
                    nomeBuscado = System.Console.ReadLine() ?? "";

                    if (nomeBuscado == "Não") continuar = false;
                }
            }
        }

        public bool PerguntarSimOuNao(string mensagem)
        {
            string resposta = "";

            System.Console.WriteLine(mensagem);
            resposta = System.Console.ReadLine() ?? "";

            while (resposta != "Sim" && resposta != "Não")
            {
                System.Console.WriteLine(mensagem);
                resposta = System.Console.ReadLine() ?? "";
            }

            return resposta == "Sim" ? true : false;
        }

        public int MostrarMenu()
        {
            MostrarText("1 - Cadastrar produto");
            MostrarText("2 - Buscar produto");
            MostrarText("3 - Mostrar valor total");
            MostrarText("4 - Mostrar todos os produtos cadastrados");
            MostrarText("0 - Sair");

            System.Console.WriteLine("Escolha uma opção:");
            string escolhaDigitada = System.Console.ReadLine() ?? "";

            int escolha;

            while (!int.TryParse(escolhaDigitada, out escolha) || escolha < 0 || escolha > 4)
            {
                System.Console.WriteLine("Escolha uma opção válida:");
                escolhaDigitada = System.Console.ReadLine() ?? "";
            }

            return escolha;
        }

        public void ListarProdutos(Estoque estoque)
        {
            if (estoque.QuantidadeProdutos <= 0)
            {
                System.Console.WriteLine("Nenhum produto cadastrado");
                return;
            }

            foreach (Produto produto in estoque.Produtos)
            {
                string preco = produto.Valor.ToString("C2", CultureInfo.GetCultureInfo("pt-BR"));

                System.Console.WriteLine($"Produto: {produto.Nome}, Preço: {preco}, Quantidade em estoque: {produto.Quantidade}");
            }
        }

        private void MostrarText(string tex)
        {
            System.Console.WriteLine(tex);
        }
    }
}
