using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PersonalApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomRadioButton : ContentView
    {
        public CustomRadioButton()
        {
            InitializeComponent();

            mainContainer.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    Command = new Command(OnTapped)
                }
            );
        }

        //START - Bindable Property Instance Declaration
        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create(
                propertyName: nameof(IsChecked),
                returnType: typeof(bool),
                declaringType: typeof(CustomRadioButton),
                defaultValue: false,
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: CheckedPropertyChanged
            );

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(
                propertyName: nameof(Title),
                returnType: typeof(string),
                declaringType: typeof(CustomRadioButton),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay
            );

        public static readonly BindableProperty LabelStyleProperty =
            BindableProperty.Create(
                propertyName: nameof(LabelStyle),
                returnType: typeof(Style),
                declaringType: typeof(CustomRadioButton),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay
            );

        public static readonly BindableProperty BorderImageSourceProperty =
            BindableProperty.Create(
                propertyName: nameof(BorderImageSource),
                returnType: typeof(string),
                declaringType: typeof(CustomRadioButton),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay
            );

        public static readonly BindableProperty CheckedBackgroundImageSourceProperty =
            BindableProperty.Create(
                propertyName: nameof(CheckedBackgroundImageSource),
                returnType: typeof(string),
                declaringType: typeof(CustomRadioButton),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay
            );

        public static readonly BindableProperty CheckMarkImageSourceProperty =
            BindableProperty.Create(
                propertyName: nameof(CheckMarkImageSource),
                returnType: typeof(string),
                declaringType: typeof(CustomRadioButton),
                defaultValue: "",
                defaultBindingMode: BindingMode.OneWay
            );

        public static readonly BindableProperty CheckedChangedCommandProperty =
            BindableProperty.Create(
                propertyName: nameof(CheckedChangedCommand),
                returnType: typeof(Command),
                declaringType: typeof(CustomRadioButton),
                defaultValue: null,
                defaultBindingMode: BindingMode.OneWay
            );
        //END - Bindable Property Instance Declaration

        //START - Creating Accessors (Getters and Setters)
        public bool IsChecked
        {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public Style LabelStyle
        {
            get => (Style)GetValue(LabelStyleProperty);
            set => SetValue(LabelStyleProperty, value);
        }

        public string BorderImageSource
        {
            get => (string)GetValue(BorderImageSourceProperty);
            set => SetValue(BorderImageSourceProperty, value);
        }

        public string CheckedBackgroundImageSource
        {
            get => (string)GetValue(CheckedBackgroundImageSourceProperty);
            set => SetValue(CheckedBackgroundImageSourceProperty, value);
        }

        public string CheckMarkImageSource
        {
            get => (string)GetValue(CheckMarkImageSourceProperty);
            set => SetValue(CheckMarkImageSourceProperty, value);
        }

        public Command CheckedChangedCommand
        {
            get => (Command)GetValue(CheckedChangedCommandProperty);
            set => SetValue(CheckedChangedCommandProperty, value);
        }

        public Label ControlLabel => controlLabel;
        //END - Creating Accessors (Getters and Setters)

        static void CheckedPropertyChanged(BindableObject bindable, object oldValue, object newValue) =>
            ((CustomRadioButton)bindable).ApplyCheckedState();

        public void ApplyCheckedState() => SetCheckedState(IsChecked);

        void SetCheckedState(bool isChecked)
        {
            Animation storyBoard = new Animation();

            Animation fadeAnim = null;
            Animation checkBounceAnim = null;
            Animation checkFadeAnim = null;

            //double fadeStartValue = 0;
            //double fadeEndValue = 1;

            //double scaleStartValue = 0;
            //double scaleEndValue = 1;

            Easing checkEasing = Easing.CubicIn;

            //if (IsChecked)
            //{
            //    checkedImage.Scale = 0;
            //    fadeStartValue = 0;
            //    fadeEndValue = 1;
            //    scaleStartValue = 0;
            //    scaleEndValue = 1;
            //    checkEasing = Easing.CubicIn;
            //}
            //else
            //{
            //    fadeStartValue = 1;
            //    fadeEndValue = 0;
            //    scaleStartValue = 1;
            //    scaleEndValue = 0;
            //    checkEasing = Easing.CubicOut;
            //}

            //fadeAnim = new Animation(
            //    callback: d => checkBackground.Opacity = d,
            //    start: fadeStartValue,
            //    end: fadeEndValue,
            //    easing: Easing.CubicOut
            //);

            //checkBounceAnim = new Animation(
            //    callback: d => checkedImage.Scale = d,
            //    start: scaleStartValue,
            //    end: scaleEndValue,
            //    easing: checkEasing
            //);

            //checkFadeAnim = new Animation(
            //    callback: d => checkedImage.Opacity = d,
            //    start: fadeStartValue,
            //    end: fadeEndValue,
            //    easing: checkEasing
            //);

            storyBoard.Add(0, 0.6, fadeAnim);
            storyBoard.Add(0, 0.6, checkFadeAnim);
            storyBoard.Add(0.4, 1, checkBounceAnim);
            storyBoard.Commit(this, "checkAnimation", length: 600);
        }

        void OnTapped()
        {
            if (!IsChecked)
            {
                IsChecked = true;
            }

            SetCheckedState(IsChecked);

            if (CheckedChangedCommand != null && CheckedChangedCommand.CanExecute(this))
            {
                CheckedChangedCommand.Execute(this);
            }
        }
    }
}