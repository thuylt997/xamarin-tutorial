using Prism.Mvvm;
using System.Collections.Generic;

namespace PrismFrameworkApps.src._03_ListView.ViewModels
{
    public class ListSampleViewModel : BindableBase
    {
        private List<string> items;

        public List<string> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        public ListSampleViewModel()
        {
            items = new List<string>
            {
                "Bien Hoa City",
                "Ho Chi Minh City",
                "Ha Noi Capital",
                "Da Nang City",
                "Phu Quoc Island",
                "Vung Tau Beach"
            };
        }
    }
}
