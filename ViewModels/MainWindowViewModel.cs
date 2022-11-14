using NapierBankMessaging.Commands;
using NapierBankMessaging.Views;
using System.Windows.Controls;
using System.Windows.Input;

namespace NapierBankMessaging.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public string SmSMessageButtonContent { get; private set; }
        public string ViewOutputContent { get; private set; }

        public ICommand SmSMessageButtonCommand { get; private set; }
        public ICommand ViewOutputButtonCommand { get; private set; }

        public UserControl ContentControlBinding { get; private set; }
    
        public MainWindowViewModel()
        {
            SmSMessageButtonContent = "Add SmS Message";
            ViewOutputContent = "View Final Message";

            SmSMessageButtonCommand = new RelayCommand(SmSMessageButtonClick);
            ViewOutputButtonCommand = new RelayCommand(ViewOutputButtonClick);

            ContentControlBinding = new DefaultView();
        }

        private void ViewOutputButtonClick()
        {
            
        }


        private void SmSMessageButtonClick()
        {
            ContentControlBinding = new AddSmS();
            OnChanged(nameof(ContentControlBinding));
        }
    }
}
