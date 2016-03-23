using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CountingApplication.CommandHelper
{
    public class RelayCommands : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object> execute;
        private Predicate<object> canExecute;

        public RelayCommands(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("Execute");
            }

            if (canExecute == null)
            {
                throw new ArgumentNullException("CanExecute");
            }

            this.execute = execute;
            this.canExecute = canExecute;

        }

        public RelayCommands(Action<object> execute) : this(execute, DefaultCanExecute)
        {

        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }

        public void OnCanExecuteChanged()
        {
            var handler = this.CanExecuteChanged;

            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        public void Destroy()
        {
            this.execute = _ => { return; };
            this.canExecute = _ => false;
        }


        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }
    }
}
