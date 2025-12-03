using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "İnputDay2.txt"; 
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        string line = File.ReadAllText(inputFilePath).Trim();
        long result = SolvePart1(line);
        Console.WriteLine($"Part 1 Result: {result}");
    }

    static long SolvePart1(string line)
    {
        long sum = 0;

        string[] ranges = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
        foreach (var r in ranges)
        {
            var parts = r.Split('-');
            long start = long.Parse(parts[0]);
            long end = long.Parse(parts[1]);

            for (long id = start; id <= end; id++)
            {
                if (IsInvalid(id))
                {
                    sum += id;
                }
            }
        }

        return sum;
    }

    static bool IsInvalid(long n)
    {
        string s = n.ToString();
        if (s.Length % 2 != 0)
            return false;

        int half = s.Length / 2;
        string first = s.Substring(0, half);
        string second = s.Substring(half, half);

        return first == second;
    }
}

