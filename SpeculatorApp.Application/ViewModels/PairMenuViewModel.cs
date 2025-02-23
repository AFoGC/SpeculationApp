﻿using SpeculatorApp.Application.Services;
using SpeculatorApp.Application.Tables.ViewModels;
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

        private PairViewModel? _pairViewModel;

        public PairMenuViewModel(NavigationService navigation)
        {
            _navigation = navigation;
        }

        public PairViewModel? Pair
        {
            get => _pairViewModel;
            set { _pairViewModel = value; OnPropertyChanged(); }
        }

        public void ToMainMenu(object? obj)
        {
            _navigation.Navigate<MainMenuViewModel>();
        }
    }
}
