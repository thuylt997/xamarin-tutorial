using System;
using Xamarin.Forms;

namespace XamarinUI.Source.ProgressBarExample
{
    public class ProgressBarCodePage : ContentPage
    {
        ProgressBar defaultProgressBar;
        ProgressBar styledProgressBar;
        float progress = 0f;

        public ProgressBarCodePage()
        {
            Title = "ProgressBar Code Page";
            Padding = 10;

            defaultProgressBar = new ProgressBar
            {
                WidthRequest = 500,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            styledProgressBar = new ProgressBar
            {
                WidthRequest = 500,
                ProgressColor = Color.Orange,
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            var progressButton = new Button
            {
                Text = "Click to increase the progress",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            progressButton.Clicked += OnButtonClicked;

            Content = new StackLayout
            {
                Children =
                {
                    defaultProgressBar,
                    styledProgressBar,
                    progressButton
                }
            };
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
