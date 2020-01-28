using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._17_Essentials.ViewModels
{
    public class PhoneDialerViewModel : BaseViewModel
    {
        string phoneNumber;

        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }

        public ICommand OpenPhoneDialerCommand { get; }

        public PhoneDialerViewModel() =>
            OpenPhoneDialerCommand = new Command(
                async () =>
                {
                    try
                    {
                        PhoneDialer.Open(PhoneNumber);
                    }
                    catch (Exception error)
                    {
                        await DisplayAlertAsync($"Dialer is not supported: {error.Message}");
                    }
                }
            );
    }
}
