namespace AT;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Escolha o exercício: (2, 3, 4, 5, 6, 7, 8, 9_1, 9_2, 10, 11, 12): ");
        string opcao = Console.ReadLine();
        
        switch (opcao)
        {
            case "2": Exercicio2(); break;
            case "3": Exercicio3(); break;
            case "4": Exercicio4(); break;
            case "5": Exercicio5(); break;
            case "6": Exercicio6(); break;
            case "7": Exercicio7(); break;
            case "8": Exercicio8(); break;
            case "9_1": Exercicio9_1(); break;
            case "9_2": Exercicio9_2(); break;
            case "10": Exercicio10(); break;
            case "11": Exercicio11(); break;
            case "12": Exercicio12(); break;
            default: Console.WriteLine("Opção inválida."); break;
        }

        static void Exercicio2()
        {
            CifradorDeNomes cifrador = new CifradorDeNomes("Emmanuel Pereira Mendes");
            cifrador.Cifrador();
            
        }

        static void Exercicio3()
        {
            Calculadora calculadora = new Calculadora();
            Console.WriteLine("Informe o primeiro numero: ");
            double num1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Informe o segundo numero: ");
            double num2 = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Informe a operação a ser executada:\nSoma(1)\nSubtração(2)\nMultiplicação(3)\nDivisão(4)");

            double resultado = double.Parse(Console.ReadLine()) switch
            {
                1 => calculadora.Soma(num1, num2),
                2 => calculadora.Subtracao(num1, num2),
                3 => calculadora.Multiplicacao(num1, num2),
                4 => num2 != 0 ? calculadora.Divisao(num1, num2) : throw new DivideByZeroException("Não é possível dividir por zero."),
                _ => throw new ArgumentException("Operação inválida")
            };
            
            Console.WriteLine($"Resultado: {resultado:F2}");
        }

        static void Exercicio4()
        {
            Console.Write("Digite a sua data de nascimento: ");
            AteProximoAniversario proximo = new AteProximoAniversario(Console.ReadLine());
            proximo.ProximoAniversario();
        }
        
        static void Exercicio5()
        {
            DistanciaFormatura distanciaFormatura = new DistanciaFormatura();
            distanciaFormatura.ExibirDiferencaEntreDatas();
        }

        static void Exercicio6()
        {
            Aluno aluno = new Aluno("Emmanuel Pereira Mendes", 3224, "ADS", 8.1);
            aluno.ExibirDados();
            aluno.VerificarAprovado();
        }

        static void Exercicio7()
        {
            ContaBancaria conta = new ContaBancaria("Emmanuel", 12000);
            conta.ExibirSaldo();
            conta.Depositar(12000);
            conta.ExibirSaldo();
        }

        static void Exercicio8()
        {
            Funcionario funcionario = new Funcionario("Armelindo", "Generico", 2000);
            Console.WriteLine(funcionario.GetSalario()); 

            Gerente gerente = new Gerente("habibi", "gerente", 2000);
            Console.WriteLine(gerente.GetSalario());
        }

        static void Exercicio9_1()
        {
            GerenciadorEstoque gerenciadorEstoque = new GerenciadorEstoque();
            gerenciadorEstoque.MenuProdutos();
        }

        static void Exercicio9_2()
        {
            GerenciadorEstoqueArquivo gerenciadorEstoqueArquivo = new GerenciadorEstoqueArquivo();
            gerenciadorEstoqueArquivo.MenuProdutos();
        }

        static void Exercicio10()
        {
            JogoAdivinhacao jogo =  new JogoAdivinhacao();
            jogo.Jogar();
        }

        static void Exercicio11()
        {
            GerenciadorContatos gerenciadorContatos = new GerenciadorContatos();
            gerenciadorContatos.MenuContatos();
        }

        static void Exercicio12()
        {
            GerenciadorContatosPolimorfismo gerenciadorContatosPolimorfismo = new GerenciadorContatosPolimorfismo();
            gerenciadorContatosPolimorfismo.MenuContatos();
        }
    }
}