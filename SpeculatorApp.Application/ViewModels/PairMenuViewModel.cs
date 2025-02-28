using SpeculatorApp.Application.Commands;
using SpeculatorApp.Application.Services;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpeculatorApp.Application.ViewModels
{
    public class PairMenuViewModel : ViewModel
    {
        private readonly NavigationService _navigation;
        private readonly PairService _pairService;

        private PairEditViewModel? _pair;

        public PairMenuViewModel(NavigationService navigation, PairService pairService)
        {
            _navigation = navigation;
            _pairService = pairService;

            NavigateToMainMenuCommand = new RelayCommand(ToMainMenu);
        }

        public ICommand NavigateToMainMenuCommand { get; }

        public PairEditViewModel? Pair
        {
            get => _pair;
            private set { _pair = value; OnPropertyChanged(); }
        }

        public void LoadPair(int baseCurrencyId, int tradeCurrencyId)
        {
            Pair = _pairService.LoadPair(baseCurrencyId, tradeCurrencyId);
        }

        public void ToMainMenu(object? obj)
        {
            bool isChanged = false;

            if (Pair != null)
            {
                isChanged = _pairService.UpdatePair(Pair);
            }

            MainMenuViewModel menu = _navigation.Navigate<MainMenuViewModel>();

            if (isChanged)
            {
                menu.RefreshData();
            }
        }
    }
}
