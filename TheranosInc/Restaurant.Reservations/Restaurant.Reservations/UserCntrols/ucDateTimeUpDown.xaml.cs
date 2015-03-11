﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Restaurant.Reservations.ViewModel;

namespace Restaurant.Reservations.UserControls
{
  /// <summary>
  /// Interaction logic for ucDateTimeUpDown.xaml
  /// </summary>
  public partial class ucDateTimeUpDown : UserControl, INotifyPropertyChanged
  {
    private DateTime _currentTime = DateTime.UtcNow;
    private bool _adHours;
    private bool _addMinutes;
    private ObservableCollection<string> _amPmTypes = new ObservableCollection<string>();
    private string _displayAmPm;


    public ucDateTimeUpDown()
    {
      InitializeComponent();
      this.DataContext = this;
      AmPmTypes.Add("AM");
      AmPmTypes.Add("PM");
      CurrentTime = DateTime.UtcNow.ToLocalTime();
    }

    public ObservableCollection<string> AmPmTypes
    {
      get { return _amPmTypes; }
      set { _amPmTypes = value; }
    }

    public string DisplayTime
    {
      get { return _currentTime.ToLocalTime().ToString("t"); }
    }


    public string DisplayAmPm
    {
      get
      {
        if (_currentTime.ToLocalTime().Hour >= 0 && _currentTime.ToLocalTime().Hour < 12)
          _displayAmPm = AmPmTypes.FirstOrDefault(s => s.Equals("AM"));
        else
        {
          if (_currentTime.ToLocalTime().Hour >= 12)
          {
            _displayAmPm = AmPmTypes.FirstOrDefault(s => s.Equals("PM"));
          }
        }

        return _displayAmPm;
      }
      set
      {
        if (!value.Equals(_displayAmPm))
        {
          if (value.Equals("PM"))
            CurrentTime = CurrentTime.ToLocalTime().AddHours(12);
          else
          {
            CurrentTime = CurrentTime.ToLocalTime().AddHours(-12);
          }
        }
        _displayAmPm = value;
      }
    }

    public string DisplayTimeHours
    {
      get
      {
        var hours = _currentTime.ToLocalTime().Hour;
        return hours > 12 ? (hours - 12).ToString("00") : hours.ToString("00");
        //return hours.ToString();
      }
      set
      {
        var hour = 0;
        Int32.TryParse(value, out hour);
        CurrentTime = CurrentTime.ToLocalTime().AddHours(hour);
        OnPropertyChanged("DisplayTime");
        OnPropertyChanged("DisplayTimeHours");
        OnPropertyChanged("DisplayTimeMinutes");
      }
    }

    public string DisplayTimeMinutes
    {
      get { return _currentTime.ToLocalTime().Minute.ToString("00"); }
      set
      {
        var minutes = 0;
        Int32.TryParse(value, out minutes);
        CurrentTime = CurrentTime.ToLocalTime().AddMinutes(minutes);
        OnPropertyChanged("DisplayTime");
        OnPropertyChanged("DisplayTimeHours");
        OnPropertyChanged("DisplayTimeMinutes");
      }
    }

    public DateTime CurrentTime
    {
      get { return _currentTime; }
      set
      {
        _currentTime = value;

        OnPropertyChanged("CurrentTime");
        OnPropertyChanged("DisplayTime");
        OnPropertyChanged("DisplayTimeHours");
        OnPropertyChanged("DisplayTimeMinutes");
        OnPropertyChanged("DisplayAmPm");
      }
    }


    private void MinutesUpButton_OnClick(object sender, RoutedEventArgs e)
    {
      CurrentTime = CurrentTime.AddMinutes(1);
    }

    private void MinutesDownButton_OnClick(object sender, RoutedEventArgs e)
    {
      CurrentTime = CurrentTime.AddMinutes(-1);
    }

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

    private void HourUpButton_OnClick(object sender, RoutedEventArgs e)
    {
      CurrentTime = CurrentTime.AddHours(1);
    }

    private void HourDownButton_OnClick(object sender, RoutedEventArgs e)
    {
      CurrentTime = CurrentTime.AddHours(-1);
    }
  }
}