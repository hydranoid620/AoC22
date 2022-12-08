using static CommonLib.CommonLib;

int[][] input = ReadFileMatrixDigits(args[0]).Select(x => x.ToArray()).ToArray();

int length = input.Length;
int width = input[0].Length;
bool IsInBounds(int x, int y) => x > 0 && y > 0 && x < length - 1 && y < width - 1;

int[][] visibleTreesArray = Enumerable.Range(0, length).Select(_ => Enumerable.Range(0, width).Select(_ => -1).ToArray()).ToArray();

for (var colIndex = 0; colIndex < input.Length; colIndex++)
{
    int[] column = input[colIndex];

    // Top -> bottom
    int maxHeight = -1;
    for (var rowIndex = 0; rowIndex < column.Length; rowIndex++)
    {
        if (input[rowIndex][colIndex] > maxHeight)
        {
            maxHeight = input[rowIndex][colIndex];
            visibleTreesArray[rowIndex][colIndex] = input[rowIndex][colIndex];
        }
    }

    // Bottom -> Top
    maxHeight = -1;
    for (var rowIndex = column.Length - 1; rowIndex >= 0; rowIndex--)
    {
        if (input[rowIndex][colIndex] > maxHeight)
        {
            maxHeight = input[rowIndex][colIndex];
            visibleTreesArray[rowIndex][colIndex] = input[rowIndex][colIndex];
        }
    }
}

for (var i = 0; i < input.Length; i++)
{
    int[] row = input[i];

    // Left -> right
    int maxHeight = -1;
    for (var j = 0; j < row.Length; j++)
    {
        if (input[i][j] > maxHeight)
        {
            maxHeight = input[i][j];
            visibleTreesArray[i][j] = input[i][j];
        }
    }

    // Right -> left
    maxHeight = -1;
    for (var j = row.Length - 1; j >= 0; j--)
    {
        if (input[i][j] > maxHeight)
        {
            maxHeight = input[i][j];
            visibleTreesArray[i][j] = input[i][j];
        }
    }
}

// Count visible trees
var visibleTreesCount = 0;
for (var i = 0; i < length; i++)
    for (var j = 0; j < width; j++)
        if (visibleTreesArray[i][j] > -1)
            visibleTreesCount++;

Console.WriteLine($"(Part 1) Visible trees: {visibleTreesCount}");


int[][] scenicScoreArray = Enumerable.Range(0, length).Select(_ => Enumerable.Range(0, width).Select(_ => 0).ToArray()).ToArray();
for (var i = 1; i < length - 1; i++)
{
    for (var j = 1; j < width - 1; j++)
    {
        scenicScoreArray[i][j] = 1;
        
        var treesSeenInDirection = 0;
        int x = i;
        int y = j;
        
        // Up
        do
        {
            treesSeenInDirection++;
        } while (input[--x][y] < input[i][j] && IsInBounds(x, y));

        scenicScoreArray[i][j] *= treesSeenInDirection;
        treesSeenInDirection = 0;
        x = i;
        y = j;
        
        // Down
        do
        {
            treesSeenInDirection++;
        } while (input[++x][y] < input[i][j] && IsInBounds(x, y));

        scenicScoreArray[i][j] *= treesSeenInDirection;
        treesSeenInDirection = 0;
        x = i;
        y = j;

        // Left
        do
        {
            treesSeenInDirection++;
        } while (input[x][--y] < input[i][j] && IsInBounds(x, y));

        scenicScoreArray[i][j] *= treesSeenInDirection;
        treesSeenInDirection = 0;
        x = i;
        y = j;

        // Right
        do
        {
            treesSeenInDirection++;
        } while (input[x][++y] < input[i][j] && IsInBounds(x, y));

        scenicScoreArray[i][j] *= treesSeenInDirection;
    }
}

Console.WriteLine($"(Part 2) Max scenic score: {scenicScoreArray.Select(x => x.Max()).Max()}");