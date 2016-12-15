using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Module.Convertors
{
  public class IntToMargin : IMultiValueConverter
  {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
      if (DependencyProperty.UnsetValue == values[0] || DependencyProperty.UnsetValue == values[1]) return default(int);
      double index = (System.Convert.ToDouble(values[0]) + 1) * 10;
      double totalPullIps = System.Convert.ToDouble(values[1]);
      return new Thickness(index,
                           0,
                           0,
                          totalPullIps);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
