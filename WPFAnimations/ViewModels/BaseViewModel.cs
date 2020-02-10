using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFAnimations.ViewModels
{
    public abstract class BaseViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region Fields
        private bool _applicationIsBusy = false;
        private Visibility _spinnerVisibility = Visibility.Hidden;
        #endregion Fields


        #region Properties


        public Visibility SpinnerVisibility
        {
            get
            {
                return _spinnerVisibility;
            }
            set
            {
                _spinnerVisibility = value;
                OnPropertyChanged(nameof(SpinnerVisibility));
            }
        }

        public bool ApplicationIsBusy
        {
            get
            {
                return _applicationIsBusy;
            }
            set
            {
                _applicationIsBusy = value;
                OnPropertyChanged(nameof(ApplicationIsBusy));

                if (value)
                {
                    SpinnerVisibility = Visibility.Visible;
                }
                else
                {
                    SpinnerVisibility = Visibility.Hidden;
                }
            }
        }

        #endregion Properties


        #region Constructors

        public BaseViewModel()
        {
        }

        #endregion Constructors


        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion Events


        #region Public Methods

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        protected void RunBackgroundTask(Action action, bool activateSpinner = false, string spinnerMessage = "")
        {
            // https://www.codeproject.com/Articles/20627/BackgroundWorker-Threads-and-Supporting-Cancel
            // https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.backgroundworker?view=netframework-4.8 // reporting progress, and cancelling

            using (var backgroundWorker = new BackgroundWorker())
            {
                backgroundWorker.DoWork += (s, e) =>
                {
                    action();
                };

                backgroundWorker.RunWorkerCompleted += (s, e) =>
                {
                    if (activateSpinner)
                    {
                        //Messenger.Default.Send(new BusyMessage(false));
                    }
                };

                if (activateSpinner)
                {
                    //Messenger.Default.Send(new BusyMessage(true, spinnerMessage));
                }

                backgroundWorker.RunWorkerAsync();
            }
        }

        #endregion Public Methods


        #region Private Methods
        #endregion Private Methods
    }
}
