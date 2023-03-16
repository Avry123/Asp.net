using System;

class Maze
{
    static long Mod = 1000000007;
    static int[,] grid;

    static long[,] dp;

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        grid = new int[N, N];
        dp = new long[N, N];

        // Read in the grid
        for (int i = 0; i < N; i++)
        {
            string[] tokens = Console.ReadLine().Split();
            for (int j = 0; j < N; j++)
            {
                grid[i, j] = int.Parse(tokens[j]);
            }
        }

        // Initialize the DP table
        dp[0, 0] = grid[0, 0];
        for (int i = 1; i < N; i++)
        {
            if (grid[i, 0] != 1)
            {
                dp[i, 0] = dp[i - 1, 0] + grid[i, 0];
            }
        }
        for (int j = 1; j < N; j++)
        {
            if (grid[0, j] != 2)
            {
                dp[0, j] = dp[0, j - 1] + grid[0, j];
            }
        }

        // Compute the DP table
        for (int i = 1; i < N; i++)
        {
            for (int j = 1; j < N; j++)
            {
                if (grid[i, j] == 3)
                {
                    dp[i, j] = (dp[i - 1, j] + dp[i, j - 1] + grid[i, j]) % Mod;
                }
                else if (grid[i, j] == 2)
                {
                    dp[i, j] = (dp[i - 1, j] + grid[i, j]) % Mod;
                }
                else if (grid[i, j] == 1)
                {
                    dp[i, j] = (dp[i, j - 1] + grid[i, j]) % Mod;
                }
            }
        }

        Console.WriteLine(dp[N - 1, N - 1]);
    }
}
