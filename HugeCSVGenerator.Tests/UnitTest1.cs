namespace HugeCSVGenerator.Tests;

public class UnitTest1
{
    [Fact]
    public void GenerateCSV_Integers_InputNumberOfRows_EmptyFile()
    {
        string filePath = "empty.csv";
        Program.GenerateCSV(filePath, 0);

        string[] rows = File.ReadAllLines(filePath);
        Assert.Single(rows);

        File.Delete(filePath);
    }

    [Fact]
    public void GenerateCSV_Integers_InputNumberOfRows_SingleLine()
    {
        string filePath = "single.csv";
        Program.GenerateCSV(filePath, 1);

        string[] rows = File.ReadAllLines(filePath);
        Assert.Equal(2, rows.Length);

        File.Delete(filePath);
    }

    [Fact]
    public void GenerateCSV_Integers_InputNumberOfRows_HugeFile()
    {
        string filePath = "huge.csv";

        Program.GenerateCSV(filePath, 10_000_000);

        string[] rows = File.ReadAllLines(filePath);
        // include headers
        Assert.Equal(10_000_001, rows.Length);

        File.Delete(filePath);
    }
}