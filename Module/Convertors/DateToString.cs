using System;
using System.Globalization;
using System.Windows.Data;

namespace Module.Convertors
{
  public class DateToString : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value != null && value is DateTime)
      {
        var newDate = (DateTime)value;
        return newDate.ToString("dd/MM/yyyy");
      }
      return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}