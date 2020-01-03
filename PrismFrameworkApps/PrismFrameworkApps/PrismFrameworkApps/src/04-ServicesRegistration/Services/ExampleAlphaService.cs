using PrismFrameworkApps.src._04_ServicesRegistration.Interfaces;
using System;

namespace PrismFrameworkApps.src._04_ServicesRegistration.Services
{
    public class ExampleAlphaService : IExampleAlphaService
    {
        public int NumberValue { get; set; }

        public ExampleAlphaService() => NumberValue = new Random().Next(1, 1000);
    }
}
