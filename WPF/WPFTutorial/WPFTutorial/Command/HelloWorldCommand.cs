using System;
using System.Windows;
using System.Windows.Input;

namespace WPFTutorial.Command
{

  public class HelloWorldCommand : ICommand
  {
    #region ICommand Members

    public void Execute(object parameter)
    {
      MessageBox.Show(parameter.ToString(), "Hello World Command", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    public bool CanExecute(object parameter)
    {
      return true;
    }
    public event EventHandler CanExecuteChanged;

    #endregion
  }
}

