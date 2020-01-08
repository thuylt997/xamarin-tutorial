using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._15_MessagingCenter.ViewModels
{
    public class TestTwoViewModel : BindableObject, INotifyPropertyChanged
    {
        public string TextMessageingCenter { get; set; } = "default";

        public TestTwoViewModel() =>
            MessagingCenter.Subscribe<TestOneViewModel>(this, "messageAddress", OnCallback);

        public void OnCallback(TestOneViewModel obj)
        {
            Debug.WriteLine(obj);
            TextMessageingCenter = obj.SelectedItemText;
            OnPropertyChanged("TextMessageingCenter");
        }
    }
}
