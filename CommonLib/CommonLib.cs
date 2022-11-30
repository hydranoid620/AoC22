namespace CommonLib;

public static class CommonLib
{
    /// <summary>
    /// Reads a file's contents
    /// </summary>
    /// <param name="filePath">Full path to input file</param>
    /// <returns>List of strings where each line in the file is an entry in the list</returns>
    public static List<string> ReadFile(string filePath)
    {
        return new List<string>(File.ReadAllLines(filePath));
    }

    /// <summary>
    /// Reads a file's contents and transforms each line into an integer
    /// </summary>
    /// <param name="filePath">Full path to input file</param>
    /// <returns>A list of integers where each line in the file is a number in the list</returns>
    public static List<int> ReadFileAsInts(string filePath)
    {
        
    }

    /// <summary>
    /// Reads a list of numbers from a file and splits each line at a separator, returning a 2D array
    /// </summary>
    /// <param name="filePath">Full path to input file</param>
    /// <param name="separator">Separator to split each line at. Uses a comma by default</param>
    /// <returns>A 2D array of integers where each line in the file is a number in the list</returns>
    public static int[][] ReadListNums(string filePath, char separator = ',')
    {
        
    }

    /// <summary>
    /// Reads a list of characters from a file and splits each line at a separator, returning a 2D array
    /// </summary>
    /// <param name="filePath">Full path to input file</param>
    /// <param name="separator">Separator to split each line at. Uses a comma by default</param>
    /// <returns>A 2D array of characters where each line in the file is a number in the list</returns>
    public static char[][] ReadListChars(string filePath, char separator = ',')
    {

    }

    /// <summary>
    /// Reads a list of strings from a file and splits each line at a separator, returning a 2D array
    /// </summary>
    /// <param name="filePath">Full path to input file</param>
    /// <param name="separator">Separator to split each line at. Uses a space by default</param>
    /// <returns>A 2D array of strings where each line in the file is a number in the list</returns>
    public static char[][] ReadListStrings(string filePath, char separator = ' ')
    {

    }
    
    /// <summary>
    /// Prints a 2D array of strings
    /// </summary>
    /// <param name="m">2D array of strings</param>
    public static void PrintMatrix(string[][] m)
    {
        
    }

    /// <summary>
    /// Prints a 2D array of integers
    /// </summary>
    /// <param name="m">2D array of integers</param>
    public static void PrintMatrix(int[][] m)
    {

    }

    /// <summary>
    /// Removes all occurrences of a target element in the given array
    /// </summary>
    /// <param name="input">Input array</param>
    /// <param name="target">Target to remove from the array</param>
    /// <typeparam name="T">Type of the input array and removal target</typeparam>
    public static void RemoveFromArray<T>(T?[] input, T target) where T : IComparable
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == null) continue;
            
            if (input[i]!.CompareTo(target) == 0)
            {
                input[i] = default;
            }
        }
    }

    /// <summary>
    /// Removes all occurrences of a target element in the given array
    /// </summary>
    /// <param name="input">Input array</param>
    /// <param name="targets">Target to remove from the array</param>
    /// <typeparam name="T">Type of the input array and removal target</typeparam>
    public static void RemoveFromArray<T>(T?[] input, T[] targets) where T : IComparable
    {
        foreach (T target in targets)
        {
            RemoveFromArray(input, target);
        }
    }
    
    /// <summary>
    /// Removes all occurrences of a target element in the given array
    /// </summary>
    /// <param name="input">Input array</param>
    /// <param name="target">Target to remove from the array</param>
    /// <typeparam name="T">Type of the input array and removal target</typeparam>
    public static void RemoveFromArray<T>(T?[][] input, T target) where T : IComparable
    {
        foreach (T?[] row in input)
        {
            RemoveFromArray(row, target);
        }
    }

    /// <summary>
    /// Removes all occurrences of a target element in the given array
    /// </summary>
    /// <param name="input">Input array</param>
    /// <param name="targets">Target to remove from the array</param>
    /// <typeparam name="T">Type of the input array and removal target</typeparam>
    public static void RemoveFromArray<T>(T?[][] input, T[] targets) where T : IComparable
    {
        foreach (T target in targets)
        {
            RemoveFromArray(input, target);
        }
    }
}