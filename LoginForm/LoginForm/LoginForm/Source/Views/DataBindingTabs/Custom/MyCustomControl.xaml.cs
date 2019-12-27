using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views.DataBindingTabs.Custom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCustomControl : ContentView
    {
        public static readonly BindableProperty TitleTextProperty =
            BindableProperty.Create(
                propertyName: "TitleText",
                returnType: typeof(string),
                declaringType: typeof(MyCustomControl),
                defaultValue: "",
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: TitleTextPropertyChanged
            );

        public static readonly BindableProperty ImageProperty =
            BindableProperty.Create(
                propertyName: "Image",
                returnType: typeof(string),
                declaringType: typeof(MyCustomControl),
                defaultValue: "",
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: ImageSourcePropertyChanged
            );

        public string TitleText
        {
            get => (string)GetValue(TitleTextProperty);
            set => SetValue(TitleTextProperty, value);
        }

        public string Image
        {
            get => (string)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MyCustomControl)bindable;

            control.title.Text = newValue.ToString();
        }

        private static void ImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MyCustomControl)bindable;

            control.image.Source = ImageSource.FromFile(newValue.ToString());
        }

        public MyCustomControl() => InitializeComponent();
    }
}