using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Module.Convertors
{
  public class IntToBool : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (DependencyProperty.UnsetValue == value) return default(int);
      if ((int)value == default(int))
        return true;
      else return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
