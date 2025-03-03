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

        private bool _isChanged;

        public PairEditViewModel(CurrencyReadViewModel baseCurrency, CurrencyReadViewModel tradeCurrency, 
            IEnumerable<ConvertationEditViewModel> convertations)
        {
            BaseCurrency = baseCurrency;
            TradeCurrency = tradeCurrency;

            _convertations = new ObservableCollection<ConvertationEditViewModel>(convertations);
            _isChanged = false;
        }

        public CurrencyReadViewModel BaseCurrency { get; }
        public CurrencyReadViewModel TradeCurrency { get; }

        public bool IsChanged => _isChanged;

        public ObservableCollection<ConvertationEditViewModel> Convertations => _convertations;
    }
}
