using System.Collections.Generic;
using Xunit;
using TrainingSets.Utils;

namespace ModuleTest.Utils
{
  public class JsonIOTest
  {
    JsonIO jsonIO = new JsonIO();
    List<int> listInt;

    public JsonIOTest()
    {
      listInt = new List<int>();
      listInt.Add(1);
    }

    [Fact]
    public void SerializeObject()
    {
      string serializedObject = jsonIO.SerializeObject(listInt);
      Assert.Equal("[\r\n  1\r\n]", serializedObject);
    }

    [Fact]
    public void DeserializeObject()
    {
      var serializedObject = jsonIO.DeserializeObject<List<int>>(jsonIO.SerializeObject(listInt));

      Assert.Equal(listInt, serializedObject);
    }
  }
}