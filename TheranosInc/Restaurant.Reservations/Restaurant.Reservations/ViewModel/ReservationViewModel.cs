using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Restaurant.Reservations.Helper;
using Restaurant.Reservations.View;

namespace Restaurant.Reservations.ViewModel
{
  public class ReservationViewModel : ViewModelBase
  {
    #region Private Member Variables

    private Guid _tableGuid;
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
    private bool _isSelected;

    #endregion

    #region Properties

    public Guid TableGuid
    {
      get { return _tableGuid; }
      set
      {
        _tableGuid = value;

        OnPropertyChanged("TableGuid");
      }
    }

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


    public bool IsSelected
    {
      get { return _isSelected; }
      set
      {
        _isSelected = value;
        OnPropertyChanged("IsSelected");
      }
    }

    #endregion

    #region Constructors

    public ReservationViewModel(Func<NewReservation> view)
    {
      //Every time when this view model class will get instantiated we will get new View object.
      _view = view();
      _view.DataContext = this;

      this.SelectedDate = DateTime.UtcNow;

      if (_view == null)
      {
        return;
      }

      _monthRange = 12;
      StartDate = DateTime.UtcNow;
      TableGuid = Guid.NewGuid();
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

      var areWeOpen = currentTime >= openTime && currentTime <= closeTime;

      if (!areWeOpen)
      {
        _view.ShowMessageAsync("New Reservation",
          "We are closed.\r\nWe are open between 10 A.M. to 10 P.M.\r\n\nPlease try later.");
        return;
      }

      //Can select multiple tables
      //

      var resultTask = _view.ShowMessageAsync("Save Reservation", "Do you want to save this reservation?",
        MessageDialogStyle.AffirmativeAndNegative,
        new MetroDialogSettings() {AffirmativeButtonText = "Yes", NegativeButtonText = "No"});

      resultTask.ContinueWith(s =>
      {
        if (s.Result != MessageDialogResult.Affirmative)
        {
          _isSaved = false;
          return;
        }
        _isSaved = true;
      }, TaskScheduler.FromCurrentSynchronizationContext());
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
      var resultTask = _view.ShowMessageAsync("Save & Close", "Do you want to save this reservation?",
        MessageDialogStyle.AffirmativeAndNegative,
        new MetroDialogSettings() {AffirmativeButtonText = "Yes", NegativeButtonText = "No"});

      resultTask.ContinueWith(s =>
      {
        _isSaved = s.Result == MessageDialogResult.Affirmative;
        _view.Close();
      }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    private bool CancelCommand_CanExecute(object param)
    {
      return true;
    }

    #endregion

    #endregion

    #region Public Methods

    public bool ShowWindow(Window ownerWindow)
    {
      _view.Owner = ownerWindow;
      _view.Show();
      return _isSaved;
    }

    #endregion

    #region Private Methods

    #endregion
  }
}