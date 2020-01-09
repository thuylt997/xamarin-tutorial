using Xamarin.Essentials;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._17_Essentials.ViewModels
{
    public class AppInfoViewModel : BaseViewModel
    {
        // android:label in the application node (Android)
        // CFBundleDisplayName if set, else CFBundleName (iOS)
        public string AppName => AppInfo.Name;

        // package in the manifest node (Android)
        // CFBundleIdentifier (iOS)
        public string AppPackageName => AppInfo.PackageName;

        //public string AppTheme => AppInfo.RequestedTheme.AppTheme;

        // android:versionName in the application node (Android)
        // CFBundleShortVersionString (iOS)
        public string AppVersion => AppInfo.VersionString;

        // android:versionCode in manifest node (Android)
        // CFBundleVersion (iOS)
        public string AppBuild => AppInfo.BuildString;

        public Command ShowSettingsUICommand { get; }

        public AppInfoViewModel() =>
            ShowSettingsUICommand = new Command(
                () =>
                {
                    AppInfo.ShowSettingsUI();
                }
            );
    }
}
