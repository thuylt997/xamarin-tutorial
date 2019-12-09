using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FirstMobileApp.Models;
using System.IO;

namespace FirstMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        /**
         * When the page appears, the OnAppearing method is executed, 
         * which populates the ListView with any notes that have been 
         * retrieved from the local application data folder.
         */
        protected override void OnAppearing()
        {
            base.OnAppearing();

            var notes = new List<Note>();
            var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");

            foreach (var item in files)
            {
                // item is filename
                notes.Add(new Note
                {
                    fileName = item,
                    text = File.ReadAllText(item),
                    date = File.GetCreationTime(item)
                });
            }

            listView.ItemsSource = notes.OrderBy(d => d.date).ToList();
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteEntryPage
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }
    }
}