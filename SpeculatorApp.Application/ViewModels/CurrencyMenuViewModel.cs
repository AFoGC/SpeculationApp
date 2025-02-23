using SpeculatorApp.Application.Services;
using SpeculatorApp.Application.Tables.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.ViewModels
{
    public class CurrencyMenuViewModel : ViewModel
    {
        private readonly NavigationService _navigation;

        private CurrencyViewModel? _currencyViewModel;

        public CurrencyMenuViewModel(NavigationService navigation)
        {
            _navigation = navigation;
        }

        public CurrencyViewModel? Currency
        {
            get => _currencyViewModel;
            set { _currencyViewModel = value; OnPropertyChanged(); }
        }

        public void ToMainMenu(object? obj)
        {
            _navigation.Navigate<MainMenuViewModel>();
        }
    }
}
