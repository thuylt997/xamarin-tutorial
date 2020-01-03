using Prism.Mvvm;
using PrismFrameworkApps.src._03_ListView.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._03_ListView.ViewModels
{
    public class ListSampleViewModel : BindableBase
    {
        private List<string> items;

        private List<Cities> cityItems;

        private string selectedItem;

        public List<string> Items
        {
            get => items;
            set => SetProperty(ref items, value);
        }

        public List<Cities> CityItems
        {
            get => cityItems;
            set => SetProperty(ref cityItems, value);
        }

        public string SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
        }

        public Command<Cities> ItemSelectedCommand { get; }

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

            cityItems = new List<Cities>
            {
                new Cities{CityName="Bien Hoa City"},
                new Cities{CityName="Can Tho City"},
                new Cities{CityName="Da Nang City"},
                new Cities{CityName="Ba Ria Vung Tau City"},
                new Cities{CityName="New York City"},
            };

            ItemSelectedCommand = new Command<Cities>(
                x => SelectedItem = x.CityName,
                x => x != null
            );
        }
    }
}
