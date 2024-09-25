using System;

class Program
{
    static void Main()
    {
        Console.Write("N: ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("M: ");
        int M = int.Parse(Console.ReadLine());

        bool[,] maze = new bool[N, M];
        Random random = new Random();

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                maze[i, j] = random.Next(0, 2) == 1; 
            }
        }

        Console.WriteLine("labirintus ");
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                Console.Write(maze[i, j] ? " . " : " # ");
            }
            Console.WriteLine();
        }

        Console.Write("sor  ", N - 1);
        int startRow = int.Parse(Console.ReadLine());
        Console.Write("oszlop ", M - 1);
        int startCol = int.Parse(Console.ReadLine());

        int targetRow = N - 1;
        int targetCol = M - 1;

        bool canReach = CanReachTarget(maze, startRow, startCol, targetRow, targetCol);

        if (canReach)
        {
            Console.WriteLine("yay");
        }
        else
        {
            Console.WriteLine("nop");
        }
    }

    static bool CanReachTarget(bool[,] maze, int row, int col, int targetRow, int targetCol)
    {
        if (row < 0 || row >= maze.GetLength(0) || col < 0 || col >= maze.GetLength(1))
            return false;

        if (!maze[row, col])
            return false;

        if (row == targetRow && col == targetCol)
            return true;

        maze[row, col] = false;

        bool result = CanReachTarget(maze, row - 1, col, targetRow, targetCol) || // fel
                      CanReachTarget(maze, row + 1, col, targetRow, targetCol) || // le
                      CanReachTarget(maze, row, col - 1, targetRow, targetCol) || // balra
                      CanReachTarget(maze, row, col + 1, targetRow, targetCol);   // jobbra

        maze[row, col] = true;

        return result;
    }
}
