using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._17_Essentials.ViewModels
{
    public class FlashlightViewModel : BaseViewModel
    {
        bool isOn;
        bool isSupported = true;

        public bool IsOn
        {
            get => isOn;
            set => SetProperty(ref isOn, value);
        }

        public bool IsSupported
        {
            get => isSupported;
            set => SetProperty(ref isSupported, value);
        }

        public ICommand ToggleCommand { get; }

        public FlashlightViewModel()
        {
            ToggleCommand = new Command(
                async () =>
                {
                    try
                    {
                        if (IsOn)
                        {
                            await Flashlight.TurnOffAsync();
                            IsOn = false;
                        }
                        else
                        {
                            await Flashlight.TurnOnAsync();
                            IsOn = true;
                        }
                    }
                    catch (FeatureNotSupportedException featureNotSupportedException)
                    {
                        IsSupported = false;
                        await DisplayAlertAsync($"Unable toggle flashlight: {featureNotSupportedException.Message}");
                    }
                    catch (Exception error)
                    {
                        await DisplayAlertAsync($"Unable toggle flashlight: {error.Message}");
                    }
                }
            );
        }

        public override void OnDisappearing()
        {
            if (!IsOn)
            {
                return;
            }

            try
            {
                Flashlight.TurnOffAsync();
                IsOn = false;
            }
            catch (FeatureNotSupportedException)
            {
                IsSupported = false;
            }

            base.OnDisappearing();
        }
    }
}
