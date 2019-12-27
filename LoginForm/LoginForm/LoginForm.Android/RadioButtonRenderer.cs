using System;
using System.ComponentModel;
using Android.Widget;
using LoginForm.Droid;
using LoginForm.Source.Views.CustomRenderersTabs.RadioButtonCustomize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomRadioButton), typeof(RadioButtonRenderer))]
namespace LoginForm.Droid
{
    [Obsolete]
    public class RadioButtonRenderer : ViewRenderer<CustomRadioButton, RadioButton>
    {
        //private ColorStateList defaultTextColor;

        protected override void OnElementChanged(ElementChangedEventArgs<CustomRadioButton> e)
        {
            base.OnElementChanged(e);

            //if (e.OldElement != null)
            //{
            //    e.OldElement.PropertyChanged += OnElementPropertyChanged;
            //}

            if (Control == null)
            {
                var radioButton = new RadioButton(Context);

                //defaultTextColor = radioButton.TextColors;

                radioButton.CheckedChange += RadioButtonCheckedChange;
                SetNativeControl(radioButton);
            }

            Control.Text = e.NewElement.Text;
            Control.Checked = e.NewElement.Checked;
            //Element.PropertyChanged += OnElementPropertyChanged;
            //UpdateTextColor();

            //if (e.NewElement.FontSize > 0)
            //{
            //    Control.TextSize = (float)e.NewElement.FontSize;
            //}

            //if (!string.IsNullOrEmpty(e.NewElement.FontName))
            //{
            //    Control.Typeface = TrySetFont(e.NewElement.FontName);
            //}
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case "Checked":
                    Control.Checked = Element.Checked;
                    break;

                case "Text":
                    Control.Text = Element.Text;
                    break;

                //case "TextColor":
                //    break;

                //case "FontName":
                //    break;

                //case "FontSize":
                //    break;

                default:
                    break;
            }
        }

        //private Typeface TrySetFont(string fontName)
        //{
        //    var typeface = Typeface.Default;

        //    try
        //    {
        //        typeface = Typeface.CreateFromAsset(Context.Assets, fontName);

        //        return typeface;
        //    }
        //    catch (Exception error)
        //    {
        //        Console.Write("Not found in assets {0}", error);

        //        try
        //        {
        //            typeface = Typeface.CreateFromFile(fontName);

        //            return typeface;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.Write(ex);

        //            return Typeface.Default;
        //        }
        //    }
        //}

        //void UpdateTextColor()
        //{
        //    if (Control == null || Element == null)
        //    {
        //        return;
        //    }

        //    if (Element.TextColor == Color.Default)
        //    {
        //        Control.SetTextColor(defaultTextColor);
        //    }
        //    else
        //    {
        //        Control.SetTextColor(Element.TextColor.ToAndroid());
        //    }
        //}

        void RadioButtonCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            Element.Checked = e.IsChecked;
        }
    }
}