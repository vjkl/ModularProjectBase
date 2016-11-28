using TrainingSets.Utils;
using System.IO;
using Xunit;

namespace ModuleTest.Utils
{
  public class FileIOTest
  {
    private FileIO fileIO = new FileIO();
    private static string _nameFileTest = "ListTrainingsTest.txt";
    private string _path = Directory.GetCurrentDirectory() + "\\" + _nameFileTest;
    private string strObjectExcepted = "[\r\n  {\r\n    \"TrainingData\": \"2016-11-22T18:10:05.1947623+02:00\",\r\n    \"Sets\": [\r\n      {\r\n        \"Count\": 50\r\n      },\r\n      {\r\n        \"Count\": 50\r\n      },\r\n      {\r\n        \"Count\": 50\r\n      },\r\n      {\r\n        \"Count\": 50\r\n      }\r\n    ],\r\n    \"TotalCount\": 200\r\n  }\r\n]";

    [Fact]
    public void LoadTest()
    {
      string strObjectActual = fileIO.Load(_path);
      Assert.Equal(strObjectExcepted, strObjectActual);
    }

    [Fact]
    public void ReadTest()
    {
      string strObjectActual = fileIO.Read(_path);
      Assert.Equal(strObjectExcepted, strObjectActual);
    }
  }
}