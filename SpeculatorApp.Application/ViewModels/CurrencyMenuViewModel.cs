using SpeculatorApp.Application.Commands;
using SpeculatorApp.Application.Services;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpeculatorApp.Application.ViewModels
{
    public class CurrencyMenuViewModel : ViewModel
    {
        private readonly NavigationService _navigation;
        private readonly CurrencyService _currencyService;

        private CurrencyEditViewModel? _currency;

        public CurrencyMenuViewModel(NavigationService navigation, CurrencyService currencyService)
        {
            _navigation = navigation;
            _currencyService = currencyService;

            NavigateToMainMenuCommand = new RelayCommand(ToMainMenu);
        }

        public ICommand NavigateToMainMenuCommand { get; }

        public CurrencyEditViewModel? Currency
        {
            get => _currency;
            private set { _currency = value; OnPropertyChanged(); }
        }

        public IEnumerable<OperationTypeReadViewModel>? OperationTypes
        {
            get => null ;
        }

        public void LoadCurrency(int currencyId)
        {
            Currency = _currencyService.LoadCurrency(currencyId);
        }

        public void ToMainMenu(object? obj)
        {
            if (Currency != null)
            {
                _currencyService.UpdateCurrency(Currency);
            }

            _navigation.Navigate<MainMenuViewModel>();
        }
    }
}
