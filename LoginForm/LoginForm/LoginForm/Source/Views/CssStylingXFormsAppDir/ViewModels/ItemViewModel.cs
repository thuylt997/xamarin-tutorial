using LoginForm.Source.Views.CssStylingXFormsAppDir.Models;
using System.Collections.Generic;

namespace LoginForm.Source.Views.CssStylingXFormsAppDir.ViewModels
{
    public class ItemViewModel
    {
        public IList<Monkey> Monkeys { get; private set; }

        public ItemViewModel() => Monkeys = MonkeyData.Monkeys;
    }
}
