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
using System.Windows;

namespace Restaurant.Reservations.ViewModel
{
  public class ApplicationViewModel : ViewModelBase
  {
    #region Private Member Variables

    private readonly int _monthRange;
    private DateTime _selectedDate;
    private DateTime _startDate;
    private DateTime _endDate;
    private MainWindow _view;
    private Func<ReservationViewModel> _reservationViewModel;
    private Func<TableViewModel> _tableViewModel;


    private ObservableCollection<ReservationViewModel> _reservations =
      new ObservableCollection<ReservationViewModel>();

    private ObservableCollection<ReservationViewModel> _todayReservations =
      new ObservableCollection<ReservationViewModel>();

    #endregion

    #region Properties

    public ObservableCollection<ReservationViewModel> Reservations
    {
      get { return _reservations; }
      set { _reservations = value; }
    }

    public ObservableCollection<ReservationViewModel> TodayReservations
    {
      get { return _todayReservations; }
      set { _todayReservations = value; }
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
        _createNewReservationCommand = _createNewReservationCommand ??
                                       new RelayCommands(CreateNewReservationCommand_Execute,
                                         CreateNewReservationCommand_CanExecute);
        return _createNewReservationCommand;
      }
    }

    private void CreateNewReservationCommand_Execute(object param)
    {
      var currentTime = DateTime.Now.TimeOfDay;
      var openTime = DateTime.Parse("10:00 AM").TimeOfDay;
      var closeTime = DateTime.Parse("10:00 PM").TimeOfDay;

      var areWeOpen = currentTime >= openTime && currentTime <= closeTime;

      if (!areWeOpen)
      {
        var resultTask = _view.ShowMessageAsync("Closed!!",
          "We are closed for the day.\r\nWe are open between 10 A.M. to 10 P.M.\r\n\nDo you still want to continue?",
          MessageDialogStyle.AffirmativeAndNegative,
          new MetroDialogSettings() {AffirmativeButtonText = "Yes", NegativeButtonText = "No"});
        resultTask.ContinueWith(s =>
        {
          if (s.Result != MessageDialogResult.Affirmative)
            return;
          else
          {
            var newReservationVm = _reservationViewModel();
            newReservationVm.ShowWindow(this._view);
          }
        }, TaskScheduler.FromCurrentSynchronizationContext());
      }
      else
      {
        var newReservationVm = _reservationViewModel();
        newReservationVm.ShowWindow(this._view);
      }
    }

    private bool CreateNewReservationCommand_CanExecute(object param)
    {
      return true;
    }

    #region Helper Methods

    private void AddReservationToCollection(ReservationViewModel newReservationVm)
    {
      Reservations.Add(newReservationVm);
      GetTodayReservation();
    }

    private void GetTodayReservation()
    {
      var todayReservation =
        Reservations.Where(s => s.CheckInDate.ToLocalTime().Date.Equals(DateTime.UtcNow.ToLocalTime().Date));
      var newlyAdded = todayReservation.Where(t => !TodayReservations.Any(s => s.TableGuid.Equals(t.TableGuid)));
      foreach (var newReservation in newlyAdded)
      {
        TodayReservations.Add(newReservation);
      }
    }

    #endregion

    #endregion

    #region Settings Command

    private ICommand _settingsCommand;

    public ICommand SettingsCommand
    {
      get
      {
        _settingsCommand = _settingsCommand ?? new RelayCommands(SettingsCommand_Execute, SettingsCommand_CanExecute);
        return _settingsCommand;
      }
    }

    private void SettingsCommand_Execute(object param)
    {
    }

    private bool SettingsCommand_CanExecute(object param)
    {
      return true;
    }

    #endregion

    #region Close Application Command

    private ICommand _closeApplicationCommand;

    public ICommand CloseApplicationCommand
    {
      get
      {
        _closeApplicationCommand = _closeApplicationCommand ??
                                   new RelayCommands(CloseApplicationCommand_Execute, CloseApplicationCommand_CanExecute);
        return _closeApplicationCommand;
      }
    }

    private void CloseApplicationCommand_Execute(object param)
    {
      var resultTask = _view.ShowMessageAsync("Reservation System", "Do you want to close application?",
        MessageDialogStyle.AffirmativeAndNegative,
        new MetroDialogSettings() {AffirmativeButtonText = "Yes", NegativeButtonText = "No"});

      resultTask.ContinueWith(t =>
      {
        if (t.Result != MessageDialogResult.Affirmative)
          return;

        _view.Close();
      }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    private bool CloseApplicationCommand_CanExecute(object param)
    {
      return true;
    }

    #endregion

    #endregion

    #region Public Methods

    public void AddReservation(ReservationViewModel reservationViewModel)
    {
      this.AddReservationToCollection(reservationViewModel);
    }

    #endregion

    #region Private Methods

    private void LoadTableDetails(string xmlFilePath)
    {
      var tableList = XmlOperations.DeSerialize(xmlFilePath);
    }

    #endregion
  }
}