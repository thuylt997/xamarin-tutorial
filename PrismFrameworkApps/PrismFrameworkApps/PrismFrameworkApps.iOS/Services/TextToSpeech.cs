using System.Threading.Tasks;
using AVFoundation;
using PrismFrameworkApps.iOS.Services;
using PrismFrameworkApps.src._05_PlatformSpecificServices.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeech))]
namespace PrismFrameworkApps.iOS.Services
{
    public class TextToSpeech : ITextToSpeech
    {
        public Task Speak(string text)
        {
            return new Task(
                () =>
                {
                    var speechSynthesizer = new AVSpeechSynthesizer();

                    var speechUtterance = new AVSpeechUtterance(text)
                    {
                        Rate = AVSpeechUtterance.MaximumSpeechRate / 2.5f,
                        Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                        Volume = 0.5f,
                        PitchMultiplier = 1.0f
                    };

                    speechSynthesizer.SpeakUtterance(speechUtterance);
                }
            );
        }
    }
}