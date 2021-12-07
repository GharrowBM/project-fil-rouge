using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FilRouge.WPFApp.ViewModel.Commands
{
    public class SwitchLoginRegisterCommand : ICommand
    {
        public LoginVM VM { get; set; }

        public event EventHandler? CanExecuteChanged;

        public SwitchLoginRegisterCommand(LoginVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            VM.SwitchLoginRegister();
        }
    }
}
