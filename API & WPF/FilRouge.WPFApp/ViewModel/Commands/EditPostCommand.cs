using FilRouge.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FilRouge.WPFApp.ViewModel.Commands
{
    public class EditPostCommand : ICommand
    {
        public EditPostVM EPvm { get; set; }

        public event EventHandler? CanExecuteChanged;

        public EditPostCommand(EditPostVM vm)
        {
            EPvm = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Post post = parameter as Post;

            EPvm.EditPost();
        }
    }
}