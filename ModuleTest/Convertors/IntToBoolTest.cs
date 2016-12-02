using Module.Convertors;
using System;
using Xunit;

namespace ModuleTest.Convertors
{
  public class IntToBoolTest
  {
    private IntToBool intToBool = new IntToBool();

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void ConvertTest(int index)
    {
      bool indexBool = Convert.ToBoolean(index);
      Assert.Equal(!indexBool, (bool)intToBool.Convert(index, null, null, null));
    }
  }
}
