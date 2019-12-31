using LoginForm.Source.Views.CustomRenderersTabs.RadioButtonCustomize.Helper;
using System;
using Xamarin.Forms;

namespace LoginForm.Source.Views.CustomRenderersTabs.RadioButtonCustomize
{
#pragma warning disable CS0618 // 'ViewRenderer<CustomRadioButton, RadioButton>.ViewRenderer()" является устаревшим: 'This constructor is obsolete as of version 2.5. Please use ViewRenderer(Context) instead.'
    public class CustomRadioButton : View
    {
        public static readonly BindableProperty CheckedProperty =
            BindableProperty.Create<CustomRadioButton, bool>(p => p.Checked, false);

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create<CustomRadioButton, string>(p => p.Text, string.Empty);

        public EventHandler<EventArgs<bool>> CheckedChanged;

        public bool Checked
        {
            get => (bool)GetValue(CheckedProperty);
            set
            {
                SetValue(CheckedProperty, value);

                //var eventHandler = CheckedChanged;

                //if (eventHandler != null)
                //{
                //    eventHandler.Invoke(this, value);
                //}
            }
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public int Id { get; set; }
    }
#pragma warning disable CS0618 // 'ViewRenderer<CustomRadioButton, RadioButton>.ViewRenderer()" является устаревшим: 'This constructor is obsolete as of version 2.5. Please use ViewRenderer(Context) instead.'
}
