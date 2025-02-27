using SpeculatorApp.Application.Services;
using SpeculatorApp.Application.ViewModels.EditViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

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
            _navigation.Navigate<MainMenuViewModel>();
        }
    }
}
