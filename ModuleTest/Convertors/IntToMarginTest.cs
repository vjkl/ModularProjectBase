using Module.Convertors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xunit;

namespace ModuleTest.Convertors
{
  public class IntToMarginTest
  {
    private IntToMargin intToMargin = new IntToMargin();

    [Fact]
    public void ConvertTest()
    {
      Thickness actualeThickness;
      object[] values = new object[2];

      values[0] = 1;
      values[1] = 2;
      actualeThickness = (Thickness)intToMargin.Convert(values, null, null, null);

      Assert.Equal(new Thickness(20,0,0,2), actualeThickness);
    }
  }
}
