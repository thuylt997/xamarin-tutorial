using PrismFrameworkApps.src._04_ServicesRegistration.Interfaces;
using System;

namespace PrismFrameworkApps.src._04_ServicesRegistration.Services
{
    public class ExampleBetaService : IExampleBetaService
    {
        public int NumberValue { get; set; }

        public ExampleBetaService() => NumberValue = new Random().Next(1, 1000);
    }
}
