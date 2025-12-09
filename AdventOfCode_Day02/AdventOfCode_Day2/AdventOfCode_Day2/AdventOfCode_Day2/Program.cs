using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "InputDay2.txt";
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        string line = File.ReadAllText(inputFilePath).Trim();
        long result = SolvePart1(line);
        Console.WriteLine($"Part 1 Result: {result}");
        Console.WriteLine($"Part 2 Result: {SolvePart2(line)}");
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

    static long SolvePart2(string line)
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
                if (IsInvalidPart2(id)) 
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

    static bool IsInvalidPart2(long n)
    {
        string s = n.ToString();
        int len = s.Length;

        
        for (int pat = 1; pat <= len / 2; pat++)
        {
            if (len % pat != 0)
                continue;

            string pattern = s.Substring(0, pat);
            bool ok = true;

          
            for (int i = pat; i < len; i += pat)
            {
                if (s.Substring(i, pat) != pattern)
                {
                    ok = false;
                    break;
                }
            }

            if (ok)
                return true;  
        }

        return false;
    }
}
