namespace AT;

public class Contato
{
    public string Nome;
    public string Telefone;
    public string Email;
}

public class GerenciadorContatos
{
    private const string _arquivo = "contatos.txt";

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

        using (StreamWriter writer = File.AppendText(_arquivo))
        {
            writer.WriteLine(
                $"{contato.Nome},{contato.Telefone},{contato.Email}"
                );
        }

        Console.WriteLine("Contato cadastrado com sucesso!");

    }

    private void ListarContatos()
    {
        if (!File.Exists(_arquivo))
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        try
        {
            using (StreamReader reader = new StreamReader(_arquivo))
            {
                string linha;
                bool encontrouContato = false;

                Console.WriteLine("\nContatos cadastrados:");

                while ((linha = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(linha))
                        continue;

                    string[] dados = linha.Split(',');

                    if (dados.Length != 3)
                    {
                        Console.WriteLine("Contato com formato inválido ignorado.");
                        continue;
                    }

                    string nome = dados[0];
                    string telefone = dados[1];
                    string email = dados[2];

                    Console.WriteLine(
                        $"Nome: {nome} | Telefone: {telefone} | Email: {email}"
                    );

                    encontrouContato = true;
                }

                if (!encontrouContato)
                {
                    Console.WriteLine("Nenhum contato cadastrado.");
                }
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Erro ao ler o arquivo.");
        }
    }
}