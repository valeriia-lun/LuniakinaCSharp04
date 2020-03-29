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
using System;
using System.Windows.Controls;
using Luniakina04.Tools.Navigation;
using Luniakina04.ViewModels;


namespace Luniakina04.Views
{
    /// <summary>
    /// Логика взаимодействия для EditingPersonView.xaml
    /// </summary>
    public partial class EditingPersonView : UserControl, INavigatable
    {
        public EditingPersonView()
        {
            InitializeComponent();
            DataContext = new EditPersonViewModel();
        }
    }
}
