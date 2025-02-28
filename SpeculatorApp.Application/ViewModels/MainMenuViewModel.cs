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
    public class MainMenuViewModel : ViewModel
    {
        private readonly NavigationService _navigation;
        private readonly MainMenuService _menuService;

        public MainMenuViewModel(NavigationService navigation, MainMenuService menuService)
        {
            _navigation = navigation;
            _menuService = menuService;

            NavigateToCurrencyCommand = new RelayCommand(NavigateToCurrency);
            NavigateToPairCommand = new RelayCommand(NavigateToPair);
        }

        public ICommand NavigateToCurrencyCommand { get; }
        public ICommand NavigateToPairCommand { get; }

        public ObservableCollection<CurrencyReadViewModel> Currencies => _menuService.Currencies;
        public ObservableCollection<PairReadViewModel> Pairs => _menuService.Pairs;

        public void LoadData()
        {
            _menuService.LoadData();
        }

        public void RefreshData()
        {
            foreach (var currency in _menuService.Currencies)
                currency.RefreshData();
        }

        public void NavigateToCurrency(object? obj)
        {
            CurrencyReadViewModel? currency = obj as CurrencyReadViewModel;

            if (currency == null)
                throw new NullReferenceException();

            _navigation
                .Navigate<CurrencyMenuViewModel>()
                .LoadCurrency(currency.Id);
        }

        public void NavigateToPair(object? obj)
        {
            PairReadViewModel? pair = obj as PairReadViewModel;

            if (pair == null)
                throw new NullReferenceException();

            _navigation
                .Navigate<PairMenuViewModel>()
                .LoadPair(pair.BaseCurrencyId, pair.TradeCurrencyId);
        }
    }
}
