/**
 * The code-behind for the NoteEntryPage class, which contains the business 
 * logic that is executed when the user interacts with the page.
 */

using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FirstMobileApp.Models;

namespace FirstMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            note.date = DateTime.UtcNow;
            await App.Database.SaveNoteAsync(note);

            //if (string.IsNullOrWhiteSpace(note.fileName))
            //{
            //    // Save
            //    var fileName = Path.Combine(App.FolderPath, $"{Path.GetRandomFileName()}.notes.txt");
            //    File.WriteAllText(fileName, note.text);
            //}
            //else
            //{
            //    // Update
            //    File.WriteAllText(note.fileName, note.text);
            //}

            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            await App.Database.DeleteNoteAsync(note);

            //if (File.Exists(note.fileName))
            //{
            //    File.Delete(note.fileName);
            //}

            await Navigation.PopAsync();
        }
    }
}