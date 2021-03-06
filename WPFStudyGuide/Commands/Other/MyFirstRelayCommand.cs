﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFStudyGuide.Commands.Other
{
    public class MyFirstRelayCommand: ICommand
    {

        #region fields
        #endregion fields


        #region properties

        Action _TargetMethodToExecute;
        Func<bool> _TargetCanExecuteMethod;

        // Beware - should use weak references if command instance lifetime is longer than lifetime of UI objects that get hooked up to command
        // Prism commands solve this in their implementation
        public event EventHandler CanExecuteChanged = delegate { };

        #endregion properties


        #region constructors

        public MyFirstRelayCommand(Action methodToExecute)
        {
            _TargetMethodToExecute = methodToExecute;
        }

        public MyFirstRelayCommand(Action methodToExecute, Func<bool> canExecuteMethod)
        {
            _TargetMethodToExecute = methodToExecute;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #region ICommand Members

        bool ICommand.CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }
            if (_TargetMethodToExecute != null)
            {
                return true;
            }
            return false;
        }


        void ICommand.Execute(object parameter)
        {
            if (_TargetMethodToExecute != null)
            {
                _TargetMethodToExecute();
            }
        }
        #endregion

        #endregion constructors


        #region public methods

        #endregion public methods


        #region private methods
        #endregion private methods
    }

    public class MyFirstRelayCommand<T> : ICommand
    {
        Action<T> _TargetExecuteMethodDelegate;
        Func<T, bool> _TargetCanExecuteMethodDelegate;
        public event EventHandler CanExecuteChanged = delegate { };

        public MyFirstRelayCommand(Action<T> methodToExecute)
        {
            _TargetExecuteMethodDelegate = methodToExecute;
        }

        public MyFirstRelayCommand(Action<T> methodToExecute, Func<T, bool> canExecuteMethod)
        {
            _TargetExecuteMethodDelegate = methodToExecute;
            _TargetCanExecuteMethodDelegate = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #region ICommand Members

        bool ICommand.CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethodDelegate != null)
            {
                T tparm = (T)parameter;
                return _TargetCanExecuteMethodDelegate(tparm);
            }
            if (_TargetExecuteMethodDelegate != null)
            {
                return true;
            }
            return false;
        }

        void ICommand.Execute(object parameter)
        {
            if (_TargetExecuteMethodDelegate != null)
            {
                _TargetExecuteMethodDelegate((T)parameter);
            }
        }

        #endregion ICommand Members
    }
}
