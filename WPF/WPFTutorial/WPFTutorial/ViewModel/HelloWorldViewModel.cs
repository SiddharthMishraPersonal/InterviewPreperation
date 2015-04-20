using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFTutorial.ViewModel
{
  class HelloWorldViewModel : INotifyPropertyChanged
  {

    private ICommand _helloWorldCommand;


    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand HelloWorldCommand
    {
      get
      {
        if (_helloWorldCommand == null)
          _helloWorldCommand = new DelegateCommand(this.HelloWorldCommand_Execute, this.HelloWorldCommand_CanExecute);

        return _helloWorldCommand;
      }

    }

    private void HelloWorldCommand_Execute(object parameter)
    {
      MessageBox.Show("Hello World from ViewModel Command Handler.", "Command", MessageBoxButton.OK,
        MessageBoxImage.Information);
    }

    private bool HelloWorldCommand_CanExecute(object parameter)
    {
      return true;
    }

    private void OnPropertyChanged(string property)
    {
      var handler = PropertyChanged;

      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs(property));
      }
    }

    #endregion
  }
}
