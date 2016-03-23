using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CountingApplication.ViewModel
{
    class CountingApplicationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _countingResult;

        private ICommand _start;
        private ICommand _stop;
        private ICommand _clear;


        public int CountingResult
        {
            get
            {
                return _countingResult;
            }

            set
            {
                _countingResult = value;
                this.OnPropertyChanged("CountingResult");
            }
        }

        public ICommand Start
        {
            get
            {
                return _start;
            }

            set
            {
                _start = value;
            }
        }

        public ICommand Stop
        {
            get
            {
                return _stop;
            }

            set
            {
                _stop = value;
            }
        }

        public ICommand Clear
        {
            get
            {
                return _clear;
            }

            set
            {
                _clear = value;
            }
        }

        public CountingApplicationViewModel()
        {
            this.Start = new RoutedUICommand();     
        }

        public void StartCommandExecuted()
        {

        }

        public bool StartCommandCanExecute()
        {
            return true;
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
