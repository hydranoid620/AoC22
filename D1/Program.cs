using static CommonLib.CommonLib;

var data = ReadFile(args[0]);
List<int> carrying = new() { 0 };
var elfNumber = 0;

foreach (string row in data)
{
    if (row == "")
    {
        carrying.Add(0);
        elfNumber++;
    }
    else
    {
        carrying[elfNumber] += int.Parse(row);
    }
}

var copy = new List<int>(carrying);
copy.Sort();

Console.WriteLine($"{carrying[carrying.IndexOf(copy[^1])]}\n" +
                  $"{carrying[carrying.IndexOf(copy[^2])]}\n" +
                  $"{carrying[carrying.IndexOf(copy[^3])]}\n" +
                  $"Total: {carrying[carrying.IndexOf(copy[^1])] + carrying[carrying.IndexOf(copy[^2])] + carrying[carrying.IndexOf(copy[^3])]}");
