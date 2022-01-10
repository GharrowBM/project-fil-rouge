using System;
using System.Windows.Input;
using FilRouge.Classes;

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
            User u = parameter as User;

            if (u != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public event EventHandler? CanExecuteChanged;
    }
}