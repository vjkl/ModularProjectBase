using Module.Utils;
using System.IO;
using Xunit;

namespace ModuleTest.Utils
{
  public class FileIOTest
  {
    private FileIO fileIO               = new FileIO()                                                                                                                                                          ;
    private static string _nameFileTest = "ListTrainingsTest.txt"                                                                                                                                               ;
    private string _path                = Directory.GetCurrentDirectory() + "\\" + _nameFileTest                                                                                                                ;                         
    private string strObjectExcepted    = "[\r\n  {\r\n    \"TrainingData\": \"2016-11-07T12:55:24.9936907+02:00\",\r\n    \"Sets\": [\r\n      12,\r\n      21\r\n    ],\r\n    \"TotalCount\": 33\r\n  }\r\n]";

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
