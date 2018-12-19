using System;
using System.Windows.Input;

namespace MVVMApplication.Infra
{
    /// <summary>
    /// This class is used to generate commands 
    /// This class implementing the ICommand interface
    /// The purpose is to separate the semantics and the object that invokes a command from the logic that executes the command
    /// The purpose of commands is to indicate whether an action is available
    /// </summary>
    public sealed class RelayCommand : ICommand
    {
        #region Memebers
        private Action localAction;
        private bool localCanExecute;
        public event EventHandler CanExecuteChanged;
        #endregion

        #region Constructor
        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="action">Actions to be executed</param>
        /// <param name="canExecute">Boolean parameter. If is true action can be executed. If is false action cannot be executed</param>
        public RelayCommand(Action action, bool canExecute)
        {
            localAction = action;
            localCanExecute = canExecute;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Is raised if the command manager that centralizes the commanding operations detects a change in the command source 
        /// that might invalidate a command that has been raised but not yet executed by the command binding
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Determines whether the command can execute on the current command target
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return localCanExecute;
        }

        /// <summary>
        /// Performs the actions that are associated with the command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            localAction();
        }
        #endregion
    }
}
