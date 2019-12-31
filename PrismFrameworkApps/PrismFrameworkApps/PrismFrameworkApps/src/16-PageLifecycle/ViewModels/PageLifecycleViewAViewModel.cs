using Prism.AppModel;
using Prism.Mvvm;

namespace PrismFrameworkApps.src._16_PageLifecycle.ViewModels
{
    public class PageLifecycleViewAViewModel : BindableBase, IPageLifecycleAware
    {
        public void OnAppearing() => System.Diagnostics.Debugger.Break();

        public void OnDisappearing() => System.Diagnostics.Debugger.Break();
    }
}
