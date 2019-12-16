using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views.HierarchicalPageViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();
        }

        async void OnPreviousPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void OnRootPageButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        void OnInsertPageButtonClicked(object sender, EventArgs e)
        {
            var page2a = Navigation.NavigationStack.FirstOrDefault(p => p.Title == "Page 2a");

            if (page2a == null)
            {
                Navigation.InsertPageBefore(new Page2a(), this);
            }
        }

        void OnRemovePageButtonClicked(object sender, EventArgs e)
        {
            var page2 = Navigation.NavigationStack.FirstOrDefault(p => p.Title == "Page 2");

            if (page2 != null)
            {
                Navigation.RemovePage(page2);
            }
        }
    }
}