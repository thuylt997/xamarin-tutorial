using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismFrameworkApps.src._03_ListView.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListSample : ContentPage
    {
        public ListSample() => InitializeComponent();

        //void OnListViewItemTapped(object sender, ItemTappedEventArgs e) => entry.Text = e.Item.ToString();
    }
}