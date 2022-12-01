using static CommonLib.CommonLib;

var data = ReadFile(args[0]);
Dictionary<int, int> carrying = new() { { 0, 0 } };
var elfNumber = 0;

foreach (string row in data)
{
    if (row == "")
    {
        carrying.Add(++elfNumber, 0);
    }
    else
    {
        carrying[elfNumber] += int.Parse(row);
    }
}

var first = carrying.AsParallel().MaxBy(e => e.Value);
carrying[first.Key] = -1;
var second = carrying.AsParallel().MaxBy(e => e.Value);
carrying[second.Key] = -1;
var third = carrying.AsParallel().MaxBy(e => e.Value);

Console.WriteLine($"{first}\n{second}\n{third}\nTotal: {first.Value + second.Value + third.Value}");
