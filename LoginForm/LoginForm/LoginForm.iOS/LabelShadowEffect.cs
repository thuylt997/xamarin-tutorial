using CoreGraphics;
using LoginForm.iOS;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(LabelShadowEffect), "LabelShadowEffect")]
namespace LoginForm.iOS
{
    public class LabelShadowEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                Control.Layer.CornerRadius = 5;
                Control.Layer.ShadowColor = Color.Black.ToCGColor();
                Control.Layer.ShadowOffset = new CGSize(5, 5);
                Control.Layer.ShadowOpacity = 1.0f;
            }
            catch (Exception error)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", error.Message);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}