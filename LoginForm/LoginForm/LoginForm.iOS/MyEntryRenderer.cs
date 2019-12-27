using LoginForm.iOS;
using LoginForm.Source.Views.CustomRenderersTabs.EntryCustomize;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

// registers the renderer with Xamarin.Forms
[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace LoginForm.iOS
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BackgroundColor = UIColor.FromRGB(204, 153, 255);
                Control.BorderStyle = UITextBorderStyle.Line;
            }
        }
    }
}