using System;
using System.IO;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._17_Essentials.ViewModels
{
    public class LauncherViewModel : BaseViewModel
    {
        string fileAttachmentName;
        string fileAttachmentContents;

        public string FileAttachmentContents
        {
            get => fileAttachmentContents;
            set => SetProperty(ref fileAttachmentContents, value);
        }

        public string FileAttachmentName
        {
            get => fileAttachmentName;
            set => SetProperty(ref fileAttachmentName, value);
        }

        // Gets https://www.google.com/ link as an example for LaunchUri
        public string LaunchUri { get; set; }

        public ICommand LaunchCommand { get; }

        public ICommand CanLaunchCommand { get; }

        public ICommand LaunchMailCommand { get; }

        public ICommand LaunchBrowserCommand { get; }

        public ICommand LaunchFileCommand { get; }

        public LauncherViewModel()
        {
            LaunchCommand = new Command(OnLaunch);
            LaunchMailCommand = new Command(OnLaunchMail);
            LaunchBrowserCommand = new Command(OnLaunchBrowser);
            CanLaunchCommand = new Command(CanLaunch);
            LaunchFileCommand = new Command(OnFileRequest);
        }

        private async void OnFileRequest()
        {
            if (!string.IsNullOrWhiteSpace(FileAttachmentContents))
            {
                var fn = string.IsNullOrWhiteSpace(FileAttachmentName) ? "Attachment.txt" : FileAttachmentName.Trim();
                var file = Path.Combine(FileSystem.CacheDirectory, fn);

                File.WriteAllText(file, FileAttachmentContents);

                await Launcher.OpenAsync(
                    new OpenFileRequest
                    {
                        File = new ReadOnlyFile(file)
                    }
                );
            }
        }

        private async void CanLaunch()
        {
            try
            {
                var canBeLaunched = await Launcher.CanOpenAsync(LaunchUri);

                await DisplayAlertAsync($"Uri {LaunchUri} can be launched: {canBeLaunched}");
            }
            catch (Exception error)
            {
                await DisplayAlertAsync($"Uri {LaunchUri} could not be verified as launchable: {error}");
            }
        }

        private async void OnLaunchBrowser() =>
            await Launcher.OpenAsync("https://github.com/xamarin/Essentials");

        private async void OnLaunchMail() =>
            await Launcher.OpenAsync("mailto:");

        private async void OnLaunch()
        {
            try
            {
                await Launcher.OpenAsync(LaunchUri);
            }
            catch (Exception error)
            {
                await DisplayAlertAsync($"Uri {LaunchUri} could not be launched: {error}");
            }
        }
    }
}
