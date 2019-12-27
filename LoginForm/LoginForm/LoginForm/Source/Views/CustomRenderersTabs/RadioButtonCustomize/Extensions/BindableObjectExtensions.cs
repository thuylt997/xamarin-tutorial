using Xamarin.Forms;

namespace LoginForm.Source.Views.CustomRenderersTabs.RadioButtonCustomize.Extensions
{
    public static class BindableObjectExtensions
    {
        public static T GetValue<T>(this BindableObject bindableObject, BindableProperty property) =>
            (T)bindableObject.GetValue(property);
    }
}
