using NapierBankMessaging.Commands;
using NapierBankMessaging.Models;
using NapierBankMessaging.Output;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace NapierBankMessaging.ViewModels
{
    public class ViewListViewModel : BaseViewModel
    {
        public string ViewTrendingListTextBox { get; set; }

        public string ViewMentionListTextBox { get; set; }

        public string ViewListsButtonText { get; private set; }
        public ICommand ViewListsCommand { get; private set; }

        public ViewListViewModel()
        {
            ViewTrendingListTextBox = string.Empty;
            ViewMentionListTextBox = string.Empty;

            ViewListsButtonText = "Show Lists";
            ViewListsCommand = new RelayCommand(ShowListButtonClick);

        }

        private void ShowListButtonClick()
        {
            TrendingList ViewTrends = new TrendingList();
            MentionList ViewMentions = new MentionList();

            ViewTrendingListTextBox = ViewTrends.FromList();
            ViewMentionListTextBox = ViewMentions.FromList();
            
            OnChanged(nameof(ViewTrendingListTextBox));
            OnChanged(nameof(ViewMentionListTextBox));
            //MessageBox.Show(ViewTrendingListTextBox);
        }
    }
}
