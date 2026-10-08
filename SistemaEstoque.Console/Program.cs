using SistemaEstoque.Console;

Estoque estoque = new Estoque();
EstoqueConsole estoqueConsole = new EstoqueConsole();

bool continuarCadastro = true;

while (continuarCadastro)
{
    estoqueConsole.CadastrarProduto(estoque);

    continuarCadastro = estoqueConsole.PerguntarSimOuNao("Deseja cadastrar outro? Responda com Sim ou Não:");
}

Console.WriteLine($"Produtos cadastrados: {estoque.QuantidadeProdutos}");

Console.WriteLine($"Valor total em estoque: {estoque.CalcularValorTotal()}");

estoqueConsole.BuscarProdutoNoConsole(estoque);
