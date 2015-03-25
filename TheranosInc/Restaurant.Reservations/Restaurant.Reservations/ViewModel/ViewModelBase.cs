using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Reservations.ViewModel
{
  [Serializable]
  public class ViewModelBase : INotifyPropertyChanged
  {
    #region INotifyPropertyChanged Implementation

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName)
    {
      if (null != PropertyChanged)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
      }
    }

    #endregion
  }
}