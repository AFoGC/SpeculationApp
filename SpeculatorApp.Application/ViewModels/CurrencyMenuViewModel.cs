using SpeculatorApp.Application.Services;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.ViewModels
{
    public class CurrencyMenuViewModel : ViewModel
    {
        private readonly NavigationService _navigation;
        private readonly CurrencyService _currencyService;

        private CurrencyEditViewModel? _currency;
        private IEnumerable<OperationTypeReadViewModel>? _operationTypes;

        public CurrencyMenuViewModel(NavigationService navigation, CurrencyService currencyService)
        {
            _navigation = navigation;
            _currencyService = currencyService;
        }

        public CurrencyEditViewModel? Currency
        {
            get => _currency;
            private set { _currency = value; OnPropertyChanged(); }
        }

        public IEnumerable<OperationTypeReadViewModel>? OperationTypes
        {
            get => _operationTypes;
            private set { _operationTypes = value; OnPropertyChanged(); }
        }

        public void LoadCurrency(int currencyId)
        {
            OperationTypes = _currencyService.LoadOperationTypes();
            Currency = _currencyService.LoadCurrency(currencyId, OperationTypes);
        }

        public void ToMainMenu(object? obj)
        {
            _navigation.Navigate<MainMenuViewModel>();
        }
    }
}
