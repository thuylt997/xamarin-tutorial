using Xamarin.Forms;

namespace LoginForm.Source.Views.BehaviorsTabViews.Behaviors
{
    public static class NumericValidationBehaviorAttached
    {
        public static readonly BindableProperty AttachBehaviorProperty =
            BindableProperty.CreateAttached(
                "AttachBehavior",                           // property name
                typeof(bool),                               // return type
                typeof(NumericValidationBehaviorAttached),  // declaring type
                false,                                      // default value
                propertyChanged: OnAttachBehaviorChanged    // attachBehaviorProperty registers this propertyChanged as a method.
            );

        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }

        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(AttachBehaviorProperty, value);
        }

        // OnAttachBehaviorChanged method will be executed when the value of the property changes.
        static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
        {
            var entry = view as Entry;
            bool attachBehavior = (bool)newValue;

            if (entry == null)
            {
                return;
            }

            if (attachBehavior)
            {
                // Setting the AttachBehavior attached property to True
                // Register / or Attach to OnEntryTextChanged
                entry.TextChanged += OnEntryTextChanged;
            }
            else
            {
                // Setting the AttachBehavior attached property to False
                // De-register / or Detach from OnEntryTextChanged
                entry.TextChanged -= OnEntryTextChanged;
            }
        }

        static void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            double result;
            bool isValid = double.TryParse(e.NewTextValue, out result);

            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
