using System;
using System.Windows.Input;
using FilRouge.Classes;

namespace FilRouge.WPFApp.ViewModel.Commands
{
    public class ShowEditPostWindowCommand : ICommand
    {
        public PostsVM VM { get; set; }

        public ShowEditPostWindowCommand(PostsVM vm)
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
            VM.ShowEditPostWindow();
        }

        public event EventHandler? CanExecuteChanged;
    }
}