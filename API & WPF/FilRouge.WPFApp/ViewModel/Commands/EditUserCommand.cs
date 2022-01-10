using System;
using System.Windows.Input;

namespace FilRouge.WPFApp.ViewModel.Commands
{
    public class EditUserCommand : ICommand
    {
        public EditUserVM vm;

        public EditUserCommand(EditUserVM VM)
        {
            vm = VM;
        }
        
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            vm.EditUser();
        }

        public event EventHandler? CanExecuteChanged;
    }
}