using System;
using System.Windows.Input;

namespace FilRouge.WPFApp.ViewModel.Commands
{
    public class LoginVerificationCommand : ICommand
    {
        public LoginVM VM { get; set; }

        public LoginVerificationCommand(LoginVM vm)
        {
            VM = vm;
        }
        
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            VM.LogUserTest();
        }

        public event EventHandler? CanExecuteChanged;
    }
}