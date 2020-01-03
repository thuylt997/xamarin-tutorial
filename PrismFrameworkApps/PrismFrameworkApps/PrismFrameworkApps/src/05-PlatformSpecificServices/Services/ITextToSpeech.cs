using System.Threading.Tasks;

namespace PrismFrameworkApps.src._05_PlatformSpecificServices.Services
{
    public interface ITextToSpeech
    {
        Task Speak(string text);
    }
}
