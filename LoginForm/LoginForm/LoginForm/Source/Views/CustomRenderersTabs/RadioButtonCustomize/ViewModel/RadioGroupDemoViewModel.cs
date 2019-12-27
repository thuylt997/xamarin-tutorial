using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace LoginForm.Source.Views.CustomRenderersTabs.RadioButtonCustomize.ViewModel
{
    public class RadioGroupDemoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Dictionary<int, string> myList;
        int selectedIndex;

        public Dictionary<int, string> MyList
        {
            get => myList;
            set
            {
                myList = value;
                OnPropertyChanged("MyList");
            }
        }

        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                if (value == selectedIndex)
                {
                    return;
                }

                selectedIndex = value;
                OnPropertyChanged("MyList");
            }
        }

        public RadioGroupDemoViewModel()
        {
            myList = new Dictionary<int, string>();
            selectedIndex = -1;

            // Load data.
            for (int i = 0; i < 3; i++)
            {
                MyList.Add(i, "Item " + i);
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
