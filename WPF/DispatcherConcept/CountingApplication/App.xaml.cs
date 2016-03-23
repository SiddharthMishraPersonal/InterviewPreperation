using CountingApplication.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CountingApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var countingAppVm = new CountingApplicationViewModel();
            var mainAppView = new MainWindow();
            mainAppView.DataContext = countingAppVm;

            mainAppView.Show();

            base.OnStartup(e);
        }
    }
}
