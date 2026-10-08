using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaEstoque.Console
{
    internal class EstoqueConsole
    {
        public void CadastrarProduto(Estoque estoque)
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

            while (!decimal.TryParse(valorDigitado, out valor) || valor < 0.05m)
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
            }
            catch (ArgumentOutOfRangeException erro)
            {
                System.Console.WriteLine(erro.Message);
            }
            catch (ArgumentException erro)
            {
                System.Console.WriteLine(erro.Message);
            }
        }

        public void BuscarProdutoNoConsole(Estoque estoque)
        {
            bool desejaBuscar = PerguntarSimOuNao("Deseja buscar um produto? Responda com Sim ou Não:");

            string nomeBuscado = "";

            if (desejaBuscar)
            {
                System.Console.WriteLine("Qual o produto que deseja buscar?");
                nomeBuscado = System.Console.ReadLine() ?? "";
            }

            bool encontrado = false;

            while (!encontrado && desejaBuscar)
            {
                Produto? produtoEncontrado = estoque.BuscarProduto(nomeBuscado);
                if (produtoEncontrado != null)
                {
                    System.Console.WriteLine($"Produto buscado: {produtoEncontrado.Nome}, preço: {produtoEncontrado.Valor}, quantidade em estoque: {produtoEncontrado.Quantidade}");

                    encontrado = true;
                }
                else
                {
                    System.Console.WriteLine($"Produto com nome {nomeBuscado} não encontrado");

                    System.Console.WriteLine("Digite o nome de um produto cadastrado ou Não para parar de buscar");
                    nomeBuscado = System.Console.ReadLine() ?? "";

                    if (nomeBuscado == "Não") desejaBuscar = false;
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
    }
}
