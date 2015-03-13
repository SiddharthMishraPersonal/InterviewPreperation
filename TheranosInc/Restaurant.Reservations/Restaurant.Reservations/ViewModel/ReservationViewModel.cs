using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;
using Restaurant.Reservations.Helper;
using Restaurant.Reservations.View;

namespace Restaurant.Reservations.ViewModel
{
  public class ReservationViewModel : ViewModelBase
  {
    #region Private Member Variables

    private ObservableCollection<TableViewModel> _tablesAvaialble;
    private TableViewModel _selectedTable;
    private string _customerName;
    private string _contactNumber;
    private int _maximumOccupantsForTable;
    private int _occupants;
    private DateTime _selectedDate;
    private DateTime _startDate;
    private DateTime _endDate;
    private DateTime _checkInDate;
    private DateTime _checkInTime;
    private readonly int _monthRange;
    private NewReservation _view;
    private bool _isSaved;

    #endregion

    #region Properties

    public ObservableCollection<TableViewModel> TablesAvaialble
    {
      get { return _tablesAvaialble; }
      set
      {
        _tablesAvaialble = value;
        OnPropertyChanged("TablesAvaialble");
      }
    }

    public string CustomerName
    {
      get { return _customerName; }
      set
      {
        _customerName = value;
        OnPropertyChanged("CustomerName");
      }
    }

    public string ContactNumber
    {
      get { return _contactNumber; }
      set
      {
        _contactNumber = value;
        OnPropertyChanged("ContactNumber");
      }
    }

    public TableViewModel SelectedTable
    {
      get { return _selectedTable; }
      set
      {
        _selectedTable = value;
        OnPropertyChanged("SelectedTable");
      }
    }

    public int MaximumOccupantsForTable
    {
      get { return _maximumOccupantsForTable; }
      set
      {
        _maximumOccupantsForTable = value;
        OnPropertyChanged("MaximumOccupantsForTable");
      }
    }

    public int Occupants
    {
      get { return _occupants; }
      set
      {
        _occupants = value;
        OnPropertyChanged("Occupants");
      }
    }

    public DateTime CheckInDate
    {
      get { return _checkInDate; }
      set
      {
        _checkInDate = value;
        OnPropertyChanged("CheckInDate");
      }
    }

    public DateTime CheckInTime
    {
      get { return _checkInTime; }
      set
      {
        _checkInTime = value;

        OnPropertyChanged("CheckInTime");
      }
    }


    public DateTime SelectedDate
    {
      get { return _selectedDate.ToLocalTime(); }
      set
      {
        _selectedDate = value.ToUniversalTime();
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

    public ReservationViewModel(Func<NewReservation> view)
    {
      //Every time when this view model class will get instantiated we will get new View object.
      _view = view();

      if (_view == null)
      {
        return;
      }

      _monthRange = 12;
      StartDate = DateTime.UtcNow;
    }

    #endregion

    #region Commands

    #region Save Command

    private ICommand _saveCommand;

    public ICommand SaveCommand
    {
      get { return _saveCommand ?? new RelayCommands(SaveCommand_Execute, SaveCommand_CanExecute); }
    }

    private void SaveCommand_Execute(object param)
    {
      CheckInDate = SelectedDate;
      //Check whether reservation is between 10AM to 10PM.
      var currentTime = DateTime.Now.TimeOfDay + new TimeSpan(12, 0, 0);
      var openTime = DateTime.Parse("10:00 AM").TimeOfDay;
      var closeTime = DateTime.Parse("10:00 PM").TimeOfDay;

      if (currentTime >= openTime && currentTime <= closeTime)
      {
        Console.WriteLine("We are open");
      }
      else
      {
        Console.WriteLine("We are closed");
      }

      //Can select multiple tables
      //

      _isSaved = true;
      _view.Close();
    }

    private bool SaveCommand_CanExecute(object param)
    {
      return true;
    }

    #endregion

    #region Cancel Command

    private ICommand _cancelCommand;

    public ICommand CancelCommand
    {
      get { return _cancelCommand ?? new RelayCommands(CancelCommand_Execute, CancelCommand_CanExecute); }
    }

    private void CancelCommand_Execute(object param)
    {
      _isSaved = false;
      _view.Close();
    }

    private bool CancelCommand_CanExecute(object param)
    {
      return true;
    }

    #endregion

    #endregion

    #region Public Methods

    public bool ShowWindow()
    {
      return _isSaved;
    }

    #endregion

    #region Private Methods

    #endregion
  }
}