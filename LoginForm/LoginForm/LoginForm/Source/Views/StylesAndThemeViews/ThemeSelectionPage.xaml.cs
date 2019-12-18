using LoginForm.Source.Views.StylesAndThemeViews.Themes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginForm.Source.Views.StylesAndThemeViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThemeSelectionPage : ContentPage, IModalPage
    {
        public ThemeSelectionPage()
        {
            InitializeComponent();
        }

        async void OnPickerSelectionChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            AvailableTheme theme = (AvailableTheme)picker.SelectedItem;
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                switch (theme)
                {
                    case AvailableTheme.Dark:
                        mergedDictionaries.Add(new DarkTheme());
                        break;

                    case AvailableTheme.Light:
                    default:
                        mergedDictionaries.Add(new LightTheme());
                        break;
                }

                statusLabel.Text = $"{theme.ToString()} theme loaded. Close the page.";
            }

            await Dismiss();
        }

        public async Task Dismiss()
        {
            await Navigation.PopModalAsync();
        }
    }
}