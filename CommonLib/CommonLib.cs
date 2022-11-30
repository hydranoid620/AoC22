namespace CommonLib;

public static class CommonLib
{
    /// <summary>
    /// Reads a file's contents line by line into entries in the List
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
    /// <returns>A 2D list of integers where the first dimension is a line in the file and the second dimension is the separated row</returns>
    public static List<List<int>> ReadListNums(string filePath, char separator = ',')
    {
        
    }

    /// <summary>
    /// Reads a list of characters from a file and splits each line at a separator, returning a 2D array
    /// </summary>
    /// <param name="filePath">Full path to input file</param>
    /// <param name="separator">Separator to split each line at. Uses a comma by default</param>
    /// <returns>A 2D list of characters where the first dimension is a line in the file and the second dimension is the separated row</returns>
    public static List<List<char>> ReadListChars(string filePath, char separator = ',')
    {

    }

    /// <summary>
    /// Reads a list of numbers from a file and splits each number into digits, returning a 2D array
    /// </summary>
    /// <param name="filePath">Full path to input file</param>
    /// <returns>A 2D list of digits where the first dimension is a line in the file and the second dimension is the number, split into individual digits</returns>
    public static List<List<int>> ReadListDigits(string filePath)
    {

    }
    
    /// <summary>
    /// Reads a list of strings from a file and splits each line at a separator, returning a 2D array
    /// </summary>
    /// <param name="filePath">Full path to input file</param>
    /// <param name="separator">Separator to split each line at. Uses a space by default</param>
    /// <returns>A 2D list of strings where the first dimension is a line in the file and the second dimension is each word on the line</returns>
    public static List<List<string>> ReadListStrings(string filePath, char separator = ' ')
    {

    }
    
    /// <summary>
    /// Prints a 2D array (matrix) of strings
    /// </summary>
    /// <param name="matrix">2D array (matrix) to print</param>
    public static void PrintMatrix<T>(List<List<T>> matrix)
    {
        for (int i = 0; i < matrix.Count; i++)
        {
            for (int j = 0; j < matrix.Count; j++)
            {
                Console.Write(matrix[i][j] + "\t");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Removes all occurrences of a target element in the given array
    /// </summary>
    /// <param name="input">Input array</param>
    /// <param name="target">Target to remove from the array</param>
    /// <typeparam name="T">Type of the input array and removal target</typeparam>
    public static void RemoveFromArray<T>(List<T> input, T target) where T : IComparable
    {
        input.RemoveAll(e => e.CompareTo(target) == 0);
    }

    /// <summary>
    /// Removes all occurrences of a target element in the given array
    /// </summary>
    /// <param name="input">Input array</param>
    /// <param name="targets">Target to remove from the array</param>
    /// <typeparam name="T">Type of the input array and removal target</typeparam>
    public static void RemoveFromArray<T>(List<T> input, IEnumerable<T> targets) where T : IComparable
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
    public static void RemoveFromArray<T>(List<List<T>> input, T target) where T : IComparable
    {
        foreach (List<T> row in input)
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
    public static void RemoveFromArray<T>(List<List<T>> input, IEnumerable<T> targets) where T : IComparable
    {
        foreach (T target in targets)
        {
            RemoveFromArray(input, target);
        }
    }
}