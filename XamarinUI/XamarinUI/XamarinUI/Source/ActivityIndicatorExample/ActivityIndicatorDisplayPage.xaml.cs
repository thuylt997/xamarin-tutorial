using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinUI.Source.ActivityIndicatorExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityIndicatorDisplayPage : ContentPage
    {
        public ICommand NavigateCommand { get; private set; }

        public ActivityIndicatorDisplayPage()
        {
            InitializeComponent();

            NavigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await Navigation.PushAsync(page);
            });

            BindingContext = this;
        }
    }
}