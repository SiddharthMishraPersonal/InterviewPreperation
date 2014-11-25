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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DispatcherConcept
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private DispatcherTimer _timer;
    private static int _counter;

    public MainWindow()
    {
      InitializeComponent();
    }

    private void btnStart_Click(object sender, RoutedEventArgs e)
    {
      _timer.Start();
    }

    private void btnStop_Click(object sender, RoutedEventArgs e)
    {
      _timer.Stop();
    }

    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
      _timer = new DispatcherTimer(DispatcherPriority.Background);
      _timer.Interval = new TimeSpan(0, 0, 0, 1);
      _timer.Tick += _timer_Tick;
    }

    void _timer_Tick(object sender, EventArgs e)
    {
      txtOutput.Dispatcher.BeginInvoke((Action)(() =>
      {
        txtOutput.Text = _counter.ToString();
        _counter++;
      }));
    }
  }
}
