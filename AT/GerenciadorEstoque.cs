namespace AT;

public class Produto
{
    public string Nome;
    public double Preco;
    public int Quantidade;
}

public class GerenciadorEstoque
{
    private Produto[] _produtos = new Produto[5];
    private int contador = 0;

    private void AdicionarProduto(string nome, double preco, int quantidade)
    {
        if (contador >= _produtos.Length)
        {
            Console.WriteLine("Limite de produtos atingido!");
            return;
        }

        _produtos[contador] = new Produto { Nome = nome, Preco = preco, Quantidade = quantidade };
        contador++;
    }
    
    public void MenuProdutos()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("1. Adicionar produto");
            Console.WriteLine("2. Listar produtos");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarProdutoMenu();
                    break;
                case "2":
                    ListarProdutos();
                    break;
                case "3":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    private void AdicionarProdutoMenu()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Quantidade em estoque: ");
        int quantidade = int.Parse(Console.ReadLine());

        Console.Write("Preço unitário: ");
        double preco = double.Parse(Console.ReadLine());

        AdicionarProduto(nome, preco, quantidade);
    }

    private void ListarProdutos()
    {
        foreach (var produto in _produtos)
        {
            if (produto != null)
            {
                Console.WriteLine($"Produto: {produto.Nome} | Quantidade: {produto.Quantidade} | Preço: R${produto.Preco:F2}");
            }
        }
    }
}