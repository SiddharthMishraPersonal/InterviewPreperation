using Restaurant.Reservations.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;
using Restaurant.Reservations.View;

namespace Restaurant.Reservations.ViewModel
{
  internal class ApplicationViewModel : ViewModelBase
  {
    #region Private Member Variables

    private readonly int _monthRange;
    private DateTime _selectedDate;
    private DateTime _startDate;
    private DateTime _endDate;
    private MainWindow _view;
    private Func<NewReservation> _newReservation;
    private Func<ReservationViewModel> _reservationViewModel;
    private Func<TableViewModel> _tableViewModel;


    private ObservableCollection<ReservationViewModel> _currentReservations =
      new ObservableCollection<ReservationViewModel>();

    #endregion

    #region Properties

    public ObservableCollection<ReservationViewModel> CurrentReservations
    {
      get { return _currentReservations; }
      set { _currentReservations = value; }
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

    public ApplicationViewModel(MainWindow view,
      Func<ReservationViewModel> reservationViewModel, Func<TableViewModel> tableViewModel)
    {
      _view = view;
      _reservationViewModel = reservationViewModel;
      _tableViewModel = tableViewModel;
      _monthRange = 12;
      StartDate = DateTime.UtcNow;
    }

    #endregion

    #region Commands

    #region New Reservation Command

    private ICommand _createNewReservationCommand;

    public ICommand CreateNewReservationCommand
    {
      get
      {
        return _createNewReservationCommand ??
               new RelayCommands(CreateNewReservationCommand_Execute, CreateNewReservationCommand_CanExecute);
      }
    }

    private void CreateNewReservationCommand_Execute(object param)
    {
      var currentTime = DateTime.Now.TimeOfDay;
      var openTime = DateTime.Parse("10:00 AM").TimeOfDay;
      var closeTime = DateTime.Parse("10:00 PM").TimeOfDay;

      if (currentTime >= openTime && currentTime <= closeTime)
      {
        var newReservationVm = _reservationViewModel();
        var isSaved = newReservationVm.ShowWindow(this._view);
        if (!isSaved)
          return;

        CurrentReservations.Add(newReservationVm);
      }
      else
      {
        _view.ShowMessageAsync("New Reservation",
          "We are closed.\r\nWe are open between 10 A.M. to 10 P.M.\r\n\nPlease try later.");
      }
    }

    private bool CreateNewReservationCommand_CanExecute(object param)
    {
      return true;
    }

    #endregion

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