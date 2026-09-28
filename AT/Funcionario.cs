namespace AT;

public class Funcionario
{
    private string _nome;
    private string _cargo;
    private double _salario;

    public Funcionario(string nome, string cargo, double salario)
    {
        _nome = nome;
        _cargo = cargo;
        _salario = salario;
    }

    public virtual double GetSalario()
    {
        return _salario;
    }
}