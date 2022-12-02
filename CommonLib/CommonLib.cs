// ReSharper disable MemberCanBePrivate.Global
namespace CommonLib;

public static class CommonLib
{
    /// <summary>
    /// Reads a file's contents line by line into entries in the List
    /// </summary>
    /// <param name="filePath">Absolute path to input file</param>
    /// <returns>List of strings where each line in the file is an entry in the list</returns>
    public static IEnumerable<string> ReadFile(string filePath)
    {
        return new List<string>(File.ReadAllLines(filePath));
    }

    /// <summary>
    /// Reads rows of data in from a file and returns an IEnumerable of the appropriate data type 
    /// </summary>
    /// <param name="filePath">Absolute path to input file</param>
    /// <typeparam name="T">Type to interpret the file's contents as</typeparam>
    /// <returns>An IEnumerable of T type elements</returns>
    public static IEnumerable<T> ReadFileColumn<T>(string filePath) where T : IConvertible
    {
        return ReadFile(filePath).Select(row => (T)Convert.ChangeType(row, typeof(T)));
    }

    /// <summary>
    /// Reads rows of data in from a file and splits each row based on a separator character. Returns an IEnumerable of the appropriate data type 
    /// </summary>
    /// <param name="filePath">Absolute path to input file</param>
    /// <param name="separator">Separator character to use for each element. Default is a comma</param>
    /// <typeparam name="T">Type to interpret the file's contents as</typeparam>
    /// <returns>An IEnumerable of IEnumerables which contain T type elements</returns>
    public static IEnumerable<IEnumerable<T>> ReadFileMatrix<T>(string filePath, char separator = ',') where T : IConvertible
    {
        // Split the rows
        var matrix = ReadFile(filePath).Select(e => e.Split(separator).AsEnumerable());
        // Convert the elements
        return matrix.Select(row => row.Select(element => (T)Convert.ChangeType(element, typeof(T))));
    }
    
    /// <summary>
    /// Reads a list of numbers from a file and splits each number into digits, returning a 2D array
    /// </summary>
    /// <param name="filePath">Full path to input file</param>
    /// <returns>An IEnumerable of IEnumerables containing the individual digits of numbers found in the file</returns>
    public static IEnumerable<IEnumerable<int>> ReadFileColumnAsDigits(string filePath)
    {
        return ReadFileColumn<string>(filePath).Select(line => line.Select(c => int.Parse(c.ToString())));
    }

    /// <summary>
    /// Prints a 2D array (matrix) of strings
    /// </summary>
    /// <param name="matrix">2D array (matrix) to print</param>
    public static void PrintMatrix<T>(List<List<T>> matrix)
    {
        foreach (List<T> t in matrix)
        {
            for (int j = 0; j < matrix.Count; j++)
            {
                Console.Write(t[j] + "\t");
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
    public static void RemoveFromArray<T>(IEnumerable<T> input, T target) where T : IComparable
    {
        input.ToList().RemoveAll(e => e.CompareTo(target) == 0);
    }

    /// <summary>
    /// Removes all occurrences of a target element in the given array
    /// </summary>
    /// <param name="input">Input array</param>
    /// <param name="targets">Target to remove from the array</param>
    /// <typeparam name="T">Type of the input array and removal target</typeparam>
    public static void RemoveFromArray<T>(IEnumerable<T> input, IEnumerable<T> targets) where T : IComparable
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
    public static void RemoveFromArray<T>(IEnumerable<IEnumerable<T>> input, T target) where T : IComparable
    {
        foreach (IEnumerable<T> row in input)
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
    public static void RemoveFromArray<T>(IEnumerable<IEnumerable<T>> input, IEnumerable<T> targets) where T : IComparable
    {
        foreach (T target in targets)
        {
            RemoveFromArray(input, target);
        }
    }
}