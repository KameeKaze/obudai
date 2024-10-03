using System;

class Program
{
    static void Main()
    {
        Random random = new Random();

        Console.Write("N: ");
        int N = int.Parse(Console.ReadLine());

        Console.Write("M: ");
        int M = int.Parse(Console.ReadLine());

        int[,] F = new int[N, M];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                F[i, j] = random.Next(0, 10);
                Console.Write(F[i, j] + "\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine("összes:");
        for (int j = 0; j < M; j++)
        {
            int halfajOsszesen = 0;
            for (int i = 0; i < N; i++)
            {
                halfajOsszesen += F[i, j];
            }
            Console.WriteLine($"Halfaj {j + 1}: {halfajOsszesen} ");
        }

        int legtobbHalHorgaszIndex = -1;
        int legtobbHalMennyiseg = 0;

        for (int i = 0; i < N; i++)
        {
            int horgaszOsszesen = 0;
            for (int j = 0; j < M; j++)
            {
                horgaszOsszesen += F[i, j];
            }

            if (horgaszOsszesen > legtobbHalMennyiseg)
            {
                legtobbHalMennyiseg = horgaszOsszesen;
                legtobbHalHorgaszIndex = i;
            }
        }

        Console.WriteLine($"\nlegtöbb hal {legtobbHalHorgaszIndex + 1} összesen {legtobbHalMennyiseg} db");

        // 3. Volt-e olyan horgász, aki egyetlen halat sem fogott?
        bool vanNullaHalasHorgasz = false;
        for (int i = 0; i < N; i++)
        {
            int horgaszOsszesen = 0;
            for (int j = 0; j < M; j++)
            {
                horgaszOsszesen += F[i, j];
            }

            if (horgaszOsszesen == 0)
            {
                Console.WriteLine($"\n {i + 1} nem fogott");
                vanNullaHalasHorgasz = true;
            }
        }

    }
    }
