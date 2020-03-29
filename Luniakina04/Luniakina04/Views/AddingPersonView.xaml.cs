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
    /// Логика взаимодействия для AddingPersonView.xaml
    /// </summary>
    public partial class AddingPersonView : UserControl, INavigatable
    {
        public AddingPersonView()
        {
            InitializeComponent();
            DataContext = new AddPersonViewModel();
        }
    }
}
