using PrismFrameworkApps.src._15_MessagingCenter.Views;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._15_MessagingCenter.ViewModels
{
    public class TestOneViewModel : BindableObject, INotifyPropertyChanged
    {
        public string SelectedItemText { get; private set; } = DateTime.Now.ToString();

        public ICommand SendMessagingCenter { get; set; }

        public TestOneViewModel() =>
            SendMessagingCenter = new Command(HandleSendMessagingCenter);

        private void HandleSendMessagingCenter(object obj)
        {
            // Navigation page.
            Application.Current.MainPage.Navigation.PushAsync(new TestTwo());
            MessagingCenter.Send<TestOneViewModel>(this, "messageAddress");

            // Send MessagingCenter.
            MessagingCenter.Send<TestOneViewModel, string>(this, "message", "value of argrument string");
        }

        public void OnCallback(TestOneViewModel obj)
        {
            Debug.WriteLine(obj);
            //SelectedItemText = obj.SelectedItemText;
        }
    }
}
