using FilRouge.Classes;
using FilRouge.WPFApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FilRouge.WPFApp.View
{
    /// <summary>
    /// Logique d'interaction pour EditPostWindow.xaml
    /// </summary>
    public partial class EditPostWindow : Window
    {
        public EditPostVM EPvm { get; set; }


        public EditPostWindow(Post post)
        {
            EPvm = new EditPostVM(post);
            
            InitializeComponent();
        }

    }
}

