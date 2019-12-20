using System.Linq;
using Xamarin.Forms;

namespace LoginForm.Source.Views.BehaviorsTabViews.Behaviors
{
    public class NumericValidationBehaviorXForms : Behavior<Entry>
    {
        /**
         * START Xamarin.Forms Behavior with a Style
         */
        public static readonly BindableProperty AttachBehaviorProperty =
            BindableProperty.CreateAttached(
                "AttachBehavior",
                typeof(bool),
                typeof(NumericValidationBehaviorXForms),
                false,
                propertyChanged: OnAttachBehaviorChanged
            );

        public static bool GetAttachBehavior(BindableObject view) => (bool)view.GetValue(AttachBehaviorProperty);

        public static void SetAttachBehavior(BindableObject view, bool value) => view.SetValue(AttachBehaviorProperty, value);

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
                entry.Behaviors.Add(new NumericValidationBehaviorXForms());
            }
            else
            {
                var toRemove = entry.Behaviors.FirstOrDefault(b => b is NumericValidationBehaviorXForms);

                if (toRemove != null)
                {
                    entry.Behaviors.Remove(toRemove);
                    //entry.Behaviors.Clear();
                }
            }
        }
        /**
         * END Xamarin.Forms Behavior with a Style
         */

        /**
         * START Xamarin.Forms Behavior without Style
         */
        // The OnAttachedTo method is fired immediately after the behavior is attached to a control.
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += OnEntryTextChanged;

            base.OnAttachedTo(bindable);
        }

        // The OnDetachingFrom method is fired when the behavior is removed from the control.
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= OnEntryTextChanged;

            base.OnDetachingFrom(bindable);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            double result;
            bool isValid = double.TryParse(e.NewTextValue, out result);

            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
        /**
         * END Xamarin.Forms Behavior without Style
         */
    }
}
