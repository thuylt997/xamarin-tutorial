using System;

namespace LoginForm.Source.Views.CustomRenderersTabs.RadioButtonCustomize.Helper
{
    public class EventArgs<T> : EventArgs
    {
        public EventArgs(T value) => Value = value;

        public T Value { get; private set; }
    }
}
