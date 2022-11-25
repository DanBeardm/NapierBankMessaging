using NapierBankMessaging.Commands;
using NapierBankMessaging.Views;
using System.Windows.Controls;
using System.Windows.Input;

namespace NapierBankMessaging.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public string AddMessageButtonContent { get; private set; }
        public string ViewOutputContent { get; private set; }

        public ICommand AddMessageButtonCommand { get; private set; }
        public ICommand ViewOutputButtonCommand { get; private set; }

        public UserControl ContentControlBinding { get; private set; }
    
        public MainWindowViewModel()
        {
            AddMessageButtonContent = "Add Message";
            ViewOutputContent = "View Lists";

            AddMessageButtonCommand = new RelayCommand(AddMessageButtonClick);
            ViewOutputButtonCommand = new RelayCommand(ViewOutputButtonClick);

            ContentControlBinding = new DefaultView();
        }

        private void ViewOutputButtonClick()
        {
            ContentControlBinding = new ViewListsView();
            OnChanged(nameof(ContentControlBinding));
        }


        private void AddMessageButtonClick()
        {
            ContentControlBinding = new AddMessage();
            OnChanged(nameof(ContentControlBinding));
        }
    }
}
