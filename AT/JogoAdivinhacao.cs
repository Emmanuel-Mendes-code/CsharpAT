namespace AT;
using System;

public class JogoAdivinhacao
{
    private int _input;
    private int _segredo;

    private void GerarSegredo()
    {
        Random random = new Random();
        _segredo = random.Next(1, 51);
    }

    private bool Acertou()
    {
        if (_segredo == _input)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public void Jogar()
    {
        GerarSegredo();
        int contador = 0;
        while (contador < 5)
        {
            Console.WriteLine($"Tente adivinhar o numero entre 1-50! Essa é a sua {contador+1} tentativa de 5");
            try
            {
                _input = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Entre 1 e 50!");
                continue;
            }
            
            if (_input < 1 || _input > 50)
            {
                Console.WriteLine("Entre 1 e 50!");
                continue;
            }
            
            if (Acertou())
            {
                Console.WriteLine($"Parabens! O numero aleatório era {_input}!");
                break;
            }
            else
            {
                Console.WriteLine("Errado! Tente Novamente!");
                contador++;
            }
        }
    }
}