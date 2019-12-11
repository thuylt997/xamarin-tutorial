using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinUI.Source.ActivityIndicatorExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActivityIndicatorXamlPage : ContentPage
    {
        bool isTaskRunning;
        public ActivityIndicatorXamlPage()
        {
            InitializeComponent();
            UpdateUiState();
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            isTaskRunning = !isTaskRunning;
            UpdateUiState();
        }

        void UpdateUiState()
        {
            runningStatusLabel.Text = isTaskRunning ? "A task is in progress" : "All tasks are completed!";
            defaultActivityIndicator.IsRunning = isTaskRunning;
            styledActivityIndicator.IsRunning = isTaskRunning;
        }
    }
}