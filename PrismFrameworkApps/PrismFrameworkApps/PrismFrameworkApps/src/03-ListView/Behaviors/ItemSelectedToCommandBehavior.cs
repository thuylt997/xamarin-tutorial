using Prism.Behaviors;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismFrameworkApps.src._03_ListView.Behaviors
{
    public class ItemSelectedToCommandBehavior : BehaviorBase<ListView>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                propertyName: "Command",
                returnType: typeof(ICommand),
                declaringType: typeof(EventToCommandBehavior)
            );

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public ItemSelectedToCommandBehavior()
        {
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.ItemSelected += (s, e) =>
            {
                if (e.SelectedItem != null)
                {
                    if (Command != null)
                    {
                        BindableItemSelected(s, e);
                    }

                    AssociatedObject.SelectedItem = null;
                }
            };
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.ItemSelected -= BindableItemSelected;
        }

        protected virtual void BindableItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (Command.CanExecute(e.SelectedItem))
            {
                Command.Execute(e.SelectedItem);
            }
        }
    }
}
