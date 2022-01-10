using System.Windows;
using FilRouge.Classes;
using FilRouge.WPFApp.ViewModel;

namespace FilRouge.WPFApp.View
{
    public partial class EditUserWindow : Window
    {
        public EditUserVM VM;
        
        public EditUserWindow(User user)
        {
            VM = new EditUserVM(user, this);
            DataContext = VM;
            
            InitializeComponent();
        }
    }
}