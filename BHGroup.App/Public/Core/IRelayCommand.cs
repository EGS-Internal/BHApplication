
namespace BHGroup.App.Public.Core
{
    internal interface IRelayCommand
    {
        event EventHandler CanExecuteChanged;

        bool CanExecute(object? parameter);
        void Execute(object? parameter);
        void OnCanExecuteChanged();
    }
}