using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "InputDay3.txt";

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        var lines = File.ReadAllLines(inputFilePath);

        long part1 = SolvePart1(lines);
        long part2 = SolvePart2(lines);

        Console.WriteLine($"Part 1 Sonuç: {part1}");
        Console.WriteLine($"Part 2 Sonuç: {part2}");
    }

    static long SolvePart1(string[] lines)
    {
        long total = 0;

        foreach (var line in lines)
        {
            var s = line.Trim();
            if (s.Length < 2) continue;

            int best = -1;

            for (int i = 0; i < s.Length; i++)
            {
                int d1 = s[i] - '0';
                for (int j = i + 1; j < s.Length; j++)
                {
                    int d2 = s[j] - '0';
                    int value = 10 * d1 + d2;
                    if (value > best)
                        best = value;
                }
            }

            total += best;
        }

        return total;
    }

    static long SolvePart2(string[] lines)
    {
        long total = 0;

        foreach (var line in lines)
        {
            string s = line.Trim();
            if (s.Length < 12)
                continue;

            int pick = 12;                 
            int startIndex = 0;         
            StringBuilder chosen = new StringBuilder();


            for (int pos = 0; pos < pick; pos++)
            {
                int bestDigit = -1;
                int bestIndex = startIndex;

                int lastPossible = s.Length - (pick - pos);

          
                for (int i = startIndex; i <= lastPossible; i++)
                {
                    int d = s[i] - '0';
                    if (d > bestDigit)
                    {
                        bestDigit = d;
                        bestIndex = i;
                    }
                }

                chosen.Append(s[bestIndex]);

       
                startIndex = bestIndex + 1;
            }

            long value = long.Parse(chosen.ToString());

            total += value;
        }

        return total;
    }
}
