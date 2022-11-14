using System;
using System.Windows;
using System.Windows.Controls;
using NapierBankMessaging.ViewModels;


namespace NapierBankMessaging.Views
{
    /// <summary>
    /// Interaction logic for AddSmS.xaml
    /// </summary>
    public partial class AddSmS : UserControl
    {
        public AddSmS()
        {
            InitializeComponent();

            this.DataContext = new AddSmSViewModel();
        }
    }
}
