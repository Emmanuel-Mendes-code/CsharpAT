using System.Globalization; 
namespace AT;

public class DistanciaFormatura
{
    private DateTime _hoje;
    private DateTime _formatura = new DateTime(2027, 12, 15);

    private void PedirInput()
    {
        bool valida = false;

        do
        {
            Console.Write("Digite a data de hoje (dd/MM/yyyy): ");
            string entrada = Console.ReadLine();

            try
            {
                _hoje = DateTime.ParseExact(entrada, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                valida = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Data inválida. Use o formato dd/MM/yyyy.");
            }

        } while (!valida);
    }

    private (int ano, int mes, int dia) DiferencaEntre()
    {
        DateTime inicio = _hoje < _formatura ? _hoje : _formatura;
        DateTime fim = _hoje < _formatura ? _formatura : _hoje;

        int anos = fim.Year - inicio.Year;
        int meses = fim.Month - inicio.Month;
        int dias = fim.Day - inicio.Day;

        if (dias < 0)
        {
            meses--;
            DateTime mesAnterior = fim.AddMonths(-1);
            dias += DateTime.DaysInMonth(mesAnterior.Year, mesAnterior.Month);
        }

        if (meses < 0)
        {
            anos--;
            meses += 12;
        }

        return (anos, meses, dias);
    }

    public void ExibirDiferencaEntreDatas()
    {
        PedirInput();

        if (_hoje > _formatura)
        {
            Console.WriteLine("Parabéns! Você já deveria estar formado!");
            return;
        }

        (int ano, int mes, int dia) = DiferencaEntre();

        Console.WriteLine(
            $"Faltam {ano} anos, {mes} meses e {dia} dias para sua formatura!"
        );

        int totalMeses = ano * 12 + mes;
        if (totalMeses < 6)
        {
            Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
        }
    }
}