using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._17_Essentials.ViewModels
{
    public class DetectShakeViewModel : BaseViewModel
    {
        double x;
        double y;
        double z;

        bool isActive;
        int speed = 0;
        string shakeTime = string.Empty;

        public double X
        {
            get => x;
            set => SetProperty(ref x, value);
        }

        public double Y
        {
            get => y;
            set => SetProperty(ref y, value);
        }

        public double Z
        {
            get => z;
            set => SetProperty(ref z, value);
        }

        public bool IsActive
        {
            get => isActive;
            set => SetProperty(ref isActive, value);
        }

        public int Speed
        {
            get => speed;
            set => SetProperty(ref speed, value);
        }

        public string ShakeTime
        {
            get => shakeTime;
            set => SetProperty(ref shakeTime, value);
        }

        public string[] Speeds { get; } = Enum.GetNames(typeof(SensorSpeed));

        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }

        public DetectShakeViewModel()
        {
            StartCommand = new Command(
                async () =>
                {
                    try
                    {
                        Accelerometer.Start((SensorSpeed)Speed);
                        IsActive = true;
                    }
                    catch (Exception error)
                    {
                        await DisplayAlertAsync($"Unable to start accelerometer: {error.Message}");
                    }
                }
            );

            StopCommand = new Command(OnStop);
        }

        public override void OnAppearing()
        {
            Accelerometer.ReadingChanged += OnReadingChanged;
            Accelerometer.ShakeDetected += OnShakeDetected;

            base.OnAppearing();
        }

        public override void OnDisappearing()
        {
            OnStop();

            Accelerometer.ReadingChanged -= OnReadingChanged;
            Accelerometer.ShakeDetected -= OnShakeDetected;

            base.OnDisappearing();
        }

        void OnShakeDetected(object sender, EventArgs eventArgs) =>
            ShakeTime = $"Shake detected: {DateTime.Now.ToLongTimeString()}";

        void OnReadingChanged(object sender, AccelerometerChangedEventArgs eventArgs)
        {
            var data = eventArgs.Reading;

            switch ((SensorSpeed)Speed)
            {
                case SensorSpeed.Fastest: // Fastest – Get the sensor data as fast as possible (not guaranteed to return on UI thread).
                case SensorSpeed.Game: // Game – Rate suitable for games (not guaranteed to return on UI thread).
                    MainThread.BeginInvokeOnMainThread(
                        () =>
                        {
                            X = data.Acceleration.X;
                            Y = data.Acceleration.Y;
                            Z = data.Acceleration.Z;
                        }
                    );

                    break;

                default:
                    X = data.Acceleration.X;
                    Y = data.Acceleration.Y;
                    Z = data.Acceleration.Z;

                    break;
            }
        }

        void OnStop()
        {
            IsActive = false;
            Accelerometer.Stop();
        }
    }
}
