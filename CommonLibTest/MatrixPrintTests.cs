using System.Globalization;

namespace CommonLibTest;

[TestClass]
public class MatrixPrintTests
{
    private const int randomSeed = 69420;
    
    [TestMethod]
    public void IntegerTest()
    {
        var data = new List<List<int>>();
        Random rand = new(randomSeed);
        
        for (int i = 0; i < 5; i++)
        {
            data.Add(new List<int>(3));
            for (int j = 0; j < 5; j++)
            {
                data[i].Add(rand.Next());
            }
        }

        var expected = $"{data[0][0]}\t{data[0][1]}\t{data[0][2]}\t{data[0][3]}\t{data[0][4]}\t\r\n" +
                       $"{data[1][0]}\t{data[1][1]}\t{data[1][2]}\t{data[1][3]}\t{data[1][4]}\t\r\n" +
                       $"{data[2][0]}\t{data[2][1]}\t{data[2][2]}\t{data[2][3]}\t{data[2][4]}\t\r\n" +
                       $"{data[3][0]}\t{data[3][1]}\t{data[3][2]}\t{data[3][3]}\t{data[3][4]}\t\r\n" +
                       $"{data[4][0]}\t{data[4][1]}\t{data[4][2]}\t{data[4][3]}\t{data[4][4]}\t\r\n";

        StringWriter stringWriter = new();
        Console.SetOut(stringWriter);
        PrintMatrix(data);
        Assert.AreEqual(expected, stringWriter.ToString());
    }

    [TestMethod]
    public void CharacterTest()
    {
        {
            var data = new List<List<char>>();
            Random rand = new(randomSeed);

            for (int i = 0; i < 5; i++)
            {
                data.Add(new List<char>(3));
                for (int j = 0; j < 5; j++)
                {
                    data[i].Add(Convert.ToChar(rand.Next(65, 91)));
                }
            }

            var expected = $"{data[0][0]}\t{data[0][1]}\t{data[0][2]}\t{data[0][3]}\t{data[0][4]}\t\r\n" +
                           $"{data[1][0]}\t{data[1][1]}\t{data[1][2]}\t{data[1][3]}\t{data[1][4]}\t\r\n" +
                           $"{data[2][0]}\t{data[2][1]}\t{data[2][2]}\t{data[2][3]}\t{data[2][4]}\t\r\n" +
                           $"{data[3][0]}\t{data[3][1]}\t{data[3][2]}\t{data[3][3]}\t{data[3][4]}\t\r\n" +
                           $"{data[4][0]}\t{data[4][1]}\t{data[4][2]}\t{data[4][3]}\t{data[4][4]}\t\r\n";

            StringWriter stringWriter = new();
            Console.SetOut(stringWriter);
            PrintMatrix(data);
            Assert.AreEqual(expected, stringWriter.ToString());
        }
    }

    [TestMethod]
    public void StringTest()
    {
        {
            var data = new List<List<string>>();
            Random rand = new(randomSeed);

            for (int i = 0; i < 5; i++)
            {
                data.Add(new List<string>(3));
                for (int j = 0; j < 5; j++)
                {
                    data[i].Add(rand.Next().ToString());
                }
            }

            var expected = $"{data[0][0]}\t{data[0][1]}\t{data[0][2]}\t{data[0][3]}\t{data[0][4]}\t\r\n" +
                           $"{data[1][0]}\t{data[1][1]}\t{data[1][2]}\t{data[1][3]}\t{data[1][4]}\t\r\n" +
                           $"{data[2][0]}\t{data[2][1]}\t{data[2][2]}\t{data[2][3]}\t{data[2][4]}\t\r\n" +
                           $"{data[3][0]}\t{data[3][1]}\t{data[3][2]}\t{data[3][3]}\t{data[3][4]}\t\r\n" +
                           $"{data[4][0]}\t{data[4][1]}\t{data[4][2]}\t{data[4][3]}\t{data[4][4]}\t\r\n";

            StringWriter stringWriter = new();
            Console.SetOut(stringWriter);
            PrintMatrix(data);
            Assert.AreEqual(expected, stringWriter.ToString());
        }
    }
}
