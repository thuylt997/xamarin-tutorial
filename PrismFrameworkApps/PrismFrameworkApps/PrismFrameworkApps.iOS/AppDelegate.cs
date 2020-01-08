using Foundation;
using Prism;
using Prism.Events;
using Prism.Ioc;
using PrismFrameworkApps.iOS.Services;
using PrismFrameworkApps.src._05_PlatformSpecificServices.Services;
using PrismFrameworkApps.src._08_NavigationPages.Services;
using PrismFrameworkApps.src._16_EventAggregator.Models;
using UIKit;

namespace PrismFrameworkApps.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        static BatteryService batteryService = new BatteryService();

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            var iOSInit = new iOSInitializer();

            var application = new App(iOSInit);

            #region 16 - Event Aggregator Example

            var ea = application.Container.Resolve<IEventAggregator>()
                                          .GetEvent<NativeEvent>()
                                          .Subscribe(OnNameChangedEvent);

            #endregion 16 - Event Aggregator Example

            LoadApplication(application);

            return base.FinishedLaunching(app, options);
        }

        private void OnNameChangedEvent(NativeEventArgs args)
        {
            var alertView = new UIAlertView
            {
                Title = "Native Alert",
                Message = $"Hi {args.Message}, from iOS"
            };

            alertView.AddButton("OK");
            alertView.Show();
        }

        public class iOSInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
                // Text to Speech
                containerRegistry.Register<ITextToSpeech, TextToSpeech>();

                // Get battery status
                containerRegistry.RegisterInstance<IBatteryService>(batteryService);
            }
        }
    }
}
