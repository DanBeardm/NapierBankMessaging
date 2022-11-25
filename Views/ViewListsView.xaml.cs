using NapierBankMessaging.ViewModels;
using System;

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NapierBankMessaging.Views
{
    /// <summary>
    /// Interaction logic for ViewListsView.xaml
    /// </summary>
    public partial class ViewListsView : UserControl
    {
        public ViewListsView()
        {
            InitializeComponent();

            this.DataContext = new ViewListViewModel();
        }
    }
}
