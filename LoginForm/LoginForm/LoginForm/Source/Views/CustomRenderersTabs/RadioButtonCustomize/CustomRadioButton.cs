using LoginForm.Source.Views.CustomRenderersTabs.RadioButtonCustomize.Helper;
using System;
using Xamarin.Forms;

namespace LoginForm.Source.Views.CustomRenderersTabs.RadioButtonCustomize
{
    public class CustomRadioButton : View
    {
        [Obsolete]
        public static readonly BindableProperty CheckedProperty =
            BindableProperty.Create<CustomRadioButton, bool>(p => p.Checked, false);

        [Obsolete]
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create<CustomRadioButton, string>(p => p.Text, string.Empty);

        public EventHandler<EventArgs<bool>> CheckedChanged;

        [Obsolete]
        public bool Checked
        {
            get => (bool)GetValue(CheckedProperty);
            set
            {
                SetValue(CheckedProperty, value);

                var eventHandler = CheckedChanged;

                if (eventHandler != null)
                {
                    eventHandler.Invoke(this, value);
                }
            }
        }

        [Obsolete]
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public int Id { get; set; }
    }
}
