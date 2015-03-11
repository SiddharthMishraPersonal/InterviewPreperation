using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Reservations.ViewModel
{
  public class TableViewModel : ViewModelBase
  {
    #region Private Member Variables

    private int _id;
    private int _maxOccupancy;

    #endregion

    #region Properties

    public int Id
    {
      get { return _id; }
      set
      {
        _id = value;
        OnPropertyChanged("Id");
      }
    }

    public int MaxOccupancy
    {
      get { return _maxOccupancy; }
      set
      {
        _maxOccupancy = value;
        OnPropertyChanged("MaxOccupancy");
      }
    }

    #endregion

    #region Constructors

    public TableViewModel(int id, int maxOccupancy)
    {
      Id = id;
      MaxOccupancy = maxOccupancy;
    }

    #endregion

    #region Commands

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
  }
}