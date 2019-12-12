using LoginForm.Source.Models;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public ICommand TapCommand => new Command<string>(
            async (url) => await Launcher.OpenAsync(url)
        );

        public LoginPage()
        {
            InitializeComponent();

            InitalizeStyle();

            BindingContext = this;
        }

        private void InitalizeStyle()
        {
            //BackgroundColor = Constants.backgroundColor;
            //labelUsername.TextColor = Constants.mainTextColor;
            //labelPassword.TextColor = Constants.mainTextColor;
            //imageIcon.HeightRequest = Constants.loginIconHeight;

            entryUsername.Completed += (s, e) => entryPassword.Focus();
            entryPassword.Completed += (s, e) => OnSignInClicked(s, e);
        }

        void OnSignInClicked(object sender, EventArgs e)
        {
            User user = new User(entryUsername.Text, entryPassword.Text);

            if (user.AuthenticationChecking())
            {
                NavigateToHomePage();
                //App.UserDatabase.SaveUser(user);
            }
            else
            {
                DisplayAlert("Login", "Your authentication is not correct", "OK");
            }
        }

        async void NavigateToHomePage()
        {
            await Navigation.PushAsync(new HomePage());
        }

        void OnFocusUsernameEntry(object sender, EventArgs e)
        {
            entryUsername.Placeholder = string.Empty;
        }

        void OnUnfocusUsernameEntry(object sender, EventArgs e) 
        {
            entryUsername.Placeholder = "Enter your username";
        }

        void OnFocusPasswordEntry(object sender, EventArgs e)
        {
            entryPassword.Placeholder = string.Empty;
        }

        void OnUnfocusPasswordEntry(object sender, EventArgs e)
        {
            entryPassword.Placeholder = "Enter your password";
        }
    }
}