using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppLifecycle : ContentPage
    {
        public AppLifecycle()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            entry.Text = (Application.Current as App).DisplayText;
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            (Application.Current as App).DisplayText = entry.Text;
        }
    }
}