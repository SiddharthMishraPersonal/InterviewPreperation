using Restaurant.Reservations.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Autofac;
using Restaurant.Reservations.AutoFac;
using Restaurant.Reservations.Helper;
using Restaurant.Reservations.View;

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
    private static IContainer _container;
    private static Mutex _applicationMutex = null;

    #endregion

    protected override void OnStartup(StartupEventArgs e)
    {
      try
      {
        base.OnStartup(e);

        if (IsMutexBound())
          Environment.Exit(1);

        var builder = new ContainerBuilder();
        builder.RegisterModule<ApplicationRegisteration>();

        _container = builder.Build();
        _appViewModel = _container.Resolve<ApplicationViewModel>();
        _view = _container.Resolve<MainWindow>();
        _view.DataContext = _appViewModel;

        _view.Show();
      }
      catch (Exception exception)
      {
        throw;
      }
    }

    private bool IsMutexBound()
    {
      try
      {
        Mutex.OpenExisting(Constants.MutexName);
      }
      catch (WaitHandleCannotBeOpenedException)
      {
        var _applicationMutex = new Mutex(true, Constants.MutexName);
        return false;
      }
      catch (Exception)
      {
      }
      return true;
    }
  }
}