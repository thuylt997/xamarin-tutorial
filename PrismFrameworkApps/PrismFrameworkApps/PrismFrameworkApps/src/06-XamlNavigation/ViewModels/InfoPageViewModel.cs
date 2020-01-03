using Prism.Mvvm;
using Prism.Navigation;

namespace PrismFrameworkApps.src._06_XamlNavigation.ViewModels
{
    public class InfoPageViewModel : BindableBase, INavigationAware
    {
        private string text;

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public InfoPageViewModel()
        {
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("Message"))
            {
                Text = parameters.GetValue<string>("Message");
            }

            if (parameters.ContainsKey("MoreMessages"))
            {
                Text += " " + parameters.GetValue<string>("MoreMessages");
            }
        }
    }
}
