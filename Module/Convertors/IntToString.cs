using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace Module.Convertors
{
  public class IntToString : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value != null && value is List<int>)
      {
        var newvalue = value as List<int>;
        string strNewvalue = "";
        int i = 1;
        if (newvalue.Count == 0)
          return null;

        foreach (int item in newvalue)
        {
          strNewvalue += "[" + i + "," + item + "],";
          i++;
        }
        return strNewvalue.Substring(0, strNewvalue.Length - 1);
      }
      return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return new NotImplementedException();
    }
  }
}