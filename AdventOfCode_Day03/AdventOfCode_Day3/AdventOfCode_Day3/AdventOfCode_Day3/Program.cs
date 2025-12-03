using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "İnputDay3.txt";

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        var lines = File.ReadAllLines(inputFilePath);
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

        Console.WriteLine($"Toplam çıkış gerilimi: {total}");
    }
}
