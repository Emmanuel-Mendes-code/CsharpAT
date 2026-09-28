namespace AT;
using System.Globalization;

public class AteProximoAniversario
{
    private string nascimento;

    public AteProximoAniversario(string nascimento)
    {
        this.nascimento = nascimento;
    }
    public void ProximoAniversario()
    {
        DateTime birthDate = DateTime.ParseExact(nascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        DateTime birthDay = new DateTime(DateTime.Today.Year, birthDate.Month, birthDate.Day);
        DateTime hoje = DateTime.Today;

        if (birthDay < hoje)
        {
            birthDay = birthDay.AddYears(1);
        }

        int diasAte = (birthDay - hoje).Days;
        
        if (diasAte < 7)
        {
            Console.WriteLine("Seu aniversário está chegando!");
        }
        
        Console.WriteLine($"{diasAte} dias até o seu aniversário.");
    }
}