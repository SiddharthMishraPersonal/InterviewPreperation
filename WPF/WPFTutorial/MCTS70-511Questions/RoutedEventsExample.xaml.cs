using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MCTS70_511Questions
{
  /// <summary>
  /// Interaction logic for RoutedEventsExample.xaml
  /// </summary>
  public partial class RoutedEventsExample : Window
  {
    public RoutedEventsExample()
    {
      InitializeComponent();
    }

    private void TestEllipse_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
      DisplayTextBlock.Text = (sender as Ellipse).Fill.ToString();
    }
  }
}
