namespace AT;

public class ContatoFormatter
{
    public virtual void ExibirContatos(List<Contato> contatos)
    {
        foreach (Contato contato in contatos)
        {
            Console.WriteLine(
                $"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}"
            );
        }
    }
}

public class MarkdownFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("## Lista de Contatos");

        foreach (Contato contato in contatos)
        {
            Console.WriteLine($"- **Nome:** {contato.Nome}");
            Console.WriteLine($"- Telefone: {contato.Telefone}");
            Console.WriteLine($"- Email: {contato.Email}");
        }
    }
}

public class TabelaFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("| Nome | Telefone | Email |");
        Console.WriteLine("----------------------------------------");

        foreach (Contato contato in contatos)
        {
            Console.WriteLine(
                $"| {contato.Nome} | {contato.Telefone} | {contato.Email} |"
            );
        }

        Console.WriteLine("----------------------------------------");
    }
}

public class RawTextFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        foreach (Contato contato in contatos)
        {
            Console.WriteLine(
                $"Nome: {contato.Nome} | Telefone: {contato.Telefone} | Email: {contato.Email}"
            );
        }
    }
}

public class GerenciadorContatosPolimorfismo
{
    private const string arquivo = "contatos.txt";

    public void MenuContatos()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n=== Gerenciador de Contatos ===");
            Console.WriteLine("1 - Adicionar novo contato");
            Console.WriteLine("2 - Listar contatos cadastrados");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarContato();
                    break;

                case "2":
                    ListarContatos();
                    break;

                case "3":
                    continuar = false;
                    Console.WriteLine("Encerrando programa...");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    private void AdicionarContato()
    {
        try
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Contato contato = new Contato
            {
                Nome = nome,
                Telefone = telefone,
                Email = email
            };

            using (StreamWriter writer = File.AppendText(arquivo))
            {
                writer.WriteLine(
                    $"{contato.Nome},{contato.Telefone},{contato.Email}"
                );
            }

            Console.WriteLine("Contato cadastrado com sucesso!");
        }
        catch (IOException)
        {
            Console.WriteLine("Erro ao gravar o contato no arquivo.");
        }
    }

    private List<Contato> LerContatos()
    {
        List<Contato> contatos = new List<Contato>();

        if (!File.Exists(arquivo))
        {
            return contatos;
        }

        try
        {
            using (StreamReader reader = new StreamReader(arquivo))
            {
                string linha;

                while ((linha = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(linha))
                        continue;

                    string[] dados = linha.Split(',');

                    if (dados.Length != 3)
                    {
                        Console.WriteLine(
                            $"Contato com formato inválido ignorado: {linha}"
                        );
                        continue;
                    }

                    Contato contato = new Contato
                    {
                        Nome = dados[0],
                        Telefone = dados[1],
                        Email = dados[2]
                    };

                    contatos.Add(contato);
                }
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Erro ao ler o arquivo.");
        }

        return contatos;
    }

    private void ListarContatos()
    {
        List<Contato> contatos = LerContatos();

        if (contatos.Count == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        Console.WriteLine("\nEscolha o formato de exibição:");
        Console.WriteLine("1 - Markdown");
        Console.WriteLine("2 - Tabela");
        Console.WriteLine("3 - Texto Puro");
        Console.Write("Escolha uma opção: ");

        string opcao = Console.ReadLine();

        ContatoFormatter formatter;

        switch (opcao)
        {
            case "1":
                formatter = new MarkdownFormatter();
                break;

            case "2":
                formatter = new TabelaFormatter();
                break;

            case "3":
                formatter = new RawTextFormatter();
                break;

            default:
                Console.WriteLine("Formato inválido.");
                return;
        }

        formatter.ExibirContatos(contatos);
    }
}