using static CommonLib.CommonLib;

var input = ReadFile(args[0]).First();

// Part 1
for (var i = 0; i < input.Length - 4; i++)
{
    if (input.Substring(i, 4).Distinct().Count() == 4)
    {
        Console.WriteLine(i + 4);
        break;
    }
}

// Part 2
for (var i = 0; i < input.Length - 14; i++)
{
    if (input.Substring(i, 14).Distinct().Count() == 14)
    {
        Console.WriteLine(i + 14);
        break;
    }
}