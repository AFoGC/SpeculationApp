using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.Factories
{
    public interface IViewModelFactory<TViewModel, TModel>
    {
        TViewModel CreateViewModel(TModel model);
    }
}
