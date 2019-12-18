using Xamarin.Forms;

namespace LoginForm.Source.Views.TriggersTabViews.Actions
{
    public class FadeTriggerAction : TriggerAction<VisualElement>
    {
        public int StartsForm { get; set; }
        protected override void Invoke(VisualElement sender)
        {
            sender.Animate("FadeTriggerAction", new Animation((d) =>
            {
                var value = StartsForm == 1 ? d : 1 - d;

                sender.BackgroundColor = Color.FromRgb(1, value, 1);
            }),
            length: 2000,
            easing: Easing.Linear);
        }
    }
}
