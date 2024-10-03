using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("N: ");
        int N = int.Parse(Console.ReadLine());


        List<int> lista = new List<int>();
        lista.Add(N);
        int K = N;

        while (K != 1)
        {
            if (K % 2 == 0)
            {
                K = K / 2; 
            }
            else
            {
                K = 3 * K + 1;
            }

            lista.Add(K);

            Console.WriteLine($"lista {string.Join(", ", lista)}");
        }

        Console.WriteLine("final");
        Console.WriteLine(string.Join("-> ", lista));
    }
}
