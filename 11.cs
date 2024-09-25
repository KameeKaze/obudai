using System;

class Program
{
    static void Main()
    {
        Console.Write("N ");
        int N = int.Parse(Console.ReadLine());

        Console.Write("M ");
        int M = int.Parse(Console.ReadLine());

        int[,] matrix = new int[N, M];
        Random random = new Random();

        Console.WriteLine("eredeti:");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                matrix[i, j] = random.Next(1, 100); 
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        Console.Write("K: ");
        int K = int.Parse(Console.ReadLine());
        K %= 4; 

        for (int k = 0; k < K; k++)
        {
            matrix = RotateMatrix(matrix, N, M);
            int temp = N;
            N = M;
            M = temp;
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static int[,] RotateMatrix(int[,] matrix, int N, int M)
    {
        int[,] rotated = new int[M, N]; 

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                rotated[j, N - 1 - i] = matrix[i, j]; 
            }
        }

        return rotated;
    }
}
