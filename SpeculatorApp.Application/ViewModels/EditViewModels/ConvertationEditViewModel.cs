﻿using SpeculationApp.Domain.Entities;
using SpeculatorApp.Application.Services.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeculatorApp.Application.ViewModels.EditViewModels
{
    public class ConvertationEditViewModel : ViewModel
    {
        private readonly ConvertationModel _model;
        private readonly ConvertationUpdateService _updateService;

        private bool _isChanged;

        public ConvertationEditViewModel(ConvertationModel model, ConvertationUpdateService updateService)
        {
            _model = model;
            _updateService = updateService;
        }

        public bool IsChanged
        {
            get => _isChanged;
            private set
            { 
                _isChanged = value; 
                OnPropertyChanged();
            }
        }

        public int Id => _model.Id;
        public int BaseCurrencyId => _model.BaseCurrencyId;
        public int TradeCurrencyId => _model.TradeCurrencyId;
        public decimal BaseCurrencyAmount
        {
            get => _model.BaseCurrencyAmount;
            set
            {
                _model.BaseCurrencyAmount = value;
                _isChanged = true;

                OnPropertyChanged();
            }
        }
        public decimal TradeCurrencyAmount
        {
            get => _model.TradeCurrencyAmount;
            set
            {
                _model.TradeCurrencyAmount = value;
                _isChanged = true;

                OnPropertyChanged();
            }
        }
        public bool ToTradeCurrency
        {
            get => _model.ToTradeCurrency;
            set
            {
                _model.ToTradeCurrency = value;
                _isChanged = true;

                OnPropertyChanged();
            }
        }
        public DateTime Date
        {
            get => _model.Date; 
            set
            {
                _model.Date = value;
                _isChanged = true;

                OnPropertyChanged();
            }
        }

        public void Update()
        {
            if (IsChanged)
            {
                _updateService.Update(_model);
                IsChanged = false;
            }
        }
    }
}
