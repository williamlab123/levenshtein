// using System;

// class Levenshtein
// {
//     static void Main()
//     {
//         System.Console.WriteLine("Digite a primeira palavra");
//         System.Console.WriteLine("Digite a segunda palavra");
//         string? palavra1 = Console.ReadLine();
//         string? palavra2 = Console.ReadLine();

//         int distancia = DistanciaLevenshtein(palavra1, palavra2);

//         Console.WriteLine("A distância de Levenshtein entre \"{0}\" e \"{1}\" é {2}", palavra1, palavra2, distancia);

//         Console.ReadLine();
//     }

//     static int DistanciaLevenshtein(string s, string t)
//     {
//         int[,] d = new int[s.Length + 1, t.Length + 1];

//         for (int i = 0; i <= s.Length; i++)
//         {
//             d[i, 0] = i;
//         }

//         for (int j = 0; j <= t.Length; j++)
//         {
//             d[0, j] = j;
//         }

//         for (int j = 1; j <= t.Length; j++)
//         {
//             for (int i = 1; i <= s.Length; i++)
//             {
//                 int custo = (s[i - 1] == t[j - 1]) ? 0 : 1;

//                 d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + custo);
//             }
//         }

//         return d[s.Length, t.Length];
//     }
// }
using System;

class CorretorOrtografico
{
    static void Main()
    {
        string[] dicionario = { "casa", "carro", "comida", "caneca", "celular" };

        Console.WriteLine("Digite uma palavra:");
        string palavra = Console.ReadLine();

        if (!Array.Exists(dicionario, x => x == palavra))
        {
            Console.WriteLine("Distância máxima de edição:");
            int distanciaMaxima = int.Parse(Console.ReadLine());

            string corrigida = CorrigirPalavra(palavra, dicionario, distanciaMaxima);

            if (corrigida != null)
            {
                Console.WriteLine("Você quis dizer \"{0}\"?", corrigida);
            }
            else
            {
                Console.WriteLine("Palavra não encontrada no dicionário.");
            }
        }
        else
        {
            Console.WriteLine("Palavra correta.");
        }

        Console.ReadLine();
    }

    static string CorrigirPalavra(string palavra, string[] dicionario, int distanciaMaxima)
    {
        int distanciaMinima = int.MaxValue;
        string melhorCorrecao = null;

        foreach (string palavraCorreta in dicionario)
        {
            int distancia = DistanciaLevenshtein(palavra, palavraCorreta);

            if (distancia <= distanciaMaxima && distancia < distanciaMinima)
            {
                distanciaMinima = distancia;
                melhorCorrecao = palavraCorreta;
            }
        }

        if (distanciaMinima <= distanciaMaxima && melhorCorrecao != null)
        {
            return melhorCorrecao;
        }
        else
        {
            return null;
        }
    }

    static int DistanciaLevenshtein(string s, string t)
    {
        int[,] d = new int[s.Length + 1, t.Length + 1];

        for (int i = 0; i <= s.Length; i++)
        {
            d[i, 0] = i;
        }

        for (int j = 0; j <= t.Length; j++)
        {
            d[0, j] = j;
        }

        for (int j = 1; j <= t.Length; j++)
        {
            for (int i = 1; i <= s.Length; i++)
            {
                int custo = (s[i - 1] == t[j - 1]) ? 0 : 1;

                d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + custo);
            }
        }

        return d[s.Length, t.Length];
    }
}


