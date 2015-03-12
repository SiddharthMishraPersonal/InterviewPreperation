using Restaurant.Reservations.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

    public ApplicationViewModel(MainWindow view)
    {
      _view = view;
      _monthRange = 12;
      StartDate = DateTime.UtcNow;
    }

    #endregion

    #region Commands

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
    }

    private bool CreateNewReservationCommand_CanExecute(object param)
    {
      return true;
    }

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