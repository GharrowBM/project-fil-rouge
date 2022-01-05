using FilRouge.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FilRouge.WPFApp.ViewModel.Commands
{
    public class DeletePostCommand : ICommand
    {
        public PostsVM VM { get; set; }

        public event EventHandler? CanExecuteChanged;

        public DeletePostCommand(PostsVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            Post post = parameter as Post;

            if (post != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object? parameter)
        {
            VM.DeletePost();
        }
    }
}
