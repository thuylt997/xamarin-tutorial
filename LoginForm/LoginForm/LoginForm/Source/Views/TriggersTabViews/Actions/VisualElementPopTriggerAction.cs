using Xamarin.Forms;

namespace LoginForm.Source.Views.TriggersTabViews.Actions
{
    public class VisualElementPopTriggerAction : TriggerAction<VisualElement>
    {
        public VisualElementPopTriggerAction()
        {
            Anchor = new Point(0.5, 0.5);
            Scale = 2;
            Length = 500;
        }

        public Point Anchor { get; set; }

        public double Scale { get; set; }

        public uint Length { get; set; }

        protected override async void Invoke(VisualElement sender)
        {
            sender.AnchorX = Anchor.X;
            sender.AnchorY = Anchor.Y;
            await sender.ScaleTo(Scale, Length / 2, Easing.SinOut);
            await sender.ScaleTo(1, Length / 2, Easing.SinIn);
        }
    }
}
