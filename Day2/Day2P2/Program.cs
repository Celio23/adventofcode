using System;
using System.IO;

var runningTotal = 0;

string[] lines = File.ReadAllLines("input.txt");

foreach (var line in lines)
{
    var gameInfo = line.Split(':');

    if (gameInfo.Length != 2)
    {
        Console.WriteLine("Invalid input format. Skipping line.");
        continue;
    }

    var gameId = int.Parse(gameInfo[0].Split(' ')[1]);
    var rounds = gameInfo[1].Split(';', StringSplitOptions.TrimEntries);
    var maxRed = 0;
    var maxGreen = 0;
    var maxBlue = 0;

    foreach (var round in rounds)
    {
        var colorInfos = round.Split(',', StringSplitOptions.TrimEntries);

        foreach (var color in colorInfos)
        {
            var colorInfo = color.Split(' ');

            if (colorInfo.Length != 2)
            {
                Console.WriteLine("Invalid color format. Skipping round.");
                continue;
            }

            var colorCount = int.Parse(colorInfo[0]);
            var colorName = colorInfo[1].ToLower(); // Convert color name to lowercase for case-insensitive comparison

            switch (colorName)
            {
                case "red":
                    maxRed = Math.Max(colorCount, maxRed);
                    break;
                case "green":
                    maxGreen = Math.Max(colorCount, maxGreen);
                    break;
                case "blue":
                    maxBlue = Math.Max(colorCount, maxBlue);
                    break;
                default:
                    Console.WriteLine($"Unknown color '{colorName}'. Skipping round.");
                    break;
            }
        }
    }

    var product = maxRed * maxGreen * maxBlue;
    runningTotal += product;
}

Console.WriteLine(runningTotal);
