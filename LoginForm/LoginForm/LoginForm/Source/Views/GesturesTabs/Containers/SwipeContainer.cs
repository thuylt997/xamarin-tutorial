using System;
using Xamarin.Forms;

namespace LoginForm.Source.Views.GesturesTabs.Containers
{
    public class SwipeContainer : ContentView
    {
        public event EventHandler<SwipedEventArgs> SwipeEventHandler;

        public SwipeContainer()
        {
            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Left));
            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Right));
            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Up));
            GestureRecognizers.Add(GetSwipeGestureRecognizer(SwipeDirection.Down));
        }

        SwipeGestureRecognizer GetSwipeGestureRecognizer(SwipeDirection direction)
        {
            var swipe = new SwipeGestureRecognizer { Direction = direction };

            swipe.Swiped += (sender, e) => SwipeEventHandler?.Invoke(this, e);

            return swipe;
        }
    }
}
