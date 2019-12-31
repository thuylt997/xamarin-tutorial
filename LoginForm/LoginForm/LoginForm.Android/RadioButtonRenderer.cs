using System.ComponentModel;
using Android.Widget;
using LoginForm.Droid;
using LoginForm.Source.Views.CustomRenderersTabs.RadioButtonCustomize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomRadioButton), typeof(RadioButtonRenderer))]
namespace LoginForm.Droid
{
#pragma warning disable CS0618 // 'ViewRenderer<CustomRadioButton, RadioButton>.ViewRenderer()" является устаревшим: 'This constructor is obsolete as of version 2.5. Please use ViewRenderer(Context) instead.'
    public class RadioButtonRenderer : ViewRenderer<CustomRadioButton, RadioButton>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomRadioButton> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                e.OldElement.PropertyChanged += ElementOnPropertyChanged;
            }

            if (Control == null)
            {
                var radioButton = new RadioButton(Context);

                //radioButton.CheckedChange += RadioButtonCheckedChange;

                SetNativeControl(radioButton);
            }

            Control.Text = e.NewElement.Text;
            Control.Checked = e.NewElement.Checked;

            Element.PropertyChanged += ElementOnPropertyChanged;
        }

        void ElementOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Checked":
                    Control.Checked = Element.Checked;
                    break;

                case "Text":
                    Control.Text = Element.Text;
                    break;

                default:
                    break;
            }
        }

        void RadioButtonCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e) =>
            Element.Checked = e.IsChecked;
    }
#pragma warning restore CS0618 // 'ViewRenderer<CustomRadioButton, RadioButton>.ViewRenderer()" является устаревшим: 'This constructor is obsolete as of version 2.5. Please use ViewRenderer(Context) instead.'
}