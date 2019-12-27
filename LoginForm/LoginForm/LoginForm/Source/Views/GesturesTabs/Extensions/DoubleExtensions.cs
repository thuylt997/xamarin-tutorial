using System;

namespace LoginForm.Source.Views.GesturesTabs.Extensions
{
    public static class DoubleExtensions
    {
        public static double Clamp(this double self, double min, double max) =>
            Math.Min(max, Math.Max(self, min));
    }
}
