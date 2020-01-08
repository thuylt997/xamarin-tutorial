using PrismFrameworkApps.src._15_MessagingCenter.Views;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._15_MessagingCenter.ViewModels
{
    public class MessagingCenterMainViewModel
    {
        public ObservableCollection<string> Greetings { get; set; }

        public MessagingCenterMainViewModel()
        {
            Greetings = new ObservableCollection<string>();

            MessagingCenter.Subscribe<MessagingCenterMain>(
                this,
                "Hi",
                (sender) =>
                {
                    Greetings.Add("Hi");
                }
            );

            MessagingCenter.Subscribe<MessagingCenterMain, string>(
                this,
                "Hi",
                (sender, args) =>
                {
                    Greetings.Add("Hi " + args);
                }
            );
        }
    }
}
