using System;
using Xamarin.Forms;

namespace LoginForm.Source.Views.TriggersTabViews.Actions
{
    public class NumericValidationTriggerAction : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            double resutlt;
            bool isValid = Double.TryParse(sender.Text, out resutlt);

            sender.TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
