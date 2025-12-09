using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "InputDay1.txt"; 
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        var lines = File.ReadAllLines(inputFilePath);

        int part1Result = SolvePart1(lines);
        int part2Result = SolvePart2(lines);

        Console.WriteLine($"Part 1 Result: {part1Result}");
        Console.WriteLine($"Part 2 Result: {part2Result}");
    }

    static int SolvePart1(string[] lines)
    {
        int position = 50;
        int countZero = 0;

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            char dir = line[0];
            int value = int.Parse(line.Substring(1));

            if (dir == 'R')
            {
                position = (position + value) % 100;
            }
            else if (dir == 'L')
            {
                position = (position - value) % 100;
                if (position < 0)
                    position += 100;
            }

            if (position == 0)
                countZero++;
        }

        return countZero;
    }

    static int SolvePart2(string[] lines)
    {
        int position = 50;   
        int countZero = 0;

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            char dir = line[0];
            int value = int.Parse(line.Substring(1));

            int step;
            if (dir == 'R')
                step = 1;
            else if (dir == 'L')
                step = -1;
            else
                continue; 

       
            for (int i = 0; i < value; i++)
            {
                position += step;
              
                if (position == 100)
                    position = 0;
                else if (position == -1)
                    position = 99;

                if (position == 0)
                    countZero++;
            }
        }

        return countZero;
    }
}
