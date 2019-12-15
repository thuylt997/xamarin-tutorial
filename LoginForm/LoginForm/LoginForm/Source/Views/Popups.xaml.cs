using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Popups : ContentPage
    {
        public Popups()
        {
            InitializeComponent();
        }

        async void OnDisplayAlertButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "This is an alert", "OK");
        }

        async void OnDisplayAlertQuestionButtonClicked(object sender, EventArgs e)
        {
            bool response = await DisplayAlert("Save?", "Would you like to save your data?", "Yes", "No");

            // Yes => response = True
            // No => response = False
            Console.WriteLine("Save data: " + response);
        }

        async void OnDisplayActionSheetButtonClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Send to?", "Cancel", null, "Email", "Twitter", "Facebook");
            Console.WriteLine("Action: " + action);
        }
    }
}