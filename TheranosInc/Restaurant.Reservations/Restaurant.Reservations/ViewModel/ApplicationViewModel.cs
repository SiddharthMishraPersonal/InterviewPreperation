using Restaurant.Reservations.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Reservations.ViewModel
{
  internal class ApplicationViewModel : ViewModelBase
  {
    #region Private Member Variables

    private readonly int _monthRange;
    private DateTime _selectedDate;
    private DateTime _startDate;
    private DateTime _endDate;

    #endregion

    #region Properties

    public DateTime SelectedDate
    {
      get { return _selectedDate.ToLocalTime(); }
      set
      {
        _selectedDate = value;
        OnPropertyChanged("SelectedDate");
      }
    }

    public DateTime StartDate
    {
      get { return _startDate.ToLocalTime(); }
      set
      {
        _startDate = value;
        OnPropertyChanged("StartDate");
        EndDate = _startDate.AddMonths(_monthRange);
      }
    }

    public DateTime EndDate
    {
      get { return _endDate.ToLocalTime(); }
      set
      {
        _endDate = value;
        OnPropertyChanged("EndDate");
      }
    }

    #endregion

    #region Constructors

    public ApplicationViewModel()
    {
      _monthRange = 12;
      StartDate = DateTime.UtcNow;
    }

    #endregion

    #region Commands

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    private void LoadTableDetails(string xmlFilePath)
    {
      var tableList = XmlOperations.DeSerialize(xmlFilePath);
    }

    #endregion
  }
}