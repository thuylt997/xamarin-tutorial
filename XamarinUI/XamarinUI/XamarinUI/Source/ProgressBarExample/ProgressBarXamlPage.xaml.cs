using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinUI.Source.ProgressBarExample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressBarXamlPage : ContentPage
    {
        float progress = 0f;
        public ProgressBarXamlPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            progress += 0.2f;

            if (progress > 1)
            {
                progress = 0;
            }

            // Directly set the new progress value.
            defaultProgressBar.Progress = progress;

            // Animate to the new value over 750 milliseconds using Linear easing.
            await styledProgressBar.ProgressTo(progress, 750, Easing.Linear);
        }
    }
}