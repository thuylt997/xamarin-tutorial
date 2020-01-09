using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.OS;
using Prism;
using Prism.Ioc;
using Plugin.CurrentActivity;
using PrismFrameworkApps.Droid.Services;
using PrismFrameworkApps.src._08_NavigationPages.Services;
using Acr.UserDialogs;
using PrismFrameworkApps.src._16_EventAggregator.Models;
using Android.Widget;
using Prism.Events;

namespace PrismFrameworkApps.Droid
{
    [Activity(
        Label = "PrismFrameworkApps",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation
    )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static BatteryService batteryService = new BatteryService();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            UserDialogs.Init(this);

            var androidInitializer = new AndroidInitializer();

            var application = new App(androidInitializer);

            #region 16 - Event Aggregator Example

            var ea = application.Container.Resolve<IEventAggregator>()
                                          .GetEvent<NativeEvent>()
                                          .Subscribe(OnNameChangedEvent);

            #endregion 16 - Event Aggregator Example

            LoadApplication(application);

            #region Hide status bar
            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);
            #endregion Hide status bar
        }

        public override void OnRequestPermissionsResult(int requestCode,
                                                        string[] permissions,
                                                        [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void OnNameChangedEvent(NativeEventArgs args)
        {
            Toast.MakeText(
                this,
                $"Hi {args.Message}, from Android",
                ToastLength.Long
            ).Show();
        }

        public class AndroidInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
                // Text to Speech
                //containerRegistry.RegisterInstance<ICurrentActivity>(CrossCurrentActivity.Current);
                //containerRegistry.Register<ITextToSpeech, AndroidTextToSpeech>();

                // Get battery status
                containerRegistry.RegisterInstance<IBatteryService>(batteryService);
            }
        }
    }
}