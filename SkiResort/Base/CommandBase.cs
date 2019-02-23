using System;
using System.Diagnostics;
using System.Windows.Input;

namespace SkiResort.Base
{
    /// <summary>
    /// A command whose sole purpose is to
    /// relay its functionality to other
    /// objects by invoking delegates. The
    /// default return value for the CanExecute
    /// method is 'true'.
    /// </summary>
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class CommandBase : ICommand
    {
        #region Constructor

        /// <summary>
        /// Creates a new command that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public CommandBase(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        /// <exception cref="System.ArgumentNullException">execute</exception>
        public CommandBase(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion Constructor

        #region Variables

        /// <summary>
        /// The _execute
        /// </summary>
        private readonly Action<object> _execute;

        /// <summary>
        /// The _can execute
        /// </summary>
        private readonly Predicate<object> _canExecute;

        #endregion Variables

        #region ICommand Members

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>true if this command can be executed; otherwise, false.</returns>
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            try
            {
                _execute(parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion ICommand Members
    }
}
