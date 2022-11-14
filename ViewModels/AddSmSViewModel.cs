using NapierBankMessaging.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NapierBankMessaging.ViewModels
{
    public class AddSmSViewModel : BaseViewModel
    {
        public string SenderNameTextBlock { get; private set; }
        public string MessageTextBlock { get; private set; }

        public string SenderNameTextBox { get; set; }
        public string MessageTextBox { get; set; }

        public string AddSmSButtonText { get; private set; }
        public ICommand AddSmSCommand { get; private set; }

        public AddSmSViewModel()
        {
            SenderNameTextBlock = "Name";
            MessageTextBlock = "Message";

            SenderNameTextBox = string.Empty;
            MessageTextBox = string.Empty;

            AddSmSButtonText = "Submit Message";
            AddSmSCommand = new RelayCommand(AddButtonClick);
        }

        private void AddButtonClick()
        {

        }
    }
}
