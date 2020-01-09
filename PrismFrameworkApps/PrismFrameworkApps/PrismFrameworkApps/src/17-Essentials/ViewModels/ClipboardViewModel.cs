using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._17_Essentials.ViewModels
{
    public class ClipboardViewModel : BaseViewModel
    {
        private string fieldValue;
        private string lastCopied;

        public string FieldValue
        {
            get => fieldValue;
            set => SetProperty(ref fieldValue, value);
        }

        public string LastCopied
        {
            get => lastCopied;
            set => SetProperty(ref lastCopied, value);
        }

        public ICommand CopyCommand { get; }
        public ICommand PasteCommand { get; }

        public ClipboardViewModel()
        {
            CopyCommand = new Command(
                async () =>
                {
                    await Clipboard.SetTextAsync(FieldValue);
                }
            );

            PasteCommand = new Command(
                async () =>
                {
                    var text = await Clipboard.GetTextAsync();

                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        FieldValue = text;
                    }
                }
            );
        }

        //public override void OnAppearing() =>
        //    Clipboard.ClipboardContentChanged += OnClipboardContentChanged;

        //public override void OnDisappearing() =>
        //    Clipboard.ClipboardContentChanged -= OnClipboardContentChanged;

        void OnClipboardContentChanged(object sender, EventArgs args) =>
            LastCopied = $"Last copied text at {DateTime.UtcNow:T}";
    }
}
