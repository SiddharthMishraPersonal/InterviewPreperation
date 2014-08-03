using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
  public partial class MainWindow : Window, INotifyPropertyChanged
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private int _counter = 0;
    private bool _stop;

    public int Counter
    {
      get { return _counter; }
      set
      {
        _counter = value;

        OnPropertyChanged("Counter");
      }
    }

    public bool Stop
    {
      get { return _stop; }
      set
      {
        _stop = value;
        OnPropertyChanged("Stop");
      }
    }

    private DispatcherTimer _dispatcherTimer = null;
    private void StartButton_OnClick(object sender, RoutedEventArgs e)
    {
      Stop = false;
      listBox.Items.Clear();
      _dispatcherTimer = new DispatcherTimer(DispatcherPriority.Background);
      _dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
      _dispatcherTimer.Tick += _dispatcherTimer_Tick;
      _dispatcherTimer.Start();
    }



    void _dispatcherTimer_Tick(object sender, EventArgs e)
    {
      // Define and start a new thread to add 20000 items to the list box
      ThreadStart job = new ThreadStart(() =>
      {
        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
        {
          listBox.Items.Add("Counter: " + Counter++);
        }));

      });

      Thread thread = new Thread(job);
      thread.Start();

      if (Stop)
      {
        if (_dispatcherTimer != null)
          _dispatcherTimer.Stop();
      }
    }

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string property)
    {
      var propertyChangedHandler = PropertyChanged;
      if (propertyChangedHandler != null)
      {
        propertyChangedHandler(this, new PropertyChangedEventArgs(property));
      }
    }

    #endregion

    private void StopButton_OnClick(object sender, RoutedEventArgs e)
    {
      Stop = true;
    }
  }
}
