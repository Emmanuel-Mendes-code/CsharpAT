namespace AT;

public class CifradorDeNomes
{
    private string _nome;

    public CifradorDeNomes(string nome)
    {
        this._nome = nome;
    }
    
    public void Cifrador()
    {
        char[] letras = _nome.ToCharArray();

        for (int i = 0; i < letras.Length; i++)
        {
            if ((letras[i] >= 'a' && letras[i] <= 'z') || (letras[i] >= 'A' && letras[i] <= 'Z'))
            {
                letras[i] = (char)(letras[i] + 2);
            }
        }
        Console.WriteLine(new string(letras));
    }
}