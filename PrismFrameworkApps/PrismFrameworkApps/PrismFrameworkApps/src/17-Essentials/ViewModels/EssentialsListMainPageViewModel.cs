using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Diagnostics;

namespace PrismFrameworkApps.src._17_Essentials.ViewModels
{
    public class EssentialsListMainPageViewModel : BindableBase, IInitialize, INavigatedAware
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand<string> NavigateCommand { get; }

        public EssentialsListMainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateCommand = new DelegateCommand<string>(
                async (string path) =>
                {
                    var result = await _navigationService.NavigateAsync(path);

                    if (!result.Success)
                    {
                        Debugger.Break();
                    }
                }
            );
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void Initialize(INavigationParameters parameters)
        {
        }
    }
}
