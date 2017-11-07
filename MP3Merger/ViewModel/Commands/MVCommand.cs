using System;
using System.Windows.Input;

namespace MP3Merger2.ViewModel.Commands
{
    /// <summary>
    /// Implementation of the command pattern to bind commands 
    /// from the UI to the ViewModel.
    /// </summary>
    class MVCommand : ICommand
    {
        private Action _TargetExecuteMethod;
        private Func<bool> _TargetCanExecuteMethod;


        /// <summary>
        /// Execute a method binded to a UI control.
        /// </summary>
        /// <param name="executeMethod"></param>
        public MVCommand(Action executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        /// <summary>
        /// Execute a method binded to an UI control if
        /// can be executed.
        /// </summary>
        /// <param name="executeMethod"></param>
        /// <param name="canExecuteMethod"></param>
        public MVCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }


        bool ICommand.CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }

            if (_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        void ICommand.Execute(object parameter)
        {
            _TargetExecuteMethod?.Invoke();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

    }
}
