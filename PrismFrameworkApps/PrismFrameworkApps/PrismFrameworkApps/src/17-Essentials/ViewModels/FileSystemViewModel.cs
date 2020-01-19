using System.IO;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._17_Essentials.ViewModels
{
    public class FileSystemViewModel : BaseViewModel
    {
        const string templateFileName = "FileSystemTemplate.txt";
        const string localFileName = "TheFile.txt";

        static string localPath = Path.Combine(FileSystem.AppDataDirectory, localFileName);

        string currentContents;

        public string CurrentContents
        {
            get => currentContents;
            set => SetProperty(ref currentContents, value);
        }

        public ICommand LoadFileCommand { get; }

        public ICommand SaveFileCommand { get; }

        public ICommand DeleteFileCommand { get; }

        public FileSystemViewModel()
        {
            LoadFileCommand = new Command(() => DoLoadFile());
            SaveFileCommand = new Command(() => DoSaveFile());
            DeleteFileCommand = new Command(() => DoDeleteFile());

            DoLoadFile();
        }

        private void DoDeleteFile()
        {
            if (File.Exists(localPath))
            {
                File.Delete(localPath);
            }
        }

        private void DoSaveFile() =>
            File.WriteAllText(localPath, CurrentContents);

        private async void DoLoadFile()
        {
            if (File.Exists(localPath))
            {
                CurrentContents = File.ReadAllText(localPath);
            }
            else
            {
                using (var stream = await FileSystem.OpenAppPackageFileAsync(templateFileName))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        CurrentContents = await reader.ReadToEndAsync();
                    }
                }
            }
        }
    }
}
