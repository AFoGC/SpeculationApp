using SpeculationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.ViewModels.EditViewModels
{
    public class PairEditViewModel : ViewModel
    {
        private readonly ObservableCollection<ConvertationEditViewModel> _convertations;

        private CurrencyModel _baseCurrency;
        private CurrencyModel _tradeCurrency;
        private bool _isChanged;

        public PairEditViewModel(CurrencyModel baseCurrency, CurrencyModel tradeCurrency, 
            IEnumerable<ConvertationEditViewModel> convertations)
        {
            _baseCurrency = baseCurrency;
            _tradeCurrency = tradeCurrency;

            _convertations = new ObservableCollection<ConvertationEditViewModel>(convertations);
        }

        public bool IsChanged => _isChanged;

        public ObservableCollection<ConvertationEditViewModel> Convertations => _convertations;
    }
}
