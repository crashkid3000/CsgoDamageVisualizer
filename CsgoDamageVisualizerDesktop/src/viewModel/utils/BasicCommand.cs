using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CsgoDamageVisualizerDesktop.viewModel.utils
{
    /// <summary>
    /// <para>A simple implementation of the <c>ICommand</c> interface, based on "Entwurfsmuster" by Matthias Geirhos (ISBN 978-3-8362-2762-9)</para>
    /// <para>This class "implements" the required methods by calling the corresponding methods provided by the creator of this object.</para>
    /// </summary>
    internal class BasicCommand : ICommand
    {
        
        private Action<object?> Executable { get; init; }
        private Predicate<object?> IsExecutableDoable { get; init; }

        /// <summary>
        /// <para>Defines a command by providing the method for the command, as well as the required condition for the provided method in order to be executed.</para>
        /// <para>Note that the client (you) needs to manually implement the check for itself before executing the command.</para>
        /// </summary>
        /// <param name="executable">The code that is run when the command is raised</param>
        /// <param name="isExecutableDoable">The conditions that need to be met</param>
        public BasicCommand(Action<object?> executable, Predicate<object?> isExecutableDoable)
        {
            this.Executable = executable;
            this.IsExecutableDoable = isExecutableDoable;
        }

        /// <summary>
        /// Defines a command by providing the method for the command. There are no checks taking place in order for the command to execute (more precisely: the check is always true).
        /// </summary>
        /// <param name="executable">The code that is run when the command is raised</param>
        public BasicCommand(Action<object?> executable) : this(executable, obj => true)
        {

        }

        public bool CanExecute(object? parameter)
        {
            return IsExecutableDoable.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            Executable.Invoke(parameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
