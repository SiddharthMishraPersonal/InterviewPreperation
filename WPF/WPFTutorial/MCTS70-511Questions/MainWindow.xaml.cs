using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
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

namespace MCTS70_511Questions
{

  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window, INotifyPropertyChanged
  {
    private ObservableCollection<ListItemClass> _listBoxItems = new ObservableCollection<ListItemClass>();
    private int _price = 0;

    public MainWindow()
    {
      InitializeComponent();
      DataContext = this;
      this.Loaded += MainWindow_Loaded;
    }

    public ObservableCollection<ListItemClass> ListBoxItems
    {
      get { return _listBoxItems; }
      set { _listBoxItems = value; }
    }

    public int Price
    {
      get { return _price; }
      set
      {
        _price = value;
        OnPropertyChanged("Price");
      }
    }

    void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
      Random random = new Random(1324);
      for (int i = 0; i < 10; i++)
      {
        ListBoxItems.Add(new ListItemClass(string.Format("Item-{0}", random.Next(123, 4567))));
      }
    }



    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
    #endregion
  }

  public class ListItemClass : INotifyPropertyChanged
  {
    private string _displayValue;

    public string DisplayValue
    {
      get { return _displayValue; }
      set
      {
        _displayValue = value;

        OnPropertyChanged("DisplayValue");
      }
    }

    public ListItemClass(string displayValue)
    {
      this.DisplayValue = displayValue;
    }

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }
    #endregion
  }
}
