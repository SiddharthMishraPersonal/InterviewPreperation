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

    private Guid _tableGuid;
    private int _tableNumber;
    private int _maxOccupancy;

    #endregion

    #region Properties

    public int TableNumber
    {
      get { return _tableNumber; }
      set
      {
        _tableNumber = value;
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

    public Guid TableGuid
    {
      get { return _tableGuid; }
      set
      {
        _tableGuid = value;
        OnPropertyChanged("TableGuid");
      }
    }

    #endregion

    #region Constructors

    public TableViewModel()
    {
    }

    public void Initialize(int tableNumber, int maxOccupancy)
    {
      TableNumber = tableNumber;
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