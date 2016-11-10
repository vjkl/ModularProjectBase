using Module.Convertors;
using System;
using Xunit;

namespace ModuleTest.Convertors
{
  public class DateToStringTest
  {
    private DateToString dateToString = new DateToString();

    [Fact]
    public void ConvertTest()
    {
      object exceptedObj = dateToString.Convert(null, null, null, null);
      Assert.Null(exceptedObj);

      exceptedObj = dateToString.Convert(string.Empty, null, null, null);
      Assert.Null(exceptedObj);

      DateTime newDate = DateTime.Now;
      exceptedObj = dateToString.Convert(newDate, null, null, null);
      string excepted = Convert.ToString(exceptedObj);
      Assert.Equal(newDate.ToString("dd/MM/yyyy"), excepted);

    }
  }
}
