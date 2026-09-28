namespace AT;

public class Aluno
{
    private string _nome;
    private int _matricula;
    private string _curso;
    private double _media;

    public Aluno(string nome, int matricula, string curso, double media)
    {
        _nome = nome;
        _matricula = matricula;
        _curso = curso;
        _media = media;
    }

    public void ExibirDados()
    {
        Console.WriteLine($"Nome do Aluno: {_nome}");
        Console.WriteLine($"Matricula: {_matricula}");
        Console.WriteLine($"Curso: {_curso}");
        Console.WriteLine($"Media: {_media}");
    }
    
    public void VerificarAprovado()
    {
        if (_media >= 7)
        {
            Console.WriteLine("Aprovado!");
        }
        else
        {
            Console.WriteLine("Reprovado!");
        }
    }
    
    
}