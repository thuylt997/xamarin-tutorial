using LoginForm.Source.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocalDatabase : ContentPage
    {
        public LocalDatabase()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            peopleListView.ItemsSource = await App.Database.GetPeopleAsync();
        }

        async void OnAddPersonButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(ageEntry.Text))
            {
                await App.Database.SavePersonAsync(new Person
                {
                    name = nameEntry.Text,
                    age = int.Parse(ageEntry.Text)
                });

                nameEntry.Text = ageEntry.Text = string.Empty;
                peopleListView.ItemsSource = await App.Database.GetPeopleAsync();
            }
        }
    }
}