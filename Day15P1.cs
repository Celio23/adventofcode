var input = File.ReadAllText("input.txt");

var parts = input.Split(",", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

var result = 0;

foreach(var part in parts)
{
    result += Hash(part);
}

Console.WriteLine(result);

int Hash(string input)
{
    int currentValue = 0;
        foreach (var ch in input)
        {
            currentValue = (currentValue + (int)ch) * 17 % 256;
        }
        return currentValue;
}