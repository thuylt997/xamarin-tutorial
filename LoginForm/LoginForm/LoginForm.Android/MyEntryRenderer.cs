using Android.Content;
using Android.Graphics.Drawables;
using LoginForm.Droid;
using LoginForm.Source.Views.CustomRenderersTabs.EntryCustomize;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

// registers the renderer with Xamarin.Forms
[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace LoginForm.Droid
{
    public class MyEntryRenderer : EntryRenderer
    {
        public MyEntryRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.LightGreen);
                //Control.Background = new ColorDrawable(Android.Graphics.Color.LightPink);
            }
        }
    }
}