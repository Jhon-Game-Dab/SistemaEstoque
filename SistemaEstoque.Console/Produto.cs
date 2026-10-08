using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaEstoque.Console
{
    internal class Produto
    {
        private string nome = "";
        private decimal valor;
        private int quantidade;

        public Produto(string nome, decimal valor, int quantidade)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("O nome do produto é obrigatorio.", nameof(nome));
            if (valor < 0.05m) throw new ArgumentOutOfRangeException(nameof(valor), $"O valor do produto cadastrado foi {valor} e não pode ser menor que 0,05. Produto com erro: {nome}");
            if (quantidade < 0) throw new ArgumentOutOfRangeException(nameof(quantidade), $"A variavel {quantidade} está menor que zero");

            this.nome = nome;
            this.valor = valor;
            this.quantidade = quantidade;
        }

        public string Nome => nome;
        public decimal Valor => valor;
        public int Quantidade => quantidade;
    }
}
