using static CommonLib.CommonLib;

var input = ReadFileColumn<string>(args[0]).ToList();

var prioritiesSum = input
                 .Select(x => x.Chunk(x.Length / 2))
                 .Select(row =>
                 {
                     var rowList = row.ToArray();
                     return rowList[0].Intersect(rowList[1]).First();
                 })
                 .Select(c => char.IsLower(c) ? c - 96 : c - 38)
                 .Sum();
Console.WriteLine($"(Part 1) Priority sum: {prioritiesSum}");

var groupBadgesSum = input
                  .Chunk(3)
                  .Select(g => g[0].Intersect(g[1]).Intersect(g[2]).First())
                  .Select(c => char.IsLower(c) ? c - 96 : c - 38)
                  .Sum();
Console.WriteLine($"(Part 2) Priority sum: {groupBadgesSum}");