using static CommonLib.CommonLib;

var input = ReadFileMatrix<string>(args[0], ' ').Select(x => x.ToArray()).ToArray();

var height = 0;
var width = 0;

// Find size of grid needed
foreach (string[] line in input)
{
    switch (line[0])
    {
        case "R":
            width += int.Parse(line[1]);
            break;
        case "U":
            height += int.Parse(line[1]);
            break;
    }
}

bool[][] visitedGrid = Enumerable.Range(0, ++height).Select(_ => Enumerable.Range(0, ++width).Select(_ => false).ToArray()).ToArray();
(int y, int x) headLocation = ((height / 2) - 1, (width / 2) - 1);
(int y, int x) tailLocation = ((height / 2) - 1, (width / 2) - 1);

// Do moves
foreach (string[] line in input)
{
    char direction = line[0][0];
    int numberOfSpacesToMove = int.Parse(line[1]);

    for (var i = 0; i < numberOfSpacesToMove; i++)
    {
        switch (direction)
        {
            case 'L':
                headLocation.x--;
                if (Math.Abs(headLocation.x - tailLocation.x) > 1)
                {
                    tailLocation.x--;
                    tailLocation.y -= tailLocation.y - headLocation.y;
                }

                break;
            case 'R':
                headLocation.x++;
                if (Math.Abs(headLocation.x - tailLocation.x) > 1)
                {
                    tailLocation.x++;
                    tailLocation.y -= tailLocation.y - headLocation.y;
                }

                break;
            case 'U':
                headLocation.y--;
                if (Math.Abs(headLocation.y - tailLocation.y) > 1)
                {
                    tailLocation.y--;
                    tailLocation.x -= tailLocation.x - headLocation.x;
                }

                break;
            case 'D':
                headLocation.y++;
                if (Math.Abs(headLocation.y - tailLocation.y) > 1)
                {
                    tailLocation.y++;
                    tailLocation.x -= tailLocation.x - headLocation.x;
                }

                break;
        }

        visitedGrid[tailLocation.y][tailLocation.x] = true;
    }
}

Console.WriteLine(visitedGrid.Sum(row => row.Count(cell => cell)));