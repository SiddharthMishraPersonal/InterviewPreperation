using System;
using System.Windows.Input;

namespace WPFTutorial.ViewModel
{
  public class DelegateCommand : ICommand
  {
    //An action delegate
    private Action<object> _executeAction = null;

    //A condition predicate
    private Predicate<object> _canExecutePredicate = null;

    /// <summary>
    /// Creates an instance for DelegateCommand.
    /// </summary>
    /// <param name="executeAction">Execute action delegate.</param>
    public DelegateCommand(Action<object> executeAction)
      : this(executeAction, null)
    {
      _executeAction = executeAction;
    }

    /// <summary>
    /// Creates an instance for DelegateCommand
    /// </summary>
    /// <param name="executeAction">Execute action delegate.</param>
    /// <param name="canExecuteAction">CanExecute predicate condition.</param>
    public DelegateCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
    {
      _executeAction = executeAction;
      _canExecutePredicate = canExecuteAction;
    }

    #region ICommand Members

    public bool CanExecute(object parameter)
    {
      return _canExecutePredicate == null || _canExecutePredicate(parameter);
    }

    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public void Execute(object parameter)
    {
      _executeAction(parameter);
    }

    #endregion
  }
}
