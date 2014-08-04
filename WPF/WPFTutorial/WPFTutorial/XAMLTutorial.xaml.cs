using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace WPFTutorial
{
  /// <summary>
  /// Interaction logic for XAMLTutorial.xaml
  /// </summary>
  public partial class XAMLTutorial : Window, INotifyPropertyChanged
  {
    public XAMLTutorial()
    {
      InitializeComponent();
    }

    private Point _coordinates;

    public Point Coordinates
    {
      get { return _coordinates; }
      set
      {
        _coordinates = value;
        OnPropertyChanged("Coordinates");
      }
    }

    private void PnlMainGrid_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
      MessageBox.Show(this, "You clicked on button at " + e.GetPosition(this).ToString());
      Coordinates = e.GetPosition(this);
    }

    #region ICommand Examples

    private ICommand showMessageCommand;

    #endregion


    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(string property)
    {
      var propertyChangedEventHandler = PropertyChanged;

      if (propertyChangedEventHandler != null)
      {
        propertyChangedEventHandler(this, new PropertyChangedEventArgs(property));
      }

    }

    #endregion
  }
}
