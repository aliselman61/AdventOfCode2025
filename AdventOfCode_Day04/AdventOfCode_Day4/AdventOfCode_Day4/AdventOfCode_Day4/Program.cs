using System;
using System.IO;
using System.Collections.Generic;

class Program
{
   
    static readonly (int dy, int dx)[] Directions = new (int, int)[]
    {
        (-1, -1), (-1, 0), (-1, 1),
        ( 0, -1),          ( 0, 1),
        ( 1, -1), ( 1, 0), ( 1, 1)
    };

    static void Main(string[] args)
    {
        string inputFilePath = "InputDay4.txt";

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(inputFilePath);

        if (lines.Length == 0)
        {
            Console.WriteLine("Empty input.");
            return;
        }

     
        char[][] grid = new char[lines.Length][];
        for (int i = 0; i < lines.Length; i++)
            grid[i] = lines[i].ToCharArray();

        int part1 = CountAccessibleRolls(grid);
        Console.WriteLine($"Part 1 (erişilebilir rulolar): {part1}");

        int part2 = SimulateRemovals(grid);
        Console.WriteLine($"Part 2 (toplam kaldırılan rulolar): {part2}");
    }

    static int CountAccessibleRolls(char[][] grid)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int accessibleCount = 0;

        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                if (grid[y][x] != '@')
                    continue;

                int neighbors = CountNeighborRolls(grid, y, x);
                if (neighbors < 4)
                    accessibleCount++;
            }
        }

        return accessibleCount;
    }


    static int SimulateRemovals(char[][] originalGrid)
    {
        int rows = originalGrid.Length;
        int cols = originalGrid[0].Length;

   
        char[][] grid = new char[rows][];
        for (int i = 0; i < rows; i++)
            grid[i] = (char[])originalGrid[i].Clone();

        int totalRemoved = 0;

        while (true)
        {
            List<(int y, int x)> toRemove = new List<(int y, int x)>();

          
            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    if (grid[y][x] != '@')
                        continue;

                    int neighbors = CountNeighborRolls(grid, y, x);
                    if (neighbors < 4)
                        toRemove.Add((y, x));
                }
            }

            if (toRemove.Count == 0)
                break;

            
            foreach (var (y, x) in toRemove)
                grid[y][x] = '.';

            totalRemoved += toRemove.Count;
        }

        return totalRemoved;
    }

  
    static int CountNeighborRolls(char[][] grid, int y, int x)
    {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int count = 0;

        foreach (var (dy, dx) in Directions)
        {
            int ny = y + dy;
            int nx = x + dx;

            if (ny < 0 || ny >= rows || nx < 0 || nx >= cols)
                continue;

            if (grid[ny][nx] == '@')
                count++;
        }

        return count;
    }
}

