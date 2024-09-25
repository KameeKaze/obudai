using System;

class Program
{
    static void Main()
    {
        int[] x = { 1, 2, 3, 4, 5, 6, 7, 8 };


        for (int i = 0; i < x.Length / 2; i++)
        {
            int tmp = x[i];
            x[i] = x[x.Length - i - 1];
            x[x.Length - i - 1] = tmp;
        }

        Console.WriteLine("reverse " + string.Join(", ", x));
    }
}
