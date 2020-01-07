using PrismFrameworkApps.src._13_RefitRestApi.Services;
using Refit;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismFrameworkApps.src._13_RefitRestApi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleRestApi : ContentPage
    {
        public SimpleRestApi() => InitializeComponent();

        #region
        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    await OnGetMakeUpClicked();
        //}

        //async Task OnGetMakeUpClicked()
        //{
        //    var apiResponse = RestService.For<IMakeUpApi>("http//makeup-api.herokuapp.com");
        //    var makeUps = await apiResponse.GetMakeUps("maybelline");
        //}
        #endregion

        async void OnGetMakeUpClicked(object sender, EventArgs e)
        {
            var apiResponse = RestService.For<IMakeUpApi>("http://makeup-api.herokuapp.com");
            var makeUps = await apiResponse.GetMakeUps("maybelline");

            MakeUpList.ItemsSource = makeUps;
        }
    }
}