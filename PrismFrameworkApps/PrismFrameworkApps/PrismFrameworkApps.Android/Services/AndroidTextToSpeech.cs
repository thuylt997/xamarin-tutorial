using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Speech.Tts;
using Plugin.CurrentActivity;
using PrismFrameworkApps.Droid.Services;
using PrismFrameworkApps.src._05_PlatformSpecificServices.Services;
using Xamarin.Forms;
using Debug = System.Diagnostics.Debug;

#pragma warning disable CS0618 // Type or member is obsolete
[assembly: Dependency(typeof(AndroidTextToSpeech))]
namespace PrismFrameworkApps.Droid.Services
{
    public class AndroidTextToSpeech : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        private TextToSpeech speaker;

        private string toSpeak;

        private ICurrentActivity _currentActivity { get; }

        protected AndroidTextToSpeech(ICurrentActivity currentActivity) =>
            _currentActivity = currentActivity;

        public Task Speak(string text)
        {
            return new Task(
                () =>
                {
                    toSpeak = text;

                    if (speaker == null)
                    {
                        speaker = new TextToSpeech(_currentActivity.Activity, this);
                    }
                    else
                    {
                        var p = new Dictionary<string, string>();

                        speaker.Speak(toSpeak, QueueMode.Flush, p);

                        Debug.WriteLine("spoke " + toSpeak);
                    }
                }
            );
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                Debug.WriteLine("speaker init");

                var p = new Dictionary<string, string>();

                speaker.Speak(toSpeak, QueueMode.Flush, p);
            }
            else
            {
                Debug.WriteLine("was quiet");
            }
        }
    }
}
#pragma warning restore CS0618 // Type or member is obsolete