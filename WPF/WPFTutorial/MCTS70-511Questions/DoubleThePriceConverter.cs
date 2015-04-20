using System;
using System.Windows;
using System.Windows.Data;

namespace MCTS70_511Questions
{
  public class DoubleThePriceConverter : IValueConverter
  {
    #region IValueConverter Members

    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      if (value == null)
        return DependencyProperty.UnsetValue;

      var price = 0;
      Int32.TryParse(value.ToString(), out price);

      return price * 2;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      if (value == null)
        return DependencyProperty.UnsetValue;

      var price = 0;
      Int32.TryParse(value.ToString(), out price);

      return price / 2;
    }

    #endregion
  }
}
