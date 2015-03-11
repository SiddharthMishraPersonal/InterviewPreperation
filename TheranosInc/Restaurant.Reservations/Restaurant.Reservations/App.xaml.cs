using Restaurant.Reservations.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Restaurant.Reservations
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    #region Private Member Variables

    private MainWindow _view = null;
    private ApplicationViewModel _appViewModel = null;

    #endregion

    protected override void OnStartup(StartupEventArgs e)
    {
      base.OnStartup(e);
    }
  }
}