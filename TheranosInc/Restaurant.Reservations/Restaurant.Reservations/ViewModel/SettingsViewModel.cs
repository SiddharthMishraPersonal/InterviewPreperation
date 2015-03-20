using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Reservations.View;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using Restaurant.Reservations.Helper;
using Restaurant.Reservations.Shared.Log;

namespace Restaurant.Reservations.ViewModel
{
  public class SettingsViewModel : ViewModelBase
  {
    #region Private Member Variables

    private string _tableFilePath;
    private string _reservationFileName;
    private string _reservationFileLocation;
    private readonly Func<SettingsView> _viewFunc;
    private SettingsView _view;

    #endregion

    #region Properties

    public string TableFilePath
    {
      get { return _tableFilePath; }
      set
      {
        _tableFilePath = value;
        OnPropertyChanged("TableFilePath");
      }
    }

    public string ReservationFileName
    {
      get { return _reservationFileName; }
      set
      {
        _reservationFileName = value;
        OnPropertyChanged("ReservationFileName");
        OnPropertyChanged("ReservationFileFullpath");
      }
    }

    public string ReservationFileLocation
    {
      get { return _reservationFileLocation; }
      set
      {
        _reservationFileLocation = value;
        OnPropertyChanged("ReservationFileLocation");
        OnPropertyChanged("ReservationFileFullpath");
      }
    }

    public string ReservationFileFullpath
    {
      get { return Path.Combine(ReservationFileLocation, ReservationFileName); }
    }

    #endregion

    #region Constructors

    public SettingsViewModel(Func<SettingsView> viewFunc)
    {
      this._viewFunc = viewFunc;
      this._view = _viewFunc();
      this._view.DataContext = this;
      this.ReservationFileName = "Reservations.xml";
      this.ReservationFileLocation =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Reservations");
      this.TableFilePath =
        Path.Combine(
          Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Reservations"),
          "Tables.xml");
    }

    #endregion

    #region Commands

    #region Browse Reservation Folder

    private ICommand _browseOutputFolder;

    public ICommand BrowseOutputFolder
    {
      get
      {
        _browseOutputFolder = _browseOutputFolder ??
                              new RelayCommands(BrowseOutputFolder_Execute, BrowseOutputFolder_CanExecute);
        return _browseOutputFolder;
      }
    }

    private void BrowseOutputFolder_Execute(object param)
    {
      var folderDialog = new FolderBrowserDialog();
      folderDialog.Description = "Select folder path for reservation xml file.";
      folderDialog.RootFolder = Environment.SpecialFolder.CommonApplicationData;
      var result = folderDialog.ShowDialog();
      while (DialogResult.OK != result && DialogResult.Cancel != result)
      {
        folderDialog.Reset();
        result = folderDialog.ShowDialog();
      }

      if (result == DialogResult.OK)
        this.ReservationFileLocation = folderDialog.SelectedPath;
    }

    private bool BrowseOutputFolder_CanExecute(object param)
    {
      return true;
    }

    #endregion

    #region Browse Table File Path

    private ICommand _browseTableXmlFilePath;

    public ICommand BrowseTableXmlFilePath
    {
      get
      {
        _browseTableXmlFilePath = _browseTableXmlFilePath ??
                                  new RelayCommands(BrowseTableXmlFilePath_Execute, BrowseTableXmlFilePath_CanExecute);
        return _browseTableXmlFilePath;
      }
    }

    private void BrowseTableXmlFilePath_Execute(object param)
    {
      try
      {
        var openFileDialog = new System.Windows.Forms.OpenFileDialog();
        openFileDialog.InitialDirectory =
          Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Reservations");
        openFileDialog.DefaultExt = "xml";
        openFileDialog.CheckFileExists = true;
        openFileDialog.Multiselect = false;
        openFileDialog.Filter = "XML files (*.xml)|*.xml";
        openFileDialog.ShowDialog();

        TableFilePath = openFileDialog.FileName;
      }
      catch (Exception exception)
      {
        NLogger.LogError(exception);
      }
    }

    private bool BrowseTableXmlFilePath_CanExecute(object param)
    {
      return true;
    }

    #endregion

    #region Save Command

    private ICommand _saveSettingsCommand;

    public ICommand SaveSettingsCommand
    {
      get
      {
        _saveSettingsCommand = _saveSettingsCommand ??
                               new RelayCommands(SaveSettingsCommand_Execute, SaveSettingsCommand_CanExecute);
        return _saveSettingsCommand;
      }
    }

    private void SaveSettingsCommand_Execute(object param)
    {
      try
      {
        var resultTask = _view.ShowMessageAsync("Save & Close",
          "Settings are saved.\r\nDo you want to close the window?",
          MessageDialogStyle.AffirmativeAndNegative,
          new MetroDialogSettings() {AffirmativeButtonText = "Yes", NegativeButtonText = "No"});

        resultTask.ContinueWith(s =>
        {
          if (s.Result == MessageDialogResult.Affirmative)
          {
            _view.Close();
            _view.DataContext = null;
          }
        }, TaskScheduler.FromCurrentSynchronizationContext());
      }
      catch (Exception exception)
      {
        NLogger.LogError(exception);
      }
    }

    private bool SaveSettingsCommand_CanExecute(object param)
    {
      if (string.IsNullOrEmpty(TableFilePath) || string.IsNullOrEmpty(ReservationFileName) ||
          string.IsNullOrEmpty(ReservationFileLocation))
        return false;

      return true;
    }

    #endregion

    #endregion

    #region Public Methods

    public void ShowWindow(MetroWindow ownerWindow)
    {
      this._view = _viewFunc();
      this._view.DataContext = this;
      _view.Owner = ownerWindow;
      _view.ShowDialog();
    }
  }

  #endregion

  #region Private Methods

  #endregion
}