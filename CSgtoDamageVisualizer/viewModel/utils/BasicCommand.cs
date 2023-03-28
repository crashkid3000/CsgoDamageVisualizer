using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CsgoDamageVisualizerDesktop.viewModel.utils
{
    /// <summary>
    /// A simple implementation of the <c>ICommand</c> interface. Based on "Entwurfsmuster" by Matthias Geirhos (ISBN 978-3-8362-2762-9)
    /// </summary>
    internal class BasicCommand : ICommand
    {
        private Action<object?> Executable { get; init; }
        private Predicate<object?> IsExecutableDoable { get; init; }

        public BasicCommand(Action<object?> executable, Predicate<object?> isExecutableDoable)
        {
            this.Executable = executable;
            this.IsExecutableDoable = isExecutableDoable;
        }

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
