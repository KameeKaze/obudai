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

        if (N <= 1 || N >= 10 || M <= 1 || M >= 10)
        {
            Console.WriteLine("nope");
            return;
        }

        int[,] matrix = new int[N, M];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                matrix[i, j] = random.Next(0, 10); 
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        int[,] transzponalt = new int[M, N];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                transzponalt[j, i] = matrix[i, j];
            }
        }
        Console.WriteLine("-------------------------") ;

        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(transzponalt[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
