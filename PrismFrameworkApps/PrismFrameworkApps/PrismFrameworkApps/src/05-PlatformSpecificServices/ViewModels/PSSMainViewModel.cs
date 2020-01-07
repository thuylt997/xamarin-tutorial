using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using PrismFrameworkApps.src._05_PlatformSpecificServices.Services;

namespace PrismFrameworkApps.src._05_PlatformSpecificServices.ViewModels
{
    public class PSSMainViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        private ITextToSpeech _textToSpeech { get; }

        private bool isExecuting;

        private string text;

        public DelegateCommand SpeakCommand { get; }

        public DelegateCommand BackToPreviousPage { get; }

        public bool IsExecuting
        {
            get => isExecuting;
            set => SetProperty(ref isExecuting, value);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        //public PSSMainViewModel(INavigationService navigationService, ITextToSpeech textToSpeech, IDeviceService deviceService)
        //{
        //    _navigationService = navigationService;
        //    _textToSpeech = textToSpeech;

        //    SpeakCommand = new DelegateCommand(OnSpeakCommandExecuted);

        //    SpeakCommand = new DelegateCommand(
        //        OnSpeakCommandExecuted,
        //        () => !IsExecuting && !string.IsNullOrEmpty(Text)
        //    )
        //    .ObservesProperty(() => IsExecuting)
        //    .ObservesProperty(() => Text);

        //    Text = $"This text will be spoken by {deviceService.RuntimePlatform}";

        //    BackToPreviousPage = new DelegateCommand(NavigateToPreviousPageExecuted);
        //}

        public PSSMainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            BackToPreviousPage = new DelegateCommand(NavigateToPreviousPageExecuted);
        }

        void OnSpeakCommandExecuted() => _textToSpeech.Speak(Text);

        async void NavigateToPreviousPageExecuted() =>
             await _navigationService.NavigateAsync("/NavigationPage/HomePageView");
    }
}
