namespace AT;

public class ContaBancaria
{
    public string nome;
    private decimal _saldo;

    public ContaBancaria(string nome, decimal saldo)
    {
        this.nome = nome;
        _saldo = saldo;
    }

    public decimal Depositar(decimal valor)
    {
        return _saldo += valor;
    }

    public void Sacar(decimal valor)
    {
        if (valor <= _saldo)
        {
            _saldo -= valor;
        }
        throw new Exception("Saldo insuficiente!");
    }
    
    public void ExibirSaldo()
    {
        Console.WriteLine("Saldo da conta: " + _saldo);
    }
}