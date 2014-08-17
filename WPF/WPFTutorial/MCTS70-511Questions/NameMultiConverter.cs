using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MCTS70_511Questions
{
  class NameMultiConverter : IMultiValueConverter
  {
    #region IMultiValueConverter Members

    public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      if (values == null || !values.Any())
        return DependencyProperty.UnsetValue;

      return values.Aggregate(string.Empty, (current, value) => string.IsNullOrEmpty(current) ? value.ToString() : string.Format("{0} {1}", current, value));
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
    {
      if (value != null)
      {
        var str = value.ToString();
        var val = str.Split(' ');

        return val;
      }

      return null;
    }

    #endregion
  }
}
