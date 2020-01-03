using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismFrameworkApps.src._07_MasterDetailPages.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomMasterDetailPage : MasterDetailPage, IMasterDetailPageOptions
    {
        public CustomMasterDetailPage() => InitializeComponent();

        public bool IsPresentedAfterNavigation => false;
    }
}