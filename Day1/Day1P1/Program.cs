using System;
using System.IO;

class Program
{
    static void Main()
    {
        string[] lines = File.ReadAllLines("input.txt");
        long total = ProcessLines(lines, string.IsNullOrWhiteSpace);

        Console.WriteLine(total);
    }

    static long ProcessLines(string[] lines, Func<string, bool> stopCondition)
    {
        long total = 0;

        foreach (var line in lines)
        {
            if (stopCondition.Invoke(line))
                break;

            int firstDigit = line.First(char.IsDigit) - '0';
            int lastDigit = line.Last(char.IsDigit) - '0';

            var fullNumber = firstDigit * 10 + lastDigit;
            total += fullNumber;
        }

        return total;
    }
}
