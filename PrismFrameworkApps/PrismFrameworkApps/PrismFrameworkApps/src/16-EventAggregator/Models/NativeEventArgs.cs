using System;

namespace PrismFrameworkApps.src._16_EventAggregator.Models
{
    public class NativeEventArgs : EventArgs
    {
        public string Message { get; set; }

        public NativeEventArgs(string message) => Message = message;
    }
}
