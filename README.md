# Sistema de Estoque

Aplicação de console em C# para cadastrar e consultar produtos
e calcular o valor total em estoque.

Projeto em desenvolvimento, criado para praticar C#,
orientação a objetos e organização de código.

## Funcionalidades

- Cadastro de produtos com nome, preço e quantidade.
- Validação das entradas do usuário.
- Busca de produto pelo nome.
- Contagem de produtos cadastrados.
- Cálculo do valor total em estoque.

## Organização

- Produto: dados e regras de validação do produto.
- Estoque: armazenamento, cadastro, busca e cálculo do total.
- EstoqueConsole: interação com o usuário pelo console.
- Program: coordenação do fluxo da aplicação.

## Como executar

1. Clone ou baixe este repositório.
2. Abra SistemaEstoque.slnx em uma versão compatível do Visual Studio.
3. Instale o SDK do .NET correspondente ao TargetFramework
   definido em SistemaEstoque.Console.csproj.
4. Execute o projeto SistemaEstoque.Console.

## Limitações atuais

- Os dados ficam na memória e são perdidos ao fechar a aplicação.
- A busca diferencia letras maiúsculas e minúsculas.
- O cadastro permite produtos com nomes repetidos.

## Melhorias planejadas

- Menu para escolher as operações.
- Listagem de todos os produtos.
- Entrada e saída de unidades do estoque.
- Persistência dos dados em arquivo.

## Contribuições

Sugestões e relatos de problemas são bem-vindos pelas Issues.
Para propor alterações, crie um fork e envie um Pull Request.
As propostas serão revisadas pelo responsável pelo projeto.
