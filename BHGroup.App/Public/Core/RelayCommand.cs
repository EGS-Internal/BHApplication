using System.Windows.Input;

namespace BHGroup.App.Public.Core
{

    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        //{
        //add { CommandManager.RequerySuggested += value; }
        //remove { CommandManager.RequerySuggested -= value; }
        //}
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
