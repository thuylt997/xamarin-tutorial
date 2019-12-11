using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinUI.Source.ProgressBarExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressBarDisplayPage : ContentPage
    {
        public ICommand NavigateCommand { get; private set; }

        public ProgressBarDisplayPage()
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