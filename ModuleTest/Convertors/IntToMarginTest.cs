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

    [Theory]
    [InlineData(0, 10)]
    public void ConvertTest(double left, double bottom)
    {
      object[] marginPoint = { left, bottom };
      Thickness expectedThickness = new Thickness(10, 0, 0, 10);
      Thickness actualeThickness = (Thickness)intToMargin.Convert(marginPoint, null, null, null);
      Assert.Equal(expectedThickness, actualeThickness);
    }
  }
}
