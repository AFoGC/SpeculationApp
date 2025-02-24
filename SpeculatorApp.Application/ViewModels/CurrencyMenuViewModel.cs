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
    public class CurrencyMenuViewModel : ViewModel
    {
        private readonly NavigationService _navigation;
        private readonly TablesService _tables;

        private CurrencyViewModel? _currencyViewModel;

        public CurrencyMenuViewModel(NavigationService navigation, TablesService tables)
        {
            _navigation = navigation;
            _tables = tables;
        }

        public CurrencyViewModel? Currency
        {
            get => _currencyViewModel;
            set { _currencyViewModel = value; OnPropertyChanged(); }
        }

        public ObservableCollection<OperationTypeViewModel> OperationTypes
        {
            get => _tables.Tables.OperationTypeCollection.OperationTypes;
        }

        public void ToMainMenu(object? obj)
        {
            _navigation.Navigate<MainMenuViewModel>();
        }
    }
}
