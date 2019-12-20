using System;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginForm.Source.Views.BehaviorsTabViews.Behaviors
{
    public class EventToCommandBehavior : BehaviorBase<View>
    {
        Delegate eventHandler;

        public static readonly BindableProperty EventNameProperty =
            BindableProperty.Create(
                "EventName",                        // property name
                typeof(string),                     // return type
                typeof(EventToCommandBehavior),     // declaring type
                null,                               // default value
                propertyChanged: OnEventNameChanged // BindingPropertyChangedDelegate
            );

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                "Command",
                typeof(ICommand),
                typeof(EventToCommandBehavior),
                null
            );

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(
                "CommandParameter",
                typeof(object),
                typeof(EventToCommandBehavior),
                null
            );

        public static readonly BindableProperty InputConverterProperty =
            BindableProperty.Create(
                "Converter",
                typeof(IValueConverter),
                typeof(EventToCommandBehavior),
                null
            );

        public string EventName
        {
            get => (string)GetValue(EventNameProperty);
            set => SetValue(EventNameProperty, value);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public IValueConverter Converter
        {
            get => (IValueConverter)GetValue(InputConverterProperty);
            set => SetValue(InputConverterProperty, value);
        }

        /**
         * The OnAttachedTo method performs setup by calling the RegisterEvent method,
         * passing in the value of the EventName property as a parameter. 
         */
        protected override void OnAttachedTo(View bindable)
        {
            base.OnAttachedTo(bindable);

            RegisterEvent(EventName);
        }

        /**
         * The OnDetachingFrom method performs cleanup by calling the DeregisterEvent method,
         * passing in the value of the EventName property as a parameter.
         */
        protected override void OnDetachingFrom(View bindable)
        {
            DeregisterEvent(EventName);

            base.OnDetachingFrom(bindable);
        }

        /**
         * The RegisterEvent method is executed in response to the EventToCommandBehavior
         * being attached to a control, and it receives the value of the eventName property
         * as a parameter. The method then attempts to locate the event defined in the 
         * EventName property, on the attached control.
         */
        void RegisterEvent(string eventName)
        {
            if (string.IsNullOrWhiteSpace(eventName))
            {
                return;
            }

            EventInfo eventInfo = AssociatedObject.GetType().GetRuntimeEvent(eventName);

            if (eventInfo == null)
            {
                throw new ArgumentException(string.Format("EventToCommandBehavior: Can not register the '{0}' event.", EventName));
            }

            //  Provided that the event can be located, the OnEvent method is registered to be the handler method for the event.
            MethodInfo methodInfo = typeof(EventToCommandBehavior).GetTypeInfo().GetDeclaredMethod("OnEvent");

            eventHandler = methodInfo.CreateDelegate(eventInfo.EventHandlerType, this);
            eventInfo.AddEventHandler(AssociatedObject, eventHandler);
        }

        /**
         * The DeregisterEvent method is used to locate and deregister the event
         * defined in the EventName property, to cleanup any potential memory leaks.
         */
        void DeregisterEvent(string eventName)
        {
            if (string.IsNullOrWhiteSpace(eventName))
            {
                return;
            }

            if (eventHandler == null)
            {
                return;
            }

            EventInfo eventInfo = AssociatedObject.GetType().GetRuntimeEvent(eventName);

            if (eventInfo == null)
            {
                throw new ArgumentException(string.Format("EventToCommandBehavior: Can not de-register the '{0}' event.", EventName));
            }

            eventInfo.RemoveEventHandler(AssociatedObject, eventHandler);
            eventHandler = null;
        }

        /**
         * The OnEvent method is executed in response to the event firing that's
         * defined in the EventName property. Provided that the Command property 
         * references a valid ICommand, the method attempts to retrieve a parameter
         * to pass to the ICommand as follows:
         *      - If the CommandParameter property defines a parameter, it is retrieved.
         *      - Otherwise, if the Converter property defines an IValueConverter 
         *      implementation, the converter is executed and converts the event argument
         *      data as it's passed between source and target by the binding engine.
         *      - Otherwise, the event arguments are assumed to be the parameter.
         */
        void OnEvent(object sender, object eventArgs)
        {
            if (Command == null)
            {
                return;
            }

            object resolvedParameter;

            if (CommandParameter != null)
            {
                resolvedParameter = CommandParameter;
            }
            else if (Converter != null)
            {
                resolvedParameter = Converter.Convert(eventArgs, typeof(object), null, null);
            }
            else
            {
                resolvedParameter = eventArgs;
            }

            /**
             * The data bound ICommand is then executed, passing in the parameter 
             * to the command, provided that the CanExecute method returns true.
             */
            if (Command.CanExecute(resolvedParameter))
            {
                Command.Execute(resolvedParameter);
            }
        }

        static void OnEventNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var behavior = (EventToCommandBehavior)bindable;

            if (behavior.AssociatedObject == null)
            {
                return;
            }

            string oldEventName = (string)oldValue;
            string newEventName = (string)newValue;

            behavior.DeregisterEvent(oldEventName);
            behavior.RegisterEvent(newEventName);
        }
    }
}
