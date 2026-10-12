using SistemaEstoque.Console;

EstoqueArquivo arquivoEstoque = new EstoqueArquivo();
Estoque estoque = arquivoEstoque.Carregar();
EstoqueConsole estoqueConsole = new EstoqueConsole();

bool executando = true;

while (executando)
{

    int menu = estoqueConsole.MostrarMenu();

    switch (menu)
    {
        case 0:
            executando = false;
            break;

        case 1:
            if (estoqueConsole.CadastrarProduto(estoque)) arquivoEstoque.Salvar(estoque);
            break;

        case 2:
            estoqueConsole.BuscarProdutoNoConsole(estoque);
            break;

        case 3:
            Console.WriteLine($"Valor total em estoque: {estoque.CalcularValorTotal()}");
            break;
    }
}

