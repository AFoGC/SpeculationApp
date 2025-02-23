using SpeculatorApp.Application.Services;
using SpeculatorApp.Application.Tables.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.ViewModels
{
    public class MainMenuViewModel : ViewModel
    {
        private readonly NavigationService _navigation;
        private readonly TablesService _tables;

        public MainMenuViewModel(NavigationService navigation, TablesService tables)
        {
            _navigation = navigation;
            _tables = tables;
        }

        public ObservableCollection<CurrencyViewModel> Currencies
        {
            get
            {
                var currencies = _tables.Tables.CurrencyCollection.Currencies;
                return currencies;
            }
        }

        public ObservableCollection<PairViewModel> Pairs
        {
            get
            {
                var pairs = _tables.Tables.PairCollection.Pairs;
                return pairs;
            }
        }

        public void NavigateToCurrency(object? obj)
        {
            CurrencyViewModel? currency = obj as CurrencyViewModel;

            if (currency == null)
                throw new NullReferenceException();

            _navigation.Navigate<CurrencyMenuViewModel>().Currency = currency;
        }

        public void NavigateToPair(object? obj)
        {
            PairViewModel? pair = obj as PairViewModel;

            if (pair == null)
                throw new NullReferenceException();

            _navigation.Navigate<PairMenuViewModel>().Pair = pair;
        }
    }
}
