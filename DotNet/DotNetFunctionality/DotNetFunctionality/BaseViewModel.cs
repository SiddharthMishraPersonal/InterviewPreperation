using System.ComponentModel;

namespace DotNetFunctionality
{
  public class BaseViewModel : INotifyPropertyChanged
  {
    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string property)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(property));
      }
    }

    #endregion
  }
}
