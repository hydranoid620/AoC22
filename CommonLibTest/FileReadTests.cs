namespace CommonLibTest;

[TestClass]
public class FileReadTests
{
    [TestMethod]
    public void TestMethod1()
    {
    }
}

/*
ReadFile(string filePath):IEnumerable<string>
ReadFileAsInts(string filePath):IEnumerable<int>
ReadListStrings(string filePath, char separator):IEnumerable<IEnumerable<string>>
ReadListNums(string filePath, char separator):IEnumerable<IEnumerable<int>>
ReadListChars(string filePath, char separator):IEnumerable<IEnumerable<char>>
ReadListDigits(string filePath):IEnumerable<IEnumerable<int>>
*/