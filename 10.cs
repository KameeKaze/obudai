using System;

class Program
{
    static void Main()
    {

        Random random = new Random();


        Console.Write("szam ");
        int n = int.Parse(Console.ReadLine());

 
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = random.Next(1, 100); 
        }

        Console.WriteLine("eredeti: " + string.Join(", ", array));

        int[] everySecondElement = new int[(n + 1) / 2];
        for (int i = 0, j = 0; i < n; i += 2, j++)
        {
            everySecondElement[j] = array[i];
        }

        Console.WriteLine("2. elem: " + string.Join(", ", everySecondElement));

        Array.Reverse(array);
        Console.WriteLine("reverse: " + string.Join(", ", array));

        int matrixSize = (int)Math.Ceiling(Math.Sqrt(n));
        int[,] matrix = new int[matrixSize, matrixSize];

        for (int i = 0; i < n; i++)
        {
            matrix[i / matrixSize, i % matrixSize] = array[i];
        }

        Console.WriteLine("matrix:");
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
