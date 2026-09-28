namespace AT;

public class GerenciadorEstoqueArquivo
{
    private Produto[] _produtos = new Produto[5];
    private int _contador = 0;

    private string _arquivo = "estoque.txt";

    private void AdicionarProduto(string nome, double preco, int quantidade)
    {
        if (_contador >= _produtos.Length)
        {
            Console.WriteLine("Limite de produtos atingido!");
            return;
        }

        _produtos[_contador] = new Produto
        {
            Nome = nome,
            Preco = preco,
            Quantidade = quantidade
        };

        _contador++;

        using (StreamWriter writer = File.AppendText(_arquivo))
        {
            writer.WriteLine($"{nome},{quantidade},{preco:F2}");
        }

        Console.WriteLine("Produto adicionado com sucesso!");
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
        if (!File.Exists(_arquivo))
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        string[] linhas = File.ReadAllLines(_arquivo);

        if (linhas.Length == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        foreach (string linha in linhas)
        {
            string[] partes = linha.Split(',');
            string nome = partes[0];
            int quantidade = int.Parse(partes[1]);
            double preco = double.Parse(partes[2]);

            Console.WriteLine($"Produto: {nome} | Quantidade: {quantidade} | Preço: R${preco:F2}");
        }
    }
}