namespace AT;

public class Gerente : Funcionario
{
    public Gerente(string nome, string cargo, double salario) : base(nome, cargo, salario)
    {
    }

    public override double GetSalario()
    {
        return base.GetSalario() * 1.2;
    }
}