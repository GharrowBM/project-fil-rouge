using System;
using System.Windows.Input;
using FilRouge.Classes;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FilRouge.WPFApp.ViewModel.Commands
{
    public class ShowEditUserCommand : ICommand
    {
        public UserVM uVM { get; set; }

        public ShowEditUserCommand(UserVM vm)
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
            uVM.ShowEditUserWindow();
        }

        public event EventHandler? CanExecuteChanged;
    }
}