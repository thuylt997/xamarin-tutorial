using System;
using Xamarin.Forms;

namespace LoginForm.Source.Views.GesturesTabs.Containers
{
    public class PanContainer : ContentView
    {
        double x;
        double y;

        public PanContainer()
        {
            /**
             * Set PanGestureRecognizer.TouchPoints to control 
             * the number of touch points needed to pan.
             */
            var panGesture = new PanGestureRecognizer();

            panGesture.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(panGesture);
        }

        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {

                case GestureStatus.Running:
                    // Translate and ensure we don't pan beyond the wrapped user interface element bounds.
                    Content.TranslationX = Math.Max(Math.Min(0, x + e.TotalX), -Math.Abs(Content.Width - GesturesMainPage.ScreenWidth));
                    Content.TranslationY = Math.Max(Math.Min(0, y + e.TotalY), -Math.Abs(Content.Height - GesturesMainPage.ScreenHeight));
                    break;

                case GestureStatus.Completed:
                    // Store the translation applied during the pan.
                    x = Content.TranslationX;
                    y = Content.TranslationY;
                    break;

                default:
                    break;
            }
        }
    }
}
