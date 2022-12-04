using static CommonLib.CommonLib;

var data = ReadFileMatrix<string>(args[0]);
var subsets = 0;
var overlaps = 0;

foreach (var row in data)
{
    var splitRow = row.Select(x =>
                      {
                          var split = x.Split('-').Select(int.Parse).ToArray();
                          return Enumerable.Range(split[0], split[1] - split[0] + 1);
                      })
                      .ToArray();
    
    // if A - B != { } then A is not a subset of B
    // if B - A != { } then B is not a subset of A
    if (!splitRow[0].Except(splitRow[1]).Any() || !splitRow[1].Except(splitRow[0]).Any()) subsets++;
    
    if (splitRow[0].Intersect(splitRow[1]).Any()) overlaps++;
}

Console.WriteLine($"(Part 1) Subsets: {subsets}");
Console.WriteLine($"(Part 2) Overlaps: {overlaps}");