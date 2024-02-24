using System;
using System.IO;


const int MaxRed = 12;
const int MaxGreen = 13;
const int MaxBlue = 14;

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
    bool isGameValid = true;

    foreach (var round in rounds)
    {
        var colorInfos = round.Split(',', StringSplitOptions.TrimEntries);

        foreach (var color in colorInfos)
        {
            var colorInfo = color.Split(' ');

            if (colorInfo.Length != 2)
            {
                Console.WriteLine("Invalid color format. Skipping round.");
                isGameValid = false;
                break;
            }

            var colorCount = int.Parse(colorInfo[0]);
            var colorName = colorInfo[1].ToLower(); // Convert color name to lowercase for case-insensitive comparison

            switch (colorName)
            {
                case "red":
                    if (colorCount > MaxRed)
                    {
                        isGameValid = false;
                    }
                    break;
                case "green":
                    if (colorCount > MaxGreen)
                    {
                        isGameValid = false;
                    }
                    break;
                case "blue":
                    if (colorCount > MaxBlue)
                    {
                        isGameValid = false;
                    }
                    break;
                default:
                    Console.WriteLine($"Unknown color '{colorName}'. Skipping round.");
                    isGameValid = false;
                    break;
            }
        }

        if (!isGameValid)
        {
            break;
        }
    }

    if (isGameValid)
    {
        runningTotal += gameId;
    }
}

Console.WriteLine(runningTotal);
