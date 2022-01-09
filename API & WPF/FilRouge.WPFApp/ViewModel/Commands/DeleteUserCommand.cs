using System;
using System.Windows.Input;

namespace FilRouge.WPFApp.ViewModel.Commands
{
    public class DeleteUserCommand : ICommand
    {
        public UserVM uVM { get; set; }

        public DeleteUserCommand(UserVM vm)
        {
            uVM = vm;
        }
        
        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler? CanExecuteChanged;
    }
}