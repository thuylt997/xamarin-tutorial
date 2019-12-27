using LoginForm.Source.Views.CustomRenderersTabs.RadioButtonCustomize.Helper;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace LoginForm.Source.Views.CustomRenderersTabs.RadioButtonCustomize
{
    public class BindableRadioGroup : StackLayout
    {
        //The items
        public ObservableCollection<CustomRadioButton> Items;

        //Initializes a new instance of the<see cref="BindableRadioGroup"/> class.
        public BindableRadioGroup() => Items = new ObservableCollection<CustomRadioButton>();

        [Obsolete]
        public static BindableProperty ItemsSourceProperty =
            BindableProperty.Create<BindableRadioGroup, IEnumerable>(
                o => o.ItemsSource,
                default(IEnumerable),
                propertyChanged: OnItemsSourceChanged
            );

        [Obsolete]
        public static BindableProperty SelectedIndexProperty =
            BindableProperty.Create<BindableRadioGroup, int>(
                o => o.SelectedIndex,
                -1,
                BindingMode.TwoWay,
                propertyChanged: OnSelectedIndexChanged
            );

        [Obsolete]
        public IEnumerable ItemsSource
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        [Obsolete]
        public int SelectedIndex
        {
            get => (int)GetValue(SelectedIndexProperty);
            set => SetValue(SelectedIndexProperty, value);
        }

        public event EventHandler<int> CheckedChanged;

        private static void OnSelectedIndexChanged(BindableObject bindable, int oldValue, int newValue)
        {
            if (newValue == -1)
            {
                return;
            }

            var bindableRadioGroup = bindable as BindableRadioGroup;

            if (bindableRadioGroup == null)
            {
                return;
            }

            foreach (var button in bindableRadioGroup.Items.Where(button => button.Id == bindableRadioGroup.SelectedIndex))
            {
                button.Checked = true;
            }
        }

        private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldValue, IEnumerable newValue)
        {
            var radioButton = bindable as BindableRadioGroup;

            foreach (var item in radioButton.Items)
            {
                item.CheckedChanged -= radioButton.OnCheckedChanged;
            }

            //radioButton.Items.Clear();
            //radioButton.Children.Clear();

            var radioIndex = 0;

            foreach (var item in radioButton.ItemsSource)
            {
                var button = new CustomRadioButton
                {
                    Text = item.ToString(),
                    Id = radioIndex++
                };

                button.CheckedChanged += radioButton.OnCheckedChanged;

                radioButton.Items.Add(button);

                //radioButton.Children.Add(button);
            }
        }

        [Obsolete]
        private void OnCheckedChanged(object sender, EventArgs<bool> e)
        {
            if (e.Value == false)
            {
                return;
            }

            var selectedItem = sender as CustomRadioButton;

            if (selectedItem == null)
            {
                return;
            }

            foreach (var item in Items)
            {
                if (!selectedItem.Id.Equals(item.Id))
                {
                    item.Checked = false;
                }
                else
                {
                    SelectedIndex = selectedItem.Id;

                    if (CheckedChanged != null)
                    {
                        CheckedChanged.Invoke(sender, item.Id);
                    }
                }
            }
        }
    }
}
